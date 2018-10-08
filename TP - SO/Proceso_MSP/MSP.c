#include"MSP.h"

//Globales y externas de las Funciones_MSP
extern t_log * logs;
extern int puerto;
int32_t SOCKET_KERNEL;



int main(int argc, char *argv[])
{
	puts("Iniciando la MSP...\n");

	if (/*argc == 2*/ argc == 1) {

		if (inicializar_memoria(argv[1]) == 0 )
		{
			//Fallo al crear la memoria
			return EXIT_FAILURE;
		}

		tabla_segmentos = list_create();
		tabla_marcos = list_create();

		inicializar_tabla_marcos();

		// Creo el directorio en_disco si no existe, alli se guardaran los archivos swap
		struct stat info_swap;
		if( stat("swap", &info_swap ) != 0 ){
			mkdir("swap",0777);
		}

		//Lanzo Hilos
		pthread_t thread_Epoll;
		pthread_t th_consola;
		pthread_create(&thread_Epoll,NULL,hilo_Epoll,NULL);
		pthread_create(&th_consola, NULL,proceso_consola,NULL);
		pthread_join(thread_Epoll,NULL);
		pthread_join(th_consola,NULL);
		free(memoria_principal);
		list_destroy(tabla_segmentos);
		list_destroy(tabla_marcos);

		proceso_consola();

	} else {
		puts("Numero incorrecto de argumentos\n");
	}

	return EXIT_SUCCESS;

}

/***********************************************************************************************************************
************************************************************************************************************************
**********************************************Hilo de Epoll*************************************************************
************************************************************************************************************************
***********************************************************************************************************************/

void* hilo_Epoll(void* argc)
{
	//Sockets y puertos que va a manejar el Epoll
		int32_t socketEscucha;
		int32_t nuevaConexion;
		int32_t puerto_escucha;
		//EPOLL->Multiplexor para recibir el handshake
		int32_t multiplexor_Consola;
		struct epoll_event event;
		struct epoll_event *events;
		int32_t maxEvents = 64;
		//n:cantidad de eventos, i:indice de array de eventos, r: retorno de recibir paquete
		int32_t r, n, i;
		//
		//Uso el puerto de escucha seteado por el config -----------------> CONFIG_MSP
		//
		puerto_escucha = puerto;/* PUERTO EN QUE VOY A ESCUCHAR*/
		//
		//
		//
		socketEscucha = crearSocketEscucha(puerto_escucha,logs);
		//Creo, seteo e inicializo el multiplexor
		multiplexor_Consola = crearInstanciaEpoll(logs);
		//Buffer para eventos de epoll
		events = calloc (maxEvents, sizeof event);
		agregarEnEpoll(multiplexor_Consola, socketEscucha, logs);

		//Headers para envio/recepcion
		t_header header_envio;
		t_header header_recep;
		t_crear_segmento creacion_segmento;
		t_destruir_segmento destruccion_segmento;
		t_escritura_memoria escritura_segmento;
		t_solicitud_memoria solicitud_segmento;


		log_info(logs,"Se inicia la escucha de conexiones");

		while (1)
		{
			n = epoll_wait (multiplexor_Consola, events, maxEvents, -1);
			for (i = 0; i < n; i++)
			{
				if(events->events & EPOLLRDHUP)
				{
					log_info(logs,"Se cerro Conexion de algo->%d",events[i].data.fd);
					if(SOCKET_KERNEL == events[i].data.fd)
					{
						close(SOCKET_KERNEL);
						log_info(logs,"<-------Conexion al Kernel cerrada------->");
						//log_info(logs,"Conexion al Kernel cerrada -> Aborto la MSP");
					}
					else
					{
						log_info(logs,"Conexion de CPU cerrada -> %d",nuevaConexion);
					}
				}

				if (socketEscucha == events[i].data.fd)
				{
					//Aceptar Conexion y monitorizarlo
					nuevaConexion = aceptarUnCliente (socketEscucha,logs);
					agregarEnEpoll(multiplexor_Consola,nuevaConexion,logs);
					log_info(logs,"Acepte conexion");
				}
				else
				{
					//Evento
					nuevaConexion = events[i].data.fd;
					r = recibir_paquete(nuevaConexion,&header_recep);

					if (r == -1)
					{
						close(nuevaConexion);
						log_info(logs,"Se cerro Socket_fd:%d",nuevaConexion);
						//Debo borrar si cree, los segmentos
						continue;
					}

					//HANDSHAKE -> KERNEL
					if (header_recep.id == 400)
					{
						log_info(logs,"Se recibio el handshake del Kernel:%d",nuevaConexion);
						SOCKET_KERNEL = nuevaConexion;
						continue;
					}

					if(header_recep.id ==  450)
					{
						log_info(logs,"Se recibio el handshake de una CPU:%d",nuevaConexion);
						continue;
					}

					//PEDIDO DE CREACION DE SEGMENTO
					if(header_recep.id == 401)
					{
						creacion_segmento = deserializar_t_crear_segmento(header_recep);
						log_info(logs,"Pedido de Creacion de Segmento->PID:%d|Size:%d"
								,creacion_segmento.PID,creacion_segmento.Size);

						//Creo el segmento
						uint32_t dir = crear_segmento(creacion_segmento.PID,creacion_segmento.Size);

						if (dir == -1 || dir == -2 || dir == -3)
						{
							//Error al crear el segmento
							header_envio.id = 403;
							header_envio.size = 0;
							if (enviar_paquete(nuevaConexion,header_envio) < 0 )
							{
								close(nuevaConexion);
								log_info(logs,"Se cerro Socket_fd:%d",nuevaConexion);
							}
						}
						else
						{
							//Se creo correctamente el segmento
							header_envio.id = 402;
							header_envio.size = sizeof(dir_log);
							header_envio.data = malloc(header_envio.size);
							dir_log dir_log;
							dir_log.direccion_logica = dir;
							memcpy(header_envio.data,&dir_log,header_envio.size);
							if (enviar_paquete(nuevaConexion,header_envio) < 0 )
							{
								close(nuevaConexion);
								log_info(logs,"Se cerro Socket_fd:%d",nuevaConexion);
							}
							free(header_envio.data);
						}
					}

					//PEDIDO DE GUARDADO DE DATOS EN SEGMENTO
					if(header_recep.id == 404)
					{
						escritura_segmento = deserializar_t_escritura_memoria(header_recep);
						log_info(logs,"Se pidio guardar datos en Segmento->PID:%d|Size:%d|Dir_Logica:%d"
								,escritura_segmento.PID,escritura_segmento.Size,escritura_segmento.Direccion_Logica);

						int size_paginas = 0;
						void* buffer_auxiliar;

						int dir = -1;

						if(escritura_segmento.Size <= 256)
						{
							buffer_auxiliar = malloc(escritura_segmento.Size);
							memcpy(buffer_auxiliar,escritura_segmento.Bytes_A_Escribir,escritura_segmento.Size);
							dir = escribir_memoria_algoritmo(escritura_segmento.PID,escritura_segmento.Direccion_Logica
											,buffer_auxiliar,escritura_segmento.Size);
							free(buffer_auxiliar);
						}
						else
						{
							while (size_paginas < escritura_segmento.Size)
							{
								if(size_paginas < 256)
								{
									buffer_auxiliar = malloc(256);
									memcpy(buffer_auxiliar,escritura_segmento.Bytes_A_Escribir+size_paginas,256);
									dir = escribir_memoria_algoritmo(escritura_segmento.PID,escritura_segmento.Direccion_Logica+size_paginas
													,buffer_auxiliar,256);
									free(buffer_auxiliar);
								}
								else
								{
									buffer_auxiliar = malloc(escritura_segmento.Size-size_paginas);
									memcpy(buffer_auxiliar,escritura_segmento.Bytes_A_Escribir+size_paginas,escritura_segmento.Size-size_paginas);
									dir = escribir_memoria_algoritmo(escritura_segmento.PID,escritura_segmento.Direccion_Logica+size_paginas
													,(void*)(escritura_segmento.Bytes_A_Escribir+size_paginas),escritura_segmento.Size-size_paginas);
									free(buffer_auxiliar);
									}

									size_paginas = size_paginas + 256;

									if(dir < 0)
									{
										break;
									}
							}
						}



						if(dir < 0)
						{
							//Segmentation Fault
							log_error(logs,"Segmentation Fault->Escritura");
							header_envio.id = 407;
							header_envio.size = 0;
							if(enviar_paquete(nuevaConexion,header_envio) < 0)
							{
								close(nuevaConexion);
								log_info(logs,"Se cerro Socket_fd:%d",nuevaConexion);
							}
						}
						else
						{
							//Escribo la memoria
							log_info(logs,"Se escribio el Segmento correctamente->PID:%d",escritura_segmento.PID);
							//Escritura correcta -> Falta el Segmentation Fault(Lista que no tengo de segmentos)
							header_envio.id = 409;
							header_envio.size = 0;
							if (enviar_paquete(nuevaConexion,header_envio) < 0 )
							{
								close(nuevaConexion);
								log_info(logs,"Se cerro Socket_fd:%d",nuevaConexion);
							}
						}
					}

					//PEDIDO DE DESTRUCCION DE SEGMENTO POR PID Y DIRECCION -> SOLO ESE SEGMENTO
					if(header_recep.id == 405)
					{
						destruccion_segmento = deserializar_t_destruir_segmento(header_recep);
						log_info(logs,"Se pidio destruir un Segmento->PID:%d|Dir_Logica:%d"
								,destruccion_segmento.PID,destruccion_segmento.Direccion_Logica);

						destruir_segmento(destruccion_segmento.PID, destruccion_segmento.Direccion_Logica);
						continue;
					}

					//PEDIDO DE DESTRUCCION DE SEGMENTOS POR PID -> DESTRUYO TODOS LOS SEGMENTOS DE ESE PID
					if(header_recep.id == 411)
					{
						//Inutilizado !!!!!!
						//destruccion_segmento = deserializar_t_destruir_segmento(header_recep);
						log_info(logs,"Se pidio destruir todos los segmentos(Inutilizado)->PID:%d",destruccion_segmento.PID);
					}

					//PEDIDO DE LECTURA DE MEMORIA
					if(header_recep.id == 406)
					{
						solicitud_segmento = deserializar_t_solicitud_memoria(header_recep);
						log_info(logs,"Se pidio leer un Segmento->PID:%d->Dir_Logica:%d->Size(Offset):%d",
								solicitud_segmento.PID,solicitud_segmento.Direccion_Logica,solicitud_segmento.Size);

						//Buffer de devolucion
						void* devolver = malloc(solicitud_segmento.Size);

						int error_lectura = leer_memoria_algoritmo(devolver,solicitud_segmento.PID, solicitud_segmento.Direccion_Logica,
						solicitud_segmento.Size);

						if(error_lectura == 0)
						{
							//Se realiza una lectura correcta
							header_envio.size = solicitud_segmento.Size;
							header_envio.data = malloc(header_envio.size);
							memcpy(header_envio.data,(void*)devolver,solicitud_segmento.Size);
							header_envio.id = 410;
							if(enviar_paquete(nuevaConexion,header_envio) < 0)
							{
								close(nuevaConexion);
								log_warning(logs,"Se cerro Socket_fd:%d",nuevaConexion);
							}
							free(header_envio.data);
							free(devolver);
						}
						else
						{
							log_error(logs,"Segmentation Fault->Lectura");
							//Segmentation Fault
							header_envio.id = 408;
							header_envio.size = 0;
							if(enviar_paquete(nuevaConexion,header_envio) < 0)
							{
								close(nuevaConexion);
								log_info(logs,"Se cerro Socket_fd:%d",nuevaConexion);
							}
							free(devolver);
						}
					}
				}//FIN_Else
			}//FIN_For
		}//FIN_While

	 free (events);
	 close (socketEscucha);

	pthread_exit(NULL);
}


/***********************************************************************************************************************
************************************************************************************************************************
***************************************Funciones Auxiliares*************************************************************
************************************************************************************************************************
***********************************************************************************************************************/
//Calcula el tamaño del fichero fp, incluyendo a EOF
int32_t calcularTamFile(FILE *fp)
{
	fseek(fp,0L,SEEK_END);
	return (ftell(fp)+1);
}
//Recorro el archivo desde el principio copiando cada caracter, inclusive el EOF
char* caracteresFile(FILE *fp)
{
	int length = calcularTamFile(fp);

	fseek (fp, 0, SEEK_SET);

	char* buffer = malloc (length);

	if (buffer)
	{
	  fread (buffer, 1, length, fp);
	}

	return buffer;
}

t_header serializar_t_escritura_memoria(t_escritura_memoria aux_esc)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(uint32_t)*3 + aux_esc.Size;
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_esc.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_esc.Direccion_Logica,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_esc.Size,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,aux_esc.Bytes_A_Escribir,aux_esc.Size);

	header_aux.size = size_Serializado;

	return header_aux;
}

t_escritura_memoria deserializar_t_escritura_memoria (t_header header)
{
	t_escritura_memoria aux_escrit;
	int32_t offset = 0;
	memcpy(&aux_escrit.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_escrit.Direccion_Logica,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_escrit.Size,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);

	//Debo hacer malloc para guardar en memoria el valor de lo que llega
	aux_escrit.Bytes_A_Escribir = malloc(aux_escrit.Size);

	memcpy(aux_escrit.Bytes_A_Escribir,header.data+offset,aux_escrit.Size);


	return aux_escrit;
}


t_header serializar_t_solicitud_memoria(t_solicitud_memoria aux_sol)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(t_solicitud_memoria);
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_sol.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_sol.Direccion_Logica,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_sol.Size,sizeof(uint32_t));

	header_aux.size = size_Serializado;

	return header_aux;
}

t_solicitud_memoria deserializar_t_solicitud_memoria (t_header header)
{
	t_solicitud_memoria aux_solic;
	int32_t offset = 0;
	memcpy(&aux_solic.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_solic.Direccion_Logica,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_solic.Size,header.data+offset,sizeof(uint32_t));

	return aux_solic;
}

t_header serializar_t_crear_segmento (t_crear_segmento aux_creacion)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(uint32_t)*2;
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_creacion.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_creacion.Size,sizeof(uint32_t));
	offset += sizeof(uint32_t);

	header_aux.size = size_Serializado;

	return header_aux;
}

t_crear_segmento deserializar_t_crear_segmento (t_header header)
{
	t_crear_segmento aux_creacion;
	int32_t offset = 0;
	memcpy(&aux_creacion.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_creacion.Size,header.data+offset,sizeof(uint32_t));

	return aux_creacion;
}

t_header serializar_t_destruir_segmento (t_destruir_segmento aux_destruccion)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(uint32_t)*2;
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_destruccion.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_destruccion.Direccion_Logica,sizeof(uint32_t));
	offset += sizeof(uint32_t);

	header_aux.size = size_Serializado;

	return header_aux;
}

t_destruir_segmento deserializar_t_destruir_segmento (t_header header)
{
	t_destruir_segmento aux_destruccion;
	int32_t offset = 0;
	memcpy(&aux_destruccion.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_destruccion.Direccion_Logica,header.data+offset,sizeof(uint32_t));

	return aux_destruccion;
}


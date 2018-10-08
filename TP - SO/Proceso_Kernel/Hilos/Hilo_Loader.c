#include"Hilo_Loader.h"

//Globales
t_hilo_proceso *hilo_proceso_syscall_global;
//Listas
//extern t_list* lista_hilos_terminados;		//Lista usada para JOIN
extern t_list* lista_wake_hilos;			//Lista usada para WAKE/BLOK -> Semaforos de los hilos
//extern t_list* lista_handle_hilos_finalizados; //Lista encargada de finalizar los hilos hijos que se encuentren en Exec/Block
//Logs
extern t_log *Log_Kernel_Temporal;
extern t_log *Log_Kernel_Planificador;
extern t_log *Log_Kernel_Loader;
//Globales Externas
extern int32_t sock_fd_MSP;
extern int32_t PUERTO_CONFIG;
extern uint32_t contador_procesos;
extern int32_t SIZE_STACK;
//Colas del planificador
extern t_queue* cola_Ready;
extern t_queue* cola_Block;
extern t_queue* cola_Block_Recurso;
extern t_queue* cola_Block_Join;
//extern t_queue* cola_Exit;
extern t_queue* cola_Exec;
extern t_queue* cola_New;
extern t_queue* cola_CPU_libres;
//extern t_queue* cola_Consolas;
//Mutex de las colas
extern pthread_mutex_t mutex_cola_Ready;
extern pthread_mutex_t mutex_cola_Block;
extern pthread_mutex_t mutex_cola_Block_Recurso;
extern pthread_mutex_t mutex_cola_Block_Join;
//extern pthread_mutex_t mutex_cola_Exit;
extern pthread_mutex_t mutex_cola_Exec;
extern pthread_mutex_t mutex_cola_New;
extern pthread_mutex_t mutex_cola_CPU_libres;
extern pthread_mutex_t mutex_SYSCALL;
//extern pthread_mutex_t mutex_lista_hilos_terminados;
extern pthread_mutex_t mutex_lista_wake_hilos;
//extern pthread_mutex_t mutex_cola_Consolas;
//extern pthread_mutex_t mutex_lista_handle_hilos_finalizados;
//Semaforos Contadores
extern sem_t sem_cola_New;
extern sem_t sem_cola_Ready;
extern sem_t sem_cola_Block;
//extern sem_t sem_cola_Exit;


//Contador de hilos -> Incremental
int32_t CONTADOR_HILOS_INCREMENTAL = 1;


void *hilo_Loader(void* argc)
{
	//Sockets y puertos que va a manejar el Epoll
	int32_t socketEscucha;
	int32_t nuevaConexion;
	int32_t puerto_escucha_kernel;
	//EPOLL->Multiplexor para recibir el handshake
	int32_t multiplexor_Consola;
	struct epoll_event event;
	struct epoll_event *events;
	int32_t maxEvents = 64;
	//n:cantidad de eventos, i:indice de array de eventos, r: retorno de recibir paquete
	int32_t r, n, i;
	puerto_escucha_kernel = PUERTO_CONFIG;
	socketEscucha = crearSocketEscucha(puerto_escucha_kernel,Log_Kernel_Loader);
	//Creo, seteo e inicializo el multiplexor
	multiplexor_Consola = crearInstanciaEpoll(Log_Kernel_Loader);
	//Buffer para eventos de epoll
	events = calloc (maxEvents, sizeof event);
	agregarEnEpoll(multiplexor_Consola, socketEscucha, Log_Kernel_Loader);

	//
	//Auxiliares a usar durante la ejecucion
	t_hilo_proceso *aux_hilo_proceso;
	t_hilo aux_t_hilo;
	int32_t errores_Hilo_CPU = 0;
	int32_t errores_creacion = 0;
	int32_t errores_system_call = 0;
	syscall_p aux_puntero_syscall;
	int32_t error_km = 0;
	int32_t error_consola = 0;
	int32_t aux_PID_hilo = 0;
	int32_t tid_hilo_join = 0;
	int32_t semaforo_block = 0;
	int32_t semaforo_wake = 0;
	//Headers para envio/recepcion
	t_header header_envio;
	t_header header_recep;
	//Guarda los datos del hilo que llamo a la system call
	hilo_proceso_syscall_global = malloc(sizeof(t_hilo_proceso));
	//
	//
	while (1)
	{
		n = epoll_wait (multiplexor_Consola, events, maxEvents, -1);
		for (i = 0; i < n; i++)
		{
			if(events->events & EPOLLRDHUP)
			{
				log_warning(Log_Kernel_Loader,"Warning->Se cerro Socket:%d\n",events[i].data.fd);


				error_km = handle_desconexiones_CPUs(events[i].data.fd);

				if(error_km == 1)	//Fallo el KM = 1 en CPU -> FIN DEL KERNEL
				{
					log_error(Log_Kernel_Temporal,"\n\nERROR_FATAL->HILO KERNEL EJECUTANDOSE EN CPU QUE FALLO(KM = 1)->ABORTO EL KERNEL\n\n");
					exit(1);
				}
				else
				{
					if (error_km == -1)
					{
						error_consola = handle_desconexiones_Consolas(events[i].data.fd);

						if (error_consola == -1)
						{
							log_warning(Log_Kernel_Loader,"\nSe cerro un Socket:%d->DESCONOCIDO\n",nuevaConexion);
						}

					}
				}

			}

			if (socketEscucha == events[i].data.fd)
			{
				//Aceptar Conexion y monitorizarlo
				nuevaConexion = aceptarUnCliente (socketEscucha,Log_Kernel_Loader);
				agregarEnEpoll(multiplexor_Consola,nuevaConexion,Log_Kernel_Loader);
				log_debug(Log_Kernel_Loader,"Acepte conexion");
			}
			else
			{
				//Evento
				nuevaConexion = events[i].data.fd;
				r = recibir_paquete(nuevaConexion, &header_recep);

				if (r == -1)
				{
					close(nuevaConexion);
					log_warning(Log_Kernel_Loader,"Se cerro Socket_fd:%d",nuevaConexion);

					continue;
				}

				/***************************************************************************************
				 *********************************Conexiones Consolas***********************************
				 ***************************************************************************************/


				//RECIBO EL HANDSHAKE DE LA CONSOLA
				if(header_recep.id == 0)
				{
					//Deberia devolver la señal de handshake
					log_debug(Log_Kernel_Loader,"Se conecto una Consola->Socket_Fd:%d",nuevaConexion);
					header_envio.id = 1;
					header_envio.size = 0;
					if(enviar_paquete(nuevaConexion,header_envio) < 0)
					{
						close(nuevaConexion);
						log_warning(Log_Kernel_Loader,"Cerro Consola:%d",nuevaConexion);
					}
					else
					{
						//
						//Se ha conectado una consola correctamente
						//
						conexion_consola(nuevaConexion);
						//
						//
					}
					continue;
				}


				//RECIBO EL CODIGO DE LA CONSOLA A EJECUTAR
				if(header_recep.id == 2)
				{
					log_debug(Log_Kernel_Loader,"Se recibio el codigo de la Consola");
					//ACA MANDO A LA MSP LAS COSAS A GUARDAR
					errores_creacion = creacion_TCB(header_recep.data,header_recep.size,nuevaConexion);
					if (errores_creacion == 1)
					{
						//Fallo la creacion por memory overload
						//Devolver mensaje y cerrar conexion
						header_envio.id = 13;
						header_envio.size = 0;
						if (enviar_paquete(nuevaConexion,header_envio) < 0)
						{
							close(nuevaConexion);
							log_warning(Log_Kernel_Loader,"Cerro Consola:%d",nuevaConexion);
							//Se ha desconectado una consola correctamente
							desconexion_consola(nuevaConexion);
							//

						}
						log_warning(Log_Kernel_Loader,"Fallo la creacion de Segmentos->Se cerrara conexion con consola");
						close(nuevaConexion);
					}
					if (errores_creacion == -1)
					{
						//Se desconecto la MSP
						header_envio.id = 15;
						header_envio.size = 0;
						if (enviar_paquete(nuevaConexion,header_envio) < 0)
						{
							close(nuevaConexion);
							log_warning(Log_Kernel_Loader,"Cerro Consola:%d",nuevaConexion);
							//Se ha desconectado una consola correctamente
							desconexion_consola(nuevaConexion);
							//
						}
						close(nuevaConexion);
						log_error(Log_Kernel_Loader,"<----------Fin de Kernel por desconexion de MSP------------>");
						pthread_exit(NULL);
					}
					//Si no entra en ningun es que funciono

				}

				/***************************************************************************************
				 *********************************Conexiones CPU's**************************************
				 ***************************************************************************************/

				//RECIBO EL HANDSHAKE DE LA CPU
				if(header_recep.id == 200)
				{
					log_debug(Log_Kernel_Loader,"Se conecto una CPU->Socket_Fd:%d",nuevaConexion);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					//Se ha desconectado una CPU correctamente
					conexion_cpu(nuevaConexion);
					//
					continue;
				}
				//FIN DE QUANTUM -> CPU ME ENVIA EL TCB
				if(header_recep.id == 204)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					log_warning(Log_Kernel_Loader,"Fin de Quantum del TCB->P:%d->T:%d",
							aux_t_hilo.pid,aux_t_hilo.tid);

					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->estado_salida = FIN_QUANTUM;
					aux_hilo_proceso->hilo = aux_t_hilo;
					aux_hilo_proceso->hilo.cola = READY;
					log_debug(Log_Kernel_Planificador,"Exec->Ready(Fin Quantum)(P:%d|T:%d)"
							,aux_hilo_proceso->hilo.pid,aux_hilo_proceso->hilo.tid);
					agregar_en_cola(cola_Ready,aux_hilo_proceso,&mutex_cola_Ready);
					//
					//Imprimo el estado de todas las colas
					imprime_t_Hilos_de_Todas_Colas();
					//
					sem_post(&sem_cola_Ready);
				}
				//SYSTEM CALL -> INTE
				if (header_recep.id == 205)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					log_debug(Log_Kernel_Loader,"System Call del TCB->P:%d->T:%d",
												aux_t_hilo.pid,aux_t_hilo.tid);

					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->estado_salida = FIN_QUANTUM;
					aux_hilo_proceso->hilo = aux_t_hilo;
					aux_hilo_proceso->hilo.cola = BLOCK;

					if(recibir_paquete(nuevaConexion,&header_recep) < 0)
					{
						handle_desconexiones_CPUs(nuevaConexion);	//Manejo la desconexion de la CPU
					}

					//Me fijo que llege por ID = 250 -> Puntero de la system call
					if (header_recep.id == 250)
					{
						//Copio el puntero a syscall y se lo asigno al proceso
						memcpy(&aux_puntero_syscall,header_recep.data,header_recep.size);
						aux_hilo_proceso->syscall_llamada = aux_puntero_syscall.puntero_instruccion_syscall;

						instruccion_protegida("INTE",&(aux_hilo_proceso->hilo));

						//Envio el t_hilo_proceso -> el socket_fd de la CPU esta en el hilo
						errores_system_call = ESO_system_call(aux_hilo_proceso,aux_puntero_syscall.puntero_instruccion_syscall);

						if (errores_system_call == 1)
						{
							//Por si falla -> Dejo la CPU libre y muevo el hilo a exit
							agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
							aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
							aux_hilo_proceso->hilo = aux_t_hilo;
							funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_CONEXION_CONSOLA);
						}
					}
					else
					{
						//Fallo la CPU, no envio la instruccion
						aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
						aux_hilo_proceso->hilo = aux_t_hilo;
						funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_CONEXION_CPU);
					}

				}
				//FIN DE HILO/PROCESO -> Fijarse si es todo el proceso o solo este hilo del proceso
				if (header_recep.id == 206)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;

					if (aux_hilo_proceso->hilo.tid == 0)
					{
						//Finalizacion del Proceso -> Puedo destruir TODOS los segmentos del proceso
						//En caso de que no hayan mas-> Sino -> Error y los quito por fallo.
						funcion_handle_hilos_finalizados (aux_hilo_proceso, FIN_PROCESO);
					}
					else
					{
						//Finalizacion del Hilo -> Puedo destruir TODOS los segmentos del hilo
						funcion_handle_hilos_finalizados (aux_hilo_proceso, FIN_HILO);
					}
					//
					//Imprimo lo de la cola Exec
					//
					imprime_t_Hilos_PorColaMutex(cola_Exec,&mutex_cola_Exec);
					//
					//
				}
				//FALLO AL LLAMAR FUNCION PROTEGIDA EN KM = 0
				if (header_recep.id == 207)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_INSTRUCCION);
				}
				//INSTRUCCION INEXISTENTE
				if (header_recep.id == 208)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_INSTRUCCION);
				}
				//MEMORY OVERLOAD
				if (header_recep.id == 209)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_MEMORY_OVERLOAD);
				}
				//SEGMENTATION FAULT
				if (header_recep.id == 210)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_SEGMENTATION_FAULT);
				}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////LLAMADAS DE SYSTEM CALL DESDE LA CPU	-> SERVICIOS QUE BRINDA EL KERNEL//////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				//
				//LLAMADA A JOIN -> DEBO VER QUE PASA CON EL HILO QUE BUSCO PARA DESBLOQUEAR
				//
				if (header_recep.id == 211)
				{
					//
					//
					instruccion_protegida("JOIN",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Loader,"Llamada a JOIN TCB->P:%d->T:%d",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);

					memcpy(&tid_hilo_join,header_recep.data,sizeof(int32_t));

					if(existeHiloParaJoinear(hilo_proceso_syscall_global->hilo.pid,tid_hilo_join) == 1)
					{
						hilo_proceso_syscall_global->hilo_join = tid_hilo_join;
					}
					else
					{
						log_warning(Log_Kernel_Loader,"JOIN TCB->P:%d->T:%d->FALLO(NO EXISTE->T:%d)->No se bloqueara el hilo",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid,tid_hilo_join);
					}
				}
				//
				//LLAMADA A BLOK -> DEBO VER SI PUEDO DESBLOQUEAR, SINO MANDO A COLA BLOCK
				//
				if (header_recep.id == 212)
				{
					//
					//
					instruccion_protegida("BLOK",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Planificador,"Llamada a BLOK TCB->P:%d->T:%d",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
					//
					//El paso de del mensaje desde la CPU genera el Block del hilo (Luego de volver de Syscall)
					//debido al cambio de valor (Sem < 0) del semaforo -> Bloqueado siempre que venga por aca
					//
					memcpy(&semaforo_block,header_recep.data,sizeof(int32_t));
					hilo_proceso_syscall_global->block = semaforo_block;
				}
				//
				//LLAMADA A WAKE -> ME FIJO SI PUEDO DESBLOQUEAR ALGO (?
				//
				if (header_recep.id == 213)
				{
					//
					//
					instruccion_protegida("WAKE",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Planificador,"Llamada a WAKE TCB->P:%d->T:%d",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
					//
					//El paso de del mensaje desde la CPU genera que se desbloquee un hilo siempre y cuando
					//el valor sea positivo (Sem >= 0) en la CPU -> Desbloqueo el 1° hilo del proceso ese bloqueado
					//
					memcpy(&semaforo_wake,header_recep.data,sizeof(int32_t));
					//
					agregar_lista_wake_hilos(semaforo_wake);
					//
					//
					//Imprimo el estado de todas las colas
					imprime_t_Hilos_de_Todas_Colas();
					//
					sem_post(&sem_cola_Block);
				}
				//
				//LLAMADA A ENTRADA ESTANDAR -> Numerica
				//
				if (header_recep.id == 214)
				{
					//
					//
					instruccion_protegida("INNN",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Loader,"Llamada a Entrada Estandar(Numerica) TCB->P:%d->T:%d",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);

					header_envio.id = 4;
					header_envio.size = 0;

					if(enviar_paquete(hilo_proceso_syscall_global->socket_Consola,header_envio) < 0)
					{
						//Se desconecto la Consola
						//
						//Aviso a la CPU para que
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CONSOLA;
						header_envio.id = 231;
						header_envio.size = 0;
						if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio) < 0)
						{
							handle_desconexiones_CPUs(hilo_proceso_syscall_global->socket_CPU);
						}
					}
				}
				if(header_recep.id == 5)
				{
					header_envio.id = 230;
					header_envio.size = sizeof(int32_t);
					header_envio.data = malloc(header_envio.size);
					memcpy(header_envio.data,header_recep.data,header_envio.size);

					if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio) < 0)
					{
						//Se desconecto la CPU
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CPU;
					}
					free(header_envio.data);
				}
				//
				//LLAMADA A SALIDA ESTANDAR -> Numerica
				//
				if (header_recep.id == 215)
				{
					//
					//
					instruccion_protegida("OUTN",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Loader,"Llamada a Salida Estandar(Numerica) TCB->P:%d->T:%d",
								hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
					header_envio.id = 9;
					header_envio.size = sizeof(int32_t);
					header_envio.data = malloc(header_envio.size);
					memcpy(header_envio.data,header_recep.data,header_envio.size);

					if(enviar_paquete(hilo_proceso_syscall_global->socket_Consola,header_envio) < 0)
					{
						//Se desconecto la Consola
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CONSOLA;
					}
					free(header_envio.data);
				}
				//
				//LLAMADA A ENTRADA ESTANDAR -> Char*
				//
				if (header_recep.id == 217)
				{
					//
					//
					instruccion_protegida("INNC",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Loader,"Llamada a Entrada Estandar(Char) TCB->P:%d->T:%d",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);

					header_envio.id = 6;
					header_envio.size = sizeof(int32_t);
					header_envio.data = malloc(header_envio.size);
					memcpy(header_envio.data,header_recep.data,header_envio.size);

					if(enviar_paquete(hilo_proceso_syscall_global->socket_Consola,header_envio) < 0)
					{
						//Se desconecto la Consola
						//
						//Aviso a la CPU para que
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CONSOLA;
						header_envio.id = 231;
						header_envio.size = 0;
						if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio) < 0)
						{
							handle_desconexiones_CPUs(hilo_proceso_syscall_global->socket_CPU);
						}
					}
					free(header_envio.data);

				}
				if(header_recep.id == 7)
				{
					//
					//
					instruccion_protegida("OUTC",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Loader,"Llamada a Salida Estandar(Char) TCB->P:%d->T:%d",
												hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
					header_envio.id = 231;
					header_envio.size = header_recep.size;
					header_envio.data = malloc(header_envio.size);
					memcpy(header_envio.data,header_recep.data,header_envio.size);

					if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio) < 0)
					{
						//Se desconecto la Consola
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CONSOLA;
					}
					free(header_envio.data);
				}
				//
				//LLAMADA A SALIDA ESTANDAR -> Char*
				//
				if (header_recep.id == 218)
				{
					//
					header_envio.id = 295;
					header_envio.size = 0;
					if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio) < 0)
					{
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CPU;
					}
					//
					header_envio.id = 3;
					header_envio.size = header_recep.size;
					header_envio.data = malloc(header_envio.size);
					memcpy(header_envio.data,header_recep.data,header_envio.size);

					//printf("PrintSalidaEstandar:\n\n%s|%d\n\n",(char*)header_envio.data,header_envio.size);

					if(enviar_paquete(hilo_proceso_syscall_global->socket_Consola,header_envio) < 0)
					{
						//Se desconecto la Consola
						hilo_proceso_syscall_global->estado_salida = FALLO_CONEXION_CONSOLA;
					}
					free(header_envio.data);
				}
				//
				//LLAMADA A CREA -> CREAR EL HILO NUEVO
				//
				if (header_recep.id == 216)
				{
					//
					//
					instruccion_protegida("CREA",&(hilo_proceso_syscall_global->hilo));
					//
					//
					log_debug(Log_Kernel_Loader,"Llamada a CREA TCB->P:%d->T:%d",
							hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);

					int32_t pc_hilo_creado;
					memcpy(&pc_hilo_creado,header_recep.data,sizeof(int32_t));

					errores_Hilo_CPU = duplicar_TCB(pc_hilo_creado);
					if (errores_Hilo_CPU == -2)	//Memory Overload en MSP
					{
						//Identifica el fallo cuando el proceso vuelve
						log_warning(Log_Kernel_Loader,"Fallo de CREA(Memory Overload)->P:%d|T:%d",
								hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
						hilo_proceso_syscall_global->estado_salida = FALLO_MEMORY_OVERLOAD;
					}
					if (errores_Hilo_CPU == -1)	//Desconexion de MSP
					{
						close(socketEscucha);
						log_error(Log_Kernel_Loader,"Fin de Hilo Kernel por desconexion de MSP");
						pthread_exit(NULL);
					}
					if(errores_Hilo_CPU == -3)
					{
						//Identifica el fallo cuando el proceso vuelve
						hilo_proceso_syscall_global->estado_salida = FALLO_SEGMENTATION_FAULT;
						log_warning(Log_Kernel_Loader,"Fallo de CREA(Segmentation Fault)->P:%d|T:%d",
								hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
					}

					header_envio.id = 232;
					header_envio.size = sizeof(int32_t);
					header_envio.data = malloc(header_envio.size);
					memcpy(header_envio.data,&errores_Hilo_CPU,header_envio.size);

					if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio) < 0)
					{
						//Aca si finaliza el Kernel por fallo de CPU con KM = 1 ejecutandose
						handle_desconexiones_CPUs(hilo_proceso_syscall_global->socket_CPU);
					}
					free(header_envio.data);

				}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////FIN DE LOS SERVICIOS QUE BRINDA EL KERNEL A CPU////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				//FIN DE SYSCALL
				if (header_recep.id == 220)
				{
					log_debug(Log_Kernel_Loader,"Fin de System Call->P:%d|T:%d"
							,hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);

					aux_t_hilo = deserializar_t_hilo(header_recep);

					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);

					//Sale el hilo de KM = 1 de la cola de EXEC
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					//La funcion se encarga de mover a Ready al Hilo que hizo el Syscall y mover a Block el Hilo KM
					fin_system_call(aux_hilo_proceso);

				}
				//FALLO POR DESCONEXION DE MSP
				if (header_recep.id == 221)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_CONEXION_MSP);
				}
				//FALLO POR DIVISION POR CERO
				if (header_recep.id == 222)
				{
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_DIVISION_CERO);
				}
/**********************************************************************************************************************
***********************************CPU-Kernel Handle para Fallos de Consola/Hilo/CPU***********************************
***********************************************************************************************************************/
				if (header_recep.id == 270)
				{
					//Me fijo en las colas si paso algo
					aux_PID_hilo = busca_cola_Exec_PID_en_ejecucion(nuevaConexion);
					//
					if (esta_en_lista_handle_hilos_finalizados_PID(aux_PID_hilo) == 0)
					{
						header_envio.id = 271; //No fallo nada
						header_envio.size = 0;
					}
					else
					{
						header_envio.id = 272; //No fallo nada
						header_envio.size = 0;
					}

					if (enviar_paquete(nuevaConexion,header_envio) < 0)
					{
						//Fallo la conexion CPU
						aux_t_hilo = deserializar_t_hilo(header_recep);
						agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
						aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
						aux_hilo_proceso->hilo = aux_t_hilo;
						//Se ha desconectado una consola correctamente
						desconexion_consola(nuevaConexion);
						close(nuevaConexion);
						//
						funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_CONEXION_CPU);
					}
				}

				if (header_recep.id == 273)
				{
					//Hilo fallido -> Mover a exit con estado
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					if(aux_hilo_proceso->estado_salida == FALLO_CONEXION_CONSOLA)
					{
						//Solo los fallos de consola
						funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_CONEXION_CONSOLA);
					}
					else
					{
						funcion_handle_hilos_finalizados (aux_hilo_proceso, FALLO_HILO_FIN);
					}

				}

				if (header_recep.id == 274)
				{
					//Hilo fallido ( KM = 1) -> Solo muevo a exit el hilo de system call (KM = 1)
					log_debug(Log_Kernel_Loader,"Fin de System Call(Fallida por otro hilo)->P:%d|T:%d"
							,hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);
					aux_t_hilo = deserializar_t_hilo(header_recep);
					agregar_en_cola(cola_CPU_libres,(void*)nuevaConexion,&mutex_cola_CPU_libres);
					//Sale el hilo de KM = 1 de la cola de EXEC
					aux_hilo_proceso = dameProcesoHilo(cola_Exec,nuevaConexion,&mutex_cola_Exec);
					aux_hilo_proceso->hilo = aux_t_hilo;
					//
					fin_system_call_fallo_hilo(aux_hilo_proceso);
					//
				}

				if(header_recep.id == 290)
				{
					//Solo se da en caso de algun fallo de memoria del hilo/Cierre MSP
					log_debug(Log_Kernel_Temporal,"Fallo al intentar acceder a memoria del hilo kernel"
							"->P:0|T:0");
					log_error(Log_Kernel_Temporal,"Se procedera a abortar el Kernel!!!");
					exit(1);
				}

/**********************************************************************************************************************
*******************************FIN CPU-Kernel Handle para Fallos de Consola/Hilo/CPU***********************************
***********************************************************************************************************************/

			}//FIN_Else
		}//FIN_For
	}//FIN_While

  free(hilo_proceso_syscall_global);
  free(events);
  close(socketEscucha);

  log_warning(Log_Kernel_Loader,"Fin de Hilo Loader");

  pthread_exit(NULL);
}


/**********************************************************************************************************************
***********************************************************************************************************************
*******************************************FUNCIONES AUXILIARES DEL LOADER*********************************************
***********************************************************************************************************************
**********************************************************************************************************************/

/*
 * 	Funcion que crea un TCB.
 * 	En caso de fallardevuelve -1, notificando el fallo de conexion con MSP.
 * 	Si devuelve 1, no se pudieron crear los segmentos.
 * 	Si devuelve 0 es que funciono la creacion del hilo y se planifico en Cola_New.
 */
int32_t creacion_TCB (char* codigo_a_guardar_MSP,int32_t size_codigo_a_guardar_MSP,int32_t socket_consola)
{
	t_hilo_proceso *proceso_aux = malloc(sizeof(t_hilo_proceso));
	//Se crea al toque
	proceso_aux->hilo.pid = contador_procesos;
	contador_procesos += 1;
	proceso_aux->hilo.tid = 0;
	proceso_aux->hilo.kernel_mode = 0;
	proceso_aux->hilo.segmento_codigo_size = size_codigo_a_guardar_MSP;
	proceso_aux->socket_Consola = socket_consola;
	proceso_aux->hilo.cola = NEW;
	proceso_aux->hilo_join = -1;	//Significa que no esta joineado con nada
	proceso_aux->block = -1;

	/*
	 * CONEXION CON LA MSP
	 */
	t_header envio_MSP;
	t_header recep_MSP;
	//Aca va el envio para crear el 1° segmento -> Memoria
	t_crear_segmento segmento_a_crear;
	dir_log dir;
	segmento_a_crear.PID = proceso_aux->hilo.pid;
	segmento_a_crear.Size = proceso_aux->hilo.segmento_codigo_size;
	envio_MSP = serializar_t_crear_segmento(segmento_a_crear);
	envio_MSP.id = 401;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		return -1;
	}
	free(envio_MSP.data);
	if (recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		return -1;
	}
	if (recep_MSP.id == 402)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		memcpy(&dir,recep_MSP.data,recep_MSP.size);
		proceso_aux->hilo.segmento_codigo = dir.direccion_logica;
		log_debug(Log_Kernel_Loader,"Segmento de Codigo creado Correctamente:%d",proceso_aux->hilo.segmento_codigo);
	}
	if (recep_MSP.id == 403)
	{
		//Memory Overload -> Cierro conexion con esa Consola
		return 1;
	}
	//Envio lo que debo guardar
	t_escritura_memoria escritura_segmento;
	escritura_segmento.PID = proceso_aux->hilo.pid;
	escritura_segmento.Direccion_Logica = 0;
	escritura_segmento.Size = proceso_aux->hilo.segmento_codigo_size;
	escritura_segmento.Bytes_A_Escribir = malloc(proceso_aux->hilo.segmento_codigo_size);
	memcpy(&escritura_segmento.Direccion_Logica,&dir.direccion_logica,sizeof(uint32_t));
	memcpy(escritura_segmento.Bytes_A_Escribir,codigo_a_guardar_MSP,proceso_aux->hilo.segmento_codigo_size);

	envio_MSP = serializar_t_escritura_memoria(escritura_segmento);
	envio_MSP.id = 404;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		return -1;
	}
	free(escritura_segmento.Bytes_A_Escribir);
	free(envio_MSP.data);

	if(recibir_paquete(sock_fd_MSP,&recep_MSP) < 0 )
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		return 1;
	}

	if (recep_MSP.id == 409)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
	}
	if (recep_MSP.id == 407)
	{
		//Segmentation Fault
		return 1;
	}

	//Aca va el envio para crear el 2° segmento -> Stack -> ACA NO GUARDO NADA
	t_crear_segmento seg_stack;
	seg_stack.PID = proceso_aux->hilo.pid;
	seg_stack.Size = SIZE_STACK;
	envio_MSP = serializar_t_crear_segmento(seg_stack);
	envio_MSP.id = 401;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		return -1;
	}
	free(envio_MSP.data);
	if (recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		return -1;
	}
	if (recep_MSP.id == 402)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		memcpy(&dir,recep_MSP.data,recep_MSP.size);
		proceso_aux->hilo.base_stack = proceso_aux->hilo.cursor_stack = dir.direccion_logica;
		log_debug(Log_Kernel_Loader,"Segmento de Stack creado Correctamente:%d",proceso_aux->hilo.base_stack);
	}
	if (recep_MSP.id == 403)
	{
		//Memory Overload -> Cierro conexion con esa Consola
		//
		//Destruyo los segmentos <<<<<<<----------
		//
		t_destruir_segmento mensaje_destruccion;
		mensaje_destruccion.PID = proceso_aux->hilo.pid;
		mensaje_destruccion.Direccion_Logica = proceso_aux->hilo.segmento_codigo;
		envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
		envio_MSP.id = 405;
		//Este mensaje id = 405 -> Destruye el segmento indicado
		if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
		{
			log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
			exit(1);
		}
		//
		//
		//
		return 1;
	}
	//Inicializo registros/PC/Base Stack/Cursor Stack
	proceso_aux->hilo.registros[0] = 0;
	proceso_aux->hilo.registros[1] = 0;
	proceso_aux->hilo.registros[2] = 0;
	proceso_aux->hilo.registros[3] = 0;
	proceso_aux->hilo.registros[4] = 0;
	proceso_aux->hilo.puntero_instruccion = 0;

	log_debug(Log_Kernel_Planificador,"Se creo el TCB->P:%d|T:%d(->New)",proceso_aux->hilo.pid,proceso_aux->hilo.tid);

	//ENCOLO EN NEW EL NUEVO TCB

	agregar_en_cola(cola_New,proceso_aux,&mutex_cola_New);
	//
	//Imprimo el estado de todas las colas
	imprime_t_Hilos_de_Todas_Colas();
	//
	sem_post(&sem_cola_New);

	return 0;
}

/*
 * 	Funcion que duplica un TCB, creando un hilo hijo. En caso de fallar
 * 	devuelve -1, notificando el fallo de conexion con MSP. Si devuelve
 * 	1, no se pudieron crear los segmentos.
 * 	Si devuelve 0 es que funciono la creacion del hilo y se planifico en Cola_New
 */

int32_t duplicar_TCB (int32_t pc_hilo_nuevo)
{

	t_hilo_proceso *proceso_aux = malloc(sizeof(t_hilo_proceso));

	//Mismo PID
	proceso_aux->hilo.pid = hilo_proceso_syscall_global->hilo.pid;
	//Aumento el TID en 1 -> Tener sumo cuidado que no venga uno con el mismo TID y me pida esto
	//fallarian todos en ese caso <<<<<<<<<<<<<<<<<<<<<<<-----------
	//
	//
	proceso_aux->hilo.tid = CONTADOR_HILOS_INCREMENTAL;
	CONTADOR_HILOS_INCREMENTAL += 1;
	//
	//proceso_aux->hilo.tid = hilo_proceso_syscall_global->hilo.tid + 1;
	//
	//
	proceso_aux->hilo_join = -1;	//Significa que no esta joineado con nada
	proceso_aux->block = -1;
	//
	proceso_aux->hilo.kernel_mode = 0;
	proceso_aux->hilo.segmento_codigo_size = hilo_proceso_syscall_global->hilo.segmento_codigo_size;
	proceso_aux->socket_Consola = hilo_proceso_syscall_global->socket_Consola;
	proceso_aux->hilo.cola = NEW;
	/*
	 * CONEXION CON LA MSP
	 */
	t_header envio_MSP;
	t_header recep_MSP;
	dir_log dir;
	//Aca va el envio para crear el segmento -> Stack -> DEBO DUPLICAR LO QUE TENIA EL OTRO STACK
	t_crear_segmento seg_stack;
	seg_stack.PID = proceso_aux->hilo.pid;
	seg_stack.Size = SIZE_STACK;
	envio_MSP = serializar_t_crear_segmento(seg_stack);
	envio_MSP.id = 401;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		free(proceso_aux);
		return -1;
	}
	free(envio_MSP.data);
	if (recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
	{
		log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
		free(proceso_aux);
		return -1;
	}
	if (recep_MSP.id == 402)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		memcpy(&dir,recep_MSP.data,recep_MSP.size);
		proceso_aux->hilo.base_stack = proceso_aux->hilo.cursor_stack = dir.direccion_logica;
	}
	if (recep_MSP.id == 403)
	{
		//Memory Overload -> Cierro conexion con esa Consola
		free(proceso_aux);
		return -2;
	}

	//Aca mando el mensaje para duplicar lo que tenia el otro STACK una vez creado este
	//Si no cumple el if es que no guardo nada todavia
	if (hilo_proceso_syscall_global->hilo.cursor_stack - hilo_proceso_syscall_global->hilo.base_stack > 0)
	{
		t_solicitud_memoria sm;
		sm.PID = hilo_proceso_syscall_global->hilo.pid;
		//Diferencia para que arranque en el lugar del otro tambien
		sm.Size = hilo_proceso_syscall_global->hilo.cursor_stack - hilo_proceso_syscall_global->hilo.base_stack;
		sm.Direccion_Logica = hilo_proceso_syscall_global->hilo.base_stack;

		envio_MSP = serializar_t_solicitud_memoria(sm);
		envio_MSP.id = 406;
		if(enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
		{
			log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
			free(proceso_aux);
			return -1;
		}
		free(envio_MSP.data);
		if(recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
		{
			log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
			free(proceso_aux);
			return -1;
		}
		if(recep_MSP.id == 408)
		{
			//Segmentation Fault-> Cierro conexion con esa Consola
			free(proceso_aux);
			return -3;
		}
		//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

		//Envio lo que debo guardar
		t_escritura_memoria escritura_segmento;
		escritura_segmento.PID = proceso_aux->hilo.pid;
		escritura_segmento.Direccion_Logica = 0;
		//escritura_segmento.Size = proceso_aux->hilo.segmento_codigo_size;
		escritura_segmento.Size = recep_MSP.size;
		escritura_segmento.Bytes_A_Escribir = malloc(recep_MSP.size);
		memcpy(&escritura_segmento.Direccion_Logica,&dir.direccion_logica,sizeof(uint32_t));
		memcpy(escritura_segmento.Bytes_A_Escribir,recep_MSP.data,recep_MSP.size);

		envio_MSP = serializar_t_escritura_memoria(escritura_segmento);
		envio_MSP.id = 404;
		if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
		{
			log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
			return -1;
		}
		free(escritura_segmento.Bytes_A_Escribir);
		free(envio_MSP.data);
		if(recibir_paquete(sock_fd_MSP,&recep_MSP) < 0 )
		{
			log_error(Log_Kernel_Loader,"Se cerro conexion con MSP");
			return 1;
		}

		if (recep_MSP.id == 409)
		{
			//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		}
		if (recep_MSP.id == 407)
		{
			//Segmentation Fault
			return -3;
		}
	}
	//Inicializo registros/PC/Base Stack/Cursor Stack
	proceso_aux->hilo.registros[0] = 0;
	proceso_aux->hilo.registros[1] = 0;
	proceso_aux->hilo.registros[2] = 0;
	proceso_aux->hilo.registros[3] = 0;
	proceso_aux->hilo.registros[4] = 0;
	proceso_aux->hilo.cursor_stack = hilo_proceso_syscall_global->hilo.cursor_stack -
									 hilo_proceso_syscall_global->hilo.base_stack +
									 dir.direccion_logica;
	proceso_aux->hilo.base_stack = dir.direccion_logica;
	//Valor dado por el HILO duplicado
	proceso_aux->hilo.segmento_codigo = hilo_proceso_syscall_global->hilo.segmento_codigo;
	//
	//
	if(pc_hilo_nuevo >= hilo_proceso_syscall_global->hilo.segmento_codigo)
	{
		//Valor del Programa Counter -> Diferencia entre la posicion inicial(Memoria) y el segmento codigo inicial
		proceso_aux->hilo.puntero_instruccion = pc_hilo_nuevo - hilo_proceso_syscall_global->hilo.segmento_codigo;
	}
	else
	{
		//Valor del Program Counter -> Valor dado directamente del Registro 'B'
		proceso_aux->hilo.puntero_instruccion = pc_hilo_nuevo;
	}
	//
	//
	log_debug(Log_Kernel_Planificador,"Se creo el TCB->P:%d|T:%d(->New)",proceso_aux->hilo.pid,proceso_aux->hilo.tid);
	//ENCOLO EN NEW EL NUEVO TCB
	agregar_en_cola(cola_New,proceso_aux,&mutex_cola_New);
	//
	//Imprimo el estado de todas las colas
	imprime_t_Hilos_de_Todas_Colas();
	//
	sem_post(&sem_cola_New);

	return (proceso_aux->hilo.tid);
}

/*
 * Funcion que atiende las System_call. Se le envia un hilo que llama la system call,
 * en caso de que el propio hilo de KM = 1 llame la systemcall lo vuelve a poner en block
 * Si retorna = 1 -> No existe mas el hilo porque se cerro la conexion de la Consola
 * Si retorna = 0 -> Sigue conectada la consola
 */

int32_t ESO_system_call(t_hilo_proceso* hilo_proceso_sys_call,uint32_t puntero_a_syscall_a_usar)
{
	//
	//
	pthread_mutex_lock(&mutex_SYSCALL);
	//
	//

	if(hilo_proceso_sys_call == NULL)
	{
		//
		//
		pthread_mutex_unlock(&mutex_SYSCALL);
		//
		//
		return 1;
	}

	//Pregunto si se llamo a si mismo, en ese caso lo vuelvo al final asi cuando se vuelve a llamar
	//a la funcion, no se llama a si mismo de nuevo, sino a otro hilo
	if(hilo_proceso_sys_call->hilo.kernel_mode == 1)
	{
		hilo_proceso_sys_call->hilo.cola = BLOCK;
		agregar_en_cola(cola_Block,hilo_proceso_sys_call,&mutex_cola_Block);
		sem_post(&sem_cola_Block);
		//
		//
		pthread_mutex_unlock(&mutex_SYSCALL);
		//
		//
		return 0;
	}

	t_hilo_proceso *hilo_KM = esta_en_cola_Hilo_KM(cola_Block,&mutex_cola_Block);
	if(hilo_KM == NULL)
	{
		//No estaba en cola de bloqueados -> Se estaba usando
		hilo_proceso_sys_call->hilo.cola = BLOCK;
		agregar_en_cola(cola_Block,hilo_proceso_sys_call,&mutex_cola_Block);

	}
	else
	{
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		////Copia los datos del TCB que hizo la llamada a system call ----> Evita buscarlo en la cola de Block///
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		memcpy(hilo_proceso_syscall_global,hilo_proceso_sys_call,sizeof(t_hilo_proceso));////////////////////////
		hilo_proceso_syscall_global->estado_salida = SYSCALL;////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		//
		//"SE USA EL STACK DEL KERNEL -> AGREGADO EN ULTIMA FE DE ERRATAS"
		//
		//hilo_KM->hilo.base_stack = hilo_proceso_sys_call->hilo.base_stack;
		//hilo_KM->hilo.cursor_stack = hilo_proceso_sys_call->hilo.cursor_stack;
		//hilo_KM->hilo.pid = hilo_proceso_sys_call->hilo.pid;
		//hilo_KM->hilo.tid = hilo_proceso_sys_call->hilo.tid;

		//Puntero a la instruccion del sistema que debo usar en la CPU
		hilo_KM->hilo.puntero_instruccion = puntero_a_syscall_a_usar;
		hilo_KM->hilo.registros[0] = hilo_proceso_sys_call->hilo.registros[0];
		hilo_KM->hilo.registros[1] = hilo_proceso_sys_call->hilo.registros[1];
		hilo_KM->hilo.registros[2] = hilo_proceso_sys_call->hilo.registros[2];
		hilo_KM->hilo.registros[3] = hilo_proceso_sys_call->hilo.registros[3];
		hilo_KM->hilo.registros[4] = hilo_proceso_sys_call->hilo.registros[4];
		hilo_KM->socket_CPU = hilo_proceso_sys_call->socket_CPU;
		hilo_KM->socket_Consola = hilo_proceso_sys_call->socket_Consola;
		hilo_proceso_sys_call->hilo.cola = BLOCK;
		hilo_KM->hilo.cola = READY;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo)(P:%d|T:%d)"
				, hilo_proceso_sys_call->hilo.pid, hilo_proceso_sys_call->hilo.tid);
		agregar_en_cola(cola_Block,hilo_proceso_sys_call,&mutex_cola_Block);
		log_debug(Log_Kernel_Planificador,"Block->Ready(Hilo Kernel)");
		agregar_en_cola(cola_Ready,hilo_KM,&mutex_cola_Ready);
		//
		//Imprimo el estado de todas las colas
		log_debug(Log_Kernel_Planificador,"Llamada a SYSTEM CALL TCB->P:%d->T:%d",
									hilo_proceso_sys_call->hilo.pid,hilo_proceso_sys_call->hilo.tid);
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Ready);
	}
	//
	//
	pthread_mutex_unlock(&mutex_SYSCALL);
	//
	//
	return 0;
}

/*
 * Mueve el hilo de Kernel a la cola de Block y hace un sem_post para fijarse si debe hacer otra systemcall;
 * Se setea el hilo global en pid y tid = 0 para evitar fallos en las busquedas;
 */

int32_t fin_system_call_fallo_hilo(t_hilo_proceso *hilo_Kernel)
{



	hilo_Kernel->hilo.pid = 0;
	hilo_Kernel->hilo.tid = 0;
	hilo_proceso_syscall_global->hilo.pid = 0;
	hilo_proceso_syscall_global->hilo.tid = 0;
	hilo_Kernel->hilo.cola = BLOCK;
	hilo_proceso_syscall_global->socket_CPU = 0;
	hilo_proceso_syscall_global->socket_Consola = 0;
	log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
	agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
	//
	//Imprimo el estado de todas las colas
	imprime_t_Hilos_de_Todas_Colas();
	//
	sem_post(&sem_cola_Block);
	return 0;
}
/*
 * Dado el hilo de KM = 1, busco al 1° de la cola de bloqueados que en teoria deberia ser siempre
 * el que llamo la system call
 * Maneja los errores devuelvos por CREA/JOIN/ETC (Sobre hilos hijos tambien)
 */

int32_t fin_system_call(t_hilo_proceso *hilo_Kernel)
{

	if (hilo_proceso_syscall_global->estado_salida == FALLO_HILO_FIN)
	{
		//Muevo el hilo a exit y porque fallo algo del Hilo principal o algun hilo hermano;
		//Si ocurre este error no voy a tener ninguno hilo referencia a este en ninguna cola
		//
		//Solo debo volver el hilo de system call a la cola de bloqueados
		// Para las busquedas
		hilo_proceso_syscall_global->hilo.pid = 0;
		hilo_proceso_syscall_global->hilo.tid = 0;
		hilo_proceso_syscall_global->socket_CPU = 0;
		hilo_proceso_syscall_global->socket_Consola = 0;
		//hilo_Kernel->hilo.pid = 0;
		//hilo_Kernel->hilo.tid = 0;
		hilo_Kernel->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
		agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Block);
		return 0;
	}

	//
	//LA SUPOSICION ESTA MAL, NO SE DEBE HACER ASI !!!!!!!!!!!!!!!!!!!!!!!
	//////////////////////////////////////////////////////////////////////
	//En teoria el que quite aqui SIEMPRE va a ser el que llamo la system call
	//t_hilo_proceso *hilo_que_llamo_syscall = quitar_de_cola(cola_Block,&mutex_cola_Block);
	//
	//
	t_hilo_proceso *hilo_que_llamo_syscall = quitar_de_cola_block_coindice_syscallglobal
			(hilo_proceso_syscall_global->hilo.pid,hilo_proceso_syscall_global->hilo.tid);

	//

	hilo_que_llamo_syscall->hilo.registros[0] = hilo_Kernel->hilo.registros[0];
	hilo_que_llamo_syscall->hilo.registros[1] = hilo_Kernel->hilo.registros[1];
	hilo_que_llamo_syscall->hilo.registros[2] = hilo_Kernel->hilo.registros[2];
	hilo_que_llamo_syscall->hilo.registros[3] = hilo_Kernel->hilo.registros[3];
	hilo_que_llamo_syscall->hilo.registros[4] = hilo_Kernel->hilo.registros[4];
	hilo_proceso_syscall_global->socket_CPU = 0;
	hilo_proceso_syscall_global->socket_Consola = 0;
	//
	//
	// Para las busquedas
	hilo_proceso_syscall_global->hilo.pid = 0;
	hilo_proceso_syscall_global->hilo.tid = 0;
	//
	if (hilo_proceso_syscall_global->estado_salida == FALLO_CONEXION_CONSOLA)
	{
		//Muevo el hilo a exit y marco los otros hilos del PID
		funcion_handle_hilos_finalizados (hilo_que_llamo_syscall,FALLO_CONEXION_CONSOLA);
		hilo_Kernel->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
		agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Block);
		return 0;
	}

	if (hilo_proceso_syscall_global->estado_salida == FALLO_MEMORY_OVERLOAD)
	{
		//Si encuentra este estado de salida es porque fallo el CREA (Memory Overload devuelto por la MSP)
		//-> Esto me evita andar usando mas variables para identificarlo
		funcion_handle_hilos_finalizados (hilo_que_llamo_syscall,FALLO_MEMORY_OVERLOAD);
		hilo_Kernel->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
		agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Block);
		return 0;
	}
	if(hilo_proceso_syscall_global->estado_salida == FALLO_SEGMENTATION_FAULT)
	{
		//Si encuentra este estado de salida es porque fallo el CREA en escritura (Seg Fault devuelto por la MSP)
		//-> Esto me evita andar usando mas variables para identificarlo
		//
		funcion_handle_hilos_finalizados (hilo_que_llamo_syscall,FALLO_SEGMENTATION_FAULT);
		hilo_Kernel->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
		agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Block);
		return 0;
	}

	//
	//
	//No cumple ninguna de las anteriores -> NO FALLA LA SYSCALL -> Ejecucion normal
	//
	//

	if(hilo_proceso_syscall_global->hilo_join >= 0)
	{
		//Se encuentra el hilo para bloquear -> Se manda a la cola de Block_Join
		//Debe esperar a que el otro hilo termine
		//
		hilo_que_llamo_syscall->hilo.cola = BLOCK;
		hilo_que_llamo_syscall->hilo_join = hilo_proceso_syscall_global->hilo_join;
		log_debug(Log_Kernel_Planificador,"Block->Block(Join)(P:%d|T:%d)"
				, hilo_que_llamo_syscall->hilo.pid, hilo_que_llamo_syscall->hilo.tid);
		agregar_en_cola(cola_Block_Join,hilo_que_llamo_syscall,&mutex_cola_Block_Join);
		hilo_Kernel->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
		agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Block);
		return 0;
	}

		if(hilo_proceso_syscall_global->block >= 0)		//Te da el numero de semaforo que estas usando
	{
		//Se encuentra el hilo para bloquear -> Se manda a la cola de Block_Recurso
		//Debe esperar que otro hilo haga un Signal(WAKE) del semaforo para desbloquearse
		//
		hilo_que_llamo_syscall->block = hilo_proceso_syscall_global->block;
		hilo_proceso_syscall_global->block = -1;
		//
		hilo_que_llamo_syscall->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Block->Block(Recurso)(P:%d|T:%d)"
				, hilo_que_llamo_syscall->hilo.pid, hilo_que_llamo_syscall->hilo.tid);
		agregar_en_cola(cola_Block_Recurso,hilo_que_llamo_syscall,&mutex_cola_Block_Recurso);
		hilo_Kernel->hilo.cola = BLOCK;
		log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
		agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
		sem_post(&sem_cola_Block);
		return 0;
	}

	hilo_que_llamo_syscall->hilo.cola = READY;
	log_debug(Log_Kernel_Planificador,"Block->Ready(P:%d|T:%d)"
			, hilo_que_llamo_syscall->hilo.pid, hilo_que_llamo_syscall->hilo.tid);
	agregar_en_cola(cola_Ready,hilo_que_llamo_syscall,&mutex_cola_Ready);
	sem_post(&sem_cola_Ready);
	hilo_Kernel->hilo.cola = BLOCK;
	log_debug(Log_Kernel_Planificador,"Exec->Block(Hilo Kernel)");
	agregar_en_cola(cola_Block,hilo_Kernel,&mutex_cola_Block);
	//
	//Imprimo el estado de todas las colas
	imprime_t_Hilos_de_Todas_Colas();
	//
	sem_post(&sem_cola_Block);
	return 0;
}

/*
 * Agrega a la lista de hilos del mismo pid que hicieron llamada a WAKE y se pueden desbloquear
 * debido a que el semaforo >= 0 -> Lo reviso luego en la cola de bloqueados
 */
void agregar_lista_wake_hilos(int32_t semaforo_wake)
{
	pthread_mutex_lock(&mutex_lista_wake_hilos);

	t_sem_hilo *wake_pid_hilo = malloc(sizeof(t_sem_hilo));
	wake_pid_hilo->nro_semaforo = semaforo_wake;
	//
	list_add(lista_wake_hilos,wake_pid_hilo);
	//
	pthread_mutex_unlock(&mutex_lista_wake_hilos);
	return;
}

/*
 * Dado un socket_fd de una CPU en ejecucion (Se envia entre quantums para buscar errores en los hilos), busca
 * en la cola de exec que esta ejecutando la CPU;
 * En caso de encontrar el hilo con PID = 0 -> Busco el hilo global que contiene el PID del hilo que esta ejecutando
 * el KM = 1 -> System_Call;
 * En caso de encontrar el hilo con PID <> 0 -> Lo devuelvo para buscar en la lista;
 * En caso de fallar -> Devuelve 0;
 */

int32_t busca_cola_Exec_PID_en_ejecucion(int32_t socket_fd_cpu_a_buscar)
{
	int32_t i = 0;

	int32_t PID_retorno = 0;

	t_hilo_proceso *hilo_que_buscar = list_get(cola_Exec->elements,i);
	int32_t size = size_de_cola(cola_Exec,&mutex_cola_Exec);

	//Mutex a la cola para que no se agrege/quite nada
	pthread_mutex_lock(&mutex_cola_Exec);
	while(i < size)
	{
		if(hilo_que_buscar->socket_CPU == socket_fd_cpu_a_buscar)
		{
			if(hilo_que_buscar->hilo.pid == 0)
			{
				PID_retorno = hilo_proceso_syscall_global->hilo.pid;
			}
			else
			{
				PID_retorno = hilo_que_buscar->hilo.pid;
			}
			pthread_mutex_unlock(&mutex_cola_Exec);
			return PID_retorno;
		}
		i++;
		hilo_que_buscar = list_get(cola_Exec->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Exec);

	return 0;
}

/*
 * Busca si existe el hilo antes de joiner
 * Return 1 -> Existe
 * Return 0 -> No existe el hilo
 */

int32_t existeHiloParaJoinear (int32_t PID_JOIN,int32_t TID_JOIN)
{
	int32_t i = 0;
	pthread_mutex_lock(&mutex_cola_New);
	t_hilo_proceso *p_hilo_proceso = list_get(cola_New->elements,i);
	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_JOIN && p_hilo_proceso->hilo.tid == TID_JOIN)
		{
			//Existe el hilo que busco
			pthread_mutex_unlock(&mutex_cola_New);
			return 1;
		}
		i++;
		p_hilo_proceso = list_get(cola_New->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_New);
	//
	pthread_mutex_lock(&mutex_cola_Ready);
	i = 0;
	p_hilo_proceso = list_get(cola_Ready->elements,i);
	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_JOIN && p_hilo_proceso->hilo.tid == TID_JOIN)
		{
			//Existe el hilo que busco
			pthread_mutex_unlock(&mutex_cola_Ready);
			return 1;
		}
		i++;
		p_hilo_proceso = list_get(cola_Ready->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Ready);
	//
	pthread_mutex_lock(&mutex_cola_Block);
	i = 0;
	p_hilo_proceso = list_get(cola_Block->elements,i);
	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_JOIN && p_hilo_proceso->hilo.tid == TID_JOIN)
		{
			//Existe el hilo que busco
			pthread_mutex_unlock(&mutex_cola_Block);
			return 1;
		}
		i++;
		p_hilo_proceso = list_get(cola_Block->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block);
	//
	pthread_mutex_lock(&mutex_cola_Block_Join);
	i = 0;
	p_hilo_proceso = list_get(cola_Block_Join->elements,i);
	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_JOIN && p_hilo_proceso->hilo.tid == TID_JOIN)
		{
			//Existe el hilo que busco
			return 1;
		}
		i++;
		p_hilo_proceso = list_get(cola_Block_Join->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block_Join);
	//
	pthread_mutex_lock(&mutex_cola_Block_Recurso);
	i = 0;
	p_hilo_proceso = list_get(cola_Block_Recurso->elements,i);
	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_JOIN && p_hilo_proceso->hilo.tid == TID_JOIN)
		{
			//Existe el hilo que busco
			pthread_mutex_unlock(&mutex_cola_Block_Recurso);
			return 1;
		}
		i++;
		p_hilo_proceso = list_get(cola_Block_Recurso->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block_Recurso);
	//
	pthread_mutex_lock(&mutex_cola_Exec);
	i = 0;
	p_hilo_proceso = list_get(cola_Exec->elements,i);
	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_JOIN && p_hilo_proceso->hilo.tid == TID_JOIN)
		{
			//Existe el hilo que busco
			pthread_mutex_unlock(&mutex_cola_Exec);
			return 1;
		}
		i++;
		p_hilo_proceso = list_get(cola_Exec->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Exec);

	return 0;
}

/*
 * Busca dentro de los hilos ejecutandose primero y luego dentro de la cola de cpus libres, que cpu se desconecto.
 * En caso de encontrarse ejecutando un Hilo -> Se desconecta el Socket y se aborta el hilo por error de cpu
 * En caso de encontrarse ejecutando un Hilo KM = 1(Hilo Kernel) -> Se desconecta el Socket -> SE ABORTA EL KERNEL
 * En caso de no encontrarse ejecutando un Hilo -> Se desconecta el Socket y se lo quita de la cola de cpus libres
 * Retorno 0 -> Hilo/No encuentra hilo;
 * Retorno 1 -> Hilo del KM = 1(Hilo Kernel);
 * Retorno -1 -> No encontro nada
 */

int32_t handle_desconexiones_CPUs(int32_t socket_fd_desconectado)
{
	//1°) Me fijo si se desconecto una CPU con un TCB ejecutandose
	t_hilo_proceso *desconectado = dameProcesoHilo(cola_Exec,socket_fd_desconectado,&mutex_cola_Exec);
	if (desconectado != NULL)
	{
		//2°)Se estaba ejecutando el hilo KM = 1 -> ABORTO EL KERNEL
		if(desconectado->hilo.kernel_mode == 1)
		{
			//
			//Se ha desconectado una CPU correctamente
			desconexion_cpu(socket_fd_desconectado);
			//
			log_error(Log_Kernel_Loader,"Fallo de CPU con el Hilo KM = 1 ejecutandose, se cerrara el kernel");
			close(sock_fd_MSP);
			return 1;
		}
		//3°)No se estaba ejecutando el hilo kernel ->Cierro el socket y el TCB que se encontraba en ejecucio
		//se aborta -> Se envia mensaje de error a consola
		quitaSocketfdColaConexiones(socket_fd_desconectado,cola_CPU_libres,&mutex_cola_CPU_libres);
		close(socket_fd_desconectado);
		//
		//Se ha desconectado una CPU correctamente
		desconexion_cpu(socket_fd_desconectado);
		//
		funcion_handle_hilos_finalizados(desconectado,FALLO_CONEXION_CPU);
		return 0;
	}
	//
	//4°)En caso de no encontrarse ejecutando ningun hilo => Estaba en la cola de cpus libres -> LO QUITO DE AHI
	int32_t error_quitasocketfd = quitaSocketfdColaConexiones(socket_fd_desconectado
					,cola_CPU_libres,&mutex_cola_CPU_libres);
	if (error_quitasocketfd == 0)
	{
		log_warning(Log_Kernel_Loader,"Desconexion de CPU->Socket:%d",socket_fd_desconectado);
		close(socket_fd_desconectado);
		//
		//Se ha desconectado una CPU correctamente
		desconexion_cpu(socket_fd_desconectado);
		//
		return 0;
	}
	return -1;
}

/*
 * Busca dentro de los hilos que se encuentran en las distintas colas, a cual pertenece la consola desconectada.
 * 1)Busco si el desconectado esta en la cola de EXEC -> Si esta => 3)
 * 2)En caso de no estar en exec -> Lo busco en las otras colas y los saco todos eliminando sus segmentos
 * 3)Marco los que estan en EXEC como FIN_DESCONEXION_CONSOLA -> Quito de las colas no EXEC los demas
 * Retorno 0 -> Encontro un hilo
 * Retorno -1 -> No encontro nada
 */
int32_t handle_desconexiones_Consolas(int32_t socket_fd_desconectado)
{

	if(socket_fd_desconectado == hilo_proceso_syscall_global->socket_Consola
			&&
			hilo_proceso_syscall_global->estado_salida == SYSCALL)
	{
		t_header header_envio_CPU;
		header_envio_CPU.id = 700;
		header_envio_CPU.size = 0;
		if(enviar_paquete(hilo_proceso_syscall_global->socket_CPU,header_envio_CPU) < 0)
		{
			log_error(Log_Kernel_Temporal,"\n\nERROR_FATAL->HILO KERNEL EJECUTANDOSE EN CPU QUE FALLO(KM = 1)->ABORTO EL KERNEL\n\n");
			exit(1);
		}
		return -1;
	}

	//	//Esta en cola de exec
	int32_t PID_a_desconectar = damePIDporSockFDConsola(cola_Exec,socket_fd_desconectado,&mutex_cola_Exec);
	//

	if(PID_a_desconectar > 0 )
	{
		marcaEstadoSalidaPorPID(cola_Exec,PID_a_desconectar,&mutex_cola_Exec,FALLO_CONEXION_CONSOLA);
		agregar_a_lista_handle_hilos_finalizados_mutex(PID_a_desconectar);
		//Se ha desconectado una consola correctamente
		desconexion_consola(socket_fd_desconectado);
		//
		close(socket_fd_desconectado);
		return 0;
	}
	//
	//No esta en cola de exec
	//

	t_hilo_proceso *aux_quita_hilos = NULL;
	aux_quita_hilos = dameProcesoHiloporSockFDConsola(cola_New,socket_fd_desconectado,&mutex_cola_New);

	if(aux_quita_hilos != NULL)
	{
		funcion_handle_hilos_finalizados (aux_quita_hilos,FALLO_CONEXION_CONSOLA);
		//Se ha desconectado una consola correctamente
		desconexion_consola(socket_fd_desconectado);
		//
		close(socket_fd_desconectado);
		return 0;
	}

	aux_quita_hilos = dameProcesoHiloporSockFDConsola(cola_Block,socket_fd_desconectado,&mutex_cola_Block);
	if(aux_quita_hilos != NULL)
	{
		funcion_handle_hilos_finalizados (aux_quita_hilos,FALLO_CONEXION_CONSOLA);
		//Se ha desconectado una consola correctamente
		desconexion_consola(socket_fd_desconectado);
		//
		close(socket_fd_desconectado);
		return 0;
	}

	aux_quita_hilos = dameProcesoHiloporSockFDConsola(cola_Block_Join,socket_fd_desconectado,&mutex_cola_Block_Join);
	if(aux_quita_hilos != NULL)
	{
		funcion_handle_hilos_finalizados (aux_quita_hilos,FALLO_CONEXION_CONSOLA);
		//Se ha desconectado una consola correctamente
		desconexion_consola(socket_fd_desconectado);
		//
		close(socket_fd_desconectado);
		return 0;
	}

	aux_quita_hilos = dameProcesoHiloporSockFDConsola(cola_Block_Recurso,socket_fd_desconectado,&mutex_cola_Block_Recurso);
	if(aux_quita_hilos != NULL)
	{
		funcion_handle_hilos_finalizados (aux_quita_hilos,FALLO_CONEXION_CONSOLA);
		//Se ha desconectado una consola correctamente
		desconexion_consola(socket_fd_desconectado);
		//
		close(socket_fd_desconectado);
		return 0;
	}

	aux_quita_hilos = dameProcesoHiloporSockFDConsola(cola_Ready,socket_fd_desconectado,&mutex_cola_Ready);
	if(aux_quita_hilos != NULL)
	{
		funcion_handle_hilos_finalizados (aux_quita_hilos,FALLO_CONEXION_CONSOLA);
		//Se ha desconectado una consola correctamente
		desconexion_consola(socket_fd_desconectado);
		//
		close(socket_fd_desconectado);
		return 0;
	}
	//Caso anomalo, siempre deberia encontrarlo
	return -1;
}




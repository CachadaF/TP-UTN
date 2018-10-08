#include"Hilos_Planificador.h"

extern t_log *Log_Kernel_Temporal;
extern t_log *Log_Kernel_Planificador;
//extern t_log *Log_Kernel_Loader;
extern int32_t sock_fd_MSP;
extern int32_t QUANTUM;
//Listas
extern t_list* lista_hilos_terminados;		//Lista usada para JOIN
extern t_list* lista_wake_hilos;			//Lista usada para WAKE/BLOK -> Semaforos de los hilos
//extern t_list* lista_handle_hilos_finalizados; //Lista encargada de finalizar los hilos hijos que se encuentren en Exec/Block
//Colas del planificador
extern t_queue* cola_Ready;
extern t_queue* cola_Block;
extern t_queue* cola_Block_Recurso;
extern t_queue* cola_Block_Join;
extern t_queue* cola_Exit;
extern t_queue* cola_Exec;
extern t_queue* cola_New;
extern t_queue* cola_CPU_libres;
//Mutex de las colas
extern pthread_mutex_t mutex_cola_Ready;
extern pthread_mutex_t mutex_cola_Block;
extern pthread_mutex_t mutex_cola_Block_Recurso;
extern pthread_mutex_t mutex_cola_Block_Join;
extern pthread_mutex_t mutex_cola_Exit;
extern pthread_mutex_t mutex_cola_Exec;
extern pthread_mutex_t mutex_cola_New;
extern pthread_mutex_t mutex_cola_CPU_libres;
extern pthread_mutex_t mutex_lista_hilos_terminados;
extern pthread_mutex_t mutex_lista_wake_hilos;
//extern pthread_mutex_t mutex_lista_handle_hilos_finalizados;
//Semaforos Contadores
extern sem_t sem_cola_New;
extern sem_t sem_cola_Ready;
extern sem_t sem_cola_Block;
extern sem_t sem_cola_Exit;



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////Hilo Planificador(Ready) -> Levanta los demas hilos//////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void *hilo_Planificador(void* argc)
{
	//Estructuras necesarias en este hilo
	t_hilo_proceso *Hilo_Proceso_nuevo;
	t_header header_envio_CPU;
	uint32_t size_cola_Ready = 0;
	uint32_t size_cola_CPU_libres = 0;
	int32_t quantum = QUANTUM;

	pthread_t thread_exit;
	pthread_create(&thread_exit,NULL,hilo_Planificador_Exit,NULL);
	pthread_t thread_new;
	pthread_create(&thread_new,NULL,hilo_Planificador_New,NULL);
	pthread_t thread_block;
	pthread_create(&thread_block,NULL,hilo_Planificador_Block,NULL);

	//SIN JOIN PORQUE CORREN AL MISMO TIEMPO

	while(1)
	{

		sem_wait(&sem_cola_Ready);

		//Muevo de cola Ready->Exec, en caso de encontrar CPU_Libres
		while(1)
		{
			Hilo_Proceso_nuevo = esta_en_cola_Hilo_KM(cola_Ready,&mutex_cola_Ready);

			//Me fijo si esta el hilo kernel para ejecutarlo primero SIEMPRE
			if(Hilo_Proceso_nuevo != NULL)
			{
				//Si encuentra el hilo de KM = 1 -> Lo saca de la cola Ready

				Hilo_Proceso_nuevo->hilo.cola = EXEC;
				agregar_en_cola(cola_Exec,Hilo_Proceso_nuevo,&mutex_cola_Exec);

				log_debug(Log_Kernel_Planificador,"Muevo de Ready->Exec(Hilo Kernel)");

				header_envio_CPU = serializar_t_hilo(Hilo_Proceso_nuevo->hilo);
				header_envio_CPU.id = 201;

				if(enviar_paquete(Hilo_Proceso_nuevo->socket_CPU,header_envio_CPU) < 0)
				{
					//Fallo el envio de KM = 1 -> Aborto el kernel
					log_debug(Log_Kernel_Temporal,"FALLO LA CONEXION A CPU->Con el KM = 1\nAbortar Kernel");
					pthread_exit(NULL);
				}

				free(header_envio_CPU.data);
				header_envio_CPU.id = 203;
				header_envio_CPU.size = sizeof(int32_t);
				header_envio_CPU.data = malloc(sizeof(int32_t));
				memcpy(header_envio_CPU.data,&quantum,sizeof(int32_t));

				if(enviar_paquete(Hilo_Proceso_nuevo->socket_CPU,header_envio_CPU) < 0)
				{
					//Fallo el envio de KM = 1 -> Aborto el kernel
					log_debug(Log_Kernel_Temporal,"FALLO LA CONEXION A CPU->Con el KM = 1\nAbortar Kernel");
					pthread_exit(NULL);
				}
				free(header_envio_CPU.data);
				//
				//Imprimo el estado de todas las colas
				imprime_t_Hilos_de_Todas_Colas();
				//
				break;	//Break del while(1) despues de Sem_Post()

			}

			else

			{
				//En caso de que no este el Hilo del Kernel (KM=1)

				size_cola_CPU_libres = size_de_cola(cola_CPU_libres,&mutex_cola_CPU_libres);

				size_cola_Ready = size_de_cola(cola_Ready,&mutex_cola_Ready);

				if(size_cola_CPU_libres > 0 && size_cola_Ready > 0)
				{
					//PUEDO EJECUTAR PORQUE HAY CPU LIBRE => READY->EXEC
					Hilo_Proceso_nuevo = quitar_de_cola(cola_Ready,&mutex_cola_Ready);

					Hilo_Proceso_nuevo->hilo.cola = EXEC;

					log_debug(Log_Kernel_Planificador,"Muevo de Ready->Exec(P:%d|T:%d)"
							,Hilo_Proceso_nuevo->hilo.pid,Hilo_Proceso_nuevo->hilo.tid);

					agregar_en_cola(cola_Exec,Hilo_Proceso_nuevo,&mutex_cola_Exec);

					Hilo_Proceso_nuevo->socket_CPU = (int32_t)(quitar_de_cola(cola_CPU_libres,&mutex_cola_CPU_libres));

					//MANDO A LA CPU EL QUANTUM PRIMERO Y LUEGO EL TCB

					header_envio_CPU = serializar_t_hilo(Hilo_Proceso_nuevo->hilo);
					header_envio_CPU.id = 201;

					if(enviar_paquete(Hilo_Proceso_nuevo->socket_CPU,header_envio_CPU) < 0)
					{
						//Debo sacar la CPU debido al fallo y borrar el TCB/SEGMENTOS/ETC
						funcion_handle_hilos_finalizados(Hilo_Proceso_nuevo,FALLO_CONEXION_CPU);
					}
					else
					{
						free(header_envio_CPU.data);
						header_envio_CPU.id = 203;
						header_envio_CPU.size = sizeof(int32_t);
						header_envio_CPU.data = malloc(sizeof(int32_t));
						memcpy(header_envio_CPU.data,&quantum,sizeof(int32_t));
						//Intento mandar el TCB
						if(enviar_paquete(Hilo_Proceso_nuevo->socket_CPU,header_envio_CPU) < 0)
						{
							//Debo sacar la CPU debido al fallo y borrar el TCB/SEGMENTOS/ETC
							funcion_handle_hilos_finalizados(Hilo_Proceso_nuevo,FALLO_CONEXION_CPU);
						}
						free(header_envio_CPU.data);
						//
						//Imprimo el estado de todas las colas
						imprime_t_Hilos_de_Todas_Colas();
						//
						break;	//Break del while(1) despues de Sem_Post()

					}//IF de que logre mandar

				}//IF de size of CPU_Conectadas

			}	//IF DE QUE NO ESTA EL HILO DE KERNEL

		}//While(1) de que pase a Ready

	}//While Principal

	log_debug(Log_Kernel_Temporal,"Fin de Hilo de Planificacion Principal(+Ready)");

	pthread_exit(NULL);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////Hilo Planificador(New)////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


void* hilo_Planificador_New (void* argc)
{
	t_hilo_proceso *Hilo_Proceso_nuevo;

	//int32_t size_cola_New;

	while (1)
	{
		sem_wait(&sem_cola_New);	//Espero a semaforo de cola New
		Hilo_Proceso_nuevo = quitar_de_cola(cola_New,&mutex_cola_New);
		Hilo_Proceso_nuevo->hilo.cola = READY;
		log_debug(Log_Kernel_Planificador,"New->Ready(P:%d|T:%d)"
				,Hilo_Proceso_nuevo->hilo.pid, Hilo_Proceso_nuevo->hilo.tid);
		agregar_en_cola(cola_Ready,Hilo_Proceso_nuevo,&mutex_cola_Ready);
		sem_post(&sem_cola_Ready);
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
	}

	log_debug(Log_Kernel_Temporal,"Fin de Hilo de Planificacion New");

	pthread_exit(NULL);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////Hilo Planificador(Block)////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void* hilo_Planificador_Block(void* argc)
{
	t_hilo_proceso *Hilo_Proceso_nuevo;
	int32_t size_cola_Block = 0;
	int32_t size_cola_Block_Recurso = 0;
	int32_t size_cola_Block_Join = 0;
	int32_t size_lista_join = 0;
	int32_t size_lista_wake_hilos = 0;

	while(1)
	{
		sem_wait(&sem_cola_Block);

		//COLA DE BLOQUEADOS POR LLAMADA AL SISTEMA -> Si hay 1 es un proceso esperando que vuelva el HILO KM = 1
		//Si hay 2 es el hilo KM y el hilo que necesita el syscall -> Ahi si entro
		size_cola_Block = size_de_cola(cola_Block,&mutex_cola_Block);
		if (size_cola_Block >= 2)
		{
			//Me fijo si hay 2 en Block -> Sino es el KM el unico bloqueado/Hay un hilo esperando
			Hilo_Proceso_nuevo = quitar_de_cola(cola_Block,&mutex_cola_Block);
			ESO_system_call(Hilo_Proceso_nuevo,Hilo_Proceso_nuevo->syscall_llamada);
		}

		//COLA DE BLOQUEADOS POR SYSTEM CALL -> BLOK/WAKE
		size_cola_Block_Recurso = size_de_cola(cola_Block_Recurso,&mutex_cola_Block_Recurso);
		if (size_cola_Block_Recurso > 0)
		{

			pthread_mutex_lock(&mutex_lista_wake_hilos);
			size_lista_wake_hilos = list_size(lista_wake_hilos);
			pthread_mutex_unlock(&mutex_lista_wake_hilos);
			if(size_lista_wake_hilos > 0)
			{
				buscar_hilos_a_desbloquear_por_semaforo();
			}
		}

		//COLA DE BLOQUEADOS POR SYSTEM CALL -> JOIN
		size_cola_Block_Join = size_de_cola(cola_Block_Join,&mutex_cola_Block_Join);
		if (size_cola_Block_Join > 0)
		{
			pthread_mutex_lock(&mutex_lista_hilos_terminados);
			size_lista_join = list_size(lista_hilos_terminados);
			pthread_mutex_unlock(&mutex_lista_hilos_terminados);
			if(size_lista_join > 0)
			{
				buscar_hilos_joineados_finalizados();
			}
		}
	}

	log_debug(Log_Kernel_Temporal,"Fin de Hilo de Planificacion Block");

	pthread_exit(NULL);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////Hilo Planificador(Exit)///////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void* hilo_Planificador_Exit(void* argc)
{
	t_hilo_proceso *aux_finalizacion_TCB;
	t_header header_envio_MSP;
	t_header header_envio_Consola;
	t_destruir_segmento mensaje_destruccion;

	while(1)
	{

		sem_wait(&sem_cola_Exit);

		aux_finalizacion_TCB = quitar_de_cola(cola_Exit,&mutex_cola_Exit);

		//Destruyo todos los segmentos del Hilo
		if (aux_finalizacion_TCB->estado_salida == FIN_HILO)
		{
			log_debug(Log_Kernel_Planificador,"Fin_Hilo->Destruccion de segmentos->P:%d|Hilo:%d"
						,aux_finalizacion_TCB->hilo.pid,aux_finalizacion_TCB->hilo.tid);

			header_envio_Consola.id = 8;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				handle_desconexiones_Consolas(aux_finalizacion_TCB->socket_Consola);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}

			free(aux_finalizacion_TCB);
		}
		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos
		if (aux_finalizacion_TCB->estado_salida == FIN_PROCESO)
		{
			log_debug(Log_Kernel_Planificador,"Fin_Proceso->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);

			header_envio_Consola.id = 10;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}
		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos -> Por Fallo
		if (aux_finalizacion_TCB->estado_salida == FALLO_CONEXION_CONSOLA)
		{
			log_debug(Log_Kernel_Planificador,"Fallo_Conexion_Consola->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}

			free(aux_finalizacion_TCB);
		}

		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos -> Por Fallo
		if (aux_finalizacion_TCB->estado_salida == FALLO_CONEXION_CPU)
		{
			log_debug(Log_Kernel_Planificador,"Fallo_Conexion_CPU->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);
			header_envio_Consola.id = 11;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}

		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos -> Por Fallo
		if (aux_finalizacion_TCB->estado_salida == FALLO_INSTRUCCION)
		{
			log_debug(Log_Kernel_Planificador,"Fallo_Instruccion->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);

			header_envio_Consola.id = 11;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}

		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos -> Por Fallo
		if (aux_finalizacion_TCB->estado_salida == FALLO_SEGMENTATION_FAULT)
		{
			log_debug(Log_Kernel_Planificador,"Segmentation Fault->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);
			header_envio_Consola.id = 12;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}

		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos -> Por Fallo
		if (aux_finalizacion_TCB->estado_salida == FALLO_MEMORY_OVERLOAD)
		{
			log_debug(Log_Kernel_Planificador,"Memory Overload->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);
			header_envio_Consola.id = 13;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}

		//Destruyo todos los segmentos del Proceso junto con los de sus Hilos Hijos -> Por Fallo
		if (aux_finalizacion_TCB->estado_salida == 	FALLO_DIVISION_CERO)
		{
			log_debug(Log_Kernel_Planificador,"Error Division por cero->Destruccion de segmentos->P:%d",aux_finalizacion_TCB->hilo.pid);

			header_envio_Consola.id = 14;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			//
			//Finalizo el Segmento de Codigo del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.segmento_codigo;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}

		//Aviso a las consolas del fallo
		if (aux_finalizacion_TCB->estado_salida == 	FALLO_CONEXION_MSP)
		{
			log_debug(Log_Kernel_Planificador,"Fallo_Conexion_MSP->P:%d",aux_finalizacion_TCB->hilo.pid);
			header_envio_Consola.id = 15;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			free(aux_finalizacion_TCB);
		}
		//Aviso a las consolas del fallo -> Fallo del hilo principal
		if (aux_finalizacion_TCB->estado_salida == 	FALLO_FIN_HILO_PADRE)
		{
			log_debug(Log_Kernel_Planificador,"Fallo_FIN_HILO_PADRE->P:%d",aux_finalizacion_TCB->hilo.pid);
			header_envio_Consola.id = 16;
			header_envio_Consola.size = 0;
			if (enviar_paquete(aux_finalizacion_TCB->socket_Consola,header_envio_Consola) < 0)
			{
				//Se ha desconectado una consola correctamente
				log_debug(Log_Kernel_Temporal,"La Consola cerro su conexion");
				desconexion_consola(aux_finalizacion_TCB->socket_Consola);
				//
			}
			close(aux_finalizacion_TCB->socket_Consola);
			free(aux_finalizacion_TCB);
		}
		//Hilos que fallaron de un Hilo padre (Sea por fallo de conexion con CPU, error de ejecucion, fin de hilo padre)
		if (aux_finalizacion_TCB->estado_salida == FALLO_HILO_FIN)
		{
			//Solo hago free porque los segmentos los finaliza el TID = 0 (Padre)
			//
			//Finalizo el Stack del Hilo
			//
			mensaje_destruccion.PID = aux_finalizacion_TCB->hilo.pid;
			mensaje_destruccion.Direccion_Logica = aux_finalizacion_TCB->hilo.base_stack;
			header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
			header_envio_MSP.id = 405;
			//Este mensaje id = 405 -> Destruye el segmento indicado
			if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
			{
				log_debug(Log_Kernel_Temporal,"La MSP cerro su conexion, se procedera a abortar el Kernel");
				exit(1);
			}
			free(aux_finalizacion_TCB);
		}
		//Borra los PID de la lista que ya no estan en ninguna cola del Kernel
		//
		limpia_lista_handle_hilos_finalizados ();
		//
		//Imprimo el estado de todas las colas
		imprime_t_Hilos_de_Todas_Colas();
		//
	}//Fin del While(1)

	log_debug(Log_Kernel_Temporal,"Fin de Hilo de Planificacion Exit");

	pthread_exit(NULL);

}

/*
 * Busca dentro de los hilos que hicieron JOIN + los hilos finalizados, cuales se pueden desbloquear
 * En caso de no estar el hilo buscado -> Siguen esperando
 * En caso de estar -> Desbloqueado (Hilo terminado se quita de la lista)
 * En caso de que el hilo que termino no sirva para desbloquear -> Se quita de la lista
 */

int32_t buscar_hilos_joineados_finalizados()
{
	pthread_mutex_lock(&mutex_lista_hilos_terminados);
	pthread_mutex_lock(&mutex_cola_Block_Join);
	int32_t i = 0;
	int32_t j = 0;
	int32_t size_lista = list_size(lista_hilos_terminados);
	int32_t size_cola = queue_size(cola_Block_Join);
	t_hilo_proceso *hilo_proceso_join = list_get(cola_Block_Join->elements,j);
	t_fin_hilo *fin_hilo_aux = list_get(lista_hilos_terminados,i);

	while (i < size_lista)		//Recorre la lista de hilos que terminar para ver si se puede quitar de join algo
								// -> No quita hasta no terminar de recorrer TODOS los elementos de la lista
	{
		while(j < size_cola)	//Recorre la cola de hilos Joineados
		{
			if(hilo_proceso_join->hilo.pid==fin_hilo_aux->proceso && hilo_proceso_join->hilo_join==fin_hilo_aux->hilo)
			{
				hilo_proceso_join = list_remove(cola_Block_Join->elements,j);
				hilo_proceso_join->hilo_join = -1;
				hilo_proceso_join->hilo.cola = READY;
				log_debug(Log_Kernel_Planificador,"Block(Join)->Ready(P:%d|T:%d)"
						,hilo_proceso_join->hilo.pid,hilo_proceso_join->hilo.tid);
				agregar_en_cola(cola_Ready,hilo_proceso_join,&mutex_cola_Ready);
				sem_post(&sem_cola_Ready);
				//
				//
				size_lista = list_size(lista_hilos_terminados);
				break;
				//
				//
			}
			//
			//
			j++;
			hilo_proceso_join = list_get(cola_Block_Join->elements,j);
			//
			//
		}
		j = 0;
		hilo_proceso_join = list_get(cola_Block_Join->elements,j);
		i++;
		fin_hilo_aux = list_get(lista_hilos_terminados,i);
	}

	list_clean_and_destroy_elements(lista_hilos_terminados,free);
	pthread_mutex_unlock(&mutex_lista_hilos_terminados);
	pthread_mutex_unlock(&mutex_cola_Block_Join);
	//
	//Imprimo el estado de todas las colas
	imprime_t_Hilos_de_Todas_Colas();
	//
	return 0;
}

/*
 * Busca, dada una señal de WAKE, un hilo que se pueda desbloquear de la cola de
 * bloqueados debido a un semaforo
 */

int32_t buscar_hilos_a_desbloquear_por_semaforo()
{
	pthread_mutex_lock(&mutex_lista_wake_hilos);
	pthread_mutex_lock(&mutex_cola_Block_Recurso);
	int32_t i = 0;
	int32_t j = 0;
	int32_t size_lista = list_size(lista_wake_hilos);
	int32_t size_cola = queue_size(cola_Block_Recurso);

	t_hilo_proceso *hilo_bloqueado_semaforo = list_get(cola_Block_Recurso->elements,j);
	t_sem_hilo *semaforo_wake = list_get(lista_wake_hilos,i);

	while (i < size_lista)		//Recorre la lista que posee el hilo que puedo desbloquear 1° -> Quita los elementos
	{
		while(j < size_cola)	//Recorre la cola de bloqueados por Semaforo
		{
			if(hilo_bloqueado_semaforo->block == semaforo_wake->nro_semaforo)
			{
				//ACA ESTA ROMPIENDO
				hilo_bloqueado_semaforo = list_remove(cola_Block_Recurso->elements,j);
				hilo_bloqueado_semaforo->block = -1;
				hilo_bloqueado_semaforo->hilo.cola = READY;
				log_debug(Log_Kernel_Planificador,"Block(Recursos)->Ready(P:%d|T:%d)"
						,hilo_bloqueado_semaforo->hilo.pid,hilo_bloqueado_semaforo->hilo.tid);
				agregar_en_cola(cola_Ready,hilo_bloqueado_semaforo,&mutex_cola_Ready);
				sem_post(&sem_cola_Ready);
				//
				//
				size_lista = list_size(lista_wake_hilos);
				break;
				//
				//
			}
			//
			//
			j++;
			hilo_bloqueado_semaforo = list_get(cola_Block_Recurso->elements,j);
			//
			//
		}
		j = 0;
		hilo_bloqueado_semaforo = list_get(cola_Block_Recurso->elements,j);
		i++;
		semaforo_wake = list_get(lista_wake_hilos,i);
	}

	//Elimino todos los semaforos
	list_clean_and_destroy_elements(lista_wake_hilos,free);

	pthread_mutex_unlock(&mutex_cola_Block_Recurso);
	pthread_mutex_unlock(&mutex_lista_wake_hilos);
	//
	//Imprimo el estado de todas las colas
	imprime_t_Hilos_de_Todas_Colas();
	//
	return 0;
}









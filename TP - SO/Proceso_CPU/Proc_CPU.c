#include"Proc_CPU.h"

//Logs globales CPU
t_log* log_CPU;
t_log* log_CPU_ESO;
//Globales
t_registros_cpu REGISTROS_CPU;
uint32_t global_tcb_TID;
t_cola global_tcb_cola;
uint32_t guardo_pid_syscall;	//Guardan los valores cuando hago system call para acceder a los segmentos

//Variables Globales
uint32_t CONTADOR_QUANTUM = 0;
uint32_t QUANTUM = 0;
uint32_t FLAG_TCB_OUT = 0;
syscall_p SYSTEMCALL;
//Path Config
#define Path_Config_CPU "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_CPU/Funciones_CPU/Config_CPU"
#define Path_Log_CPU "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_CPU/Funciones_CPU/CPU.log"
#define Path_Log_CPU_ESO "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_CPU/Funciones_CPU/CPU_ESO.log"
//Sockets globales para poder usarse en las primitivas
int32_t sock_fd_Kernel;
int32_t sock_fd_MSP;

int main ()
{
	//Levanto los Logs
	log_CPU = log_create(Path_Log_CPU,"CPU.log",true,LOG_LEVEL_INFO);

	if (log_CPU == NULL)
	{
		printf("Fallo al abrir Log->Finalizacion de Programa");
		return EXIT_FAILURE;
	}
	log_CPU_ESO = log_create(Path_Log_CPU_ESO,"CPU_ESO.log",false,LOG_LEVEL_DEBUG);
	if (log_CPU_ESO == NULL)
	{
		printf("Fallo al abrir Log->Finalizacion de Programa");
		return EXIT_FAILURE;
	}
	//
	//Obtengo el Path de la CPU
	//
	char CPU_Path_Folder[1024];
	t_tipo_proceso tipo_proceso = CPU;
	if(getcwd(CPU_Path_Folder, sizeof(CPU_Path_Folder)) == NULL)
	{
		log_error(log_CPU,"ERROR->No se pudo obtener el Path de la CPU\n");
		return EXIT_FAILURE;
	}
	log_debug(log_CPU_ESO,"Inicio de Proceso CPU->Path:%s",CPU_Path_Folder);
	//
	inicializar_panel(tipo_proceso,CPU_Path_Folder);
	//
	//Signal Handles para evitar cierres extraños de las CPU -> Cierran los Socket_fd del Kernel y del MSP
	signal(SIGUSR1,sig_handler);
	signal(SIGUSR2,sig_handler);
	signal(SIGINT,sig_handler);
	signal(SIGTERM,sig_handler);
	//
	//Levanto el Config
	Config_CPU *conf_CPU = malloc(sizeof(Config_CPU));
	get_config_CPU(conf_CPU);
	log_debug(log_CPU,"IP_KERNEL:%s|PUERTO_KERNEL:%d|IP_MSP:%s|PUERTO_MSP:%d|RETARDO:%d",
			conf_CPU->IP_KERNEL,conf_CPU->PUERTO_KERNEL,conf_CPU->IP_MSP,conf_CPU->PUERTO_MSP,conf_CPU->RETARDO);
	//Armo las conexiones
	struct t_conection *conexion_Kernel = malloc(sizeof(struct t_conection));
	strcpy(conexion_Kernel->ip,conf_CPU->IP_KERNEL);
	conexion_Kernel->puerto = conf_CPU->PUERTO_KERNEL;
	struct t_conection *conexion_MSP = malloc(sizeof(struct t_conection));
	strcpy(conexion_MSP->ip,conf_CPU->IP_MSP);
	conexion_MSP->puerto = conf_CPU->PUERTO_MSP;

	//Obtengo los Socket_File_Descriptor
	sock_fd_Kernel = new_connection(conexion_Kernel);
	sock_fd_MSP = new_connection(conexion_MSP);
	log_debug(log_CPU,"Testeo Conexion al Kernel");

	//Testeo que la conexion no falle
	if (sock_fd_Kernel == -1)
	{
		log_error(log_CPU,"Fallo la conexion al Kernel");
		close(sock_fd_Kernel);
		return EXIT_FAILURE;
	}

  	log_debug(log_CPU,"Testeo Conexion a la MSP");
	if (sock_fd_MSP == -1)
	{
		log_error(log_CPU,"Fallo la conexion a la MSP");
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		return EXIT_FAILURE;
	}

	//Buffers de envio y recepcion
	t_header paquete_envio_MSP;
	t_header paquete_envio_Kernel;
	t_header paquete_recibido_Kernel;

	//Handshake con la MSP
	paquete_envio_MSP.id = 450;// Uso el 450 como un handshake para notificar que soy una CPU
	paquete_envio_MSP.size = 0;
	if (enviar_paquete(sock_fd_MSP,paquete_envio_MSP) < 0)
	{
		log_warning(log_CPU,"Fallo el Handshake");
		log_error(log_CPU,"Se cerro la conexion con la MSP");
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		return EXIT_FAILURE;
	}
	log_debug(log_CPU,"Se ha conectado a la MSP");

	//Handshake con el Kernel
	paquete_envio_Kernel.id = 200;// Uso el 200 como un handshake para notificar que soy una CPU
	paquete_envio_Kernel.size = 0;
	if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
	{
		log_warning(log_CPU,"Fallo el Handshake");
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		return EXIT_FAILURE;
	}
	log_debug(log_CPU,"Se ha conectado al Kernel");

	t_hilo HILO_EN_CPU;	//Tengo otra variable global que guarda los REGISTROS de la CPU
	SYSTEMCALL.puntero_instruccion_syscall = 0;

	//guardo_pid_syscall = 0;
/*
 * |-----------------------------------------------------------------------------------|
 * |--------------------------Aqui inicia la ejecucion de la CPU-----------------------|
 * |-----------------------------------------------------------------------------------|
*/

	while(1)	//Inicio de While principal de la CPU
	{

		if (recibir_paquete(sock_fd_Kernel,&paquete_recibido_Kernel) < 0)
		{
			log_error(log_CPU,"Se cerro la conexion del Kernel");
			close(sock_fd_Kernel);
			close(sock_fd_MSP);
			return EXIT_FAILURE;
			//break;
		}

		if (paquete_recibido_Kernel.id == 201)	//Una vez recibido el TCB, inicio la ejecucion de los quantums
		{
			//Debo deserializar el TCB recibido y cargarlo en la CPU -> Uso funciones de panel.h y cpu.h
			HILO_EN_CPU = deserializar_t_hilo(paquete_recibido_Kernel);
			//Cargo los registros de la CPU una vez recibido el QUANTUM
			carga_Registros_CPU(HILO_EN_CPU);
			//
			if (recibir_paquete(sock_fd_Kernel,&paquete_recibido_Kernel) < 0)
			{
				close(sock_fd_Kernel);
				close(sock_fd_MSP);
				return EXIT_FAILURE;
			}
			if (paquete_recibido_Kernel.id == 203)
			{
				//Fijarse que este valor venga bien
				memcpy(&QUANTUM,paquete_recibido_Kernel.data,sizeof(uint32_t));

				if (QUANTUM <= 0)	//En caso de que llege un valor erroneo del QUANTUM
				{
					QUANTUM = 0;
					FLAG_TCB_OUT = 0;
				}
			}
			//
			if(HILO_EN_CPU.kernel_mode == 1)
			{
				//
				log_debug(log_CPU_ESO,"Recibido->PID:%d|TID:%d(Kernel Mode = 1)",HILO_EN_CPU.pid,HILO_EN_CPU.tid);
				comienzo_ejecucion(&HILO_EN_CPU,QUANTUM);
				//
			}
			else
			{
				//
				log_debug(log_CPU_ESO,"Recibido->PID:%d|TID:%d",HILO_EN_CPU.pid,HILO_EN_CPU.tid);
				comienzo_ejecucion(&HILO_EN_CPU,QUANTUM);
				//
			}
			//
			//
			//
			//
			while(CONTADOR_QUANTUM < QUANTUM||HILO_EN_CPU.kernel_mode==1)	//El "OR" le permite al HILO KM ejecutar todo lo que quiera
			{
				if(HILO_EN_CPU.kernel_mode == 1)
				{
					log_debug(log_CPU_ESO,"Ejecuto Instruccion->Quantum_Total:Infinito->Usado:%d",CONTADOR_QUANTUM+1);
				}
				else
				{
					log_debug(log_CPU_ESO,"Ejecuto Instruccion->Quantum_Total:%d->Usado:%d",QUANTUM,CONTADOR_QUANTUM+1);
				}
				//****************************************************************************************************
				//*****************************Ejecucion de CPU ******************************************************
				//****************************************************************************************************
				FUNCION_ESO_PRINCIPAL();
				//
				print_Registros_CPU();		//-> Print de los registros para control
				//
				cambio_registros(REGISTROS_CPU);
				//
				//
				//Conexion con Kernel <-> en Caso de devolver alguno de los id de error se quita el hilo de la CPU
				//
				paquete_envio_Kernel.id = 270;
				paquete_envio_Kernel.size = 0;
				if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
				{
					log_error(log_CPU,"Se cerro la conexion del Kernel");
					close(sock_fd_Kernel);
					close(sock_fd_MSP);
					return EXIT_FAILURE;
				}
				if (recibir_paquete(sock_fd_Kernel,&paquete_recibido_Kernel) < 0)
				{
					log_error(log_CPU,"Se cerro la conexion del Kernel");
					close(sock_fd_Kernel);
					close(sock_fd_MSP);
					return EXIT_FAILURE;
				}
				if (paquete_recibido_Kernel.id == 271)
				{
					//No hago nada
				}
				if (paquete_recibido_Kernel.id == 272)
				{
					//Fallo algo en el medio -> Expropio la CPU
					if (REGISTROS_CPU.K == 1)
					{
						//Estaba el hilo de Kernel
						FLAG_TCB_OUT = 2;	//En fin de system call handleo este error
					}
					else
					{
						//Hilo comun
						FLAG_TCB_OUT = 10;
					}
				}
				//
				//Aumento el Quantum
				//
				CONTADOR_QUANTUM++;
				usleep(conf_CPU->RETARDO);	//Retardo de la CPU
				if (FLAG_TCB_OUT >= 1)	//SALE POR ERROR/FIN DE HILO
				{
					if(REGISTROS_CPU.K == 1 && (FLAG_TCB_OUT == 4 || FLAG_TCB_OUT == 5 || FLAG_TCB_OUT == 6 ||
							FLAG_TCB_OUT == 8 || FLAG_TCB_OUT == 9) )
					{
						FLAG_TCB_OUT = 12;
						break;
					}
					break;
				}
			}//Fin de ejecucion de Quantum

			/*
			 * Uso un valor para definir las distintos comportamientos de las instrucciones enviando el TCB
			 * con diferentes ID en el header para identificar lo ocurrido
			 */
			//
			HILO_EN_CPU = descarga_Registros_CPU();	//Bajo lo que hay en los registros
			//
			paquete_envio_Kernel = serializar_t_hilo(HILO_EN_CPU);//Serializo el Hilo que estaba en la CPU para enviarlo al Kernel
			log_debug(log_CPU_ESO,"PID:%d|TID:%d -> Sale de CPU",HILO_EN_CPU.pid,HILO_EN_CPU.tid);
			switch(FLAG_TCB_OUT)
			{
				case 0:	//Fin de QUANTUM
				{
					paquete_envio_Kernel.id = 204;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Fin de QUANTUM");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 1:	//Se llama a una SYSTEM CALL
				{
					paquete_envio_Kernel.id = 205;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}

					paquete_envio_Kernel.id = 250;
					paquete_envio_Kernel.size = sizeof(syscall_p);
					paquete_envio_Kernel.data = malloc(paquete_envio_Kernel.size);
					memcpy(paquete_envio_Kernel.data,&SYSTEMCALL,paquete_envio_Kernel.size);

					if(enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					free(paquete_envio_Kernel.data);

					//Guardo el PID del Syscall -> Podria guardar el TID tambien
					//
					guardo_pid_syscall = REGISTROS_CPU.I;
					//
					log_debug(log_CPU_ESO,"Se llama a una SYSTEM CALL");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 2:	//Fin de ejecucion de Instruccion XXXX => FIN DE HILO
				{
					//Envio luego de enviar el hilo_tcb -> Posicion de la system call
					//-> con un struct para evitar problemas

					paquete_envio_Kernel.id = 206;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Fin de ejecucion de Instruccion XXXX => FIN DE HILO");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 3:	//Se llamo a una FUNCION PROTEGIDA en Modo Usuario (KM = 0)
				{
					paquete_envio_Kernel.id = 207;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Se llamo a una FUNCION PROTEGIDA en Modo Usuario (KM = 0)");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 4:	//Error -> Instruccion Inexistente
				{
					paquete_envio_Kernel.id = 208;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Error -> Instruccion Inexistente");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 5:	//Error -> Memory Overload
				{
					paquete_envio_Kernel.id = 209;

					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Error -> Memory Overload");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 6:	//Error -> Segmentation Fault
				{
					paquete_envio_Kernel.id = 210;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Error -> Segmentation Fault");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 7: //Termine de ejecutar el Hilo de Kernel-> Fin de System Call
				{
					paquete_envio_Kernel.id = 220;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Sale el Hilo del Kernel");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 8:	//Fallo por desconexion de MSP
				{
					paquete_envio_Kernel.id = 221;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Falla de Conexion con MSP");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 9:	//Fallo por division por cero
				{
					paquete_envio_Kernel.id = 222;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Falla de division por Cero");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 10:	//Error en Kernel ->Debo expropiar CPU
				{
					paquete_envio_Kernel.id = 273;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Error en Kernel ->Debo expropiar CPU");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 11:	//Error en Kernel ->Debo expropiar CPU (Kernel Mode = 1)
				{
					paquete_envio_Kernel.id = 274;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Error en Kernel ->Debo expropiar CPU (Kernel Mode = 1)");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				case 12:	//Error en Acceso a Memoria por el Hilo del kernel -> Abortar el kernel
				{
					paquete_envio_Kernel.id = 290;
					if (enviar_paquete(sock_fd_Kernel,paquete_envio_Kernel) < 0)
					{
						log_error(log_CPU,"Se cerro la conexion del Kernel");
						close(sock_fd_Kernel);
						close(sock_fd_MSP);
						return EXIT_FAILURE;
					}
					log_debug(log_CPU_ESO,"Error en Acceso a Memoria del Hilo Kernel -> Aborto el Kernel");
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				default:
				{
					FLAG_TCB_OUT = 0;
					//
					fin_ejecucion();
					//
					break;
				}
				free(paquete_envio_Kernel.data);
			}

		}	//IF de recepcion de TCB

		CONTADOR_QUANTUM = 0;	//Reinicio el contador de Quantum
	}	//Fin de Loop principal

	//Cierro los sockets
	close(sock_fd_Kernel);
	close(sock_fd_MSP);
	//Libero conf_CPU
	free(conf_CPU);
	log_debug(log_CPU,"Finalizacion de CPU");

	return EXIT_SUCCESS;
}

void carga_Registros_CPU (t_hilo AUX_HILO_EN_CPU)
{
	REGISTROS_CPU.registros_programacion[0] = AUX_HILO_EN_CPU.registros[0];
	REGISTROS_CPU.registros_programacion[1] = AUX_HILO_EN_CPU.registros[1];
	REGISTROS_CPU.registros_programacion[2] = AUX_HILO_EN_CPU.registros[2];
	REGISTROS_CPU.registros_programacion[3] = AUX_HILO_EN_CPU.registros[3];
	REGISTROS_CPU.registros_programacion[4] = AUX_HILO_EN_CPU.registros[4];
	REGISTROS_CPU.I = AUX_HILO_EN_CPU.pid;
	REGISTROS_CPU.K = AUX_HILO_EN_CPU.kernel_mode;
	REGISTROS_CPU.M = AUX_HILO_EN_CPU.segmento_codigo;
	REGISTROS_CPU.P = AUX_HILO_EN_CPU.puntero_instruccion;
	REGISTROS_CPU.S = AUX_HILO_EN_CPU.cursor_stack;
	REGISTROS_CPU.X = AUX_HILO_EN_CPU.base_stack;
	//Sino no guarda estos valores en ningun lado y devuelve fruta
	global_tcb_TID = AUX_HILO_EN_CPU.tid;
	global_tcb_cola = AUX_HILO_EN_CPU.cola;
	//
	return;
}
t_hilo descarga_Registros_CPU ()
{
	t_hilo AUX_HILO_EN_CPU;

	//Sino no guarda estos valores en ningun lado y devuelve fruta
	AUX_HILO_EN_CPU.cola = global_tcb_cola ;
	AUX_HILO_EN_CPU.tid = global_tcb_TID;
	//
	AUX_HILO_EN_CPU.registros[0] = REGISTROS_CPU.registros_programacion[0];
	AUX_HILO_EN_CPU.registros[1] = REGISTROS_CPU.registros_programacion[1];
	AUX_HILO_EN_CPU.registros[2] = REGISTROS_CPU.registros_programacion[2];
	AUX_HILO_EN_CPU.registros[3] = REGISTROS_CPU.registros_programacion[3];
	AUX_HILO_EN_CPU.registros[4] = REGISTROS_CPU.registros_programacion[4];
	AUX_HILO_EN_CPU.pid = REGISTROS_CPU.I;
	AUX_HILO_EN_CPU.kernel_mode = REGISTROS_CPU.K ;
	AUX_HILO_EN_CPU.segmento_codigo = REGISTROS_CPU.M;
	AUX_HILO_EN_CPU.puntero_instruccion = REGISTROS_CPU.P;
	AUX_HILO_EN_CPU.cursor_stack = REGISTROS_CPU.S;
	AUX_HILO_EN_CPU.base_stack = REGISTROS_CPU.X;
	return AUX_HILO_EN_CPU;
}


void get_config_CPU (Config_CPU *config)
{
	t_config *fcon = config_create(Path_Config_CPU);
	Config_CPU *aux = config;
	aux->IP_KERNEL = config_get_string_value(fcon,"IP_KERNEL");
	aux->IP_MSP = config_get_string_value(fcon,"IP_MSP");
	aux->PUERTO_MSP = config_get_int_value(fcon,"PUERTO_MSP");
	aux->PUERTO_KERNEL = config_get_int_value(fcon,"PUERTO_KERNEL");
	aux->RETARDO = config_get_int_value(fcon,"RETARDO");
	return;
}

void sig_handler(int signo)
{
	if (signo == SIGUSR1)
	{
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		exit(1);
	}
	if(signo == SIGUSR2)
	{
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		exit(1);
	}
	if(signo == SIGINT)
	{
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		exit(1);
	}
	if(signo == SIGTERM)
	{
		close(sock_fd_Kernel);
		close(sock_fd_MSP);
		exit(1);
	}
}


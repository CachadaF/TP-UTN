#include"Kernel.h"

//Declaracion de variables globales
#define Path_log_Kernel "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_Kernel/Funciones_EpollYSockets/Log_Kernel.log"
#define Path_Config_Kernel "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_Kernel/Funciones_EpollYSockets/Config_Kernel"
#define Path_log_Planificador "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_Kernel/Funciones_EpollYSockets/Log_Planificador.log"
#define Path_log_Loader "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_Kernel/Funciones_EpollYSockets/Log_Loader.log"
//Logs
t_log *Log_Kernel_Temporal;
t_log *Log_Kernel_Planificador;
t_log *Log_Kernel_Loader;
//Sockets Fd
int32_t sock_fd_MSP;
//Debo crear un log por cada hilo
Config_Kernel *conf_kernel;
//Listas
t_list* lista_hilos_terminados;		//Lista usada para JOIN
t_list* lista_wake_hilos;			//Lista usada para WAKE/BLOK -> Semaforos de los hilos
t_list* lista_handle_hilos_finalizados; //Lista encargada de finalizar los hilos hijos que se encuentren en Exec/Block
//Variable global
uint32_t contador_procesos = 0;
int32_t PUERTO_CONFIG;
int32_t QUANTUM;
int32_t SIZE_STACK;
//Colas del planificador
t_queue* cola_Ready;
t_queue* cola_Block;
t_queue* cola_Block_Recurso;
t_queue* cola_Block_Join;
t_queue* cola_Exit;
t_queue* cola_Exec;
t_queue* cola_New;
t_queue* cola_CPU_libres;
//t_queue* cola_Consolas;
//Mutex de las colas
pthread_mutex_t mutex_cola_Ready;
pthread_mutex_t mutex_cola_Block;
pthread_mutex_t mutex_cola_Block_Recurso;
pthread_mutex_t mutex_cola_Block_Join;
pthread_mutex_t mutex_cola_Exit;
pthread_mutex_t mutex_cola_Exec;
pthread_mutex_t mutex_cola_New;
pthread_mutex_t mutex_cola_CPU_libres;
pthread_mutex_t mutex_SYSCALL;
pthread_mutex_t mutex_lista_hilos_terminados;
pthread_mutex_t mutex_lista_wake_hilos;
pthread_mutex_t mutex_lista_handle_hilos_finalizados;
//Semaforos Contadores
sem_t sem_cola_New;
sem_t sem_cola_Ready;
sem_t sem_cola_Block;
sem_t sem_cola_Exit;

int main(void)
{
	//Levanto los distintos logs a usar en el Kernel
	Log_Kernel_Temporal = log_create(Path_log_Kernel,"Log_Kernel.log",true,LOG_LEVEL_DEBUG);

	if (Log_Kernel_Temporal == NULL)
	{
		printf("Fallo al abrir Log->Finalizacion de Programa\n");
		return EXIT_FAILURE;
	}

	Log_Kernel_Planificador = log_create(Path_log_Planificador,"Log_Planificador.log",false,LOG_LEVEL_DEBUG);

	if (Log_Kernel_Planificador == NULL)
	{
		printf("Fallo al abrir Log->Finalizacion de Programa\n");
		return EXIT_FAILURE;
	}

	Log_Kernel_Loader = log_create(Path_log_Loader,"Log_Loader.log",false,LOG_LEVEL_DEBUG);

	if (Log_Kernel_Loader == NULL)
	{
		printf("Fallo al abrir Log->Finalizacion de Programa\n");
		return EXIT_FAILURE;
	}
	//
	//Obtengo el Path del Kernel
	//
	char Kernel_Path_Folder[1024];
	t_tipo_proceso tipo_proceso = KERNEL;
	if(getcwd(Kernel_Path_Folder, sizeof(Kernel_Path_Folder)) == NULL)
	{
		log_error(Log_Kernel_Temporal,"ERROR->No se pudo obtener el Path del Kernel\n");
		return EXIT_FAILURE;
	}
	log_debug(Log_Kernel_Temporal,"Inicio de Proceso Kernel->Path:%s",Kernel_Path_Folder);
	//
	inicializar_panel(tipo_proceso,Kernel_Path_Folder);
	//


	//Levanto el config
	conf_kernel = malloc(sizeof(Config_Kernel));
	get_config_Kernel(conf_kernel);
	log_debug(Log_Kernel_Temporal,"PUERTO:%d|IP_MSP:%s|PUERTO_MSP:%d|QUANTUM:%d|SYSCALLS:%s\n",conf_kernel->PUERTO,conf_kernel->IP_MSP,conf_kernel->PUERTO_MSP,conf_kernel->QUANTUM,conf_kernel->SYSCALLS);
	PUERTO_CONFIG = conf_kernel->PUERTO;
	QUANTUM = conf_kernel->QUANTUM;
	SIZE_STACK = conf_kernel->SIZESTACK;

	//Creo las colas
	cola_Block = NULL;
	cola_Block_Recurso = NULL;
	cola_Block_Join = NULL;
	cola_CPU_libres = NULL;
	cola_Exec = NULL;
	cola_Exit = NULL;
	cola_New = NULL;
	cola_Ready = NULL;
	//cola_Consolas = NULL;
	cola_Block = queue_create();
	cola_Block_Recurso = queue_create();
	cola_Block_Join = queue_create();
	cola_CPU_libres = queue_create();
	cola_Exec = queue_create();
	cola_Exit = queue_create();
	cola_New = queue_create();
	cola_Ready = queue_create();
	//cola_Consolas = queue_create();
	//Creo las listas
	lista_hilos_terminados = NULL;
	lista_hilos_terminados = list_create();
	lista_wake_hilos = NULL;
	lista_wake_hilos = list_create();
	lista_handle_hilos_finalizados = NULL;
	lista_handle_hilos_finalizados = list_create();
	//Inicializo los semaforos en 0
	sem_init(&sem_cola_New,0,0);
	sem_init(&sem_cola_Ready,0,0);
	sem_init(&sem_cola_Block,0,0); // Deberia empezar en 0 ???
	sem_init(&sem_cola_Exit,0,0);

	//Handshake con MSP
	struct t_conection *conexion_MSP = malloc(sizeof(struct t_conection));
	strcpy(conexion_MSP->ip,conf_kernel->IP_MSP);
	conexion_MSP->puerto = conf_kernel->PUERTO_MSP;
	sock_fd_MSP = new_connection(conexion_MSP);

	t_header paquete_envio_MSP;

	paquete_envio_MSP.id = 400;// Uso el 450 como un handshake para notificar que soy una CPU
	paquete_envio_MSP.size = 0;
	if (enviar_paquete(sock_fd_MSP,paquete_envio_MSP) < 0)
	{
		log_debug(Log_Kernel_Temporal,"Fallo el Handshake\n");
		log_debug(Log_Kernel_Temporal,"Se cerro la conexion con la MSP\n");
		return EXIT_FAILURE;
	}
	log_debug(Log_Kernel_Temporal,"Se ha conectado a la MSP\n");

	//INICIO EL BOOT-> CARGO EN MEMORIA LAS SYSTEM CALLS

	int32_t boot_errors = Boot_Kernel();
	if ( boot_errors == -1)
	{
		log_debug(Log_Kernel_Temporal,"Fallo de carga de System Calls en MSP por conexion cerrada\nSe procede a abortar el Kernel\n");
		return EXIT_FAILURE;
	}
	if ( boot_errors == 1)
	{
		log_debug(Log_Kernel_Temporal,"Fallo de carga de System Calls en MSP por memory overload\nSe procede a abortar el Kernel\n");
		return EXIT_FAILURE;
	}

	//LANZO LOS HILOS DEL LOADER Y PLANIFICADOR
	pthread_t thread_Loader;
	pthread_t thread_Planificador;
	log_debug(Log_Kernel_Temporal,"Lanzo el Hilo_Loader");
	pthread_create(&thread_Loader,NULL,hilo_Loader,NULL);
	log_debug(Log_Kernel_Temporal,"Lanzo el Hilo_Planificador");
	pthread_create(&thread_Planificador,NULL,hilo_Planificador,NULL);
	pthread_join(thread_Loader,NULL);
	pthread_join(thread_Planificador,NULL);

	//Destruyo los Semaforos Mutex y Contadores
	sem_destroy(&sem_cola_New);
	sem_destroy(&sem_cola_Ready);
	sem_destroy(&sem_cola_Block);
	sem_destroy(&sem_cola_Exit);
	pthread_mutex_destroy(&mutex_cola_Block);
	pthread_mutex_destroy(&mutex_cola_Block_Recurso);
	pthread_mutex_destroy(&mutex_cola_Block_Join);
	pthread_mutex_destroy(&mutex_cola_CPU_libres);
	pthread_mutex_destroy(&mutex_cola_Exec);
	pthread_mutex_destroy(&mutex_cola_Exit);
	pthread_mutex_destroy(&mutex_cola_New);
	pthread_mutex_destroy(&mutex_cola_Ready);
	pthread_mutex_destroy(&mutex_lista_hilos_terminados);
	pthread_mutex_destroy(&mutex_lista_wake_hilos);
	pthread_mutex_destroy(&mutex_lista_handle_hilos_finalizados);
	pthread_mutex_destroy(&mutex_SYSCALL);

	//Libero todas las colas y el config
	log_debug(Log_Kernel_Temporal,"Libero la Memoria\nFinalizo el Proceso Kernel\n");
	queue_destroy_and_destroy_elements(cola_Block,free);
	queue_destroy_and_destroy_elements(cola_Block_Recurso,free);
	queue_destroy_and_destroy_elements(cola_Block_Join,free);
	queue_destroy_and_destroy_elements(cola_Exec,free);
	queue_destroy_and_destroy_elements(cola_Exit,free);
	queue_destroy_and_destroy_elements(cola_New,free);
	queue_destroy_and_destroy_elements(cola_Ready,free);
	queue_destroy(cola_CPU_libres);
	//queue_destroy(cola_Consolas);
	list_destroy_and_destroy_elements(lista_hilos_terminados,free);
	list_destroy_and_destroy_elements(lista_wake_hilos,free);
	list_destroy_and_destroy_elements(lista_handle_hilos_finalizados,free);
	free(conf_kernel);

	return EXIT_SUCCESS;
}

int32_t Boot_Kernel ()
{

	char* Path_System_Calls = conf_kernel->SYSCALLS;

	FILE *fp = fopen(Path_System_Calls,"r");

	log_debug(Log_Kernel_Temporal,"Levanto el File de System Calls del Kernel");

	if (fp == NULL)
	{
		log_debug(Log_Kernel_Temporal,"Fallo al levantar el File de System Calls\n");
		return -1;
	}

	int32_t size_SC = calcularTamFile(fp);
	char* SC = caracteresFile(fp);
	fclose(fp);

	t_hilo_proceso *proceso_hilo_kernel = malloc(sizeof(t_hilo_proceso));
	//Se crea al toque
	proceso_hilo_kernel->hilo.pid = contador_procesos;
	//Aumento el contador de PID
	contador_procesos += 1;
	proceso_hilo_kernel->hilo.tid = 0;
	proceso_hilo_kernel->hilo.kernel_mode = 1;
	proceso_hilo_kernel->hilo.segmento_codigo_size = size_SC;
	proceso_hilo_kernel->socket_Consola = 0;
	proceso_hilo_kernel->hilo.cola = BLOCK;	//No se si sirva de algo usando colas

	/*
	 * CONEXION CON LA MSP
	 */
	t_header envio_MSP;
	t_header recep_MSP;
	//Aca va el envio para crear el 1° segmento -> Memoria
	t_crear_segmento segmento_a_crear;
	dir_log dir;
	segmento_a_crear.PID = proceso_hilo_kernel->hilo.pid;
	segmento_a_crear.Size = size_SC;
	envio_MSP = serializar_t_crear_segmento(segmento_a_crear);
	envio_MSP.id = 401;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_debug(Log_Kernel_Temporal,"Se cerro conexion con MSP");
		return -1;
	}
	free(envio_MSP.data);
	if (recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
	{
		log_debug(Log_Kernel_Temporal,"Se cerro conexion con MSP");
		return -1;
	}
	if (recep_MSP.id == 402)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		memcpy(&dir,recep_MSP.data,recep_MSP.size);
		proceso_hilo_kernel->hilo.segmento_codigo = dir.direccion_logica;
		log_debug(Log_Kernel_Temporal,"Segmento de Codigo creado Correctamente->System Calls");
	}
	if (recep_MSP.id == 403)
	{
		//Memory Overload -> Cierro conexion con esa Consola
		return 1;
	}
	//Envio lo que debo guardar
	t_escritura_memoria escritura_segmento;
	escritura_segmento.PID = proceso_hilo_kernel->hilo.pid;
	escritura_segmento.Direccion_Logica = 0;
	escritura_segmento.Size = size_SC;
	escritura_segmento.Bytes_A_Escribir = malloc(size_SC);
	memcpy(&escritura_segmento.Direccion_Logica,&dir.direccion_logica,sizeof(uint32_t));
	memcpy(escritura_segmento.Bytes_A_Escribir,SC,size_SC);

	envio_MSP = serializar_t_escritura_memoria(escritura_segmento);
	envio_MSP.id = 404;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_debug(Log_Kernel_Temporal,"Se cerro conexion con MSP");
		return -1;
	}
	free(escritura_segmento.Bytes_A_Escribir);
	free(envio_MSP.data);

	if(recibir_paquete(sock_fd_MSP,&recep_MSP) < 0 )
	{
		log_debug(Log_Kernel_Temporal,"Se cerro conexion con MSP");
		return 1;
	}

	if (recep_MSP.id == 409)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		log_debug(Log_Kernel_Temporal,"Segmento de Codigo escrito Correctamente->System Calls");
	}
	if (recep_MSP.id == 407)
	{
		//Segmentation Fault
		return 1;
	}

	//Aca va el envio para crear el 2° segmento -> Stack -> ACA NO GUARDO NADA
	t_crear_segmento seg_stack;
	seg_stack.PID = proceso_hilo_kernel->hilo.pid;
	seg_stack.Size = SIZE_STACK;
	envio_MSP = serializar_t_crear_segmento(seg_stack);
	envio_MSP.id = 401;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_debug(Log_Kernel_Temporal,"Se cerro conexion con MSP");
		return -1;
	}
	free(envio_MSP.data);
	if (recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
	{
		log_debug(Log_Kernel_Temporal,"Se cerro conexion con MSP");
		return -1;
	}
	if (recep_MSP.id == 402)
	{
		//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		memcpy(&dir,recep_MSP.data,recep_MSP.size);
		proceso_hilo_kernel->hilo.base_stack = proceso_hilo_kernel->hilo.cursor_stack = dir.direccion_logica;
		log_debug(Log_Kernel_Temporal,"Segmento de Stack creado Correctamente->System Calls");
	}
	if (recep_MSP.id == 403)
	{
		//Memory Overload -> Cierro conexion con esa Consola
		return 1;
	}
	//Inicializo registros/PC/Base Stack/Cursor Stack
	proceso_hilo_kernel->hilo.registros[0] = 0;
	proceso_hilo_kernel->hilo.registros[1] = 0;
	proceso_hilo_kernel->hilo.registros[2] = 0;
	proceso_hilo_kernel->hilo.registros[3] = 0;
	proceso_hilo_kernel->hilo.registros[4] = 0;
	proceso_hilo_kernel->hilo.puntero_instruccion = 0;

	log_debug(Log_Kernel_Temporal,"Se creo el TCB(KM = 1)->P:%d|T:%d\n",proceso_hilo_kernel->hilo.pid,
			proceso_hilo_kernel->hilo.tid);

	//ENCOLO EN BLOCK EL TCB KERNEL -> SE LLAMARA EN CASO DE EJECUCION DE INSTRUCCIONES PROTEGIDAS
	agregar_en_cola(cola_Block,proceso_hilo_kernel,&mutex_cola_Block);
	return 0;
}

void get_config_Kernel (Config_Kernel *config)
{
	t_config *fcon = config_create(Path_Config_Kernel);

	Config_Kernel *aux = config;

	aux->PUERTO = config_get_int_value(fcon,"PUERTO");
	aux->IP_MSP = config_get_string_value(fcon,"IP_MSP");
	aux->PUERTO_MSP = config_get_int_value(fcon,"PUERTO_MSP");
	aux->QUANTUM = config_get_int_value(fcon,"QUANTUM");
	aux->SYSCALLS = config_get_string_value(fcon,"SYSCALLS");
	aux->SIZESTACK = config_get_int_value(fcon,"SIZESTACK");

	return;
}

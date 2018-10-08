#ifndef FUNCIONES_HILOS_H_
#define FUNCIONES_HILOS_H_

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<stdint.h>
#include<pthread.h>
#include<semaphore.h>
#include"../Funciones_EpollYSockets/LecturaYEscritura.h"
#include"../Funciones_EpollYSockets/Sockets_Connection.h"
#include"../Funciones_EpollYSockets/epoll.h"
#include"../panel/kernel.h"
#include"../panel/panel.h"
#include"../Kernel.h"
//Commons Libraries
#include<commons/collections/node.h>
#include<commons/collections/queue.h>
#include<commons/collections/list.h>
#include<commons/config.h>
#include<commons/log.h>


//Estructuras
typedef enum { FIN_QUANTUM,FIN_HILO,FIN_PROCESO,FALLO_CONEXION_CPU,FALLO_CONEXION_CONSOLA,FALLO_CONEXION_MSP
				,FALLO_MEMORY_OVERLOAD,FALLO_SEGMENTATION_FAULT,FALLO_INSTRUCCION,FALLO_DIVISION_CERO
				,FALLO_HILO_FIN,FALLO_FIN_HILO_PADRE,SYSCALL} estado_exit;

typedef struct{ int32_t direccion_logica;} dir_log;

typedef struct{uint32_t puntero_instruccion_syscall;}syscall_p;

typedef struct{uint32_t pid_hilo_finalizar;}t_pid_hilo_finalizar;

typedef struct
{
	uint32_t hilo;
	uint32_t proceso;
}t_fin_hilo;

typedef struct { int32_t nro_semaforo; }t_sem_hilo;

typedef struct	{
	int32_t socket_CPU;
	int32_t socket_Consola;
	t_hilo hilo;
	estado_exit estado_salida;
	int32_t hilo_join;
	int32_t block;
	uint32_t syscall_llamada;
}t_hilo_proceso;

typedef struct {
	int32_t PUERTO;
	char* IP_MSP;
	int32_t PUERTO_MSP;
	int32_t QUANTUM;
	char* SYSCALLS;
	int32_t SIZESTACK;
}Config_Kernel;

typedef struct{
	uint32_t PID;
	uint32_t Direccion_Logica;
	uint32_t Size;
} t_solicitud_memoria;

typedef struct{
	uint32_t PID;
	uint32_t Direccion_Logica;
	uint32_t Size;
	void*	 Bytes_A_Escribir;
} t_escritura_memoria;

typedef struct{
	uint32_t PID;
	uint32_t Size;
} t_crear_segmento;

typedef struct{
	uint32_t PID;
	uint32_t Direccion_Logica;
} t_destruir_segmento;

typedef struct {
	uint32_t dir_logica;
}t_direcciones_logicas;

t_header serializar_t_hilo (t_hilo tcb);
t_hilo deserializar_t_hilo (t_header header);
t_hilo_proceso *dameProcesoHilo (t_queue *cola, int32_t socket_fd,pthread_mutex_t* mutex_cola);
void agregar_en_cola(t_queue* cola_en_donde_agregar,void* que_agregar,pthread_mutex_t* mutex_cola);
void* quitar_de_cola(t_queue* cola_en_donde_agregar,pthread_mutex_t* mutex_cola);
int32_t size_de_cola(t_queue* cola_en_donde_agregar,pthread_mutex_t* mutex_cola);
int32_t calcularTamFile(FILE *fp);
char* caracteresFile(FILE *fp);
int32_t esta_en_cola(t_queue* cola_en_donde_buscar,t_hilo_proceso* que_buscar,pthread_mutex_t* mutex_cola);
void* esta_en_cola_Hilo_KM(t_queue *cola_en_que_buscar,pthread_mutex_t *mutex_de_cola);
int32_t quitaSocketfdColaConexiones (int32_t socket_fd,t_queue* cola,pthread_mutex_t* mutex_cola);
t_header serializar_t_solicitud_memoria(t_solicitud_memoria aux_sol);
t_escritura_memoria deserializar_t_escritura_memoria (t_header header);
t_header serializar_t_escritura_memoria(t_escritura_memoria aux_esc);
t_solicitud_memoria deserializar_t_solicitud_memoria (t_header header);
t_header serializar_t_crear_segmento (t_crear_segmento aux_creacion);
t_crear_segmento deserializar_t_crear_segmento (t_header header);
t_header serializar_t_destruir_segmento (t_destruir_segmento aux_destruccion);
t_destruir_segmento deserializar_t_destruir_segmento (t_header header);
void imprimir_elementos_cola(t_queue *cola_a_imprimir, pthread_mutex_t *mutex_cola_a_imprimir);
int32_t damePIDporSockFDConsola (t_queue *cola, int32_t socket_fd_Consola,pthread_mutex_t *mutex_cola);
t_hilo_proceso *dameProcesoHiloporSockFDConsola (t_queue *cola, int32_t socket_fd_Consola,pthread_mutex_t *mutex_cola);
void marcaEstadoSalidaPorPID (t_queue *cola, int32_t PID_a_marcar,pthread_mutex_t *mutex_cola,estado_exit estado_salida_marcar);
void imprime_t_Hilos_PorColaMutex(t_queue *cola,pthread_mutex_t *mutex_cola);

#endif /* FUNCIONES_HILOS_H_ */

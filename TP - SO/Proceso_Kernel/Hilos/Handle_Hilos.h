#ifndef HANDLE_HILOS_H_
#define HANDLE_HILOS_H_

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
#include"Funciones_Hilos.h"
#include"Hilo_Loader.h"

//Prototypes
void funcion_handle_hilos_finalizados (t_hilo_proceso *hilo_handlear, estado_exit estado_handlear);
int32_t cantidad_hilos_existentes (t_hilo_proceso *hilo_a_finalizar);
void mover_hilos_hijos_no_exec_exit(t_hilo_proceso *hilo_a_finalizar);
void agregar_a_lista_handle_hilos_finalizados_mutex(int32_t PID_Hilo);
int32_t esta_en_lista_handle_hilos_finalizados_PID(int32_t PID_hilo_buscar);
int32_t esta_en_cola_PID_l(t_queue* cola_en_donde_buscar,int32_t pid_buscar,pthread_mutex_t* mutex_cola);
void limpia_lista_handle_hilos_finalizados ();
void agregar_lista_join(int32_t pid_hilo_join,int32_t tid_hilo_join);
int32_t quita_por_PID_de_Cola (t_queue *cola, int32_t pid_a_quitar, pthread_mutex_t* mutex_cola);
void imprime_t_Hilos_de_Todas_Colas();
t_hilo_proceso *quitar_de_cola_block_coindice_syscallglobal (int32_t pid_a_quitar, int32_t tid_a_quitar);

#endif /* HANDLE_HILOS_H_ */

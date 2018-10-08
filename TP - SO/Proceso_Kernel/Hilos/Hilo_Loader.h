#ifndef HILO_LOADER_H_
#define HILO_LOADER_H_

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
#include"Handle_Hilos.h"

int32_t creacion_TCB (char* codigo_a_guardar_MSP,int32_t size_codigo_a_guardar_MSP,int32_t socket_consola);
void *hilo_Loader(void* argc);
int32_t duplicar_TCB (int32_t pc_hilo_nuevo);
int32_t ESO_system_call(t_hilo_proceso* hilo_proceso_sys_call,uint32_t puntero_a_syscall_a_usar);
int32_t fin_system_call(t_hilo_proceso *hilo_Kernel);
void agregar_lista_wake_hilos(int32_t semaforo_wake);
int32_t handle_desconexiones_CPUs(int32_t socket_fd_desconectado);
int32_t handle_desconexiones_Consolas(int32_t socket_fd_desconectado);
int32_t busca_cola_Exec_PID_en_ejecucion(int32_t socket_fd_cpu_a_buscar);
int32_t fin_system_call_fallo_hilo(t_hilo_proceso *hilo_Kernel);
int32_t existeHiloParaJoinear (int32_t PID_JOIN,int32_t TID_JOIN);

#endif /* HILO_LOADER_H_ */

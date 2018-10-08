#ifndef HILOS_PLANIFICADOR_H_
#define HILOS_PLANIFICADOR_H_

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
#include"Handle_Hilos.h"

void* hilo_Planificador(void* argc);
void* hilo_Planificador_New (void* argc);
void* hilo_Planificador_Exit(void* argc);
void* hilo_Planificador_Block(void* argc);
int32_t buscar_hilos_joineados_finalizados();
int32_t buscar_hilos_a_desbloquear_por_semaforo();


#endif /* HILOS_PLANIFICADOR_H_ */

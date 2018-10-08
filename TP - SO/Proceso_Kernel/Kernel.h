#ifndef KERNEL_H_
#define KERNEL_H_

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<pthread.h>
#include<semaphore.h>
#include"Funciones_EpollYSockets/LecturaYEscritura.h"
#include"Funciones_EpollYSockets/Sockets_Connection.h"
#include"Funciones_EpollYSockets/epoll.h"
#include"panel/kernel.h"
#include"panel/panel.h"
//Commons Libraries
#include<commons/collections/node.h>
#include<commons/collections/queue.h>
#include<commons/collections/list.h>
#include<commons/config.h>
#include<commons/log.h>
#include"Hilos/Funciones_Hilos.h"
#include"Hilos/Hilo_Loader.h"
#include"Hilos/Hilos_Planificador.h"



//Prototipos
void get_config_Kernel (Config_Kernel *config);
int32_t Boot_Kernel ();



#endif /* KERNEL_H_ */

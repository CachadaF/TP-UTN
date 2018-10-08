#ifndef PROC_CPU_H_
#define PROC_CPU_H_

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<commons/config.h>
#include<commons/log.h>
#include"Funciones_CPU/LecturaYEscritura.h"
#include"Funciones_CPU/Sockets_Connection.h"
#include"panel/cpu.h"
#include"panel/panel.h"
#include"Funciones_CPU/Funciones_ESO.h"
#include<signal.h>
#include<unistd.h>

//Prototipos
void get_config_CPU (Config_CPU *config);
void carga_Registros_CPU (t_hilo HILO_EN_CPU);
t_hilo descarga_Registros_CPU ();
void sig_handler(int signo);



#endif /* PROC_CPU_H_ */

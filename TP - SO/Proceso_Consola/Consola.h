#ifndef CONSOLA_H_
#define CONSOLA_H_

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<limits.h>
#include<commons/config.h>
#include<commons/log.h>
#include<commons/string.h>
#include"Funciones_Consola/LecturaYEscritura.h"
#include"Funciones_Consola/Sockets_Connection.h"
#include<signal.h>



//Estructuras

typedef struct {
	char* IP_KERNEL;
	int32_t PUERTO_KERNEL;
}Config_Consola;

//Prototipos
void get_config_Consola (Config_Consola *config);
int32_t calcularTamFile(FILE *fp);
char* caracteresFile(FILE *fp);
void sig_handler(int signo);


#endif /* CONSOLA_H_ */

#ifndef MSP_H_
#define MSP_H_

#include"LecturaYEscritura.h"
#include"Sockets_Connection.h"
#include<pthread.h>
#include<stdio.h>
#include<stdlib.h>
#include<stdint.h>
#include"commons/log.h"
#include"commons/collections/list.h"
#include"commons/collections/node.h"
#include"epoll.h"
#include"Funciones_MSP.h"
#include <sys/stat.h>
#include <sys/types.h>

//Estructuras
typedef struct{ int32_t direccion_logica;} dir_log;

typedef struct{
	uint32_t PID;
	uint32_t *DIR_INICIO;
	uint32_t SIZE;
} t_segmento;

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

//Prototipos
int32_t calcularTamFile(FILE *fp);
char* caracteresFile(FILE *fp);
void* hilo_Epoll(void* argc);
t_header serializar_t_solicitud_memoria(t_solicitud_memoria aux_sol);
t_escritura_memoria deserializar_t_escritura_memoria (t_header header);
t_header serializar_t_escritura_memoria(t_escritura_memoria aux_esc);
t_solicitud_memoria deserializar_t_solicitud_memoria (t_header header);
t_header serializar_t_crear_segmento (t_crear_segmento aux_creacion);
t_crear_segmento deserializar_t_crear_segmento (t_header header);
t_header serializar_t_destruir_segmento (t_destruir_segmento aux_destruccion);
t_destruir_segmento deserializar_t_destruir_segmento (t_header header);



#endif /* MSP_H_ */

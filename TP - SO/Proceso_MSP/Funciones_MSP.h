#ifndef FUNCIONES_MSP_H_
#define FUNCIONES_MSP_H_

#include <string.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <unistd.h>
#include <pthread.h>
#include <assert.h>
#include <string.h>
#include <math.h>
#include <commons/collections/list.h>
#include <commons/collections/queue.h>
#include <commons/config.h>
#include <commons/string.h>
#include <commons/log.h>
#include <commons/txt.h>
#include <stdlib.h>
#include "LecturaYEscritura.h"
#include "Sockets_Connection.h"
#include "epoll.h"

//Variables globales
int algoritmo;
t_config* config;
t_log * logs;
t_list* tabla_segmentos;
t_list* tabla_marcos;
int puerto;
char* sust_pags;
int cant_memoria, cant_swapp, cant_marcos;
void* memoria_principal;
int archivos_en_disco;

//Definicion de Estructuras

typedef struct {
	unsigned int segmento :12;
	unsigned int pagina :12;
	unsigned int offset :8;
} t_mem;

typedef struct {
	int PID;
	t_mem base_seg;
	long tamano;
	int* TP; // tabla de paginas, por cada posicion num de marco en el que se almacena,
			 //-1 en caso de no estar asignada, -2 en caso de estar en disco
	int cant_pags;
} TS;

typedef struct {
	int index;
	int PID;
	t_mem memoria;
	char bitUso;
	char bitMod;
	char bitPuntero;
}t_algoritmo;

//Prototipos
void inicializar_tabla_marcos();
t_algoritmo* agregar_marcos_algoritmos(int PID, t_mem direc, int* tam_tabla);
void* proceso_consola();
int inicializar_memoria(char* config);
int crearArchivosLog();
int leerArchivoConfiguracion(char *ruta_archivo);
void mostrar_tabla_marcos();
void mostrar_tabla_segmentos();
int mostrar_tabla_paginas(int PID, t_mem base_seg);
int escribir_memoria_algoritmo(uint32_t PID, uint32_t dir_logica_uint, void* buffer,uint32_t tamano);
int buscar_asignar_y_escribir_marcos_algoritmo(int PID, t_mem dir_logica, int tamano,
		void* buffer, TS* segmento, int *indice_marco);
int escribir_algoritmo(t_algoritmo* marco, t_mem dir_logica, uint32_t tamano,
		void* buffer);
int calcular_len_TP(int32_t tamano);
unsigned int aplicar_algoritmo();
void marcar_pagina_en_2(t_algoritmo* infoMarco);
int elegir_marco_victima();
char *armar_nombre(t_algoritmo* infoMarco);
int vueltas_Clock();
int cuarta_vuelta_Clock();
int tercera_vuelta_Clock();
int segunda_vuelta_Clock();
int primera_vuelta_Clock();
int leer_memoria_algoritmo(void* buffer, uint32_t PID, uint32_t direc,
		uint32_t tamano);
t_mem dir_a_t_mem(uint32_t direccion);
uint32_t t_mem_a_dir(t_mem estructura);
void deswappear(int PID, t_mem direc, void* texto);
void leer_archivo(char* archivo_nom, char texto[]);
void destruir_archivo(int PID, t_mem direc);
int destruir_segmento(uint32_t PID, uint32_t base_seg_uint);
uint32_t crear_segmento(uint32_t PID, uint32_t tamano);
uint32_t memoria_ocupada();
TS* agregar_segmento(int PID, t_mem base_seg, int tamano, int* TP,
		int cant_pags);
void inicializar_TP(int* TP, int len_TP);
int calcular_len_TP(int32_t tamano);
int mostrar_tabla_paginas_alternativo(int PID);
int firstOut_FIFO();

#endif /* FUNCIONES_MSP_H_ */

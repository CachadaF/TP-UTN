#ifndef FUNCIONES_ESO_H_
#define FUNCIONES_ESO_H_

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<commons/config.h>
#include<commons/log.h>
#include<commons/string.h>
#include<commons/collections/list.h>
#include"../Funciones_CPU/LecturaYEscritura.h"
#include"../Funciones_CPU/Sockets_Connection.h"
#include"../panel/cpu.h"
#include"../panel/panel.h"


//Estructuras
typedef struct {
	char* IP_KERNEL;
	int32_t PUERTO_KERNEL;
	char* IP_MSP;
	int32_t PUERTO_MSP;
	uint32_t RETARDO;
}Config_CPU;

typedef struct{uint32_t puntero_instruccion_syscall;}syscall_p;

typedef struct{ int32_t direccion_logica;} dir_log;

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
void FUNCION_ESO_PRINCIPAL();
int32_t leer_valor_registro(char reg);
void grabar_valor_registro(int32_t valor,char reg);
void LOAD_ESO();
void GETM_ESO();
void SETM_ESO();
void MOVR_ESO();
void ADDR_ESO();
void SUBR_ESO();
void MULR_ESO();
void MODR_ESO();
void DIVR_ESO();
void INCR_ESO();
void DECR_ESO();
void COMP_ESO();
void CGEQ_ESO();
void CLEQ_ESO();
void GOTO_ESO();
void JMPZ_ESO();
void JPNZ_ESO();
void INTE_ESO();
void FLCL_ESO();
void SHIF_ESO();
void NOPP_ESO();
void PUSH_ESO();
void TAKE_ESO();
void XXXX_ESO();
void MALC_ESO();
void FREE_ESO();
void INNN_ESO();
void INNC_ESO();
void OUTN_ESO();
void OUTC_ESO();
void CREA_ESO();
void JOIN_ESO();
void BLOK_ESO();
void WAKE_ESO();
void print_Registros_CPU();
t_header serializar_t_hilo (t_hilo tcb);
t_hilo deserializar_t_hilo (t_header header);
t_header serializar_t_solicitud_memoria(t_solicitud_memoria aux_sol);
t_escritura_memoria deserializar_t_escritura_memoria (t_header header);
t_header serializar_t_escritura_memoria(t_escritura_memoria aux_esc);
t_solicitud_memoria deserializar_t_solicitud_memoria (t_header header);
t_header serializar_t_crear_segmento (t_crear_segmento aux_creacion);
t_crear_segmento deserializar_t_crear_segmento (t_header header);
t_header serializar_t_destruir_segmento (t_destruir_segmento aux_destruccion);
t_destruir_segmento deserializar_t_destruir_segmento (t_header header);
//
//Funciones auxiliares
//
void list_parametros_0(char* Funcion_ESO);
void list_parametros_1(char* Funcion_ESO,char registro,int32_t numero);
void list_parametros_2(char* Funcion_ESO,char registro1,char registro2);
void list_parametros_3(char* Funcion_ESO,int32_t numero,char registro1,char registro2);
void list_parametros_4(char* Funcion_ESO,char registro);
void list_parametros_5(char* Funcion_ESO,int32_t numero);
void list_parametros_6(char* Funcion_ESO,int32_t numero,char registro);
//
//
#endif /* FUNCIONES_ESO_H_ */

#include"Funciones_ESO.h"

//Globales
extern t_log* log_CPU_ESO;
extern t_log* log_CPU;
extern t_registros_cpu REGISTROS_CPU;
extern uint32_t FLAG_TCB_OUT;
extern int32_t sock_fd_Kernel;
extern syscall_p SYSTEMCALL;
extern int32_t sock_fd_MSP;
extern uint32_t guardo_pid_syscall;

/*
 * Funcion que se encarga de llamar a las demas funciones
 */

void FUNCION_ESO_PRINCIPAL()
{
	t_solicitud_memoria sm;
	t_header header_recepcion;
	t_header header_envio;
	int32_t COP = 0;

	if (REGISTROS_CPU.K == 1)
	{
		sm.PID = 0;
	}
	else
	{
		sm.PID = REGISTROS_CPU.I;
	}

	sm.Size = 4;
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;

	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo
	if(header_recepcion.id == 410)
	{
		memcpy(&COP,header_recepcion.data,header_recepcion.size);
	}
	REGISTROS_CPU.P = REGISTROS_CPU.P + 4;	//Sumo 4 siempre a la direccion logica cuando agarro la instruccion

	switch (COP)
	{
		case(0x44414F4C)://Codigo:LOAD|44414F4C|1145130828
		{
			LOAD_ESO();break;
		}
		case(0x4D544547)://Codigo:GETM|4D544547|1297368391
		{
			GETM_ESO();break;
		}
		case(0x4D544553)://Codigo:SETM|4D544553|1297368403
		{
			SETM_ESO();break;
		}
		case(0x52564F4D)://Codigo:MOVR|52564F4D|1381388109
		{
			MOVR_ESO();break;
		}
		case(0x52444441)://Codigo:ADDR|52444441|1380205633
		{
			ADDR_ESO();break;
		}
		case(0x52425553)://Codigo:SUBR|52425553|1380078931
		{
			SUBR_ESO();break;
		}
		case(0x524C554D)://Codigo:MULR|524C554D|1380734285
		{
			MULR_ESO();
			break;
		}
		case(0x52444F4D)://Codigo:MODR|52444F4D|1380208461
		{
			MODR_ESO();
			break;
		}
		case(0x52564944)://Codigo:DIVR|52564944|1381386564
		{
			DIVR_ESO();
			break;
		}
		case(0x52434E49)://Codigo:INCR|52434E49|1380142665
		{
			INCR_ESO();
			break;
		}
		case(0x52434544)://Codigo:DECR|52434544|1380140356
		{
			DECR_ESO();
			break;
		}
		case(0x504D4F43)://Codigo:COMP|504D4F43|1347243843
		{
			COMP_ESO();
			break;
		}
		case(0x51454743)://Codigo:CGEQ|51454743|1363494723
		{
			CGEQ_ESO();
			break;
		}
		case(0x51454C43)://Codigo:CLEQ|51454C43|1363496003
		{
			CLEQ_ESO();
			break;
		}
		case(0x4F544F47)://Codigo:GOTO|4F544F47|1330925383
		{
			GOTO_ESO();
			break;
		}
		case(0x5A504D4A)://Codigo:JMPZ|5A504D4A|1515212106
		{
			JMPZ_ESO();
			break;
		}
		case(0x5A4E504A)://Codigo:JPNZ|5A4E504A|1515081802
		{
			JPNZ_ESO();
			break;
		}
		case(0x45544E49)://Codigo:INTE|45544E49|1163152969
		{
			INTE_ESO();
			break;
		}
		case(0x4C434C46)://Codigo:FLCL|4C434C46|1279478854
		{
			FLCL_ESO();
			break;
		}
		case(0x46494853)://Codigo:SHIF|46494853|1179207763
		{
			SHIF_ESO();
			break;
		}
		case(0x50504F4E)://Codigo:NOPP|50504F4E|1347440462
		{
			NOPP_ESO();
			break;
		}
		case(0x48535550)://Codigo:PUSH|48535550|1213420880
		{
			PUSH_ESO();
			break;
		}
		case(0x454B4154)://Codigo:TAKE|454B4154|1162559828
		{
			TAKE_ESO();
			break;
		}
		case(0x58585858)://Codigo:XXXX|58585858|1482184792
		{
			XXXX_ESO();
			break;
		}
		case(0x434C414D)://Codigo:MALC|434C414D|1129070925
		{
			MALC_ESO();
			break;
		}
		case(0x45455246)://Codigo:FREE|45455246|1162170950
		{
			FREE_ESO();
			break;
		}
		case(0x4E4E4E49)://Codigo:INNN|4E4E4E49|1313754697
		{
			INNN_ESO();
			break;
		}
		case(0x434E4E49)://Codigo:INNC|434E4E49|1129205321
		{
			INNC_ESO();
			break;
		}
		case(0x4E54554F)://Codigo:OUTN|4E54554F|1314149711
		{
			OUTN_ESO();
			break;
		}
		case(0x4354554F)://Codigo:OUTC|4354554F|1129600335
		{
			OUTC_ESO();
			break;
		}
		case(0x41455243)://Codigo:CREA|41455243|1095062083
		{
			CREA_ESO();
			break;
		}
		case(0x4E494F4A)://Codigo:JOIN|4E494F4A|1313427274
		{
			JOIN_ESO();
			break;
		}
		case(0x4B4F4C42)://Codigo:BLOK|4B4F4C42|1263488066
		{
			BLOK_ESO();
			break;
		}
		case(0x454B4157)://Codigo:WAKE|454B4157|1162559831
		{
			WAKE_ESO();
			break;
		}
		default:
		{
			int* m_COP = malloc(sizeof(int32_t));
			memcpy(m_COP,&COP,sizeof(int32_t));
			log_warning(log_CPU_ESO,"Intento de Funcion:%d",*m_COP);
			free(m_COP);
			FLAG_TCB_OUT = 4;
			break;
		}
	}
	return;
}

void LOAD_ESO()
{
	//
	log_debug(log_CPU_ESO,"EJECUTO LOAD_ESO");
	//
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 5;		//Pido 1b(Registro)+4b(Numero)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 5;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo
	int32_t value_aux;
	char reg_aux;
	memcpy(&reg_aux,header_recepcion.data,1);
	memcpy(&value_aux,header_recepcion.data+1,sizeof(int32_t));
	//
	list_parametros_1("LOAD",reg_aux,value_aux);
	//
	grabar_valor_registro(value_aux,reg_aux);
	return;
}

void GETM_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO GETM_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	//
	//Me fijo si estoy ejecutando una syscall -> Los semaforos los maneja el stack del hilo del kernel !!!!!!!!!!!!!!!
	//
	if (REGISTROS_CPU.K == 1)
	{sm.PID = 0;}
	else
	{sm.PID = REGISTROS_CPU.I;}
	//
	//
	//
	sm.Size = 2;		//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo
	char reg_aux_1,reg_aux_2;
	memcpy(&reg_aux_1,header_recepcion.data,1);
	memcpy(&reg_aux_2,header_recepcion.data+1,1);
	//
	list_parametros_2("GETM",reg_aux_1,reg_aux_2);
	//
	/*
	 * Se devuelven 1 byte de la memoria
	 */
	//sm.Size = sizeof(int32_t);
	sm.Size = 1;
	sm.Direccion_Logica = leer_valor_registro(reg_aux_2);
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo
	//int32_t *aux_grabar_registro = malloc(sizeof(int32_t));
	//memcpy(aux_grabar_registro,header_recepcion.data,sizeof(int32_t));
	char *aux_grabar_registro = malloc(1);
	memcpy(aux_grabar_registro,header_recepcion.data,1);
	grabar_valor_registro(*aux_grabar_registro,reg_aux_1);
	free(aux_grabar_registro);
	return;
}

void SETM_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO SETM_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	//
	//Me fijo si estoy ejecutando una syscall -> Los semaforos los maneja el stack del hilo del kernel !!!!!!!!!!!!!!!
	//
	if (REGISTROS_CPU.K == 1)
	{sm.PID = 0;}
	else
	{sm.PID = REGISTROS_CPU.I;}
	//
	//
	//
	sm.Size = 6;		//Pido 4b(Numero)+1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 6;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	int32_t aux_value;
	char reg_aux_1,reg_aux_2;
	memcpy(&aux_value,header_recepcion.data,sizeof(int32_t));
	memcpy(&reg_aux_1,header_recepcion.data+sizeof(int32_t),1);
	memcpy(&reg_aux_2,header_recepcion.data+sizeof(int32_t)+1,1);
	//
	list_parametros_3("SETM",aux_value,reg_aux_1,reg_aux_2);
	//
	//Copio el valor del registro 2
	int32_t valor_copiado_del_registro = leer_valor_registro(reg_aux_2);
	//Controlo que el Numero pasado no sea negativo
	if (aux_value <= 0)
	{
		return;
	}


	t_escritura_memoria em;
	em.PID = REGISTROS_CPU.I;
	if (reg_aux_1 == 83)
	{
		em.Direccion_Logica = REGISTROS_CPU.S;		//Si es para guardar en Stack
	}
	else
	{
		//Leo la direccion de memoria del 1° Registro
		em.Direccion_Logica = (uint32_t)leer_valor_registro(reg_aux_1);		//Si es para guardar en memoria de codigo
	}

	if (aux_value >= 4)
	{	//Si es mayor o igual que cuatro, copio todos los bytes registro
		em.Bytes_A_Escribir = malloc(sizeof(int32_t));
		memcpy(em.Bytes_A_Escribir,&valor_copiado_del_registro,sizeof(int32_t));
		em.Size = 4;
	}else{
		//Copia el valor indicado en el numero
		em.Bytes_A_Escribir = malloc(aux_value);
		memcpy(em.Bytes_A_Escribir,&valor_copiado_del_registro,aux_value);
		em.Size = aux_value;
	}

	header_envio = serializar_t_escritura_memoria(em);
	header_envio.id = 404;
	if (enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		return; //Debo setear una variable de error
	}
	free(header_envio.data);
	free(em.Bytes_A_Escribir);

	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
	}
	if(header_recepcion.id == 407)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 409 que indica que es correcto -> No hace falta controlarlo

	return;
}

void MOVR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO MOVR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;		//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	//Muevo el valor del 2° Registro al 1° Registro
	char reg_aux_leer,reg_aux_grabar;

	memcpy(&reg_aux_leer,header_recepcion.data+1,1);

	memcpy(&reg_aux_grabar,header_recepcion.data,1);

	//
	list_parametros_2("MOVR",reg_aux_grabar,reg_aux_leer);
	//

	int32_t value_aux = leer_valor_registro(reg_aux_leer);

	grabar_valor_registro(value_aux,reg_aux_grabar);
	return;
}
void ADDR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO ADDR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//
	list_parametros_2("ADDR",reg_aux_leer1,reg_aux_leer2);
	//
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	grabar_valor_registro(value_aux_reg1 + value_aux_reg2,reg_a);
	return;
}
void SUBR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO SUBR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//
	list_parametros_2("SUBR",reg_aux_leer1,reg_aux_leer2);
	//
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	grabar_valor_registro(value_aux_reg1 - value_aux_reg2,reg_a);
	return;
}
void MULR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO MULR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//
	list_parametros_2("MULR",reg_aux_leer1,reg_aux_leer2);
	//
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	grabar_valor_registro(value_aux_reg1 * value_aux_reg2,reg_a);
	return;
}
void MODR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO MODR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	//
	list_parametros_2("MODR",reg_aux_leer1,reg_aux_leer2);
	//
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	grabar_valor_registro(value_aux_reg1 % value_aux_reg2,reg_a);
	return;
}
void DIVR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO DIVR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	//
	list_parametros_2("DIVR",reg_aux_leer1,reg_aux_leer2);
	//
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	if (value_aux_reg2 == 0)
	{
		log_warning(log_CPU_ESO,"Error:Division por Cero");
		FLAG_TCB_OUT = 9;
		return;
	}
	else
	{
		char reg_a = 'A';

		grabar_valor_registro(value_aux_reg1 / value_aux_reg2,reg_a);
	}
	return;
}
void INCR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO INCR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 1;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer;
	memcpy(&reg_aux_leer,header_recepcion.data,1);
	//
	list_parametros_4("INCR",reg_aux_leer);
	//
	int32_t value_aux_reg = leer_valor_registro(reg_aux_leer);
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	grabar_valor_registro(value_aux_reg + 1,reg_aux_leer);
	return;
}
void DECR_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO DECR_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 1;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer;
	memcpy(&reg_aux_leer,header_recepcion.data,1);
	int32_t value_aux_reg = leer_valor_registro(reg_aux_leer);
	//
	list_parametros_4("DECR",reg_aux_leer);
	//
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	grabar_valor_registro(value_aux_reg - 1,reg_aux_leer);
	return;
}
void COMP_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO COMP_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		return;	//Debo setear una variable de error
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		return; //Debo setear una variable de error
	}
	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	//
	list_parametros_2("COMP",reg_aux_leer1,reg_aux_leer2);
	//
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	if (value_aux_reg1 == value_aux_reg2)
	{
		grabar_valor_registro(1,reg_a);
	}
	else
	{
		grabar_valor_registro(0,reg_a);
	}
	return;
}
void CGEQ_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO CGEQ_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	//
	list_parametros_2("CGEQ",reg_aux_leer1,reg_aux_leer2);
	//
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	if (value_aux_reg1 >= value_aux_reg2)
	{
		grabar_valor_registro(1,reg_a);
	}
	else
	{
		grabar_valor_registro(0,reg_a);
	}
	return;
}
void CLEQ_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO CLEQ_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 2;	//Pido 1b(Registro)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 2;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux_leer1,reg_aux_leer2;
	memcpy(&reg_aux_leer1,header_recepcion.data,1);
	memcpy(&reg_aux_leer2,header_recepcion.data+1,1);
	//
	list_parametros_2("CLEQ",reg_aux_leer1,reg_aux_leer2);
	//
	int32_t value_aux_reg1 = leer_valor_registro(reg_aux_leer1);
	int32_t value_aux_reg2 = leer_valor_registro(reg_aux_leer2);
	//FIJARSE QUE NO PASE EL LIMITE DE LOS VALORES POSIBLES DE ALMANCENAR PARA EVITAR -> OVERFLOW
	char reg_a = 'A';
	if (value_aux_reg1 <= value_aux_reg2)
	{
		grabar_valor_registro(1,reg_a);
	}
	else
	{
		grabar_valor_registro(0,reg_a);
	}
	return;
}
void GOTO_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO GOTO_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 1;		//Pido 1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 1;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	char reg_aux;
	memcpy(&reg_aux,header_recepcion.data,1);
	//
	list_parametros_4("GOTO",reg_aux);
	//
	int32_t valor_aux_reg = leer_valor_registro(reg_aux);

	memcpy(&REGISTROS_CPU.P,&valor_aux_reg,sizeof(uint32_t));

	return;
}
void JMPZ_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO JMPZ_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 4;		//Pido 4b(Numero)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 4;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	uint32_t value_aux;
	memcpy(&value_aux,header_recepcion.data,sizeof(uint32_t));
	//
	list_parametros_5("JMPZ",value_aux);
	//
	if (leer_valor_registro(65) == 0)
	{
		memcpy(&REGISTROS_CPU.P,&value_aux,sizeof(uint32_t));
	}
	return;
}
void JPNZ_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO JPNZ_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 4;		//Pido 4b(Numero)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 4;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	uint32_t *value_aux = malloc(sizeof(uint32_t));
	memcpy(value_aux,header_recepcion.data,sizeof(uint32_t));
	//
	list_parametros_5("JMPZ",*value_aux);
	//
	if (leer_valor_registro(65) != 0)
	{
		memcpy(&REGISTROS_CPU.P,value_aux,sizeof(uint32_t));
	}
	free(value_aux);
	return;
}
void INTE_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO INTE_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 4;		//Pido 4b(Direccion)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 4;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	int32_t direccion_aux;
	memcpy(&direccion_aux,header_recepcion.data,sizeof(uint32_t));
	//
	list_parametros_5("INTE",direccion_aux);
	//
	//
	//
	SYSTEMCALL.puntero_instruccion_syscall = direccion_aux;	//Asigno la direccion de system call a llamar
	FLAG_TCB_OUT = 1;		//SYSTEM CALL
	//
	//
	return;
}
void FLCL_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO FLCL_ESO");
	//
	list_parametros_0("FLCL");
	//
	//Cargo los registros de la CPU para probar que ejecute el codigo
	REGISTROS_CPU.registros_programacion[0] = 0;
	REGISTROS_CPU.registros_programacion[1] = 0;
	REGISTROS_CPU.registros_programacion[2] = 0;
	REGISTROS_CPU.registros_programacion[3] = 0;
	REGISTROS_CPU.registros_programacion[4] = 0;
	return;
}
void SHIF_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO SHIF_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 5;		//Pido 4b(Numero)+1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 5;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	int32_t value_aux;
	char reg_aux;
	memcpy(&value_aux,header_recepcion.data,sizeof(int32_t));
	memcpy(&reg_aux,header_recepcion.data+sizeof(int32_t),1);
	//
	list_parametros_6("SHIF",value_aux,reg_aux);
	//
	if (value_aux == 0)
	{
		return;
	}
	if (value_aux >= 32)
	{
		grabar_valor_registro(0,reg_aux);
	}
	else
	{
		int32_t valor_registro_leido = leer_valor_registro(reg_aux);

		if (value_aux > 0)	//Shift Logico positivo -> Shift a Derecha
		{
			valor_registro_leido = valor_registro_leido >> value_aux;
			grabar_valor_registro(valor_registro_leido,reg_aux);
		}
		else	//Shift Logico negativo -> Shift a Izquierda
		{
			valor_registro_leido = valor_registro_leido << value_aux;
			grabar_valor_registro(valor_registro_leido,reg_aux);
		}
	}
	return;
}
void NOPP_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO NOPP_ESO");
	//
	list_parametros_0("NOPP");
	//
	return;
}
void PUSH_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO PUSH_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 5;		//Pido 4b(Numero)+ 1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 5;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	//Guardo en las variables los valores necesarios para saber que guardar en el Stack
	int32_t value_aux;
	char reg_aux;
	memcpy(&value_aux,header_recepcion.data,sizeof(int32_t));
	memcpy(&reg_aux,header_recepcion.data+sizeof(int32_t),1);
	//
	list_parametros_6("PUSH",value_aux,reg_aux);
	//
	//Copio el valor del Registro que voy a guardar en el Stack
	int32_t valor_copiado_del_registro = leer_valor_registro(reg_aux);

	//Controlo que el Numero pasado no sea negativo
	if (value_aux <= 0)
	{
		return;
	}
	t_escritura_memoria em;
	em.PID = REGISTROS_CPU.I;
	em.Direccion_Logica = REGISTROS_CPU.S;

	if (value_aux >= 4)
	{	//Si es mayor o igual que cuatro, copio todos los bytes registro
		em.Bytes_A_Escribir = malloc(sizeof(int32_t));
		memcpy(em.Bytes_A_Escribir,&valor_copiado_del_registro,sizeof(int32_t));
		em.Size = 4;
		REGISTROS_CPU.S = REGISTROS_CPU.S + sizeof(int32_t);	//Cursor Stack
	}
	else
	{
		//Copia el valor indicado en el numero
		em.Bytes_A_Escribir = malloc(value_aux);
		memcpy(em.Bytes_A_Escribir,&valor_copiado_del_registro,value_aux);
		em.Size = value_aux;
		REGISTROS_CPU.S = REGISTROS_CPU.S + value_aux;	//Cursor Stack
	}


	header_envio = serializar_t_escritura_memoria(em);
	header_envio.id = 404;
	if (enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		return; //Debo setear una variable de error
	}
	free(header_envio.data);
	free(em.Bytes_A_Escribir);


	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
	}
	if(header_recepcion.id == 407)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 409 que indica que es correcto -> No hace falta controlarlo
	return;
}
void TAKE_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO TAKE_ESO");
	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;
	sm.PID = REGISTROS_CPU.I;
	sm.Size = 5;		//Pido 4b(Numero)+ 1b(Registro)
	sm.Direccion_Logica = REGISTROS_CPU.P + REGISTROS_CPU.M;
	REGISTROS_CPU.P += 5;
	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	//Guardo en las variables los valores necesarios para saber que quitar del Stack
	t_solicitud_memoria sm_stack;
	sm_stack.PID = REGISTROS_CPU.I;
	//sm_stack.Direccion_Logica = REGISTROS_CPU.S;	//ACA ESTA EL ERROR -> VIENE PARA ADELANTE NO PARA ATRAS
	char reg_aux;
	memcpy(&sm_stack.Size,header_recepcion.data,sizeof(int32_t));
	memcpy(&reg_aux,header_recepcion.data+sizeof(int32_t),1);
	//
	list_parametros_6("TAKE",sm_stack.Size,reg_aux);
	//
	sm_stack.Direccion_Logica = REGISTROS_CPU.S-sm_stack.Size;

	//Controlo que el Numero pasado no sea negativo
	if (sm_stack.Size <= 0)
	{
		return;
	}
	//No se esta controlando que sea menor que un valor, sino que pide todos los bytes que pueda
	if (REGISTROS_CPU.S-sm_stack.Size < REGISTROS_CPU.X)
	{
		log_info(log_CPU_ESO,"Overflow (Por Debajo) del cursor de Stack");
		return;
	}
	header_envio = serializar_t_solicitud_memoria(sm_stack);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 410 que indica que es correcto -> No hace falta controlarlo

	//
	//Agrego esto <<<<<<------------ Sino no devuelve siempre bien
	//
	if(sm_stack.Size == 1 || sm_stack.Size == 2 || sm_stack.Size == 3)
	{
		int32_t valor_a_grabar1;
		memcpy(&valor_a_grabar1,header_recepcion.data,sm_stack.Size);
		grabar_valor_registro(valor_a_grabar1,reg_aux);
	}
	//
	else
	{
		//Esto ya estaba
		int32_t *valor_a_grabar = malloc(sizeof(int32_t));
		memcpy(valor_a_grabar,header_recepcion.data,sm_stack.Size);
		//Guardo en el registro
		grabar_valor_registro(*valor_a_grabar,reg_aux);
		free(valor_a_grabar);
	}
	//Retrocedo el puntero del Stack
	REGISTROS_CPU.S = REGISTROS_CPU.S - sm_stack.Size;
	return;
}
void XXXX_ESO()
{
	log_debug(log_CPU_ESO,"EJECUTO XXXX_ESO");
	//
	list_parametros_0("XXXX");
	//
	if (REGISTROS_CPU.K == 1)
	{
		FLAG_TCB_OUT = 7;	//Valor de fin de syscall
	}
	else
	{
		FLAG_TCB_OUT = 2;	//Valor de fin de hilo
	}
	return;
}
void MALC_ESO()
{
	//
	list_parametros_0("MALC");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida MALC_ESO->Se encuentra en Modo Usuario");
		return;
	}

	log_debug(log_CPU_ESO,"EJECUTO MALC_ESO");

	t_header envio_MSP;
	t_header recep_MSP;
	//Aca va el envio para crear el 1° segmento -> Memoria
	t_crear_segmento segmento_a_crear;
	dir_log dir;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////Uso el PID del Hilo que llamo al syscall guardado anteriormente////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	segmento_a_crear.PID = guardo_pid_syscall;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	segmento_a_crear.Size = REGISTROS_CPU.registros_programacion[0];	//Registro 'A'

	envio_MSP = serializar_t_crear_segmento(segmento_a_crear);
	envio_MSP.id = 401;
	if (enviar_paquete(sock_fd_MSP,envio_MSP) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		FLAG_TCB_OUT = 8;
		return;
	}
	free(envio_MSP.data);
	if (recibir_paquete(sock_fd_MSP,&recep_MSP) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		FLAG_TCB_OUT = 8;
		return;
	}
	if (recep_MSP.id == 402)
	{	//Creacion correcta -> Asigno .data que tiene la posicion de memoria
		memcpy(&dir,recep_MSP.data,recep_MSP.size);
		//Direccion logica del segmento que acabo de crear
		REGISTROS_CPU.registros_programacion[0] = dir.direccion_logica;
		//
		log_info(log_CPU_ESO,"Segmento de Codigo creado Correctamente:%d",dir.direccion_logica);
	}
	if (recep_MSP.id == 403)
	{
		//Memory Overload -> Cierro conexion con esa Consola
		FLAG_TCB_OUT = 5;
		return;
	}

	return;
}
void FREE_ESO()
{
	//
	list_parametros_0("FREE");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida FREE_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO FREE_ESO");

	t_header header_envio_MSP;
	t_destruir_segmento mensaje_destruccion;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////Uso el PID del Hilo que llamo al syscall guardado anteriormente////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	mensaje_destruccion.PID = guardo_pid_syscall;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	mensaje_destruccion.PID = REGISTROS_CPU.I;


	mensaje_destruccion.Direccion_Logica = (uint32_t)REGISTROS_CPU.registros_programacion[0];	//Registro 'A'

	header_envio_MSP = serializar_t_destruir_segmento(mensaje_destruccion);
	header_envio_MSP.id = 405;
	//Este mensaje id = 405 -> Destruye el segmento indicado
	if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		FLAG_TCB_OUT = 8;
	}

	return;
}
void INNN_ESO()
{
	//
	list_parametros_0("INNN");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida INNN_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO INNN_ESO");

	t_header header_envio_Kernel;
	t_header header_recep_Kernel;

	header_envio_Kernel.id = 214;
	header_envio_Kernel.size = 0;

	if (enviar_paquete(sock_fd_Kernel,header_envio_Kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}

	if(recibir_paquete(sock_fd_Kernel,&header_recep_Kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}

	if(header_recep_Kernel.id == 700)
	{
		log_info(log_CPU_ESO,"Paquete erroneo->No guardo nada");
		return;
	}
	int32_t numero_a_guardar_en_reg = 0;
	memcpy(&numero_a_guardar_en_reg,header_recep_Kernel.data,header_recep_Kernel.size);

	grabar_valor_registro(numero_a_guardar_en_reg,'A');

	return;
}
void INNC_ESO()
{
	//
	list_parametros_0("INNC");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida INNC_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO INNC_ESO");

	t_header header_envio_Kernel;
	t_header header_recep_Kernel;

	header_envio_Kernel.id = 217;
	header_envio_Kernel.size = sizeof(int32_t);
	header_envio_Kernel.data = malloc(header_envio_Kernel.size);

	int32_t size_de_char = leer_valor_registro('B');

	memcpy(header_envio_Kernel.data,&size_de_char,sizeof(int32_t));

	if (enviar_paquete(sock_fd_Kernel,header_envio_Kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}
	free(header_envio_Kernel.data);

	if(recibir_paquete(sock_fd_Kernel,&header_recep_Kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}

	if(header_recep_Kernel.id == 700)
	{
		log_info(log_CPU_ESO,"Paquete erroneo->No guardo nada");
		return;
	}

	int32_t posicion_de_memoria_donde_guardar = leer_valor_registro('A');

	t_escritura_memoria em;
	t_header header_envio_MSP;
	t_header header_recepcion_MSP;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////Uso el PID del Hilo que llamo al syscall guardado anteriormente////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	em.PID = guardo_pid_syscall;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	em.Direccion_Logica = posicion_de_memoria_donde_guardar;

	//Copia el valor indicado en el numero
	em.Bytes_A_Escribir = malloc(header_recep_Kernel.size);	//Tamaño a guardar
	em.Size = header_envio_Kernel.size;
	memcpy(em.Bytes_A_Escribir,header_recep_Kernel.data,em.Size);

	header_envio_MSP = serializar_t_escritura_memoria(em);
	header_envio_MSP.id = 404;
	if (enviar_paquete(sock_fd_MSP,header_envio_MSP) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		return; //Debo setear una variable de error
	}
	free(header_envio_MSP.data);
	free(em.Bytes_A_Escribir);

	if(recibir_paquete(sock_fd_MSP,&header_recepcion_MSP) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
	}
	if(header_recepcion_MSP.id == 407)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}
	//Llega el header_recepcion.id == 409 que indica que es correcto -> No hace falta controlarlo

	return;
}
void OUTN_ESO()
{
	//
	list_parametros_0("OUTN");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida OUTN_ESO->Se encuentra en Modo Usuario");

		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO OUTN_ESO");

	int32_t aux_a_mandar_a_consola = 0;
	t_header header_envio_Kernel;
	aux_a_mandar_a_consola = leer_valor_registro('A');

	header_envio_Kernel.id = 215;
	header_envio_Kernel.size = sizeof(int32_t);
	header_envio_Kernel.data = malloc(header_envio_Kernel.size);
	memcpy(header_envio_Kernel.data,&aux_a_mandar_a_consola,sizeof(int32_t));

	//printf("Bytes a mandar al Kernel:%d\n",(int32_t)header_envio_Kernel.data);

	if (enviar_paquete(sock_fd_Kernel,header_envio_Kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}

	free(header_envio_Kernel.data);

	return;
}
void OUTC_ESO()
{
	//
	list_parametros_0("OUTC");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida OUTC_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO OUTC_ESO");

	int32_t posicion_de_memoria_del_char;
	int32_t size_del_char;
	t_header header_envio_Kernel;
	posicion_de_memoria_del_char = leer_valor_registro('A');
	size_del_char = leer_valor_registro('B');

	//printf("\n\n\nSize a leer de MSP :%d\n\n\n",size_del_char);

	t_header header_envio;
	t_header header_recepcion;
	t_solicitud_memoria sm;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////Uso el PID del Hilo que llamo al syscall guardado anteriormente////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	sm.PID = guardo_pid_syscall;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	sm.Size = size_del_char;		//Size del char* guardado en memoria
	sm.Direccion_Logica = posicion_de_memoria_del_char;	//Posicion de memoria del char*

	header_envio = serializar_t_solicitud_memoria(sm);
	header_envio.id = 406;
	if(enviar_paquete(sock_fd_MSP,header_envio) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	free(header_envio.data);
	if(recibir_paquete(sock_fd_MSP,&header_recepcion) < 0)
	{
		log_error(log_CPU,"Se cerro conexion con MSP");
		//Debo setear una variable de error
		FLAG_TCB_OUT = 8;
		return;
	}
	if(header_recepcion.id == 408)
	{
		log_warning(log_CPU_ESO,"Segmentation Fault(Lectura De Memoria)");
		FLAG_TCB_OUT = 6;
		return;
	}

	header_envio_Kernel.id = 218;
	header_envio_Kernel.size = size_del_char;
	//header_envio_Kernel.data = malloc(header_envio_Kernel.size);
	header_envio_Kernel.data = malloc(size_del_char);

	memcpy(header_envio_Kernel.data,header_recepcion.data,size_del_char);

	//printf("\n\n\nBytes_Enviados_Al_Kernel:%s\n\n\n",(char*)header_envio_Kernel.data);

	if (enviar_paquete(sock_fd_Kernel,header_envio_Kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}
	//
	else
	{
		free(header_envio_Kernel.data);

		if(recibir_paquete(sock_fd_Kernel,&header_recepcion) < 0)
		{

		}
		if(header_recepcion.id == 295)
		{
			return;
		}
		return;
	}
	//
}
void CREA_ESO()
{
	//
	list_parametros_0("CREA");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida CREA_ESO|->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO CREA_ESO");

	int32_t program_counter_nuevo_proceso = 0;
	program_counter_nuevo_proceso = leer_valor_registro('B');

	t_header header_envio_kernel;
	t_header header_recep_kernel;

	header_envio_kernel.id = 216;
	header_envio_kernel.size = sizeof(int32_t);
	header_envio_kernel.data = malloc(header_envio_kernel.size);
	memcpy(header_envio_kernel.data,&program_counter_nuevo_proceso,header_envio_kernel.size);

	if (enviar_paquete(sock_fd_Kernel,header_envio_kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}
	free(header_envio_kernel.data);

	if(recibir_paquete(sock_fd_Kernel,&header_recep_kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}

	if(header_recep_kernel.id != 232)
	{
		//Verificar en JOIN esto para ver si falla
		grabar_valor_registro(-1,'A');
	}
	int32_t hilo_crea_devuelvo = 0;
	memcpy(&hilo_crea_devuelvo,header_recep_kernel.data,sizeof(int32_t));
	//Debo guardar en A el nuevo hilo creado -> Seguro es para el JOIN
	grabar_valor_registro(hilo_crea_devuelvo,'A');

	return;
}
void JOIN_ESO()
{
	//
	list_parametros_0("JOIN");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida JOIN_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO JOIN_ESO");

	int32_t tid_join = 0;
	tid_join = leer_valor_registro('A');

	t_header header_envio_kernel;
	//t_header header_recep_kernel;

	header_envio_kernel.id = 211;
	header_envio_kernel.size = sizeof(int32_t);
	header_envio_kernel.data = malloc(header_envio_kernel.size);
	memcpy(header_envio_kernel.data,&tid_join,header_envio_kernel.size);

	if (enviar_paquete(sock_fd_Kernel,header_envio_kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}
	free(header_envio_kernel.data);

	return;
}
void BLOK_ESO()
{
	//
	list_parametros_0("BLOK");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida BLOK_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO BLOK_ESO");

	int32_t sem_blok = 0;
	sem_blok = leer_valor_registro('B');

	t_header header_envio_kernel;
	header_envio_kernel.id = 212;
	header_envio_kernel.size = sizeof(int32_t);
	header_envio_kernel.data = malloc(header_envio_kernel.size);
	memcpy(header_envio_kernel.data,&sem_blok,header_envio_kernel.size);

	if (enviar_paquete(sock_fd_Kernel,header_envio_kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}
	free(header_envio_kernel.data);

	return;
}
void WAKE_ESO()
{
	//
	list_parametros_0("WAKE");
	//
	if(REGISTROS_CPU.K == 0)
	{
		log_warning(log_CPU_ESO,"Fallo al ejecutar la funcion protegida WAKE_ESO->Se encuentra en Modo Usuario");
		return;
	}
	log_debug(log_CPU_ESO,"EJECUTO WAKE_ESO");

	int32_t sem_wake = 0;
	sem_wake = leer_valor_registro('B');

	t_header header_envio_kernel;
	header_envio_kernel.id = 213;
	header_envio_kernel.size = sizeof(int32_t);
	header_envio_kernel.data = malloc(header_envio_kernel.size);
	memcpy(header_envio_kernel.data,&sem_wake,header_envio_kernel.size);

	if (enviar_paquete(sock_fd_Kernel,header_envio_kernel) < 0)
	{
		log_error(log_CPU,"Se cerro la conexion con la Kernel");
		exit(1);
	}

	return;
}

//Dado un numero de registro, sea A=65/B=66/C=67/D=68/E=69/I=73/K=75/M=77/P=80/S=83/X=88 devuelvo el valor de este
int32_t leer_valor_registro(char reg)
{
	int32_t valor_registro;

	switch(reg)
	{
	case(65):{valor_registro = REGISTROS_CPU.registros_programacion[0];break;}
	case(66):{valor_registro = REGISTROS_CPU.registros_programacion[1];break;}
	case(67):{valor_registro = REGISTROS_CPU.registros_programacion[2];break;}
	case(68):{valor_registro = REGISTROS_CPU.registros_programacion[3];break;}
	case(69):{valor_registro = REGISTROS_CPU.registros_programacion[4];break;}
	case(73):{valor_registro = REGISTROS_CPU.I;break;}
	case(75):{valor_registro = REGISTROS_CPU.K;break;}
	case(77):{valor_registro = REGISTROS_CPU.M;break;}
	case(80):{valor_registro = REGISTROS_CPU.P;break;}
	case(83):{valor_registro = REGISTROS_CPU.S;break;}
	case(88):{valor_registro = REGISTROS_CPU.X;break;}
	default:{
			log_warning(log_CPU_ESO,"Error->Registro Incorrecto");
			break;	//Aca devuelve un error por intento de acceder a registro inexistente
					//Seteo alguna variable para que salga por error
		}
	}
	return valor_registro;
}

//Dado un numero de registro, sea A=65/B=66/C=67/D=68/E=69/I=73/K=75/M=77/P=80/S=83/X=88 devuelvo el valor de este
void grabar_valor_registro(int32_t valor,char reg)
{
	switch(reg)
	{
	case(65):{REGISTROS_CPU.registros_programacion[0] = valor;break;}
	case(66):{REGISTROS_CPU.registros_programacion[1] = valor;break;}
	case(67):{REGISTROS_CPU.registros_programacion[2] = valor;break;}
	case(68):{REGISTROS_CPU.registros_programacion[3] = valor;break;}
	case(69):{REGISTROS_CPU.registros_programacion[4] = valor;break;}
	case(73):{REGISTROS_CPU.I = valor;break;}
	case(75):{REGISTROS_CPU.K = valor;break;}
	case(77):{REGISTROS_CPU.M = valor;break;}
	case(80):{REGISTROS_CPU.P = valor;break;}
	case(83):{REGISTROS_CPU.S = valor;break;}
	case(88):{REGISTROS_CPU.X = valor;break;}
	default:
		{
			log_warning(log_CPU_ESO,"Error->Registro Incorrecto");
			break;	//Aca devuelve un error por intento de acceder a registro inexistente
					//Seteo alguna variable para que salga por error
		}
	}

	return;
}

/*
 * Funcion que serializa un t_hilo en el header.data para
 * poder ser enviado por socket al Kernel
 */

t_header serializar_t_hilo (t_hilo tcb)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(t_hilo);
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&(tcb.pid),sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&(tcb.tid),sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&(tcb.kernel_mode),sizeof(bool));
	offset += sizeof(bool);
	memcpy(header_aux.data+offset,&(tcb.segmento_codigo),sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&(tcb.segmento_codigo_size),sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&(tcb.puntero_instruccion),sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&(tcb.base_stack),sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&(tcb.cursor_stack),sizeof(uint32_t));
	offset += sizeof(int32_t);
	memcpy(header_aux.data+offset,&(tcb.registros[0]),sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(header_aux.data+offset,&(tcb.registros[1]),sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(header_aux.data+offset,&(tcb.registros[2]),sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(header_aux.data+offset,&(tcb.registros[3]),sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(header_aux.data+offset,&(tcb.registros[4]),sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(header_aux.data+offset,&(tcb.registros[0]),sizeof(int32_t));
	offset += sizeof(t_cola);
	memcpy(header_aux.data+offset,&(tcb.tid),sizeof(t_cola));
	header_aux.size = size_Serializado;

	return header_aux;
}

/*
 * Funcion que deserializa el void* del header.data
 * en un t_hilo ( o TCB) para usarse en la CPU
 */

t_hilo deserializar_t_hilo (t_header header)
{
	t_hilo aux_hilo;
	int32_t offset = 0;
	memcpy(&(aux_hilo.pid),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.tid),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.kernel_mode),header.data+offset,sizeof(bool));
	offset += sizeof(bool);
	memcpy(&(aux_hilo.segmento_codigo),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.segmento_codigo_size),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.puntero_instruccion),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.base_stack),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.cursor_stack),header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&(aux_hilo.registros[0]),header.data+offset,sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(&(aux_hilo.registros[1]),header.data+offset,sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(&(aux_hilo.registros[2]),header.data+offset,sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(&(aux_hilo.registros[3]),header.data+offset,sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(&(aux_hilo.registros[4]),header.data+offset,sizeof(int32_t));
	offset += sizeof(int32_t);
	memcpy(&(aux_hilo.cola),header.data+offset,sizeof(t_cola));

	return aux_hilo;
}

t_header serializar_t_escritura_memoria(t_escritura_memoria aux_esc)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(uint32_t)*3 + aux_esc.Size;
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_esc.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_esc.Direccion_Logica,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_esc.Size,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,aux_esc.Bytes_A_Escribir,aux_esc.Size);

	header_aux.size = size_Serializado;

	return header_aux;
}

t_escritura_memoria deserializar_t_escritura_memoria (t_header header)
{
	t_escritura_memoria aux_escrit;
	int32_t offset = 0;
	memcpy(&aux_escrit.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_escrit.Direccion_Logica,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_escrit.Size,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);

	//Debo hacer malloc para guardar en memoria el valor de lo que llega
	aux_escrit.Bytes_A_Escribir = malloc(aux_escrit.Size);

	memcpy(aux_escrit.Bytes_A_Escribir,header.data+offset,aux_escrit.Size);


	return aux_escrit;
}


t_header serializar_t_solicitud_memoria(t_solicitud_memoria aux_sol)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(t_solicitud_memoria);
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_sol.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_sol.Direccion_Logica,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_sol.Size,sizeof(uint32_t));

	header_aux.size = size_Serializado;

	return header_aux;
}

t_solicitud_memoria deserializar_t_solicitud_memoria (t_header header)
{
	t_solicitud_memoria aux_solic;
	int32_t offset = 0;
	memcpy(&aux_solic.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_solic.Direccion_Logica,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_solic.Size,header.data+offset,sizeof(uint32_t));

	return aux_solic;
}

t_header serializar_t_crear_segmento (t_crear_segmento aux_creacion)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(uint32_t)*2;
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_creacion.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_creacion.Size,sizeof(uint32_t));
	offset += sizeof(uint32_t);

	header_aux.size = size_Serializado;

	return header_aux;
}

t_crear_segmento deserializar_t_crear_segmento (t_header header)
{
	t_crear_segmento aux_creacion;
	int32_t offset = 0;
	memcpy(&aux_creacion.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_creacion.Size,header.data+offset,sizeof(uint32_t));

	return aux_creacion;
}

t_header serializar_t_destruir_segmento (t_destruir_segmento aux_destruccion)
{
	t_header header_aux;
	int32_t size_Serializado = sizeof(uint32_t)*2;
	header_aux.data = malloc(size_Serializado);
	int32_t offset = 0;
	memcpy(header_aux.data+offset,&aux_destruccion.PID,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(header_aux.data+offset,&aux_destruccion.Direccion_Logica,sizeof(uint32_t));
	offset += sizeof(uint32_t);

	header_aux.size = size_Serializado;

	return header_aux;
}

t_destruir_segmento deserializar_t_destruir_segmento (t_header header)
{
	t_destruir_segmento aux_destruccion;
	int32_t offset = 0;
	memcpy(&aux_destruccion.PID,header.data+offset,sizeof(uint32_t));
	offset += sizeof(uint32_t);
	memcpy(&aux_destruccion.Direccion_Logica,header.data+offset,sizeof(uint32_t));

	return aux_destruccion;
}

void print_Registros_CPU()
{
	log_debug(log_CPU_ESO,"|A:%d|B:%d|C:%d|D:%d|E:%d|I:%d|K:%d|M:%d|P:%d|S:%d|X:%d|"
	,REGISTROS_CPU.registros_programacion[0],REGISTROS_CPU.registros_programacion[1]
	,REGISTROS_CPU.registros_programacion[2],REGISTROS_CPU.registros_programacion[3]
	,REGISTROS_CPU.registros_programacion[4],REGISTROS_CPU.I
	,REGISTROS_CPU.K,REGISTROS_CPU.M,REGISTROS_CPU.P
	,REGISTROS_CPU.S,REGISTROS_CPU.X);
	return;
}



/***********************************************************************************************************************
************************************************************************************************************************
************************************Funciones Auxiliares para imprimir lo pedido en Panel*******************************
************************************************************************************************************************
***********************************************************************************************************************/

void list_parametros_0(char* Funcion_ESO)
{
	t_list *lista_parametros = list_create();

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

void list_parametros_1(char* Funcion_ESO,char registro,int32_t numero)
{
	t_list *lista_parametros = list_create();

	char* aux_a = string_repeat(registro,1);

	char* aux_b = string_itoa(numero);

	list_add(lista_parametros,(void*)aux_a);

	list_add(lista_parametros,(void*)aux_b);

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

void list_parametros_2(char* Funcion_ESO,char registro1,char registro2)
{
	t_list *lista_parametros = list_create();

	char* aux_a = string_repeat(registro1,1);

	char* aux_b = string_repeat(registro2,1);

	list_add(lista_parametros,(void*)aux_a);

	list_add(lista_parametros,(void*)aux_b);

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

void list_parametros_3(char* Funcion_ESO,int32_t numero,char registro1,char registro2)
{
	t_list *lista_parametros = list_create();

	char* aux_c = string_itoa(numero);

	char* aux_a = string_repeat(registro1,1);

	char* aux_b = string_repeat(registro2,1);

	list_add(lista_parametros,(void*)aux_a);

	list_add(lista_parametros,(void*)aux_b);

	list_add(lista_parametros,(void*)aux_c);

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

void list_parametros_4(char* Funcion_ESO,char registro)
{
	t_list *lista_parametros = list_create();

	char* aux_a = string_repeat(registro,1);

	list_add(lista_parametros,(void*)aux_a);

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

void list_parametros_5(char* Funcion_ESO,int32_t numero)
{
	t_list *lista_parametros = list_create();

	char* aux_a = string_itoa(numero);

	list_add(lista_parametros,(void*)aux_a);

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

void list_parametros_6(char* Funcion_ESO,int32_t numero,char registro)
{
	t_list *lista_parametros = list_create();

	char* aux_a = string_itoa(numero);

	char* aux_b = string_repeat(registro,1);

	list_add(lista_parametros,(void*)aux_a);

	list_add(lista_parametros,(void*)aux_b);

	ejecucion_instruccion(Funcion_ESO,lista_parametros);

	list_destroy(lista_parametros);

	return;
}

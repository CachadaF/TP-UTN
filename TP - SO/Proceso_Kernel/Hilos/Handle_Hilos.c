#include"Funciones_Hilos.h"

//Listas
extern t_list* lista_hilos_terminados;		//Lista usada para JOIN
//extern t_list* lista_wake_hilos;			//Lista usada para WAKE/BLOK -> Semaforos de los hilos
extern t_list* lista_handle_hilos_finalizados; //Lista encargada de finalizar los hilos hijos que se encuentren en Exec/Block
//Globales externas
extern t_log *Log_Kernel_Temporal;
extern t_log *Log_Kernel_Planificador;
//extern t_log *Log_Kernel_Loader;
//Colas del planificador
extern t_queue* cola_Ready;
extern t_queue* cola_Block;
extern t_queue* cola_Block_Recurso;
extern t_queue* cola_Block_Join;
extern t_queue* cola_Exit;
extern t_queue* cola_Exec;
extern t_queue* cola_New;
//Mutex de las colas
extern pthread_mutex_t mutex_cola_Ready;
extern pthread_mutex_t mutex_cola_Block;
extern pthread_mutex_t mutex_cola_Block_Recurso;
extern pthread_mutex_t mutex_cola_Block_Join;
extern pthread_mutex_t mutex_cola_Exit;
extern pthread_mutex_t mutex_cola_Exec;
extern pthread_mutex_t mutex_cola_New;
extern pthread_mutex_t mutex_lista_hilos_terminados;
extern pthread_mutex_t mutex_lista_handle_hilos_finalizados;
//Semaforos Contadores
//extern sem_t sem_cola_New;
//extern sem_t sem_cola_Ready;
extern sem_t sem_cola_Block;
extern sem_t sem_cola_Exit;


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


/*
 * Imprime todos los t_hilo de una cola determinada
 */

void imprime_t_Hilos_de_Todas_Colas()
{
	t_list *lista_t_hilos_imprimir = list_create();
	int32_t i = 0;
	t_hilo_proceso *p_hilo_proceso = NULL;
	//
	pthread_mutex_lock(&mutex_cola_New);
	p_hilo_proceso = list_get(cola_New->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_New->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_New);
	i = 0;
	//
	pthread_mutex_lock(&mutex_cola_Ready);
	p_hilo_proceso = list_get(cola_Ready->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_Ready->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Ready);
	i = 0;
	//
	pthread_mutex_lock(&mutex_cola_Exec);
	p_hilo_proceso = list_get(cola_Exec->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_Exec->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Exec);
	i = 0;
	//
	pthread_mutex_lock(&mutex_cola_Exit);
	p_hilo_proceso = list_get(cola_Exit->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_Exit->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Exit);
	i = 0;
	//
	pthread_mutex_lock(&mutex_cola_Block);
	p_hilo_proceso = list_get(cola_Block->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_Block->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block);
	i = 0;
	//
	pthread_mutex_lock(&mutex_cola_Block_Join);
	p_hilo_proceso = list_get(cola_Block_Join->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_Block_Join->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block_Join);
	i = 0;
	//
	pthread_mutex_lock(&mutex_cola_Block_Recurso);
	p_hilo_proceso = list_get(cola_Block_Recurso->elements,i);
	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));
		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));
		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);
		i++;
		p_hilo_proceso = list_get(cola_Block_Recurso->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block_Recurso);
	i = 0;
	//
	//Imprimo los hilos que tenia la cola
	//
	hilos(lista_t_hilos_imprimir);
	//
	//
	list_destroy_and_destroy_elements(lista_t_hilos_imprimir,free);
	return;
}


/*
 * 	Dada una cola, un PID y el Mutex, quita de la cola si existe el PID en la cola.
 * 	Devuelve 0 si no lo encuentra. -> Quita procesos no KM = 1
 */

int32_t quita_por_PID_de_Cola (t_queue *cola, int32_t pid_a_quitar, pthread_mutex_t* mutex_cola)
{
	int32_t i = 0;

	t_hilo_proceso *aux_a_filtrar = list_get(cola->elements,i);

	t_hilo_proceso *pasar_hilo_a_exit = NULL;

	int32_t size = size_de_cola(cola,mutex_cola);

	while(i < size)
	{
		if(aux_a_filtrar->hilo.pid == pid_a_quitar && aux_a_filtrar->hilo.kernel_mode == 0)
		{
			//Los que no estan en las colas de exec los mando a exit para que finalizen sus segmentos
			pasar_hilo_a_exit = list_remove(cola->elements,i);
			pasar_hilo_a_exit->estado_salida = FALLO_HILO_FIN;
			agregar_en_cola(cola_Exit,pasar_hilo_a_exit,&mutex_cola_Exit);
			//
			//Imprimo el estado de todas las colas
			imprime_t_Hilos_de_Todas_Colas();
			//
			sem_post(&sem_cola_Exit);
		}
		i++;
		aux_a_filtrar = list_get(cola->elements,i);
	}
	return 0;
}



/*
 *
 *
 * Agrega a la lista de hilos finalizados para luego en el hilo planificador de Block_Join
 * revisar si termino el hilo esperado de por los demas hilos para moverlos a Ready
 */

void agregar_lista_join(int32_t pid_hilo_join,int32_t tid_hilo_join)
{
	pthread_mutex_lock(&mutex_lista_hilos_terminados);

	t_fin_hilo *datos_hilo_finalizado = malloc(sizeof(t_fin_hilo));
	datos_hilo_finalizado->hilo = tid_hilo_join;
	datos_hilo_finalizado->proceso = pid_hilo_join;
	//
	list_add(lista_hilos_terminados,datos_hilo_finalizado);
	//
	pthread_mutex_unlock(&mutex_lista_hilos_terminados);
	return;
}

/*
 * Se fija si todavia quedan en las colas PIDS que no quite antes de limpiar de la lista_handle_hilos_finalizados
 * 1-> Hay
 * 0-> No hay
 */
int32_t esta_en_cola_PID_l(t_queue* cola_en_donde_buscar,int32_t pid_buscar,pthread_mutex_t* mutex_cola)
{
	int32_t i = 0;

	t_hilo_proceso *hilo_que_buscar = list_get(cola_en_donde_buscar->elements,i);
	int32_t size = size_de_cola(cola_en_donde_buscar,mutex_cola);

	//Mutex a la cola para que no se agrege/quite nada
	pthread_mutex_lock(mutex_cola);
	while(i < size)
	{
		if(hilo_que_buscar->hilo.pid == pid_buscar)
		{
			pthread_mutex_unlock(mutex_cola);
			return 1;
		}
		i++;
		hilo_que_buscar = list_get(cola_en_donde_buscar->elements,i);
	}
	pthread_mutex_unlock(mutex_cola);
	return 0;
}

/*
 * Quitar de la lista de hilos finalizador por PID
 */

void limpia_lista_handle_hilos_finalizados ()
{
	int32_t i = 0;

	int32_t suma_hilos = 0;

	pthread_mutex_lock(&mutex_lista_handle_hilos_finalizados);

	int32_t size = list_size(lista_handle_hilos_finalizados);

	t_pid_hilo_finalizar* hilo_pid_finalizar = list_get(lista_handle_hilos_finalizados,i);

	while(i < size)
	{
		suma_hilos += esta_en_cola_PID_l(cola_Exec,hilo_pid_finalizar->pid_hilo_finalizar,&mutex_cola_Exec);
		suma_hilos += esta_en_cola_PID_l(cola_Block_Join,hilo_pid_finalizar->pid_hilo_finalizar,&mutex_cola_Block_Join);
		suma_hilos += esta_en_cola_PID_l(cola_Block,hilo_pid_finalizar->pid_hilo_finalizar,&mutex_cola_Block);
		suma_hilos += esta_en_cola_PID_l(cola_Block_Recurso,hilo_pid_finalizar->pid_hilo_finalizar,&mutex_cola_Block_Recurso);
		suma_hilos += esta_en_cola_PID_l(cola_New,hilo_pid_finalizar->pid_hilo_finalizar,&mutex_cola_New);
		suma_hilos += esta_en_cola_PID_l(cola_Ready,hilo_pid_finalizar->pid_hilo_finalizar,&mutex_cola_Ready);

		if (suma_hilos == 0)
		{
			list_remove_and_destroy_element(lista_handle_hilos_finalizados,i,free);
		}
		i++;
		suma_hilos = 0;
		hilo_pid_finalizar = list_get(lista_handle_hilos_finalizados,i);
	}

	pthread_mutex_unlock(&mutex_lista_handle_hilos_finalizados);

	return;
}

/*
 * Busca en la lista de hilos dado un PID.
 * Devuelve -> 0 -> NO ESTA;
 * Devuelve -> 1 -> ESTA;
 */
int32_t esta_en_lista_handle_hilos_finalizados_PID(int32_t PID_hilo_buscar)
{
	int32_t i = 0;

	pthread_mutex_lock(&mutex_lista_handle_hilos_finalizados);

	int32_t size = list_size(lista_handle_hilos_finalizados);

	t_pid_hilo_finalizar* hilo_pid_finalizar = list_get(lista_handle_hilos_finalizados,i);

	while(i < size)
	{
		if(hilo_pid_finalizar->pid_hilo_finalizar == PID_hilo_buscar)
		{
			pthread_mutex_unlock(&mutex_lista_handle_hilos_finalizados);
			return 1;
		}
		i++;
		hilo_pid_finalizar = list_get(lista_handle_hilos_finalizados,i);
	}

	pthread_mutex_unlock(&mutex_lista_handle_hilos_finalizados);
	return 0;
}

/*
 * Agrega a la lista de handle de hilos finalizados el PID correspondiente usando mutex
 * si no esta agregado.
 * Si esta agregado no hace nada
 */
void agregar_a_lista_handle_hilos_finalizados_mutex(int32_t PID_Hilo)
{
	pthread_mutex_lock(&mutex_lista_handle_hilos_finalizados);

	int32_t i = 0;
	t_pid_hilo_finalizar *hilo_fin_buscar_existente = list_get(lista_handle_hilos_finalizados,i);
	int32_t size_cola = list_size(lista_handle_hilos_finalizados);

	//Me fijo si esta agregado para no volver a agregarlo
	while (i < size_cola)
	{
		if(hilo_fin_buscar_existente->pid_hilo_finalizar == PID_Hilo)
		{
			pthread_mutex_unlock(&mutex_lista_handle_hilos_finalizados);
			return;
		}
		i++;
		hilo_fin_buscar_existente = list_get(lista_handle_hilos_finalizados,i);
	}
	//Si no existe lo agrego
	t_pid_hilo_finalizar *hilo_finalizar_pid= malloc(sizeof(t_pid_hilo_finalizar));
	hilo_finalizar_pid->pid_hilo_finalizar = PID_Hilo;
	//
	list_add(lista_handle_hilos_finalizados,hilo_finalizar_pid);
	//
	pthread_mutex_unlock(&mutex_lista_handle_hilos_finalizados);
	return;
}


/*	Funcion que cuenta la cantidad de hilos hijos que tiene un proceso
 * 	devolviendo 0 si no hay ninguno
 * 	o un valor mayor a 0 si hay alguno/s
 */

int32_t cantidad_hilos_existentes (t_hilo_proceso *hilo_a_finalizar)
{
	int32_t cantidad_hilos_hijos = 0;
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_New,hilo_a_finalizar,&mutex_cola_New);
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_Block,hilo_a_finalizar,&mutex_cola_Block);
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_Block_Join,hilo_a_finalizar,&mutex_cola_Block_Join);
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_Block_Recurso,hilo_a_finalizar,&mutex_cola_Block_Recurso);
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_Exit,hilo_a_finalizar,&mutex_cola_Exit);
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_Ready,hilo_a_finalizar,&mutex_cola_Ready);
	cantidad_hilos_hijos = cantidad_hilos_hijos + esta_en_cola(cola_Exec,hilo_a_finalizar,&mutex_cola_Exec);

	return cantidad_hilos_hijos;
}


/*
 * 	Quita todos los hilos hijos de un hilo principal de todas las colas menos de Cola_Exec
 * 	Debido a que estan en ejecucion.
 */

void mover_hilos_hijos_no_exec_exit(t_hilo_proceso *hilo_a_finalizar)
{
	/*

	ACA VA EL MOVIMIENTO DE TODO A EXIT -> ASI FINALIZO TODOS LOS SEGMENTOS DE STACK
	EL SEGMENTO DE CODIGO LO VA AFINALIZAR EL PRINCIPAL
	*/

	quita_por_PID_de_Cola(cola_New,hilo_a_finalizar->hilo.pid,&mutex_cola_New);
	quita_por_PID_de_Cola(cola_Ready,hilo_a_finalizar->hilo.pid,&mutex_cola_Ready);
	quita_por_PID_de_Cola(cola_Block,hilo_a_finalizar->hilo.pid,&mutex_cola_Block);
	quita_por_PID_de_Cola(cola_Block_Join,hilo_a_finalizar->hilo.pid,&mutex_cola_Block_Join);
	quita_por_PID_de_Cola(cola_Block_Recurso,hilo_a_finalizar->hilo.pid,&mutex_cola_Block_Recurso);
	quita_por_PID_de_Cola(cola_Exit,hilo_a_finalizar->hilo.pid,&mutex_cola_Exit);
	return;
}


/*
 * Funcion encargada de buscar los hilos y finalizarlos.
 * En caso de errores se encarga de manejar el error marcando al hilo para que termine de ejecutar sus otro hilos.
 * Se encarga de mandar a Exit el hilo que se paso con el estado pasado.
 * <-------------------------------------ESTADOS DE SALIDA--------------------------------------------------------->
 * FIN_QUANTUM,FIN_HILO,FIN_PROCESO,FALLO_CONEXION_CPU,FALLO_CONEXION_CONSOLA,FALLO_CONEXION_MSP
 *,FALLO_MEMORY_OVERLOAD,FALLO_SEGMENTATION_FAULT,FALLO_INSTRUCCION,FALLO_DIVISION_CERO
 *,FALLO_HILO_FIN,FALLO_FIN_HILO_PADRE
 */

void funcion_handle_hilos_finalizados (t_hilo_proceso *hilo_handlear, estado_exit estado_handlear)
{
	log_info(Log_Kernel_Planificador,"Exec->Exit(P:%d|T:%d)",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);

	if (estado_handlear == FIN_PROCESO)
	{
		if (cantidad_hilos_existentes(hilo_handlear) == 0)
		{
			//No tiene hilos hijos-> Fin normal del proceso
			hilo_handlear->estado_salida = estado_handlear;
			hilo_handlear->hilo.cola = EXIT;
			log_info(Log_Kernel_Temporal,"Fin de Proceso del TCB->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		}
		else
		{
			//Tiene hilos hijos -> Fin Anormal del proceso
			hilo_handlear->estado_salida = FALLO_FIN_HILO_PADRE;
			hilo_handlear->hilo.cola = EXIT;
			//Quita todos los hilos hijos por aqui
			mover_hilos_hijos_no_exec_exit(hilo_handlear);
			//Agrego en la lista de PID's el perteneciente al proceso
			agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
			log_info(Log_Kernel_Temporal,"Fin de Proceso(Fallo porque quedaban hilos)->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);

		}
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	if (estado_handlear == FIN_HILO)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		//
		log_info(Log_Kernel_Temporal,"Fin de Hilo del TCB->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Agrego a la lista para ver los joins
		agregar_lista_join(hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//
		//
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		//
		sem_post(&sem_cola_Block);
		return;
	}

	if (estado_handlear == FALLO_FIN_HILO_PADRE)
	{
		//Tiene hilos hijos -> Fin Anormal del proceso
		hilo_handlear->hilo.cola = EXIT;
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		//
		hilo_handlear->estado_salida = estado_handlear;
		log_info(Log_Kernel_Temporal,"Fin de Hilo del TCB->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	if (estado_handlear == FALLO_HILO_FIN)
	{
		//Quita todos los hilos hijos por aqui
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"Fallo hilo(Expropiacion CPU)->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}


	if (estado_handlear == FALLO_CONEXION_CONSOLA)
	{
		//Me fijo si hay mas segmentos en la cola de Exec -> El ultimo es el encargado de finalizar los segmentos
		//debido al FALLO DE CONSOLA
		if (esta_en_cola(cola_Exec,hilo_handlear,&mutex_cola_Exec) == 0)
		{
			//No lo encuentra -> Finalizo segmentos
			hilo_handlear->estado_salida = estado_handlear;
			hilo_handlear->hilo.cola = EXIT;
			log_info(Log_Kernel_Temporal,"FALLO_CONEXION_CONSOLA->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
			//Quita todos los hilos hijos por aqui
			mover_hilos_hijos_no_exec_exit(hilo_handlear);
			//Agrego en la lista de PID's el perteneciente al proceso
			agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
			agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
			sem_post(&sem_cola_Exit);
			return;
		}
		else
		{
			//Si lo encuentra -> Free del TCB
			hilo_handlear->estado_salida = FALLO_HILO_FIN;
			hilo_handlear->hilo.cola = EXIT;
			log_info(Log_Kernel_Temporal,"FALLO_HILO_FIN(FALLO_CONEXION_CONSOLA)->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
			//Agrego en la lista de PID's el perteneciente al proceso
			agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
			agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
			sem_post(&sem_cola_Exit);
			return;
		}
	}

	if (estado_handlear == FALLO_CONEXION_CPU)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"FALLO_CONEXION_CPU->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	if (estado_handlear == FALLO_CONEXION_MSP)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"FALLO_CONEXION_MSP->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);

		return;
	}

	if (estado_handlear == FALLO_INSTRUCCION)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"FALLO_INSTRUCCION->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	if (estado_handlear == FALLO_DIVISION_CERO)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"FALLO_DIVISION_CERO->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	if (estado_handlear == FALLO_MEMORY_OVERLOAD)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"FALLO_MEMORY_OVERLOAD->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	if (estado_handlear == FALLO_SEGMENTATION_FAULT)
	{
		hilo_handlear->estado_salida = estado_handlear;
		hilo_handlear->hilo.cola = EXIT;
		log_info(Log_Kernel_Temporal,"FALLO_SEGMENTATION_FAULT->P:%d->T:%d",hilo_handlear->hilo.pid,hilo_handlear->hilo.tid);
		//Quita todos los hilos hijos por aqui
		mover_hilos_hijos_no_exec_exit(hilo_handlear);
		//Agrego en la lista de PID's el perteneciente al proceso
		agregar_a_lista_handle_hilos_finalizados_mutex(hilo_handlear->hilo.pid);
		agregar_en_cola(cola_Exit,hilo_handlear,&mutex_cola_Exit);
		sem_post(&sem_cola_Exit);
		return;
	}

	return;
}




/*
 * 	Quita de la cola de blockeados por system call el hilo de syscall global (Con PID y TID)
 */

t_hilo_proceso *quitar_de_cola_block_coindice_syscallglobal (int32_t pid_a_quitar, int32_t tid_a_quitar)
{
	int32_t i = 0;

	t_hilo_proceso *pasar_hilo_a_ready = list_get(cola_Block->elements,i);

	int32_t size = size_de_cola(cola_Block,&mutex_cola_Block);

	pthread_mutex_lock(&mutex_cola_Block);

	while(i < size)
	{
		if(pasar_hilo_a_ready->hilo.pid == pid_a_quitar && pasar_hilo_a_ready->hilo.tid == tid_a_quitar)
		{
			//Los que no estan en las colas de exec los mando a exit para que finalizen sus segmentos
			pasar_hilo_a_ready = list_remove(cola_Block->elements,i);
			pthread_mutex_unlock(&mutex_cola_Block);
			return pasar_hilo_a_ready;
		}
		i++;
		pasar_hilo_a_ready = list_get(cola_Block->elements,i);
	}
	pthread_mutex_unlock(&mutex_cola_Block);
	return NULL;
}












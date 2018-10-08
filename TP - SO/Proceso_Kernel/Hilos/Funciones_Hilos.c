#include"Funciones_Hilos.h"

/*
 *	Te devuelve el Hilo de KM = 1, si este esta libre en la cola
 */

void* esta_en_cola_Hilo_KM(t_queue *cola_en_que_buscar,pthread_mutex_t *mutex_de_cola)
{
	int32_t i = 0;

	t_hilo_proceso *hilo_que_buscar = list_get(cola_en_que_buscar->elements,i);
	int32_t size = size_de_cola(cola_en_que_buscar,mutex_de_cola);

	//Mutex a la cola para que no se agrege/quite nada
	pthread_mutex_lock(mutex_de_cola);
	while(i < size)
	{
		if(hilo_que_buscar->hilo.kernel_mode ==1)
		{
			hilo_que_buscar = list_remove(cola_en_que_buscar->elements,i);
			pthread_mutex_unlock(mutex_de_cola);
			return hilo_que_buscar;
		}
		i++;
		hilo_que_buscar = list_get(cola_en_que_buscar->elements,i);
	}
	pthread_mutex_unlock(mutex_de_cola);
	return NULL;
}


/*
 * 	Se fija si en la cola esta el elemento t_hilo_proceso
 * 	Retorna 0 -> Si no lo encuentra
 * 	Retorna 1 -> Si lo encuentra
 */

int32_t esta_en_cola(t_queue* cola_en_donde_buscar,t_hilo_proceso* que_buscar,pthread_mutex_t* mutex_cola)
{
	int32_t i = 0;

	t_hilo_proceso *hilo_que_buscar = list_get(cola_en_donde_buscar->elements,i);
	int32_t size = size_de_cola(cola_en_donde_buscar,mutex_cola);

	//Mutex a la cola para que no se agrege/quite nada
	pthread_mutex_lock(mutex_cola);
	while(i < size)
	{
		if(hilo_que_buscar->hilo.pid == que_buscar->hilo.pid && hilo_que_buscar->hilo.tid != que_buscar->hilo.tid
				&& hilo_que_buscar->hilo.kernel_mode == 0)
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
 * Agrega en una cola un elemento pero haciendo mutex de la cola
 */

void agregar_en_cola(t_queue* cola_en_donde_agregar,void* que_agregar,pthread_mutex_t* mutex_cola)
{
	pthread_mutex_lock(mutex_cola);

	queue_push(cola_en_donde_agregar,que_agregar);

	pthread_mutex_unlock(mutex_cola);

	return;
}

/*
 * Quita de una cola un elemento pero haciendo mutex de la cola
 */

void* quitar_de_cola(t_queue* cola_en_donde_agregar,pthread_mutex_t* mutex_cola)
{
	pthread_mutex_lock(mutex_cola);

	void* quitado = queue_pop(cola_en_donde_agregar);

	pthread_mutex_unlock(mutex_cola);

	return quitado;
}

/*
 * Size de una cola un elemento pero haciendo mutex de la cola
 */

int32_t size_de_cola(t_queue* cola_en_donde_agregar,pthread_mutex_t* mutex_cola)
{
	pthread_mutex_lock(mutex_cola);

	int32_t size_cola_a_devolver = queue_size(cola_en_donde_agregar);

	pthread_mutex_unlock(mutex_cola);

	return size_cola_a_devolver;
}

/*
 * Te devuelve un t_hilo_proceso dado un socket_fd de una CPU y una cola
 * return p_hilo_proceso -> Devuelve el Hilo buscado para poder enviarlo a otra cola
 * return NULL -> No existe mas el hilo proceso que se mando a ejecutar
 */

t_hilo_proceso *dameProcesoHilo (t_queue *cola, int32_t socket_fd,pthread_mutex_t* mutex_cola)
{
	int32_t i = 0;
	t_hilo_proceso *p_hilo_proceso = list_get(cola->elements,i);

	pthread_mutex_lock(mutex_cola);

	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->socket_CPU == socket_fd)
		{
			//DEBO SACARLO DE LA COLA
			pthread_mutex_unlock(mutex_cola);
			p_hilo_proceso = list_remove(cola->elements,i);
			return p_hilo_proceso;
		}
		i++;
		p_hilo_proceso = list_get(cola->elements,i);
	}
	pthread_mutex_unlock(mutex_cola);
	return NULL;
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

//Calcula el tamaño del fichero fp, incluyendo a EOF
int32_t calcularTamFile(FILE *fp)
{
	fseek(fp,0L,SEEK_END);
	return (ftell(fp)+1);
}

//Recorro el archivo desde el principio copiando cada caracter, inclusive el EOF
char* caracteresFile(FILE *fp)
{
	int length = calcularTamFile(fp);

	fseek (fp, 0, SEEK_SET);

	char* buffer = malloc (length);

	if (buffer)
	{
	  fread (buffer, 1, length, fp);
	}

	return buffer;
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

void imprimir_elementos_cola(t_queue *cola_a_imprimir, pthread_mutex_t *mutex_cola_a_imprimir)
{
	int32_t i = 0;
	pthread_mutex_lock(mutex_cola_a_imprimir);
	t_hilo_proceso *p_hilo_proceso = list_get(cola_a_imprimir->elements,i);

	printf("Elementos de Cola->\n");

	while(p_hilo_proceso != NULL)
	{
		printf("Orden:%d|PID:%d|TID:%d\n",i,p_hilo_proceso->hilo.pid,p_hilo_proceso->hilo.tid);
		i++;
		p_hilo_proceso = list_get(cola_a_imprimir->elements,i);
	}
	pthread_mutex_unlock(mutex_cola_a_imprimir);

	return;
}

int32_t quitaSocketfdColaConexiones(int32_t socket_fd,t_queue* cola,pthread_mutex_t* mutex_cola)
{
	int32_t i = 0;

	int32_t p_socket_fd = (int32_t) list_get(cola->elements,i);
	int32_t size = size_de_cola(cola,mutex_cola);

	while(i < size)
	{
		if(p_socket_fd == socket_fd)
		{
			list_remove(cola->elements,i);
			return 0;
		}
		i++;
		p_socket_fd = (int32_t) list_get(cola->elements,i);
	}
	return -1;
}

/*
 * Dado un socket_fd de consola te devuelve el PID del hilo que fue creado por esa consola para
 * poder ser eliminado junto con sus hijos y segmentos
 * Retorna -1 -> No existe ningun hilo que posea ese socket_fd
 * Retorna > 0 -> PID del hilo
 */

int32_t damePIDporSockFDConsola  (t_queue *cola, int32_t socket_fd_Consola,pthread_mutex_t *mutex_cola)
{
	int32_t i = 0;
	pthread_mutex_lock(mutex_cola);
	t_hilo_proceso *p_hilo_proceso = list_get(cola->elements,i);

	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->socket_Consola == socket_fd_Consola)
		{
			//DEBO SACARLO DE LA COLA
			pthread_mutex_unlock(mutex_cola);
			return p_hilo_proceso->hilo.pid;
		}
		i++;
		p_hilo_proceso = list_get(cola->elements,i);
	}
	pthread_mutex_unlock(mutex_cola);
	return -1;
}

/*
 * Te devuelve un t_hilo_proceso (o NULL si no encuentra nada) dado un socket_fd de una CONSOLA, una cola
 * en la que buscar y su mutex.
 */

t_hilo_proceso *dameProcesoHiloporSockFDConsola (t_queue *cola, int32_t socket_fd_Consola,pthread_mutex_t *mutex_cola)
{
	int32_t i = 0;
	pthread_mutex_lock(mutex_cola);
	t_hilo_proceso *p_hilo_proceso = list_get(cola->elements,i);

	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->socket_Consola == socket_fd_Consola)
		{
			//DEBO SACARLO DE LA COLA
			pthread_mutex_unlock(mutex_cola);
			list_remove(cola->elements,i);
			return p_hilo_proceso;
		}
		i++;
		p_hilo_proceso = list_get(cola->elements,i);
	}
	pthread_mutex_unlock(mutex_cola);
	return NULL;
}

void marcaEstadoSalidaPorPID (t_queue *cola, int32_t PID_a_marcar,pthread_mutex_t *mutex_cola,estado_exit estado_salida_marcar)
{
	int32_t i = 0;
	pthread_mutex_lock(mutex_cola);
	t_hilo_proceso *p_hilo_proceso = list_get(cola->elements,i);

	while(p_hilo_proceso != NULL)
	{
		if(p_hilo_proceso->hilo.pid == PID_a_marcar)
		{
			p_hilo_proceso->estado_salida = estado_salida_marcar;
		}
		i++;
		p_hilo_proceso = list_get(cola->elements,i);
	}
	pthread_mutex_unlock(mutex_cola);

	return;
}

/*
 * Imprime todos los t_hilo de una cola determinada
 */

void imprime_t_Hilos_PorColaMutex(t_queue *cola,pthread_mutex_t *mutex_cola)
{
	t_list *lista_t_hilos_imprimir = list_create();

	int32_t i = 0;

	pthread_mutex_lock(mutex_cola);

	t_hilo_proceso *p_hilo_proceso = list_get(cola->elements,i);

	if(p_hilo_proceso == NULL)
	{
		pthread_mutex_unlock(mutex_cola);
		printf("Hilos ejecutando: []\n");
		return;
	}

	while(p_hilo_proceso != NULL)
	{
		t_hilo *hilo_aux_imprimir = malloc(sizeof(t_hilo));

		memcpy(hilo_aux_imprimir,&(p_hilo_proceso->hilo),sizeof(t_hilo));

		list_add(lista_t_hilos_imprimir,hilo_aux_imprimir);

		i++;

		p_hilo_proceso = list_get(cola->elements,i);
	}
	pthread_mutex_unlock(mutex_cola);
	//
	//Imprimo los hilos que tenia la cola
	//
	hilos(lista_t_hilos_imprimir);
	//
	//
	list_destroy_and_destroy_elements(lista_t_hilos_imprimir,free);

	return;
}


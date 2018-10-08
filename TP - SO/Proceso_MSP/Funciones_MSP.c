#include"Funciones_MSP.h"

//Globales
#define Path_Log_MSP "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_MSP/MSP.log"
#define Path_Config_MSP "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_MSP/Config_MSP"
#define TAM_PAGINAS 256;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void inicializar_tabla_marcos() {
	int tam_tabla = 0;

	cant_marcos = (cant_memoria * 1024) / 256;

	t_mem dir;
	dir.segmento = 0;
	dir.pagina = 0;
	dir.offset = 0;

	while (tam_tabla < cant_marcos) {
		list_add(tabla_marcos, agregar_marcos_algoritmos(-1, dir, &tam_tabla));
	}
}


t_algoritmo* agregar_marcos_algoritmos(int PID, t_mem direc, int* tam_tabla) {

	t_algoritmo *new = malloc(sizeof(t_algoritmo));
	new->PID = PID;
	new->memoria = direc;
	new->index = (*tam_tabla);
	new->bitMod = 0;
	if(new->index == 0)
	{
		new->bitPuntero = 1;
	}
	else
	{
		new->bitPuntero = 0;
	}
	new->bitUso = 0;

	(*tam_tabla)++;

	return new;
}

TS* agregar_segmento(int PID, t_mem base_seg, int tamano, int* TP,
		int cant_pags) {

	TS *new = malloc(sizeof(TS));
	new->PID = PID;
	new->base_seg = base_seg;
	new->tamano = tamano;
	new->TP = TP;
	new->cant_pags = cant_pags;

	return new;
}

int calcular_len_TP(int32_t tamano) {
	int len = tamano / TAM_PAGINAS
	;

	if (tamano % 256 > 0)
		len++;

	return len;
}

void inicializar_TP(int* TP, int len_TP) {
	int pos = 0;

	while (pos < len_TP) {
		TP[pos] = -1;
		pos++;
	}
}


uint32_t memoria_ocupada() {

	uint32_t retorno = 0;

	int sumar_tamano_segmento(TS *p) {
		if (1) {
			retorno += p->tamano;
			return 1;
		}
		return 0;
	}

	list_iterate(tabla_segmentos, (void*) sumar_tamano_segmento);
	return retorno;
}

uint32_t crear_segmento(uint32_t PID, uint32_t tamano) {
	t_mem base_seg;

	//if (cant_memoria  + cant_swapp	< memoria_ocupada() + archivos_en_disco * 256)
	//Agrege el 1024 porque se esta multiplicando por ese valor cuando se levanta la memoria

	if (cant_memoria * 1024 + cant_swapp * 1024
			<= memoria_ocupada() + archivos_en_disco * 256) {
		log_error(logs, "Memoria total llena");
		return -3;
	}

	if (PID < 0) {
		log_error(logs, "Numero de segmento invalido");
		return -1;
	}

	if (tamano > 1048576 || tamano < 1) {
		log_error(logs, "Tamano de segmento invalido");
		return -2;
	}
	t_list *aux = tabla_segmentos;

	//CREACION TABLA DE PAGINAS
	int len_TP = calcular_len_TP(tamano);
	int cant_pags = calcular_len_TP(tamano);
	int* TP = malloc(4096 * sizeof(int));
	inicializar_TP(TP, len_TP);

	//PRIMER SEGMENTO
	if (tabla_segmentos->elements_count == 0) {
		base_seg.segmento = 0;
		base_seg.pagina = 0;
		base_seg.offset = 0;
		list_add(aux, agregar_segmento(PID, base_seg, tamano, TP, cant_pags));
		log_info(logs, "Se creo correctamente el segmento %d del PID %d",
				base_seg.segmento, PID);
	}
	//PRIMER SEGMENTO DE PROCESO NUEVO

	else {
		int donde_esta_PID(TS *p) {
			return p->PID == PID;
		}

		TS* elem = list_find(tabla_segmentos, (void*) donde_esta_PID);

		if (elem == 0) {
			base_seg.segmento = 0;
			base_seg.pagina = 0;
			base_seg.offset = 0;
			list_add(aux,
					agregar_segmento(PID, base_seg, tamano, TP, cant_pags));
			log_info(logs, "Se creo correctamente el segmento %d del PID %d",
					base_seg.segmento, PID);
		}

		//SEGMENTO DE PROCESO EXISTENTE

		else {
			int mayor = 0;

			int buscar_mayor_segmento(TS *p) {
				if (PID == p->PID && mayor < p->base_seg.segmento) {
					mayor = p->base_seg.segmento;
					return 1;
				}
				return 0;
			}

			list_iterate(tabla_segmentos, (void*) buscar_mayor_segmento);

			base_seg.segmento = mayor + 1;
			base_seg.pagina = 0;
			base_seg.offset = 0;

			list_add(aux,
					agregar_segmento(PID, base_seg, tamano, TP, cant_pags));
			log_info(logs, "Se creo correctamente el segmento %d del PID %d",
					base_seg.segmento, PID);
		}
	}

	int comparador(TS *pri, TS *segun) {
		return pri->PID == segun->PID ?
				pri->base_seg.segmento < segun->base_seg.segmento :
				pri->PID < segun->PID;
	}

	list_sort(tabla_segmentos, (void*) comparador);

	return t_mem_a_dir(base_seg);

}

int destruir_segmento(uint32_t PID, uint32_t base_seg_uint) {

	t_mem base_seg = dir_a_t_mem(base_seg_uint);

	if (base_seg.offset != 0 || base_seg.pagina != 0) {
		log_error(logs, "No corresponde a una base de segmento");
		return -1;
	}

	int i = 0;

	int coinciden_PID_y_base_seg(TS *p) {
		return (base_seg.segmento == p->base_seg.segmento && PID == p->PID);
	}

	TS* segmento = list_find(tabla_segmentos, (void*) coinciden_PID_y_base_seg);

	if (segmento == 0) {
		log_error(logs, "Segmento o proceso no encontrado");
		return -2;
	}

	while (i < segmento->cant_pags) {

		//puts("pre entrada a comparador");
		if (segmento->TP[i] >= 0)
		{
			int busqueda_de_indice(t_algoritmo *p)
			{
				return (p->index == segmento->TP[i]);
			}

			t_algoritmo* marco = list_find(tabla_marcos, (void*) busqueda_de_indice);
			t_mem dir_aux;
			dir_aux.segmento = 0;
			dir_aux.pagina = 0;
			dir_aux.offset = 0;
			marco->PID = -1;
			marco->memoria = dir_aux;

		}
		//puts("pre entrada a -2");
		if (segmento->TP[i] == -2)
		{
			//puts("entro");
			t_mem dir_logica;
			dir_logica.segmento = segmento->base_seg.segmento;
			dir_logica.pagina = i;
			dir_logica.offset = 0;

			//puts("predeswapeo");
			destruir_archivo(segmento->PID, dir_logica);
		}
		log_info(logs,"Segmento:%d->Pagina:%d->Eliminada",segmento->PID,i);
		i++;
	}

	list_remove_by_condition(tabla_segmentos, (void*) coinciden_PID_y_base_seg);

	log_info(logs, "Se destruyo correctamente el segmento %d del PID %d",
			base_seg.segmento, PID);
	return 0;
}


void destruir_archivo(int PID, t_mem direc) {

	char* archivo_nom = string_new();
	string_append(&archivo_nom,"swap/");
	char* PID_string = malloc(sizeof(char));
	sprintf(PID_string, "%d", PID);
	char* segmento_string = malloc(sizeof(char));
	sprintf(segmento_string, "%d", direc.segmento);
	char* pagina_string = malloc(sizeof(char));
	sprintf(pagina_string, "%d", direc.pagina);

	string_append(&archivo_nom, PID_string);
	string_append(&archivo_nom, "-");
	string_append(&archivo_nom, segmento_string);
	string_append(&archivo_nom, pagina_string);
	string_append(&archivo_nom, ".txt");

	if (remove(archivo_nom) == 0)
		log_info(logs, "Archivo %s eliminado", archivo_nom);
	else
		log_error(logs, "Error eliminando el archivo %s", archivo_nom);

	archivos_en_disco--;
}

void leer_archivo(char* archivo_nom, char* texto) {
	FILE* file = NULL;

	file = fopen(archivo_nom, "r");
/*
	char c;

	int i = 0;

	while ((c = fgetc(file)) != EOF) {
		texto[i] = c;
		i++;
	}
	texto[i] = '\0';
*/
	int32_t calcularTamFile(FILE *fp)
	{
		fseek(fp,0L,SEEK_END);
		return (ftell(fp)+1);
	}
	//Recorro el archivo desde el principio copiando cada caracter, inclusive el EOF

	int length = calcularTamFile(file);

	fseek (file, 0, SEEK_SET);

	char* buffer = malloc (length);

	if (buffer)
	{
	  fread (buffer, 1, length, file);
	}

	memcpy(texto,buffer,256);

}

/*
 * Dado un void* texto, con el PID y la direccion puedo encontrar la pagina que fue swapeada al disco
 * En caso de error -> Se logea y va a fallar luego;
 */

void deswappear(int PID, t_mem direc, void* texto) {

	char* archivo_nom = string_new();
	string_append(&archivo_nom,"swap/");
	char* PID_string = malloc(sizeof(char));
	sprintf(PID_string, "%d", PID);
	char* segmento_string = malloc(sizeof(char));
	sprintf(segmento_string, "%d", direc.segmento);
	char* pagina_string = malloc(sizeof(char));
	sprintf(pagina_string, "%d", direc.pagina);

	string_append(&archivo_nom, PID_string);
	string_append(&archivo_nom, "-");
	string_append(&archivo_nom, segmento_string);
	string_append(&archivo_nom, pagina_string);
	string_append(&archivo_nom, ".txt");

	FILE* file = NULL;

	int pagina_size = TAM_PAGINAS;

	file = fopen(archivo_nom, "r");

	if (file == NULL ) {
		log_error(logs, "Error al leer el archivo swappeado");
	}
	else
	{
		//Uso Fread directamente-> Para usar el void* y evitar que se corte el texto
		if(fread(texto,sizeof(char),pagina_size,file) != pagina_size)
		{
			perror("fread");
			exit(1);
		}
	}

	if (remove(archivo_nom) == 0)
		log_info(logs,"Deswapeado->%s\n", archivo_nom);
	else
		log_error(logs, "Error eliminando el archivo %s.\n", archivo_nom);

	archivos_en_disco--;
}

/*
 * Memoria -> Direccion logica
 */
uint32_t t_mem_a_dir(t_mem estructura) {
//Movemos los bits necesarios
	uint32_t seg = (estructura.segmento << 20);
	uint32_t pag = (estructura.pagina << 8);
	uint32_t off = estructura.offset;

//Juntamos
	uint32_t direccion = (seg | pag | off);

	return direccion;
}
/*
 * Direccion logica -> Memoria
 */
t_mem dir_a_t_mem(uint32_t direccion) {
	t_mem estructura;

	estructura.segmento = direccion >> 20;
	estructura.pagina = direccion >> 8;
	estructura.offset = direccion;

	return estructura;
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Leer de memoria y guarda en buffer lo leido.
 * Lee desde una direccion, con un PID y un determinado tamaño.
 * Se encarga de swapear en caso de no estar en un Marco.
 */
int leer_memoria_algoritmo(void* buffer, uint32_t PID, uint32_t direc,
		uint32_t tamano) {

	t_mem dir_logica = dir_a_t_mem(direc);

	if (dir_logica.offset + tamano > 256) {
		log_error(logs, "Hubo segmentation fault");
		return -1;
	}

	if (dir_logica.offset < 0) {
		log_error(logs, "Offset negativo");
		return -1;
	}

	t_mem base_seg;
	base_seg.segmento = dir_logica.segmento;
	base_seg.pagina = 0;
	base_seg.offset = 0;

	int donde_esta_segmento(TS *p) {
		return (p->PID == PID) && (p->base_seg.segmento == base_seg.segmento);
	}

	TS* segmento = list_find(tabla_segmentos, (void*) donde_esta_segmento);

	int indice = 0;

	if (segmento == NULL) {
		log_error(logs, "Segmento o proceso no existente");
		return -1;
	}

	if (segmento->cant_pags < dir_logica.pagina || dir_logica.pagina < 0) {
		log_error(logs, "Pagina no existente");
		return -1;
	}

	//Agrego esto para ver que no se pase de segmento -> (Pagina * 256 + offset < tamaño del segmento -> sino esta fuera)
	if ((dir_logica.pagina) * 256 + dir_logica.offset > segmento->tamano) {
		log_error(logs, "Segmentation Fault(Direccion Fuera del segmento)");
		return -1;
	}

	if (segmento->TP[dir_logica.pagina] == -1) { ///////////Vemos si la pagina ha sido asignada a un marco anteriormente

		log_error(logs, "Pagina no escrita");
		return -1;

	} else if (segmento->TP[dir_logica.pagina] == -2) { ///////////////////Esta en disco?/////////////////

		//Agrego -> Direccion logica de la pagina que quiero escribir;
		t_mem dir_pagina_swapeada;
		dir_pagina_swapeada.offset = 0;
		dir_pagina_swapeada.segmento = dir_logica.segmento;
		dir_pagina_swapeada.pagina = dir_logica.pagina;	//Que pagina del segmento deswapear

		//char texto[256];
		int size_pagina = TAM_PAGINAS;
		void* texto = malloc(size_pagina);

		deswappear(PID, dir_pagina_swapeada, texto);

		//Luego de traerla al buffer -> La voy a escribir en un marco -> La funcion se encarga
		buscar_asignar_y_escribir_marcos_algoritmo(PID, dir_pagina_swapeada, size_pagina, texto, //Cambie tamano -> size_pagina
						segmento,&indice);
		//Libero el texto ya guardado
		free(texto);

		//Copio del marco lo necesario
		int inicio = (indice * 256) + dir_logica.offset;

		//
		//Actualizar el Marco (Agregado)
		if(algoritmo == 2)
		{
			t_algoritmo *Marco = list_get(tabla_marcos,indice);
			Marco->bitUso = 1;
			Marco->bitMod = 0;
		}
		//(Agregado)
		//

		memcpy(buffer, memoria_principal + inicio, tamano);

		return 0;

	} else { ////////////Ya tiene un marco asignado?////////////////////

		int buscar_marco(t_algoritmo *p) {
			return (p->memoria.segmento == dir_logica.segmento
					&& p->memoria.pagina == dir_logica.pagina && p->PID == PID);
		}

		t_algoritmo* marco = list_find(tabla_marcos, (void*) buscar_marco);

		//
		//Actualizar el Marco (Agregado)
		if(algoritmo == 2)
		{
			t_algoritmo *Marco = list_get(tabla_marcos,indice);
			Marco->bitUso = 1;
		}
		//(Agregado)
		//

		int inicio = (marco->index * 256) + dir_logica.offset;

		memcpy(buffer, memoria_principal + inicio, tamano);

		return 0;
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////ALGORITMOS DE REEMPLAZO DE PAGINAS///////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

unsigned int aplicar_algoritmo()
{
	int c;
	int tam = TAM_PAGINAS;
	c = elegir_marco_victima();
	char *nombreArch = armar_nombre(list_get(tabla_marcos,c));
	//Saco el strdup porque no levanta el file
	FILE *page = fopen(nombreArch, "wb+");
	//
	if(page == NULL)
	{
		printf("Path:%s\n",nombreArch);
		perror("fopen");
		exit(1);
	}
	//
	//Cambio char* buffer = malloc(tam); -> void* buffer -> Para que lea los caracteres no imprimibles;
	void* buffer = malloc(tam);
	//Agrego multiplicado por (Nro Marco * TAM_PAGINA) -> Sino siempre quita el 1° marco;
	memcpy(buffer, memoria_principal + (c * tam), tam);
	bzero(memoria_principal + (c * tam), tam);
	//
	if (fwrite(buffer, sizeof(char), tam, page) != tam)
	{
		printf("Path:%s\n",nombreArch);
		perror("fwrite");
		exit(1);
	}
	//
	marcar_pagina_en_2(list_get(tabla_marcos,c));
	log_info(logs,"Swap_File:%s",nombreArch);
	fclose(page);
	free(buffer);
	free(nombreArch);
	return c;
}

int elegir_marco_victima()
{
	int numMarco;
	//t_algoritmo *firstOut;
	switch(algoritmo)
	{
		//case 1: firstOut = list_get(tabla_marcos, 0);
		//numMarco = firstOut->index;
		case 1: numMarco = firstOut_FIFO();
		break;
		case 2: numMarco = vueltas_Clock();
		break;
	}
	return numMarco;
}
/*
 * Algoritmo FIFO
 */
int firstOut_FIFO()
{
	//Busco donde esta el puntero
	int dameIndexPuntero(t_algoritmo *p)
	{
		return (p->bitPuntero == 1);
	}
	t_algoritmo *firstOut =	list_find(tabla_marcos, (void*) dameIndexPuntero);
	//Devuelvo este INDEX
	int index_FIFO = firstOut->index;
	//Pongoo el anterior en 0;
	firstOut->bitPuntero = 0;
	//
	//Avanzo el Puntero del index
	//
	if((index_FIFO + 1) == (cant_marcos - 1))	//cant_marcos - 1 -> Index del Marco
	{
		t_algoritmo *avanzo_puntero = list_get(tabla_marcos,0);
		avanzo_puntero->bitPuntero = 1;
	}
	else
	{
		t_algoritmo *avanzo_puntero = list_get(tabla_marcos,index_FIFO + 1);
		avanzo_puntero->bitPuntero = 1;
	}
	//
	return index_FIFO;
}

/*
 * Algoritmo de Clock Modificado
 */

int primera_vuelta_Clock()
{
	//int i, cantMarcos = cant_memoria * 4;

	//Busco donde esta el puntero
	int dameIndexPuntero(t_algoritmo *p)
	{
		return (p->bitPuntero == 1);
	}
	//
	t_algoritmo *puntero_donde = list_find(tabla_marcos, (void*) dameIndexPuntero);
	//Guardo el puntero para ver como me muevo
	int j = puntero_donde->index;
	//
	int i, cantMarcos = cant_marcos;
	t_algoritmo* punt_marco;
	//
	for(i = 0; i < cantMarcos; i++)
	{
		//
		punt_marco = list_get(tabla_marcos,j);
		//
		if (punt_marco->bitUso == 0 && punt_marco->bitMod == 0)
		{
			//Puntero que voy a sacar -> 0
			punt_marco->bitPuntero = 0;
			//Puntero siguiente es -> 1
			if((punt_marco->index + 1) == (cant_marcos - 1))	//cant_marcos - 1 -> Index del Marco
			{
				t_algoritmo *avanzo_puntero = list_get(tabla_marcos,0);
				avanzo_puntero->bitPuntero = 1;
			}
			else
			{
				t_algoritmo *avanzo_puntero = list_get(tabla_marcos,punt_marco->index + 1);
				avanzo_puntero->bitPuntero = 1;
			}
			return punt_marco->index;
		}
		//
		if((j + 1) == cant_marcos )	//cant_marcos - 1 -> Index del Marco
		{
			j = 0;
		}
		else
		{
			j++;
		}
	}
	//No debo cambiar el puntero de lugar porque vuelve al mismo lugar
	return -1;
}

int segunda_vuelta_Clock()
{
	//int i, cantMarcos = cant_memoria * 4;

	//Busco donde esta el puntero
	int dameIndexPuntero(t_algoritmo *p)
	{
		return (p->bitPuntero == 1);
	}
	//
	t_algoritmo *puntero_donde = list_find(tabla_marcos, (void*) dameIndexPuntero);
	//Guardo el puntero para ver como me muevo
	int j = puntero_donde->index;
	//
	int i, cantMarcos = cant_marcos;
	t_algoritmo* punt_marco;
	//
	for(i = 0; i < cantMarcos; i++)
	{
		//
		punt_marco = list_get(tabla_marcos,j);
		//
		if (punt_marco->bitUso == 0 && punt_marco->bitMod == 1)
		{
			//Puntero que voy a sacar -> 0
			punt_marco->bitPuntero = 0;
			//Puntero siguiente es -> 1
			if((punt_marco->index + 1) == (cant_marcos - 1))	//cant_marcos - 1 -> Index del Marco
			{
				t_algoritmo *avanzo_puntero = list_get(tabla_marcos,0);
				avanzo_puntero->bitPuntero = 1;
			}
			else
			{
				t_algoritmo *avanzo_puntero = list_get(tabla_marcos,punt_marco->index + 1);
				avanzo_puntero->bitPuntero = 1;
			}
			return punt_marco->index;
		}
		//
		punt_marco->bitUso = 0;
		//
		if((j + 1) == cant_marcos )	//cant_marcos - 1 -> Index del Marco
		{
			j = 0;
		}
		else
		{
			j++;
		}
	}
	return -1;
}

int tercera_vuelta_Clock()
{
	return primera_vuelta_Clock();
}

int cuarta_vuelta_Clock()
{
	//int i, cantMarcos = cant_memoria * 4;
	int i, cantMarcos = cant_marcos;
	t_algoritmo* punt_marco;
	int j = 0;
	for(i = 0; i < cantMarcos; i++)
	{
		punt_marco = list_get(tabla_marcos,j);
		j++;
		if (punt_marco->bitUso == 0 && punt_marco->bitMod == 0) return punt_marco->index;
		if (++j == cantMarcos) j = 0;
	}	//oops aqui paso algo
	puts("FALLASTE EN EL CLOCK");
	exit(1);
}

int vueltas_Clock()
{
	int c;
	c = primera_vuelta_Clock();
	if (c >= 0) return c;
	c = segunda_vuelta_Clock();
	if (c >= 0) return c;
	c = tercera_vuelta_Clock();
	if (c >= 0) return c;
	c = cuarta_vuelta_Clock();
	return c;
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

char *armar_nombre(t_algoritmo* infoMarco)
{
	int digitos = 1;
	int ax = infoMarco->PID;
	while(ax >= 10)
	{
		ax = ax / 10;
		digitos++;
	}
	char *nombre = calloc(digitos + 13, sizeof(char)); //3 de pagina, 3 de segmento, un guion medio y un nulo + 5 de swap/
	char *aux = string_new();
	string_append(&nombre, "swap/");
	aux = string_itoa(infoMarco->PID);
	string_append(&nombre, aux);
	aux = "";
	string_append(&nombre, "-");
	aux = string_itoa(infoMarco->memoria.segmento);
	string_append(&nombre, aux);
	aux = "";
	aux = string_itoa(infoMarco->memoria.pagina);
	string_append(&nombre, aux);
	string_append(&nombre, ".txt");
	free(aux);

	archivos_en_disco++;

	return nombre;
}

void marcar_pagina_en_2(t_algoritmo* infoMarco)
{
	unsigned int cantProcesos = list_size(tabla_marcos);
	unsigned short i;
	t_algoritmo* proc;
	for(i = 0; i < cantProcesos; i++)
	{
		proc = list_get(tabla_marcos, i);
		//Agrego que ademas del PID busque el segmento y pagina que tengo que quitar
		if (proc->PID == infoMarco->PID
				&& proc->memoria.segmento == infoMarco->memoria.segmento
				&& proc->memoria.pagina == infoMarco->memoria.pagina)
		{
			break;
		}
	}

	unsigned int cantSegmentos = list_size(tabla_segmentos);
	TS *seg;
	for(i = 0; i < cantSegmentos; i++)
	{
		seg = list_get(tabla_segmentos, i);
		//Agrego que ademas del PID busque el segmento y pagina que tengo que marcar de los segmentos
		if (seg->PID == infoMarco->PID
				&& seg->base_seg.segmento == infoMarco->memoria.segmento
				&& seg->base_seg.pagina == infoMarco->memoria.pagina)
		{
			break;
		}
	}
	//Marco la pagina como swapeada a disco
	int valor_pagina_disco = -2;
	//memcpy(seg->TP,&valor_pagina_disco,sizeof(int));
	//
	//A la pagina n° tanto la apunto a -2 para saber que esta swapeada
	memcpy(&seg->TP[seg->base_seg.pagina],&valor_pagina_disco,sizeof(int));
	//mostrar_tabla_paginas_alternativo(seg->PID);
	//
	log_info(logs,"Swapeado->PID:%d|Seg:%d|Pag:%d",seg->PID,seg->base_seg.segmento,seg->base_seg.pagina);
}

int escribir_algoritmo(t_algoritmo* marco, t_mem dir_logica, uint32_t tamano,
		void* buffer) {

	int inicio = (marco->index * 256) + dir_logica.offset; //Desplazamiento dentro de la memo_ppal

	if (dir_logica.offset + tamano <= 256) {
		memcpy(memoria_principal + inicio, buffer, tamano);
		log_info(logs, "Se escribio correctamente->el marco %d",marco->index);

		return 0;

	} else {
		log_error(logs,
				"Hubo segmentation fault al intentar escribir el marco %d",
				marco->index);
		return -6;
	}
}

/*
 * Busca un marco que este libre;
 * En caso de no encontrar un marco libre, swapea a disco segun algoritmo.
 */

int buscar_asignar_y_escribir_marcos_algoritmo(int PID, t_mem dir_logica, int tamano,
		void* buffer, TS* segmento, int *indice_marco){

	int primer_marco_desocupado(t_algoritmo *p) {
		return p->PID == -1;
	}

	t_algoritmo* marco = list_find(tabla_marcos, (void*) primer_marco_desocupado); //Buscamos un marco libre

	if (marco != 0) { //Caso de encontrar un marco libre
		marco->PID = PID;
		marco->memoria.segmento = dir_logica.segmento;
		marco->memoria.pagina = dir_logica.pagina;
		marco->memoria.offset = dir_logica.offset;

		//
		//Actualizar el Marco (Agregado)
		if(algoritmo == 2)
		{
			marco->bitUso = 1;
			marco->bitMod = 0;
		}
		//(Agregado)
		//

		segmento->TP[dir_logica.pagina] = marco->index;

		(*indice_marco) = (marco->index);

		return escribir_algoritmo(marco, dir_logica, tamano, buffer);
	}
	else {
			////////////////////No hay marcos libres? Swappear////////////////
		/*
		int marco_de_swapeo(t_algoritmo *p) {
				return p->index == aplicar_algoritmo();
			}
		t_algoritmo* marco = list_find(tabla_marcos, (void*) marco_de_swapeo); //Buscamos un marco libre
		*/

		//
		//Aplicar algoritmo siempre te devuelve un index para ingresar <<<<<<<<<<<---------
		//
		t_algoritmo* marco = list_get(tabla_marcos,aplicar_algoritmo());

		//
		//Actualizo los datos del Marco con los de la nueva pagina cargada
		marco->PID = PID;
		marco->memoria.segmento = dir_logica.segmento;
		marco->memoria.pagina = dir_logica.pagina;
		marco->memoria.offset = dir_logica.offset;
		segmento->TP[dir_logica.pagina] = marco->index;
		//

		//
		//Actualizar el Marco (Agregado)
		if(algoritmo == 2)
		{
			marco->bitUso = 1;
			marco->bitMod = 0;
		}
		//(Agregado)
		//

		(*indice_marco) = (marco->index);

		return escribir_algoritmo(marco, dir_logica, tamano, buffer);
	}
	return 0;
}

/*
 * Funcion de escritura principal, escribe en memoria. Se encarga de hacer el swapeo a disco
 * en caso de que sea necesario.
 */

int escribir_memoria_algoritmo(uint32_t PID, uint32_t dir_logica_uint, void* buffer,uint32_t tamano)
{
	t_mem dir_logica = dir_a_t_mem(dir_logica_uint);

	if (dir_logica.offset + tamano > 256) {
		log_error(logs, "Hubo segmentation fault");
		return -2;
	}

	if (dir_logica.offset < 0) {
		log_error(logs, "Offset negativo");
		return -3;
	}

	t_mem base_seg;
	base_seg.segmento = dir_logica.segmento;
	base_seg.pagina = 0;
	base_seg.offset = 0;

	int indice = 0;

	//Verificar donde esta la pagina
	int donde_esta_segmento(TS *p) {
		return (p->PID == PID) && (p->base_seg.segmento == base_seg.segmento);
	}
	//

	TS* segmento = list_find(tabla_segmentos, (void*) donde_esta_segmento);

	if (segmento == NULL) {
		log_error(logs, "Segmento o proceso no existente");
		return -4;
	}

	if (segmento->cant_pags < dir_logica.pagina || dir_logica.pagina < 0) {
		log_error(logs, "Pagina no existente");
		return -5;
	}

	//
	//En caso de que la pagina que quiero escribir se encuentra swapeada a memoria
	//
	if(segmento->TP[dir_logica.pagina] == -2)
	{
		//Agrego -> Direccion logica de la pagina que quiero escribir;
		t_mem dir_pagina_swapeada;
		dir_pagina_swapeada.offset = 0;
		dir_pagina_swapeada.segmento = dir_logica.segmento;
		dir_pagina_swapeada.pagina = dir_logica.pagina;	//Que pagina del segmento deswapear

		//char texto[256];
		int size_pagina = TAM_PAGINAS;
		void* texto = malloc(size_pagina);

		deswappear(PID, dir_pagina_swapeada, texto);

		//Luego de traerla al buffer -> La voy a escribir en un marco -> La funcion se encarga
		buscar_asignar_y_escribir_marcos_algoritmo(PID, dir_pagina_swapeada, size_pagina, texto, //Cambie tamano -> size_pagina
						segmento,&indice);
		//Libero el texto ya guardado
		free(texto);

		//
		//Dame el marco donde deswapeaste la memoria
		t_algoritmo* marco = list_get(tabla_marcos,indice);

		return escribir_algoritmo(marco, dir_logica, tamano, buffer);
	}
	//
	//
	//Casos en que no esta swapeados -> Esta en un marco o no tiene un marco asignado
	if (segmento->TP[dir_logica.pagina] == -1) { ///////////Vemos si la pagina ha sido asignada a un marco anteriormente

		//Debo pasar el segmento de Memoria -> Marco => No hago escribir, lo hace adentro
		return buscar_asignar_y_escribir_marcos_algoritmo(PID, dir_logica, tamano,
				buffer, segmento, &indice);

	}
	else
	{
		//Caso en que ya esta cargado el marco en la memoria
		//
		//Busco el Marco donde es cargado
		int dame_marco_ocupado_por_proceso(t_algoritmo *p) {
			return (p->PID == segmento->PID
					&& p->memoria.pagina == dir_logica.pagina
					&& p->memoria.segmento == dir_logica.segmento);
		}
		//
		t_algoritmo* marco = list_find(tabla_marcos, (void*) dame_marco_ocupado_por_proceso);
		//
		//Actualizar el Marco (Agregado)
		if(algoritmo == 2)
		{
			marco->bitUso = 1;
			marco->bitMod = 1;
		}
		//(Agregado)
		//
		//Escribo el marco
		return escribir_algoritmo(marco, dir_logica, tamano, buffer);

	}
	return 0;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////Funciones usadas para mostrar tablas en consola////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * Muestra la tabla de paginas
 */
int mostrar_tabla_paginas(int PID, t_mem base_seg) {

	int i = 0;

	int donde_esta_segmento(TS *p) {
		return (p->PID == PID) && (p->base_seg.segmento == base_seg.segmento);
	}

	TS* elem = list_find(tabla_segmentos, (void*) donde_esta_segmento);

	if (elem == 0) {
		log_error(logs, "Segmento o proceso no existente");
		return -1;
	}

	if (elem->cant_pags == 0)
		printf("No hay paginas en la tabla\n");

	while (i < elem->cant_pags) {

		if (elem->TP[i] == -1)
			printf("Pagina # %d, Marco: NO ASIGNADO\n", i);
		else if (elem->TP[i] == -2)
			printf("Pagina # %d, EN DISCO\n", i);
		else
			printf("Pagina # %d, Marco: %d\n", i, elem->TP[i]);

		i++;
	}
	return 0;
}

/*
 * Muestra la tabla de paginas segun solo el PID;
 */

int mostrar_tabla_paginas_alternativo(int PID)
{
	int donde_esta_segmento(TS *p) {
		return (p->PID == PID);
	}

	t_list* elem_lista = list_filter(tabla_segmentos, (void*) donde_esta_segmento);

	if (list_size(elem_lista) == 0)
	{
		printf("Proceso no existente\n");
		return -1;
	}

	int i = 0;
	int j = 0;
	TS* segmentos_pid = list_get(elem_lista,i);
	printf("PID # %d\n",PID);
	while (segmentos_pid != NULL)
	{
		printf("Segmento # %d\n",segmentos_pid->base_seg.segmento);
		while (j < segmentos_pid->cant_pags) {

			if (segmentos_pid->TP[j] == -1)
				printf("Pagina # %d, Marco:NO ASIGNADO\n", j);
			else if (segmentos_pid->TP[j] == -2)
				printf("Pagina # %d, EN DISCO\n", j);
			else
				printf("Pagina # %d, Marco:%d\n", j, segmentos_pid->TP[j]);

			j++;
		}
		j = 0;
		i++;
		segmentos_pid = list_get(elem_lista,i);
	}
	return 0;
}

/*
 * Muestra la tabla de segmentos
 */

void mostrar_tabla_segmentos() {
	t_list *aux = tabla_segmentos;

	int tam_tabla = tabla_segmentos->elements_count;
	int i = 0;
	if (tam_tabla == 0)
		printf("No hay elementos cargados en la lista\n");

	while (i < tam_tabla) {
		TS *nodo = list_get(aux, i);
		printf(
				"Proceso # %d, Base de segmento # %d, Tamano: %ld, Cant de paginas: %d\n",
				nodo->PID, nodo->base_seg.segmento, nodo->tamano,
				nodo->cant_pags);
		i++;
	}
}

/*
 * Muestra el estado de la memoria (Tabla de Marcos asignado y no asignados )
 */

void mostrar_tabla_marcos() {
	t_list *aux = tabla_marcos;

	int tam_tabla = tabla_marcos->elements_count;
	int i = 0;
	if (tam_tabla == 0)
		printf("No hay elementos cargados en la lista\n");

	while (i < tam_tabla) {
		t_algoritmo *nodo = list_get(aux, i);
		if (nodo->PID != -1)
		{
			printf(
					"Marco # %d. Ocupado por proceso: %d. Segmento: %d. Pagina: %d",
					nodo->index, nodo->PID, nodo->memoria.segmento,
					nodo->memoria.pagina);
			if(algoritmo == 1)
			{
				printf(" Puntero : %d\n",nodo->bitPuntero);
			}
			else
			{
				if(algoritmo == 2)
				{
					printf(" Puntero: %d. BitUso: %d. BitModificado: %d\n",
							nodo->bitPuntero,nodo->bitUso,nodo->bitMod);
				}
				else
				{
					printf("\n");
				}
			}
		}
		else
		{
			printf(
					"Marco # %d. No ocupado por ningun proceso.\n",
					nodo->index);
		}

		i++;
	}
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////Hilo de la consola de la MSP//////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void* proceso_consola() {
	int eleccion, PID;
	int consola = 1;
	int tamano;
	t_mem base_seg;
	t_mem dir_logica;
	char escritura[256];

	log_info(logs, "INICIO DE CONSOLA");
	puts("Iniciando consola...\n");

	while (consola) {
		int seg, pag, off;
		puts(
				"\n1) Crear segmento\n2) Destruir segmento\n3) Escribir memoria\n4) Leer memoria\n5) Tabla de segmentos\n"
						"6) Tabla de paginas\n7) Listar marcos\n8) Salir de la consola\nSeleccione accion a ejecutar:");

		scanf("%d", &eleccion);
		switch (eleccion) {
		case 1:
			log_info(logs, "Eleccion de creacion de segmento");
			puts("Seleccione el proceso a tratar: ");
			scanf("%d", &PID);
			puts("Seleccione el tamano de memoria a reservar: ");
			scanf("%d", &tamano);
			crear_segmento(PID, tamano);
			break;

		case 2:
			log_info(logs, "Eleccion de destruccion de segmento");
			puts("Seleccione el proceso a tratar: ");
			scanf("%d", &PID);
			puts("Seleccione el segmento a eliminar: ");
			scanf("%d", &seg);
			base_seg.segmento = seg;
			base_seg.pagina = 0;
			base_seg.offset = 0;
			uint32_t direc = t_mem_a_dir(base_seg);
			destruir_segmento(PID, direc);
			break;

		case 3:

			log_info(logs, "Eleccion de escribir memoria");
			puts("Seleccione el proceso a tratar: ");
			scanf("%d", &PID);
			puts(
					"Seleccione el segmento de la direccion logica donde desea escribir: ");
			scanf("%d", &seg);
			dir_logica.segmento = seg;
			puts("Seleccione la pagina: ");
			scanf("%d", &pag);
			dir_logica.pagina = pag;
			puts("Seleccione el offset: ");
			scanf("%d", &off);
			dir_logica.offset = off;
			puts("Escriba lo que desea almacenar en memoria: ");
			scanf("%s", escritura);
			puts("Indique el espacio que la escritura ocupara: ");
			scanf("%d", &tamano);
			uint32_t direccion = t_mem_a_dir(dir_logica);
			escribir_memoria_algoritmo(PID, direccion, escritura, tamano);
			break;

		case 4:
			log_info(logs, "Eleccion de leer memoria");
			puts("Seleccione el proceso a tratar: ");
			scanf("%d", &PID);
			puts(
					"Seleccione el segmento de la direccion logica donde desea leer: ");
			scanf("%d", &seg);
			dir_logica.segmento = seg;
			puts("Seleccione la pagina: ");
			scanf("%d", &pag);
			dir_logica.pagina = pag;
			puts("Seleccione el offset: ");
			scanf("%d", &off);
			dir_logica.offset = off;
			puts("Indique el tamano que quiere leer: ");
			scanf("%d", &tamano);
			uint32_t dir = t_mem_a_dir(dir_logica);
			char devolver[256];
			leer_memoria_algoritmo(devolver, PID, dir, tamano);
			printf("Se leyo: %s\n", devolver);
			break;

		case 5:
			log_info(logs, "Eleccion de mostrar tabla de segmentos");
			mostrar_tabla_segmentos();
			break;

		case 6:
			/*
			log_info(logs, "Eleccion de mostrar tabla de paginas");
			puts("Seleccione el proceso: ");
			scanf("%d", &PID);
			puts("Seleccione el segmento: ");
			scanf("%d", &seg);
			base_seg.segmento = seg;
			mostrar_tabla_paginas(PID, base_seg);
			*/
			log_info(logs, "Eleccion de mostrar tabla de paginas");
			puts("Seleccione el proceso: ");
			scanf("%d", &PID);
			mostrar_tabla_paginas_alternativo(PID);
			break;

		case 7:
			log_info(logs, "Eleccion de mostrar tabla de marcos");
			mostrar_tabla_marcos();
			break;

		case 8:
			log_info(logs, "Salida de consola");
			consola = 0;
			break;

		default:
			log_error(logs, "Numero de opcion incorrecta");
			puts("Opcion incorrecta, vuelva a intentar");
			break;
		}
	}
	return 0;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////Funciones de Config y Memoria Inicial//////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * Lee la config de la MSP
 */
int leerArchivoConfiguracion(char *ruta_archivo) {
	int devolver = -1;

	//config = config_create(ruta_archivo);
	//printf("Leyendo archivo de configuraciones: %s\n", ruta_archivo);
	config = config_create(Path_Config_MSP);

	printf("Leyendo archivo de configuraciones: %s\n", Path_Config_MSP);

	puerto = config_get_int_value(config, "PUERTO");
	cant_memoria = config_get_int_value(config, "CANTIDAD_MEMORIA");
	cant_swapp = config_get_int_value(config, "CANTIDAD_SWAP");
	sust_pags = config_get_string_value(config, "SUST_PAGS");

	if(strcmp(sust_pags,"FIFO") == 0)
	{
		//Seteo el algoritmo en 1 para usarlo cuando tengo que reemplazar
		algoritmo = 1;
		printf("Se seteo Algoritmo de Sustitucion de Paginas ->FIFO\n");
	}
	if(strcmp(sust_pags,"CLOCK_MODIFICADO") == 0)
	{
		//Seteo el algoritmo en 2 para usarlo cuando tengo que reemplazar
		algoritmo = 2;
		printf("Se seteo Algoritmo de Sustitucion de Paginas ->CLOCK_MODIFICADO\n");
	}
	else
	{
		printf("No hay seteado ningun Algoritmo de Sustitucion de Paginas\n");
	}

	printf("Puerto de escucha de conexiones: %d\n", puerto);
	printf("Tamano de memoria principal: %d\n", cant_memoria);
	printf("Tamano del archivo de swapping: %d\n", cant_swapp);
	printf("Algoritmo de sustitucion de paginas: %s\n", sust_pags);
	puts("Listo.\n");

	return devolver;
}

/*
 * Crea el archivo log d ela msp en caso de inexistencia, sino lo levanta.
 */
int crearArchivosLog() {
	int devolver = 0;

	puts("Creando archivo de logueo...\n");

	logs = log_create(Path_Log_MSP, "MSP.log", false, LOG_LEVEL_TRACE);

	if (logs == NULL ) {
		puts("No se pudo generar el archivo de logueo\n");
		return -1;
	}

	log_info(logs, "INICIALIZACION DEL ARCHIVO DE LOGUEO");

	puts("Listo.\n");

	return devolver;
}

/*
 * Inicializa la memoria junto con su tabla de marcos
 */

int inicializar_memoria(char* config) {

	puts("Listo.\n");
	leerArchivoConfiguracion(config);
	crearArchivosLog();

	puts("Reservando la memoria principal...\n");
	memoria_principal = malloc(((1024 * cant_memoria) + 1) * sizeof(char));
	if (memoria_principal == NULL ) {
		log_error(logs,
				"No se pudo reservar correctamente la memoria principal");
		return 0;
	} else {
		puts("Listo.\n");
		return 1;
		log_info(logs,
				"Se reservo correctamente la memoria principal con un espacio de %d kilobytes",
				cant_memoria);
	}
	return 0;
}

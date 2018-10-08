#include"Consola.h"

//Globales
t_log* log_Consola;
//Path Config
#define Path_Config_Consola "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_Consola/Funciones_Consola/Config_Consola"
#define Path_Log_Consola "/home/utnso/tp-2014-2c-los-envirusaos/Proceso_Consola/Funciones_Consola/Consola.log"
//Socket fd del kernel
int32_t sock_fd_Kernel;
char* Path_ESO_CONFIG;


int main(int argc, char **argv)
{
	//Levanto los Logs
	log_Consola = log_create(Path_Log_Consola,"Consola.log",true,LOG_LEVEL_INFO);

	if (log_Consola == NULL)
	{
		printf("Fallo al abrir Log->Finalizacion de Programa\n");
		return EXIT_FAILURE;
	}

	log_info(log_Consola,"Inicio de Consola\n");

	//Me aseguro la existencia del Argumento para el File
	if (argc < 2)
	{
		log_info(log_Consola,"Falta el Argumento con la direccion del archivo a levantar\n");
		return EXIT_FAILURE;
	}


	//Signal Handles para evitar cierres extraños de la Consola -> Cierra el Socket_fd con el Kernel
	signal(SIGUSR1,sig_handler);
	signal(SIGUSR2,sig_handler);
	signal(SIGINT,sig_handler);
	signal(SIGTERM,sig_handler);
	//

	//Path del config de la consola
	Path_ESO_CONFIG = getenv("ESO_CONFIG");

	if (Path_ESO_CONFIG == NULL)
	{
		printf("Fallo al levantar la variable de entorno ESO_CONFIG\n");
		return EXIT_FAILURE;
	}

	//Levanto el Config
	Config_Consola *conf_cons = malloc(sizeof(Config_Consola));
	get_config_Consola(conf_cons);
	log_info(log_Consola,"IP_Kernel:%s|Puerto_Kernel:%d\n",conf_cons->IP_KERNEL,conf_cons->PUERTO_KERNEL);

	//Armo estructura de conexion
	struct t_conection *conexion_Kernel = malloc(sizeof(struct t_conection));
	strcpy(conexion_Kernel->ip,conf_cons->IP_KERNEL);
	conexion_Kernel->puerto = conf_cons->PUERTO_KERNEL;

	sock_fd_Kernel = new_connection(conexion_Kernel);

	//Conexion a Kernel
	log_info(log_Consola,"Conexion al Kernel\n");

	if (sock_fd_Kernel == -1)
	{
		log_info(log_Consola,"Fallo la conexion al Kernel\n");
		return EXIT_FAILURE;
	}

	//Headers para el envio/recepcion de informacion
	t_header envio_Kernel;
	t_header recep_Kernel;

	/*
	 * 		Handshake ( Envio un paquete sin datos para avisar que soy la Consola)
	 */
	envio_Kernel.id = 0;
	envio_Kernel.size = 0;
	if(enviar_paquete(sock_fd_Kernel,envio_Kernel) < 0)
	{
		log_info(log_Consola,"Fallo el Handshake\nSe cerro la conexion con el Kernel\n");
		return EXIT_FAILURE;
	}
	/*
	 * 		Recibo el Handshake del Kernel
	 */
	if(recibir_paquete(sock_fd_Kernel,&recep_Kernel) < 0)
	{
		log_info(log_Consola,"Fallo el Handshake\nSe cerro la conexion con el Kernel\n");
		return EXIT_FAILURE;
	}

	if (recep_Kernel.id == 1)
	{
		log_info(log_Consola,"Handshake del Kernel recibido\n");
	}


	/*
	 * Procesamiento del Codigo
	 */

	log_info(log_Consola,"File Direction:%s\n",argv[1]);
	FILE *fp = fopen(argv[1],"r");
	if (fp == NULL)
	{
		log_info(log_Consola,"Fallo al levantar el File\n");
		return EXIT_FAILURE;
	}
	envio_Kernel.id = 2;
	envio_Kernel.size = calcularTamFile(fp);
	envio_Kernel.data = malloc(envio_Kernel.size);
	envio_Kernel.data = caracteresFile(fp);
	fclose(fp);

	/*
	 * Envio del Codigo y Loop hasta finalizacion del Procesamiento del Codigo
	 */

	if (enviar_paquete(sock_fd_Kernel,envio_Kernel) < 0)
	{
		log_info(log_Consola,"Se cerro la conexion con el Kernel\n");
		return EXIT_FAILURE;
	}
	free(envio_Kernel.data);

	while(1)	//Loop principal de espera
	{
		int32_t error_rec = recibir_paquete(sock_fd_Kernel,&recep_Kernel);
		if (error_rec < 0)
		{
			log_info(log_Consola,"Se cerro la conexion con el Kernel\n");
			close(sock_fd_Kernel);
			return EXIT_FAILURE;
		}

		switch(recep_Kernel.id)
			{
			case 3:				//Se imprime algo que llega del kernel por pantalla -> Char*
				{
					//log_info(log_Consola,"Se recibio->%s|Size->%d\n",(char*)recep_Kernel.data,recep_Kernel.size);

					//char* chara_imprimir = malloc(recep_Kernel.size + 1);
					char* chara_imprimir = malloc(recep_Kernel.size);
					memcpy(chara_imprimir,recep_Kernel.data,recep_Kernel.size);
					//chara_imprimir[recep_Kernel.size + 1] = '\0';
					chara_imprimir[recep_Kernel.size ] = '\0';
					log_info(log_Consola,"Se recibio->%s|Size->%d\n",chara_imprimir,strlen(chara_imprimir));
					free(chara_imprimir);

					break;
				}
			case 4:				//Se pide que se ingrese algo por consola y se envia al Kernel
				{
					int32_t valor_copiar;
					while(1)
					{
						printf("Por favor imprima por pantalla un valor (2147483647 > x >-2147483648):\n");
						scanf("%d",&valor_copiar);
						if (valor_copiar < INT_FAST32_MAX || valor_copiar > INT_FAST32_MIN )//LIMITES
						{
							break;
						}
					}
					envio_Kernel.id = 5;		//Se usa para identificar el valor enviado
					envio_Kernel.size = sizeof(int32_t);
					envio_Kernel.data = malloc(envio_Kernel.size);
					memcpy(envio_Kernel.data,&valor_copiar,sizeof(int32_t));

					if (enviar_paquete(sock_fd_Kernel,envio_Kernel) < 0)
					{
						log_info(log_Consola,"Se cerro la conexion con el Kernel\n");
						return EXIT_FAILURE;
					}
					free(envio_Kernel.data);

					log_info(log_Consola,"Se envio el valor->%d",valor_copiar);

					break;
				}
			case 6:		//Se pide que ingrese una cadena por consola y se envia al kernel
				{
					int32_t longitud_chars = 0;
					memcpy(&longitud_chars,recep_Kernel.data,sizeof(int32_t));

					char* char_copiar = malloc(longitud_chars);
					while(1)
					{
						printf("Por favor imprima por pantalla un string (Longitud < %d):\n",longitud_chars);
						scanf("%s",char_copiar);
						if(strlen(char_copiar) < longitud_chars)
						{
							break;
						}
					}

					envio_Kernel.id = 7;		//Se usa para identificar el valor enviado
					envio_Kernel.size = longitud_chars;
					envio_Kernel.data = malloc(envio_Kernel.size);

					memcpy(envio_Kernel.data,char_copiar,envio_Kernel.size);

					if (enviar_paquete(sock_fd_Kernel,envio_Kernel) < 0)
					{
						log_info(log_Consola,"Se cerro la conexion con el Kernel\n");
						return EXIT_FAILURE;
					}
					free(envio_Kernel.data);
					break;
				}
			case 8:				//Finalizacion Correcta del Hilo
				{
					log_info(log_Consola,"Finalizo un hilo de ejecucion\n");
					break;
				}
			case 9:				//Se imprime algo que llega del kernel por pantalla -> Numerico
				{
					int32_t valor_a_imprimir_por_pantalla = 0;
					memcpy(&valor_a_imprimir_por_pantalla,recep_Kernel.data,sizeof(int32_t));
					log_info(log_Consola,"Se recibio:%d\n",valor_a_imprimir_por_pantalla);

					break;
				}
			case 10:			//Finalizacion Correcta del Proceso
				{
					log_info(log_Consola,"Finalizacion del programa principal\n");
					break;
				}
			case 11:
				{
					log_info(log_Consola,"Se aborto el programa\n");
					break;
				}
			case 12:			//Error -> Segmentation Fault
				{
					log_info(log_Consola,"Error->Segmentation Fault\n");
					break;
				}
			case 13:			//Error -> Memory Overload
				{
					log_info(log_Consola,"Error->Memory Overload\n");
					break;
				}
			case 14:			//Error -> Division por Cero
				{
					log_info(log_Consola,"Error->Division por Cero\n");
					break;
				}
			case 15:			//Error -> Desconexion de MSP
				{
					log_info(log_Consola,"Error->Desconexion de MSP\n");
					break;
				}
			case 16:
				{
					log_info(log_Consola,"Error->Hilo padre termino su ejecucion cuando quedaban hijos por ejecutar\n");
					break;
				}
			default:
				{
					log_info(log_Consola,"Fallo la conexion al Kernel\n");
					return EXIT_FAILURE;
				}

		}	//Fin de Switch

		if (recep_Kernel.id >= 10)	// Fin de ejecucion -> Finalizado/Abortado
		{
			break;
		}


	}	//Fin de While

	//Cierro Conexion y devuelvo memoria
	close(sock_fd_Kernel);
	free(conf_cons);
	free(conexion_Kernel);

	log_info(log_Consola,"Finalizacion de Consola");

	return EXIT_SUCCESS;
}

void get_config_Consola (Config_Consola *config)
{

	t_config *fcon = config_create(Path_ESO_CONFIG);

	if(fcon == NULL)
	{
		printf("\nNo se pudo levntar el config -> Se aborta la consola\n");
		exit(1);
	}

	Config_Consola *aux = config;

	aux->IP_KERNEL = config_get_string_value(fcon,"IP_KERNEL");
	aux->PUERTO_KERNEL = config_get_int_value(fcon,"PUERTO_KERNEL");

	return;
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

void sig_handler(int signo)
{
	if (signo == SIGUSR1)
	{
		close(sock_fd_Kernel);
		exit(1);
	}
	if(signo == SIGUSR2)
	{
		close(sock_fd_Kernel);
		exit(1);
	}
	if(signo == SIGINT)
	{
		close(sock_fd_Kernel);
		exit(1);
	}
	if(signo == SIGTERM)
	{
		close(sock_fd_Kernel);
		exit(1);
	}
}

#include"Sockets_Connection.h"

//Funciones de Conexion

/*
 * Se le pasa una estructura del tipo Conexion y devuelve el Socket_fd (Socket File Desciptor)
 */


int32_t new_connection(struct t_conection* conexion){

	struct sockaddr_in direccion;
	struct hostent *host;
	int32_t new_connect_descr;

	host = gethostbyname(conexion->ip);

	if (host == NULL)
		return -1;

	direccion.sin_family = AF_INET;
	direccion.sin_addr.s_addr = ((struct in_addr *)(host->h_addr))->s_addr;
	direccion.sin_port = htons(conexion->puerto);

	new_connect_descr = socket (AF_INET, SOCK_STREAM, 0);
	if (new_connect_descr == -1)
		return -1;

	if (connect (new_connect_descr, (struct sockaddr*)&direccion, sizeof(direccion)) == -1)
	{
		return -1;
	}

	return new_connect_descr;
}
/*
* Abre un socket servidor de tipo AF_INET. Devuelve el descriptor
* del socket o -1 si hay probleamas
*/
int32_t abrir_servidor (int puerto){
	struct sockaddr_in direccion;
	int descriptor;

	/*
	* se abre el socket
	*/
	descriptor = socket (AF_INET, SOCK_STREAM, 0);
	if (descriptor == SOCKET_ERROR)
	 	return SOCKET_ERROR;

	/*
	* Se rellenan los campos de la estructura Direccion, necesaria
	* para la llamada a la funcion bind()
	*/
	direccion.sin_family = AF_INET;
	direccion.sin_port = htons(puerto);
	//direccion.sin_addr.s_addr =INADDR_ANY;
	//Se prueba usando LOCALHOST : 127.0.0.1
	direccion.sin_addr.s_addr = inet_addr("127.0.0.1");

	if (bind (descriptor, (struct sockaddr *)&direccion, sizeof(direccion)) == SOCKET_ERROR){
		close (descriptor);
		return SOCKET_ERROR;
	}

	/*
	* Se avisa al sistema que comience a atender llamadas de clientes
	*/
	if (listen (descriptor, 1) == SOCKET_ERROR){
		close (descriptor);
		return SOCKET_ERROR;
	}

	/*
	* Se devuelve el descriptor del socket servidor
	*/
	return descriptor;
}


/*
* Se le pasa un socket de servidor y acepta en el una conexion de cliente.
* devuelve el descriptor del socket del cliente o -1 si hay problemas.
*/
int32_t aceptar_cliente (int descriptor){
	socklen_t longitud_cliente;
	struct sockaddr cliente;
	int32_t hijo;

		/*
		* La llamada a la funcion accept requiere que el parametro
		* longitud_cliente contenga inicialmente el tamano de la
		* estructura Cliente que se le pase. A la vuelta de la
		* funcion, esta variable contiene la longitud de la informacion
		* util devuelta en Cliente
		*/
	longitud_cliente = sizeof(cliente);
	hijo = accept (descriptor, &cliente, &longitud_cliente);

	if (hijo == SOCKET_ERROR)
		return SOCKET_ERROR;

		/*
		* Se devuelve el descriptor en el que esta "enchufado" el cliente.
		*/
	return hijo;
}





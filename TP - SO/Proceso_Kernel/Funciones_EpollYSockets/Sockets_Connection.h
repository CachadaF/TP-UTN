#ifndef SOCKETS_CPU_H_
#define SOCKETS_CPU_H_

#include <sys/types.h>
#include <sys/socket.h>
#include <sys/un.h>
#include <netinet/in.h>
#include <netdb.h>
#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <arpa/inet.h>
#define SOCKET_ERROR -1

//Estructuras
struct t_conection{
	char ip[15];
	int32_t puerto;
};

//Prototipos
int32_t new_connection(struct t_conection* conexion);
int32_t abrir_servidor (int puerto);
int32_t aceptar_cliente (int descriptor);

#endif /* SOCKETS_CPU_H_ */

#ifndef EPOLL_H_
#define EPOLL_H_

#include <stdlib.h>
#include <sys/epoll.h>
#include <stdio.h>
#include <netinet/in.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <errno.h>
#include <curses.h>
#include <string.h>
#include <unistd.h>
#include <sys/time.h>
#include <signal.h>
#include <fcntl.h>
//Commons libraries
#include <commons/log.h>


int crearInstanciaEpoll(t_log* logger);
void agregarEnEpoll(int instancia, int socket, t_log* logger);
//Funciones para usar en Sockets
signed int connectToServer(char *ip_server, int puerto, t_log *logger);
int crearSocketEscucha(int puerto, t_log* logger);
void bindearSocket(int unSocket, struct sockaddr_in socketInfo, t_log* logger);
void escucharEn(int unSocket);
int aceptarUnCliente (int socketCliente, t_log* logger);

#endif /* EPOLL_H_ */

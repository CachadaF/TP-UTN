#define EPOLL_ERROR -1

#include "epoll.h"

void agregarEnEpoll(int instancia, int socket, t_log* logger){

	struct epoll_event event;
	event.data.fd = socket;
	event.events = EPOLLIN | EPOLLET | EPOLLRDHUP;

	if(epoll_ctl (instancia, EPOLL_CTL_ADD, socket, &event) == -1){
		log_error(logger, "Error al intentar agregar socket a instancia de epoll %d", instancia);
		exit (EXIT_FAILURE);
	}
}

int crearInstanciaEpoll(t_log* logger){
	int instancia;
	instancia = epoll_create1 (0);
	if(instancia == -1){
		log_error(logger, "Error al intentar crear instancia de epoll");
		exit (EXIT_FAILURE);
	}
	return instancia;
}

#define MAXIMUM 64

signed int connectToServer(char *ip_server, int puerto, t_log *logger)
{
	int iSocket; 					// Escuchar sobre sock_fd, nuevas conexiones sobre new_fd
	struct sockaddr_in their_addr; 	// Información sobre mi dirección

	// Seteo IP y Puerto
	their_addr.sin_family = AF_INET;  					// Ordenación de bytes de la máquina
	their_addr.sin_port = htons(puerto); 				// short, Ordenación de bytes de la red
	their_addr.sin_addr.s_addr = inet_addr(ip_server);
	memset(&(their_addr.sin_zero), '\0', 8); 			// Poner a cero el resto de la estructura

	// Pido socket
	if ((iSocket = socket(AF_INET, SOCK_STREAM, 0)) == -1) {
		log_error(logger, "socket: %s", strerror(errno));
		return EXIT_FAILURE;
	}

	// Intento conectar
	if (connect(iSocket, (struct sockaddr *) &their_addr, sizeof their_addr) == -1) {
		log_error(logger, "connect: %s", strerror(errno));
		return EXIT_FAILURE;
	}

	log_trace(logger, "Se realiza conexion con socket %d", iSocket);

	return iSocket;
}

int crearSocket(t_log* logger)
{
	int unSocket;
	int si = 1;
	//--Crea el socket
	if ((unSocket = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		log_error(logger, "Creacion socket: %s", strerror(errno));
		return EXIT_FAILURE;

	} else {
		//--Setea las opciones para que pueda escuchar varios al mismo tiempo
		if (setsockopt(unSocket, SOL_SOCKET, SO_REUSEADDR, &si, sizeof(int)) == -1) {
			log_error(logger, "Setsockopt: %s", strerror(errno));
			return EXIT_FAILURE;
		}

		return unSocket;
	}
}

int crearSocketEscucha(int puerto, t_log* logger)
{
	struct sockaddr_in myAddress;
	int socketEscucha;

	socketEscucha = crearSocket(logger);

	//--Arma la información que necesita para mandar cosas
	myAddress.sin_family = AF_INET;
	myAddress.sin_addr.s_addr = INADDR_ANY;
	myAddress.sin_port = htons(puerto);
	memset(&(myAddress.sin_zero), '\0', 8);  	 // Poner a cero el resto de la estructura

	bindearSocket(socketEscucha, myAddress,logger);

	//--Escuchar
	escucharEn(socketEscucha);
	//--Liberar puerto despues de cerrarlo
	int optval = 1;
		if (setsockopt(socketEscucha, SOL_SOCKET, SO_REUSEADDR, &optval,sizeof optval) == -1){
			log_error(logger, "Error al incluir el atributo al socket escucha, de liberarse a cerrarlo: %s", strerror(errno));
			exit(EXIT_FAILURE);
		}
	return socketEscucha;
}

void bindearSocket(int unSocket, struct sockaddr_in socketInfo, t_log* logger)
{
	//--Bindear socket al proceso server
	if (bind(unSocket, (struct sockaddr*)&socketInfo, sizeof(socketInfo)) == -1) {
		log_error(logger, "Error al bindear socket escucha: %s", strerror(errno));
		exit(EXIT_FAILURE);
	}
}

void escucharEn(int unSocket)
{
	if (listen(unSocket, MAXIMUM ) == -1) {
		perror("Error al poner a escuchar socket");
		exit(EXIT_FAILURE);
	}
}

int aceptarUnCliente (int socketServidor, t_log* logger){

	socklen_t longitud_cliente;
	struct sockaddr cliente;
	int socketCliente;

	longitud_cliente = sizeof(cliente);
	socketCliente = accept (socketServidor, &cliente, &longitud_cliente);
	if (socketCliente == -1){
		if ((errno == EAGAIN) ||
                (errno == EWOULDBLOCK)){
			log_info(logger, "Se aceptaron todas las conexiones para el socket servidor: %d",socketServidor);
			return -1;
		}else{
			log_error(logger, "Error en la llamada al sistema accept");
			return -1;
		}
	}
	/*Se devuelve el descriptor en el que esta "enchufado" el cliente.*/
	return socketCliente;
}



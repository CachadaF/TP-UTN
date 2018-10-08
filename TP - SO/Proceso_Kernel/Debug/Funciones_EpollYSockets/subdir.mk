################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Funciones_EpollYSockets/LecturaYEscritura.c \
../Funciones_EpollYSockets/Sockets_Connection.c \
../Funciones_EpollYSockets/epoll.c 

OBJS += \
./Funciones_EpollYSockets/LecturaYEscritura.o \
./Funciones_EpollYSockets/Sockets_Connection.o \
./Funciones_EpollYSockets/epoll.o 

C_DEPS += \
./Funciones_EpollYSockets/LecturaYEscritura.d \
./Funciones_EpollYSockets/Sockets_Connection.d \
./Funciones_EpollYSockets/epoll.d 


# Each subdirectory must supply rules for building sources it contributes
Funciones_EpollYSockets/%.o: ../Funciones_EpollYSockets/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



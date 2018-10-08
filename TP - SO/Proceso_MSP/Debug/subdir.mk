################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Funciones_MSP.c \
../LecturaYEscritura.c \
../MSP.c \
../Sockets_Connection.c \
../epoll.c 

OBJS += \
./Funciones_MSP.o \
./LecturaYEscritura.o \
./MSP.o \
./Sockets_Connection.o \
./epoll.o 

C_DEPS += \
./Funciones_MSP.d \
./LecturaYEscritura.d \
./MSP.d \
./Sockets_Connection.d \
./epoll.d 


# Each subdirectory must supply rules for building sources it contributes
%.o: ../%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



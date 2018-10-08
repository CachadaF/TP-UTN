################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Funciones_CPU/Funciones_ESO.c \
../Funciones_CPU/LecturaYEscritura.c \
../Funciones_CPU/Sockets_Connection.c 

OBJS += \
./Funciones_CPU/Funciones_ESO.o \
./Funciones_CPU/LecturaYEscritura.o \
./Funciones_CPU/Sockets_Connection.o 

C_DEPS += \
./Funciones_CPU/Funciones_ESO.d \
./Funciones_CPU/LecturaYEscritura.d \
./Funciones_CPU/Sockets_Connection.d 


# Each subdirectory must supply rules for building sources it contributes
Funciones_CPU/%.o: ../Funciones_CPU/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



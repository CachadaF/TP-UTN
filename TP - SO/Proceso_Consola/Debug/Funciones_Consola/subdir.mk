################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Funciones_Consola/LecturaYEscritura.c \
../Funciones_Consola/Sockets_Connection.c 

OBJS += \
./Funciones_Consola/LecturaYEscritura.o \
./Funciones_Consola/Sockets_Connection.o 

C_DEPS += \
./Funciones_Consola/LecturaYEscritura.d \
./Funciones_Consola/Sockets_Connection.d 


# Each subdirectory must supply rules for building sources it contributes
Funciones_Consola/%.o: ../Funciones_Consola/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



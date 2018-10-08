################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Hilos/Funciones_Hilos.c \
../Hilos/Handle_Hilos.c \
../Hilos/Hilo_Loader.c \
../Hilos/Hilos_Planificador.c 

OBJS += \
./Hilos/Funciones_Hilos.o \
./Hilos/Handle_Hilos.o \
./Hilos/Hilo_Loader.o \
./Hilos/Hilos_Planificador.o 

C_DEPS += \
./Hilos/Funciones_Hilos.d \
./Hilos/Handle_Hilos.d \
./Hilos/Hilo_Loader.d \
./Hilos/Hilos_Planificador.d 


# Each subdirectory must supply rules for building sources it contributes
Hilos/%.o: ../Hilos/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



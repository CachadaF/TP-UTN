################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../panel/commons/config.c \
../panel/commons/error.c \
../panel/commons/log.c \
../panel/commons/process.c \
../panel/commons/string.c \
../panel/commons/temporal.c \
../panel/commons/txt.c 

OBJS += \
./panel/commons/config.o \
./panel/commons/error.o \
./panel/commons/log.o \
./panel/commons/process.o \
./panel/commons/string.o \
./panel/commons/temporal.o \
./panel/commons/txt.o 

C_DEPS += \
./panel/commons/config.d \
./panel/commons/error.d \
./panel/commons/log.d \
./panel/commons/process.d \
./panel/commons/string.d \
./panel/commons/temporal.d \
./panel/commons/txt.d 


# Each subdirectory must supply rules for building sources it contributes
panel/commons/%.o: ../panel/commons/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '



INSERT INTO LOS_NULL.Reserva(Fecha_Inicio,Fecha_Realizada,Cant_Noches,ID_Estado,ID_Regimen,Usuario)
VALUES (GETDATE(),GETDATE(),7,6,4,'SuperUser')

INSERT INTO LOS_NULL.Reserva(Fecha_Inicio,Fecha_Realizada,Cant_Noches,ID_Estado,ID_Regimen,Usuario)
VALUES (GETDATE(),GETDATE(),7,6,1,'SuperUser')

INSERT INTO LOS_NULL.Reserva(Fecha_Inicio,Fecha_Realizada,Cant_Noches,ID_Estado,ID_Regimen,Usuario)
VALUES (GETDATE(),GETDATE(),10,6,1,'SuperUser')

INSERT INTO LOS_NULL.ReservaXCliente(Codigo_Reserva,Nro_Cliente)
VALUES (110741,1)

INSERT INTO LOS_NULL.ReservaXCliente(Codigo_Reserva,Nro_Cliente)
VALUES (110742,1)

INSERT INTO LOS_NULL.ReservaXCliente(Codigo_Reserva,Nro_Cliente)
VALUES (110743,1)

INSERT INTO LOS_NULL.Estadia(Codigo_Reserva,Fecha_Inicio,Cant_Noches,Usuario_Egreso,Usuario_Ingreso,Cant_Noches_Estadia)
VALUES (110741,GETDATE(),7,'SuperUser','SuperUser',7)

INSERT INTO LOS_NULL.Estadia(Codigo_Reserva,Fecha_Inicio,Cant_Noches,Usuario_Egreso,Usuario_Ingreso,Cant_Noches_Estadia)
VALUES (110742,GETDATE(),7,'SuperUser','SuperUser',4)

INSERT INTO LOS_NULL.Estadia(Codigo_Reserva,Fecha_Inicio,Cant_Noches,Usuario_Egreso,Usuario_Ingreso,Cant_Noches_Estadia)
VALUES (110743,GETDATE(),10,'SuperUser','SuperUser',5)

INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
VALUES (11,110741)

INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
VALUES (17,110742)

INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
VALUES (11,110743)

INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
VALUES (17,110743)


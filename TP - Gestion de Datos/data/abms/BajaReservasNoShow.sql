-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[BAJARESERVASNOSHOWPORHOTEL]
	@ID_HOTEL NUMERIC(18,0),
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	
	UPDATE LOS_NULL.Reserva 
	SET ID_Estado = 1
	WHERE Codigo_Reserva IN 
	(
		SELECT R.Codigo_Reserva
		FROM LOS_NULL.Reserva R 
			JOIN LOS_NULL.ReservaXHabitacion RH ON (R.Codigo_Reserva = RH.ID_Reserva)
			JOIN LOS_NULL.Habitacion H ON (H.ID_Habitacion = RH.ID_Habitacion)
		WHERE R.Fecha_Inicio < @FECHA_ACTUAL AND H.ID_Hotel = @ID_HOTEL 
			  AND
			  (R.ID_Estado = 1 OR R.ID_Estado = 2)
	)
	
	
END
GO

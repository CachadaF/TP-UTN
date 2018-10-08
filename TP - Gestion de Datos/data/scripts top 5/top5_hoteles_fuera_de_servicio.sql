CREATE PROCEDURE [LOS_NULL].[TOP5HOTELESFUERADESERVICIO]
	@FECHA datetime
	
AS
BEGIN
	
	SELECT * FROM
		(SELECT TOP 5 HO.ID_HOTEL,
			LOS_NULL.CANTIDAD_DIAS_SIN_SERVICIO(HO.Id_Hotel,@FECHA) Dias_Inhabilitado
		FROM LOS_NULL.Hotel HO
		ORDER BY Dias_Inhabilitado DESC) TAB
	WHERE TAB.Dias_Inhabilitado IS NOT NULL

    
END
GO

CREATE FUNCTION [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]
(
	@ID_HOTEL numeric (18,0),
	@FECHA datetime
)

RETURNS numeric (18,0)

AS
BEGIN
	
	RETURN
	(
	SELECT SUM (DATEDIFF(day,Fecha_Inicio,LOS_NULL.MENOR_FECHA(Fecha_Fin,@FECHA))) FROM   
		(SELECT Id_Hotel FROM LOS_NULL.Hotel WHERE Id_Hotel = @ID_HOTEL) HO 
		JOIN LOS_NULL.BajaTemporalHotel BH ON (HO.Id_Hotel = BH.Id_Hotel)
		WHERE DATEDIFF (QUARTER,Fecha_Inicio,@FECHA)=0
	)

	/*--utilizo la funcion MENOR_FECHA para lo siguiente:
	Si por ejemplo:
	Fecha_Inicio_de_baja=11/3/2014
	Fecha_Fin_de_baja=2/4/2014
	Entonces, la fecha de fin supera el primer trimestre de consulta (que termina el 31/3/2014)
	Utilizando esta funcion, me va a devolver la cantidad de dias inhabilitados desde inicio hasta la fecha limite del fin del trimestre
	Por ahi esta demás, pero me parece logico
	
	*/
	
END
GO

CREATE FUNCTION[LOS_NULL].[MENOR_FECHA]
(
	@FECHA1 datetime,
	@FECHA2 datetime
)
RETURNS datetime

AS
BEGIN
	
	DECLARE @FECHA_MENOR datetime

	IF (@FECHA1 < @FECHA2) SET @FECHA_MENOR= @FECHA1
	ELSE SET @FECHA_MENOR= @FECHA2
	
	RETURN @FECHA_MENOR
	
END
GO

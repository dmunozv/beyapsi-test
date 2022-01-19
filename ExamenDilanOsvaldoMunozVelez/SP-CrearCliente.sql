--CREAR CLIENTE
ALTER PROCEDURE SP_RegistrarCliente (@Nombre VARCHAR(40), @Apellido VARCHAR(40), @FechaNacimiento DATETIME,
	@Correo VARCHAR(40), @Telefono NUMERIC, @FechaActual DATETIME, @Monto FLOAT, @Mensaje VARCHAR(100)OUT)
	
AS
	BEGIN		
		IF(EXISTS(SELECT * FROM Clientes WHERE @Nombre = Nombre AND @Apellido = Apellido))
			SET @Mensaje = 'El nombre de este cliente ya ha sido registrado'
		ELSE
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION;
					INSERT Clientes VALUES(@Nombre,@Apellido,@FechaNacimiento,@Correo,@Telefono)
					INSERT Movimientos VALUES ((SELECT MAX(IdCliente) FROM Clientes), 1, @Monto, @FechaActual)
					INSERT ControlCliente VALUES (@FechaActual,	1, 0.0, @Monto)
					SET @Mensaje = 'Cliente registrado con exito'
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				SET @Mensaje = error_message()
				ROLLBACK TRANSACTION;
			END CATCH
		END
	END
GO


--MODIFICAR INFORMACION CLIENTE
CREATE PROCEDURE SP_EditarCliente (@IdCliente INT, @Nombre VARCHAR(40), @Apellido VARCHAR(40), @FechaNacimiento DATETIME,
	@Correo VARCHAR(40), @Telefono NUMERIC, @FechaActual DATETIME, @Monto FLOAT, @Mensaje VARCHAR(100)OUT)
	
AS
	BEGIN		
		IF(EXISTS(SELECT * FROM Clientes WHERE @Nombre = Nombre AND @Apellido = Apellido))
			SET @Mensaje = 'El nombre de este cliente ya ha sido registrado'
		ELSE
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION;
					UPDATE Clientes 
					SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Correo = Correo, Telefono = Telefono
					WHERE IdCliente = @IdCliente
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				SET @Mensaje = error_message()
				ROLLBACK TRANSACTION;
			END CATCH
		END
	END
GO
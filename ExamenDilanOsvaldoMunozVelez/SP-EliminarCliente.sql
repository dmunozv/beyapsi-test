--ELIMINAR CLIENTE
ALTER PROCEDURE SP_EliminarCliente (@IdCliente INT, @Mensaje VARCHAR(100))
	
AS
	BEGIN		
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION;
					DELETE FROM Clientes WHERE IdCliente = @IdCliente
					DELETE FROM Movimientos WHERE IdCliente = @IdCliente
					DELETE FROM ControlCliente WHERE IdCliente = @IdCliente
				COMMIT TRANSACTION;
				SET @Mensaje = 'Cliente eliminado conexito'
			END TRY
			BEGIN CATCH
				SET @Mensaje = error_message()
				ROLLBACK TRANSACTION;
			END CATCH
		END
	END
GO
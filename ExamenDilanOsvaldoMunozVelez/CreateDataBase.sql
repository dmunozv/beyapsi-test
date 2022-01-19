CREATE DATABASE CAJAPOPULARHIDALGO

CREATE TABLE Clientes (
	IdCliente INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre VARCHAR(40) NOT NULL,
	Apellido VARCHAR(40) NOT NULL,
	FechaNacimiento DATETIME,
	Correo VARCHAR(40) NOT NULL,
	Telefono NUMERIC
);

CREATE TABLE Movimientos(
	IdMovimiento INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	IdCliente INT,
	TipoMovimiento INT, --1.Aportacion Social 2.Ahorro, 2.Retiro
	Monto FLOAT,
	FechaOperacion DATE NOT NULL
);

CREATE TABLE ControlCliente(
	IdCliente INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	FechaUltimoMovimiento DATE NOT NULL,
	TipoUltimoMovimiento INT,
	SaldoAnterior FLOAT,
	SaldoActual FLOAT
);

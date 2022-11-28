CREATE DATABASE Empresa
GO

USE Empresa
GO

-- Inicio Tablas

CREATE TABLE Turnos(
	Id INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	HoraEntrada TIME NOT NULL,
	HoraSalida TIME NOT NULL,
	FechaCreacion NVARCHAR(30) NOT NULL,
	FechaModificacion NVARCHAR(30) NULL,
	PRIMARY KEY(Id)
);
GO

CREATE TABLE Sucursal(
	Id INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	TurnoId INT NOT NULL,
	FechaCreacion NVARCHAR(30) NOT NULL,
	FechaModificacion NVARCHAR(30) NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY (TurnoId) REFERENCES Turnos(Id)
);
GO

CREATE TABLE Empleado(
	Id INT IDENTITY(1,1) NOT NULL,
	SucursalId INT NOT NULL,
	CodigoEmpleado VARCHAR(100) NOT NULL,
	PrimerNombre VARCHAR(300) NOT NULL,
	SegundoNombre VARCHAR(300) NOT NULL,
	FechaNacimiento NVARCHAR(30) NOT NULL,
	Genero VARCHAR(100) NOT NULL,
	Email VARCHAR(300) NOT NULL,
	PaisId INT NOT NULL,
	Ciudad VARCHAR(100) NOT NULL,
	Direccion VARCHAR(300) NOT NULL,
	Telefono VARCHAR(100) NOT NULL,
	FechaContratacion NVARCHAR(30) NOT NULL,
	Estado BIT NOT NULL,
	FechaCreacion NVARCHAR(30) NOT NULL,
	FechaModificacion NVARCHAR(30) NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(SucursalId) REFERENCES Sucursal(Id)
);
GO

CREATE TABLE MarcacionesEmpleados(
	Id INT IDENTITY(1,1) NOT NULL,
	EmpleadoId INT NOT NULL,
	HoraEntrada NVARCHAR(30) NOT NULL,
	HoraSalida NVARCHAR(30) NOT NULL,
	FechaCreacion NVARCHAR(30) NOT NULL,
	FechaModificacion NVARCHAR(30) NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(EmpleadoId) REFERENCES Empleado(Id)
);
GO
-- Fin Tablas



-- Inicio Procedimientos Consultas Generales

CREATE PROCEDURE __TurnosIndex
AS
BEGIN
	SELECT 
		Id AS "ID",
		Nombre AS "NOMBRE",
		HoraEntrada AS "H. ENTRADA",
		HoraSalida AS "H. SALIDA",
		FechaCreacion AS "F. CREACION",
		FechaModificacion AS "F. MODIFICACION"
	FROM Turnos
END
GO

CREATE PROCEDURE __SucursalesIndex
AS
BEGIN
	SELECT
		Id AS "ID",
		Nombre AS "NOMBRE",
		TurnoId AS "ID TURNO",
		FechaCreacion AS "F. CREACION",
		FechaModificacion AS "F. MODIFICACION"
	FROM Sucursal
END
GO

CREATE PROCEDURE __EmpleadoIndex
AS
BEGIN
	SELECT 
		Id AS "ID",
		SucursalId AS "ID SUCURSAL",
		CodigoEmpleado AS "C. EMPLEADO",
		CONCAT(PrimerNombre,' ',SegundoNombre) AS "NOMBRE",
		Genero AS "GENERO",
		Email AS "CORREO",
		CONCAT(PaisId, '|', Ciudad, '|', Direccion) AS "RESIDENCIA",
		Telefono AS "TELEFONO",
		Estado AS "ESTADO"
	FROM Empleado
END
GO
-- Fin Procedimientos Consultas Generales



-- Inicio Procedimientos Turnos

CREATE PROCEDURE __TurnosInsert
	@NOMBRE VARCHAR(100),
	@HORAENTRADA TIME,
	@HORASALIDA TIME
AS
BEGIN
	INSERT INTO Turnos(
		Nombre,
		HoraEntrada,
		HoraSalida,
		FechaCreacion,
		FechaModificacion
	) VALUES(
		@NOMBRE,
		@HORAENTRADA,
		@HORASALIDA,
		SYSDATETIME(),
		NULL
	)
	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE __TurnosUpdate
	@ID int,
	@NOMBRE VARCHAR(300),
	@HORAENTRADA TIME,
	@HORASALIDA TIME
AS
BEGIN
	UPDATE Turnos
	SET
		Nombre = @NOMBRE,
		HoraEntrada = @HORAENTRADA,
		HoraSalida = @HORASALIDA,
		FechaModificacion = SYSDATETIME()
	WHERE
		Id = @ID
END
GO

CREATE PROCEDURE __TurnosDelete
	@ID int
AS
BEGIN
	DELETE FROM Turnos
	WHERE Id = @ID
END
GO

CREATE PROCEDURE __TurnosCbo
AS
BEGIN
	SELECT
		Id AS "ID",
		Nombre AS "NOMBRE"
	FROM Turnos
END
GO
-- Fin procedimientos Turnos



-- Inicio Procedimientos Sucursal

CREATE PROCEDURE __SucursalInsert
	@NOMBRE VARCHAR(300),
	@TURNOID INT
AS
BEGIN
	INSERT INTO Sucursal (
		Nombre,
		TurnoId,
		FechaCreacion,
		FechaModificacion
	) VALUES (
		@NOMBRE,
		@TURNOID,
		SYSDATETIME(),
		NULL
	)
END
GO

CREATE PROCEDURE __SucursalUpdate
	@NOMBRE VARCHAR(300),
	@TURNOID INT,
	@ID INT
AS
BEGIN
	UPDATE Sucursal
	SET
		Nombre = @NOMBRE,
		TurnoId = @TURNOID,
		FechaModificacion = SYSDATETIME()
	WHERE
		Id = @ID
END
GO


CREATE PROCEDURE __SucursalDelete
	@ID INT
AS
BEGIN
	DELETE FROM Sucursal
	WHERE Id = @ID
END
GO

CREATE PROCEDURE __SucursalCbo
AS
BEGIN
	SELECT
		Id AS "ID",
		Nombre AS "NOMBRE"
	FROM Sucursal
END
GO
-- Fin Procedimientos Sucursal



-- Inicio Procedimientos Empleado
CREATE PROCEDURE __EmpleadoInsert
	@SUCURSALID INT,
	@CODIGOEMPLEADO VARCHAR(100),
	@PRIMERNOMBRE VARCHAR(300),
	@SEGUNDONOMBRE VARCHAR(300),
	@FECHANACIMIENTO NVARCHAR(30),
	@GENERO VARCHAR(100),
	@EMAIL VARCHAR(300),
	@PAISID INT,
	@CIUDAD VARCHAR(100),
	@DIRECCION VARCHAR(300),
	@TELEFONO VARCHAR(100)
AS
BEGIN
	INSERT INTO Empleado (
		SucursalId,
		CodigoEmpleado,
		PrimerNombre,
		SegundoNombre,
		FechaNacimiento,
		Genero,
		Email,
		PaisId,
		Ciudad,
		Direccion,
		Telefono,
		FechaContratacion,
		Estado,
		FechaCreacion,
		FechaModificacion
	) VALUES (
		@SUCURSALID,
		@CODIGOEMPLEADO,
		@PRIMERNOMBRE,
		@SEGUNDONOMBRE,
		@FECHANACIMIENTO,
		@GENERO,
		@EMAIL,
		@PAISID,
		@CIUDAD,
		@DIRECCION,
		@TELEFONO,
		SYSDATETIME(),
		1,
		SYSDATETIME(),
		NULL
	)
END
GO

CREATE PROCEDURE __EmpleadoUpdate
	@SUCURSALID INT,
	@CODIGOEMPLEADO VARCHAR(100),
	@PRIMERNOMBRE VARCHAR(300),
	@SEGUNDONOMBRE VARCHAR(300),
	@FECHANACIMIENTO NVARCHAR(30),
	@GENERO VARCHAR(100),
	@EMAIL VARCHAR(300),
	@PAISID INT,
	@CIUDAD VARCHAR(100),
	@DIRECCION VARCHAR(300),
	@TELEFONO VARCHAR(100),
	@ID INT
AS
BEGIN
	UPDATE Empleado
	SET
		SucursalId = @SUCURSALID,
		CodigoEmpleado = @CODIGOEMPLEADO,
		PrimerNombre = @PRIMERNOMBRE,
		SegundoNombre = @SEGUNDONOMBRE,
		FechaNacimiento = @FECHANACIMIENTO,
		Genero = @GENERO,
		Email = @EMAIL,
		PaisId = @PAISID,
		Ciudad = @CIUDAD,
		Direccion = @DIRECCION,
		Telefono = @TELEFONO,
		FechaModificacion = SYSDATETIME()
	WHERE
		Id = @ID
END
GO

CREATE PROCEDURE __EmpleadoDelete
	@ID INT
AS
BEGIN
	DELETE FROM Empleado
	WHERE Id = @ID
END
GO
-- Fin Procedimientos Empleado

-- MARCAR

CREATE PROCEDURE __Marcar
	@CODIGO NVARCHAR(30),
	@HORAENTRADA NVARCHAR(30),
	@HORASALIDA NVARCHAR(30)
AS
BEGIN
	INSERT INTO MarcacionesEmpleados (
		EmpleadoId,
		HoraEntrada,
		HoraSalida,
		FechaCreacion,
		FechaModificacion
	) VALUES (
		(SELECT Id FROM Empleado WHERE CodigoEmpleado = @CODIGO),
		@HORAENTRADA,
		@HORASALIDA,
		SYSDATETIME(),
		NULL
	)
END
GO


CREATE PROCEDURE __VerMarcaciones
AS
BEGIN
	SELECT
		Empleado.CodigoEmpleado AS 'CODIGO EMPLEADO',
		CONCAT(Empleado.PrimerNombre,' ',Empleado.SegundoNombre) AS 'NOMBRE',
		MarcacionesEmpleados.HoraEntrada AS 'HORA ENTRADA',
		MarcacionesEmpleados.HoraSalida AS 'HORA SALIDA'
	FROM MarcacionesEmpleados
	INNER JOIN Empleado
	ON MarcacionesEmpleados.EmpleadoId = Empleado.Id
END
GO
-- FIN MARCAR

-- PRUEBAS
exec __TurnosIndex
GO
exec __TurnosInsert 'Matutino2', '08:00', '17:00'
GO
exec __SucursalesIndex
GO
exec __SucursalInsert 'Primera', 14
GO
exec __EmpleadoIndex
GO
exec __EmpleadoInsert 2, 'AMEJICANOS', 'ABRAHAM', 'MEJICANOS', '07/05/2003', 'Masculino', 'amejianos38@gmail.com', 91, 'Guatemala', 'Vista al Valle Oriente', '5332 8043'
GO
exec __Marcar 'AMEJICANOS', '08:00', '17:00'
GO
-- FIN PRUEBAS
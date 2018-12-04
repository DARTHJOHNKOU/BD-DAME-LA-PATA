--Se crea la Bd
CREATE DATABASE Proyecto_DLP
GO

--SE usa la Bd creada para las adopciones--
USE Proyecto_DLP
GO

CREATE TABLE Perro
(
	IdPerro INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(30),
	FechaIngreso DATE,
	Edad INT,
	Raza VARCHAR(30),
	Tamaño VARCHAR(30),
	Esterilizado VARCHAR(2),
	Adoptado VARCHAR(2),
)
GO

CREATE TABLE Adoptante
(
	IdAdoptante INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	Edad INT,
	Domicilio VARCHAR(50),
	Telefono VARCHAR(10)
)
GO

CREATE TABLE Adopcion
(
	IdAdopcion INT IDENTITY(1,1) PRIMARY KEY,
	IdAdoptante INT,
	IdPerro INT,
	FechaAdopcion DATE,
	Lugar VARCHAR(50),

	FOREIGN KEY(IdAdoptante) REFERENCES Adoptante(IdAdoptante),
	FOREIGN KEY(IdPerro) REFERENCES Perro(IdPerro)
)
GO


CREATE TABLE Visita
(
	IdVisita INT IDENTITY(1,1) PRIMARY KEY,
	IdAdoptante INT,
	Lugar VARCHAR(50),
	FechaVisita DATE,
	FechaProximaVisita DATE,
	NombreVisitante VARCHAR(50),
	Observaciones VARCHAR(500),
	
	FOREIGN KEY(IdAdoptante) REFERENCES Adoptante(IdAdoptante)	
)
GO

CREATE TABLE Vacuna
(
	IdVacuna INT IDENTITY(1,1) PRIMARY KEY,
	IdPerro INT,
	TipoVacuna VARCHAR(30),
	Fecha DATE,

	FOREIGN KEY(idPerro) REFERENCES Perro(IdPerro)
)
GO

-- METODOS PARA LA TABLA PERRO	

-- Metodo para insertar un perro--
CREATE PROCEDURE SP_InsertPerro
	@Nombre VARCHAR(30),
	@FechaIngreso DATE,
	@Edad INT,
	@Raza VARCHAR(30),
	@Tamaño VARCHAR(30),
	@Esterilizado VARCHAR(2),
	@Adoptado VARCHAR(2)
	
AS
	BEGIN
		INSERT INTO Perro(Nombre, FechaIngreso, Edad, Raza, Tamaño, Esterilizado, Adoptado) 
		VALUES(@Nombre, @FechaIngreso, @Edad, @Raza, @Tamaño, @Esterilizado, @Adoptado)		
	END
GO

-- Metodo para Actualizar un perro--
CREATE PROCEDURE SP_UpdatePerro
    @IdPerro INT,
	@Nombre VARCHAR(30),
	@FechaIngreso DATE,
	@Edad INT,
	@Raza VARCHAR(30),
	@Tamaño VARCHAR(30),
	@Esterilizado VARCHAR(2),
	@Adoptado VARCHAR(2)
	
AS
	BEGIN
		INSERT INTO Perro(IdPerro, Nombre, FechaIngreso, Edad, Tamaño, Esterilizado, Adoptado) 
		VALUES(@IdPerro, @Nombre, @FechaIngreso, @Edad, @Tamaño, @Esterilizado, @Adoptado)
	END
GO

-- Metodo para Seleccionar un perro--
CREATE PROCEDURE SP_SelectPerro
	@Nombre VARCHAR(30)
AS	
	BEGIN
		SELECT * FROM Perro WHERE Nombre=@Nombre
	END
GO

-- Metodo para Seleccionar un perro disponible para ser adoptado--
CREATE PROCEDURE SP_SelectPerroDisponible	
AS	
	BEGIN
		SELECT * FROM Perro WHERE Adoptado='No'
	END
GO
  
-- Metodo para Selecccionar todos los perros--
CREATE PROCEDURE SP_SelectPerros
AS
	BEGIN
		SELECT * FROM Perro
	END
GO 

  
  --METODOS PARA LA TABLA VACUNAS ---

-- Metodo para insertar una vacuna--
CREATE PROCEDURE SP_InsertVacuna
	@IdPerro INT,
	@Fecha DATE,
	@TipoVacuna VARCHAR(30)
	
AS
	BEGIN
		INSERT INTO Vacuna(IdPerro, Fecha, TipoVacuna) 
		VALUES(@IdPerro, @Fecha, @TipoVacuna)
	END
GO

-- Metodo para Actualizar una vacuna--
CREATE PROCEDURE SP_UpdateVacuna
    @IdVacuna INT, 
	@IdPerro INT,
	@Fecha DATE,
	@TipoVacuna VARCHAR(30)
	
AS
	BEGIN
		INSERT INTO Vacuna(IdVacuna, IdPerro, Fecha, TipoVacuna) 
		VALUES(@IdVacuna, @IdPerro, @Fecha, @TipoVacuna)
	END
GO

-- Metodo paraSeleccionar una Vacuna--
CREATE PROCEDURE SP_SelectVacuna
	@TipoVacuna INT
AS
	BEGIN
		SELECT * FROM Vacuna WHERE TipoVacuna=@TipoVacuna
	END
GO

-- Metodo para Selecccionar todas las Vacunas--
CREATE PROCEDURE SP_SelectVacunas
AS
    BEGIN
	    SELECT * FROM Vacuna
	END
GO 


  --METODOS PARA LA TABLA ADOPCIONES ---

  -- Metodo para insertar una adopcion--
CREATE PROCEDURE SP_InsertAdopcion
	@IdPerro INT,
	@IdAdoptante INT,
	@FechaAdopcion INT, 
	@Lugar VARCHAR(50)
	
AS
	BEGIN
		INSERT INTO Adopcion(IdPerro, IdAdoptante, FechaAdopcion, Lugar) 
		VALUES(@IdPerro, @IdAdoptante, @FechaAdopcion, @Lugar)
	END
GO

-- Metodo para Actualizar una adopcion--
CREATE PROCEDURE SP_UpdateAdopcion
    @IdAdopcion INT, 
 	@IdPerro INT,
	@IdAdoptante INT,
	@FechaAdopcion INT, 
	@Lugar VARCHAR(50)
	
AS
	BEGIN
		INSERT INTO Adopcion(IdAdopcion, IdPerro, IdAdoptante, FechaAdopcion, Lugar)
		VALUES(@IdAdopcion, @IdPerro, @IdAdoptante, @FechaAdopcion, @Lugar)
	END
GO

-- Metodo paraSeleccionar una Adopcion--
CREATE PROCEDURE SP_SelectAdopcion
	@IdPerro INT 
AS
	BEGIN
		SELECT * FROM  Adopcion WHERE IdPerro=@IdPerro
	END
GO

  -- Metodo para Selecccionar todas las Adopciones
CREATE PROCEDURE SP_SelectAdopciones
AS
    BEGIN
		SELECT * FROM Adopcion
	END
GO 

  
--METODOS PARA LA TABLA ADOPTANTES--  

-- Metodo para insertar una adoptante--
CREATE PROCEDURE SP_InsertAdoptante
	@Nombre VARCHAR(50),
	@Edad INT,
	@Domicilio VARCHAR(50),
	@Telefono VARCHAR(10)
AS
	BEGIN
      INSERT INTO Adoptante(Nombre, Edad, Domicilio, Telefono) 
	  VALUES(@Nombre, @Edad, @Domicilio, @Telefono)
	END
GO

-- Metodo para Actualizar una adoptante--
CREATE PROCEDURE SP_UpdateAdoptante
    @IdAdoptante INT, 
 	@Nombre VARCHAR(50),
	@Edad INT,
	@Domicilio VARCHAR(50),
	@Telefono VARCHAR(10)
AS
	BEGIN
		INSERT INTO Adoptante(IdAdoptante, Nombre, Edad, Domicilio, Telefono) 
		VALUES(@IdAdoptante, @Nombre, @Edad, @Domicilio, @Telefono)
	END
GO

-- Metodo paraSeleccionar una Adopcion--
CREATE PROCEDURE SP_SelectAdoptante
	@Nombre VARCHAR(50)
AS
	BEGIN
	SELECT * FROM  Adoptante WHERE Nombre=@Nombre
	END
GO

-- Metodo para Selecccionar todos los adoptantes--
CREATE PROCEDURE SP_SelectAdoptantes
AS
	BEGIN
		SELECT * FROM Adoptante
	END
GO 


   
   --METODOS PARA LA TABLA VISITA--


  -- Metodo para insertar una Visita--
CREATE PROCEDURE SP_InsertVisita
	@IdAdoptante INT,
	@Lugar VARCHAR(50),
	@FechaVisita DATE,
	@FechaProximaVisita DATE,
	@NombreVisitante VARCHAR(50),
	@Observaciones VARCHAR(500)
AS
  BEGIN
      INSERT INTO Visita(IdAdoptante, Lugar, FechaVisita, FechaProximaVisita, NombreVisitante, Observaciones) 
	  VALUES(@IdAdoptante, @Lugar, @FechaVisita, @FechaProximaVisita, @NombreVisitante, @Observaciones)
  END
GO

-- Metodo para Actualizar una Visita--
CREATE PROCEDURE SP_UpdateVisita
    @IdVisita INT, 
 	@IdAdoptante INT,
	@Lugar VARCHAR(50),
	@FechaVisita DATE,
	@FechaProximaVisita DATE,
	@NombreVisitante VARCHAR(50),
	@Observaciones VARCHAR(500)
AS
	BEGIN
		INSERT INTO Visita(IdVisita, IdAdoptante, Lugar, FechaVisita, FechaProximaVisita, NombreVisitante, Observaciones) 
		VALUES(@IdVisita, @IdAdoptante, @Lugar, @FechaVisita, @FechaProximaVisita, @NombreVisitante, @Observaciones)
	END
GO

-- Metodo para Seleccionar una Visita--
CREATE PROCEDURE SP_SelectVisita
	@IdAdoptante INT

AS	
	BEGIN
		SELECT * FROM  Visita WHERE IdAdoptante=@IdAdoptante
	END
GO
  
-- Metodo para Selecccionar todas las visitas--
CREATE PROCEDURE SP_SelectVisitas
AS
	BEGIN
		SELECT * FROM Visita
	END
GO 


--SE usa la Bd creada para las adopciones--
Use DATABASE Proyecto_DLP

-- Metodo para insertar un perro--
CREATE PROCEDURE SP_InsertPerro
	@Nombre VARCHAR(30),
	@FechaIngreso DATE,
	@Edad INT,
	@Raza VARCHAR(20),
	@Tamaño DECIMAL(7,2),
	@Esterilizado BIT,
	@Adoptado as varchar(2)
	
AS
  BEGIN
      INSERT INTO Perro(Nombre, FechaIngreso, Edad, Tamaño, Esterilizado, Adoptado) 
	  VALUES(@Nombre, @FechaIngreso, @Edad, @Tamaño, @Esterilizado, @Adoptado)
  END
GO

-- Metodo para Actualizar un perro--
CREATE PROCEDURE SP_UpdatePerro
    @IdPerro As int, 
  	@Nombre VARCHAR(30),
	@FechaIngreso DATE,
	@Edad INT,
	@Raza VARCHAR(20),
	@Tamaño DECIMAL(7,2),
	@Esterilizado BIT,
	@Adoptado as varchar(2)
	
AS
  BEGIN
      INSERT INTO Perro(IdPerro, Nombre, FechaIngreso, Edad, Tamaño, Esterilizado, Adoptado) 
	  VALUES(@IdPerro, @Nombre, @FechaIngreso, @Edad, @Tamaño, @Esterilizado, @Adoptado)
  END
GO

-- Metodo paraSeleccionar un perro--
CREATE PROCEDURE SP_SelectPerro
 @Nombre
AS
  BEGIN
  SELECT * FROM Perro WHERE Nombre=@IdNombre

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
CREATE PROCEDURE SP_InserVacuna
	@IdPerro As int,
	@Fecha DATE,
	@TipoVacuna As varchar(30)
	
AS
  BEGIN
      INSERT INTO Vacuna(IdPerro, Fecha, TipoVacuna) 
	  VALUES(@IdPerro, @Fecha, @TipoVacuna)
  END
GO

-- Metodo para Actualizar una vacuna--
CREATE PROCEDURE SP_UpdateVacuna
    @IdVacuna As int, 
	@IdPerro As int,
	@Fecha DATE,
	@TipoVacuna As varchar(30)
	
AS
  BEGIN
      INSERT INTO Vacuna(IdVacuna, IdPerro, Fecha, TipoVacuna) 
	  VALUES(@IdVacuna, @IdPerro, @Fecha, @TipoVacuna)
  END
GO

-- Metodo paraSeleccionar una Vacuna--
CREATE PROCEDURE SP_SelectVacuna
 @TipoVacuna
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
	@IdPerro AS int,
	@IdAdoptante As int,
	@FechaAdopcion As int, 
	@Lugar As varchar(50)
	
AS
  BEGIN
      INSERT INTO Adopcion(IdPerro, IdAdopatnte, FechaAdopcion, Lugar) 
	  VALUES(@IdPerro, @IdAdoptante, @FechaAdopcion, @Lugar)
  END
GO

-- Metodo para Actualizar una adopcion--
CREATE PROCEDURE SP_UpdateAdopcion
    @IdAdopcion As int, 
 	@IdPerro AS int,
	@IdAdoptante As int,
	@FechaAdopcion As int, 
	@Lugar As varchar(50)
	
AS
  BEGIN
    INSERT INTO Adopcion(IdAdopcion, IdPerro, IdAdoptante, FechaAdopcion, Lugar)
	 VALUES(@IdAdopcion, @IdPerro, @IdAdoptante, @FechaAdopcion, @Lugar)
  END
GO

-- Metodo paraSeleccionar una Adopcion--
CREATE PROCEDURE SP_SelectAdopcion
 @IdPerro As int 
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
	@Nombre As varchar(50),
	@Edad As int,
	@Domicilio As varchar(50),
	@Telefono As Varchar(10)
AS
  BEGIN
      INSERT INTO Adoptante(Nombre, Edad, Domicilio, Telefono) 
	  VALUES(@Nombre, @Edad, @Domicilio, @Telefono)
  END
GO

-- Metodo para Actualizar una adoptante--
CREATE PROCEDURE SP_UpdateAdopcion
    @IdAdoptante As int, 
 	@Nombre As varchar(50),
	@Edad As int,
	@Domicilio As varchar(50),
	@Telefono As Varchar(10)
AS
  BEGIN
      INSERT INTO Adoptante(IdAdoptante, Nombre, Edad, Domicilio, Telefono) 
	  VALUES(@IdAdoptante, @Nombre, @Edad, @Domicilio, @Telefono)
  END
GO

-- Metodo paraSeleccionar una Adopcion--
CREATE PROCEDURE SP_SelectAdoptante
 @Nombre As varchar(50)
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
	@IdAdoptante As int,
	@Lugar As varchar(50),
	@FechaVisita As Date,
	@NombreVisitante As varchar(50),
	@Observaciones As varchar(50)
AS
  BEGIN
      INSERT INTO Visita(IdAdoptante, Lugar, FechaVisita, NombreVistante, Observaciones) 
	  VALUES(@IdAdoptante, @Lugar, @FechVisita, @NombreVisitante, @Observaciones)
  END
GO

-- Metodo para Actualizar una Visita--
CREATE PROCEDURE SP_UpdateVisita
    @IdVisita As int, 
 	@IdAdoptante As int,
	@Lugar As varchar(50),
	@FechaVisita As Date,
	@NombreVisitante As varchar(50),
	@Observaciones As varchar(50)
AS
  BEGIN
      INSERT INTO Visita(IdVisita, IdAdoptante, Lugar, FechaVisita, NombreVistante, Observaciones) 
	  VALUES(@IdVisita, @IdAdoptante, @Lugar, @FechVisita, @NombreVisitante, @Observaciones)
  END
GO

-- Metodo paraSeleccionar una Visita--
CREATE PROCEDURE SP_SelectVisita
 @IdAdoptante As int
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


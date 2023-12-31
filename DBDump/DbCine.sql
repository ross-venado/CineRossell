USE [DbCine]
GO
/****** Object:  Table [dbo].[Asiento]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asiento](
	[AsientoId] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NULL,
	[SalaId] [int] NULL,
	[ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AsientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrada]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada](
	[EntradaId] [int] IDENTITY(1,1) NOT NULL,
	[FuncionId] [int] NULL,
	[Precio] [decimal](18, 0) NULL,
	[ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EntradaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcion]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcion](
	[FuncionId] [int] IDENTITY(1,1) NOT NULL,
	[Hora] [time](7) NULL,
	[SalaId] [int] NULL,
	[PeliculaId] [int] NULL,
	[ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FuncionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pelicula](
	[PeliculaId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](255) NULL,
	[Duracion] [time](7) NULL,
	[ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[SalaId] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NULL,
	[Capacidad] [int] NULL,
	[PeliculaId] [int] NULL,
	[ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SalaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[VT_SP_ASIENTO]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VT_SP_ASIENTO]
(
  @i_operacion INT,
  @AsientoId INT = NULL,
  @Numero INT = NULL,
  @SalaId INT = NULL,
  @ts DATETIME = NULL
)
AS
BEGIN
  IF @i_operacion = 1
  BEGIN 
    SELECT [AsientoId],
           [Numero],
           [SalaId],
           [ts]
      FROM [dbo].[Asiento]
  END

  IF @i_operacion = 2
  BEGIN 
    INSERT INTO [dbo].[Asiento] (
      [Numero],
      [SalaId],
      [ts]
    )
    VALUES (
      @Numero,
      @SalaId,
      @ts
    )

    SELECT SCOPE_IDENTITY() AS LastInsertedId
  END

  IF @i_operacion = 3
  BEGIN
    UPDATE [dbo].[Asiento]
    SET [Numero] = @Numero,
        [SalaId] = @SalaId,
        [ts] = @ts
    WHERE [AsientoId] = @AsientoId

	select @AsientoId [modificado]
  END

  IF @i_operacion = 4
  BEGIN
    DELETE FROM [dbo].[Asiento]
    WHERE [AsientoId] = @AsientoId
  END

  IF @i_operacion = 5
  BEGIN
    SELECT [AsientoId],
           [Numero],
           [SalaId],
           [ts]
    FROM [dbo].[Asiento]
    WHERE [AsientoId] = @AsientoId
  END

END
GO
/****** Object:  StoredProcedure [dbo].[VT_SP_ENTRADA]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VT_SP_ENTRADA]
(
  @i_operacion INT,
  @EntradaId INT = NULL,
  @FuncionId INT = NULL,
  @Precio DECIMAL(10, 2) = NULL,
  @ts DATETIME = NULL
)
AS
BEGIN
  IF @i_operacion = 1
  BEGIN 
    SELECT [EntradaId],
           [FuncionId],
           [Precio],
           [ts]
      FROM [dbo].[Entrada]
  END

  IF @i_operacion = 2
  BEGIN 
    INSERT INTO [dbo].[Entrada] (
      [FuncionId],
      [Precio],
      [ts]
    )
    VALUES (
      @FuncionId,
      @Precio,
      @ts
    )

    SELECT SCOPE_IDENTITY() AS LastInsertedId
  END

  IF @i_operacion = 3
  BEGIN
    UPDATE [dbo].[Entrada]
    SET [FuncionId] = @FuncionId,
        [Precio] = @Precio,
        [ts] = @ts
    WHERE [EntradaId] = @EntradaId

	select @EntradaId [modificado]
  END

  IF @i_operacion = 4
  BEGIN
    DELETE FROM [dbo].[Entrada]
    WHERE [EntradaId] = @EntradaId
  END

  IF @i_operacion = 5
  BEGIN
    SELECT [EntradaId],
           [FuncionId],
           [Precio],
           [ts]
    FROM [dbo].[Entrada]
    WHERE [EntradaId] = @EntradaId
  END

END
GO
/****** Object:  StoredProcedure [dbo].[VT_SP_FUNCION]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[VT_SP_FUNCION]
(
  @i_operacion INT,
  @FuncionId INT = NULL,
  @Hora TIME = NULL,
  @SalaId INT = NULL,
  @PeliculaId INT = NULL,
  @ts DATETIME = NULL
)
AS
BEGIN
  IF @i_operacion = 1
  BEGIN 
    SELECT [FuncionId],
            CONVERT(VARCHAR(5),CAST([Hora] AS TIME), 108) as [Hora],
           [SalaId],
           [PeliculaId],
           [ts]
      FROM [dbo].[Funcion]
  END

  IF @i_operacion = 2
  BEGIN 
    INSERT INTO [dbo].[Funcion] (
      [Hora],
      [SalaId],
      [PeliculaId],
      [ts]
    )
    VALUES (
      @Hora,
      @SalaId,
      @PeliculaId,
      @ts
    )

    SELECT SCOPE_IDENTITY() AS LastInsertedId
  END

  IF @i_operacion = 3
  BEGIN
    UPDATE [dbo].[Funcion]
    SET [Hora] = @Hora,
        [SalaId] = @SalaId,
        [PeliculaId] = @PeliculaId,
        [ts] = @ts
    WHERE [FuncionId] = @FuncionId

	select @FuncionId [modificado]
  END

  IF @i_operacion = 4
  BEGIN
    DELETE FROM [dbo].[Funcion]
    WHERE [FuncionId] = @FuncionId
  END

  IF @i_operacion = 5
  BEGIN
    SELECT [FuncionId],
           CONVERT(VARCHAR(5),CAST([Hora] AS TIME), 108) as [Hora],
           [SalaId],
           [PeliculaId],
           [ts]
    FROM [dbo].[Funcion]
    WHERE [FuncionId] = @FuncionId
  END

END
GO
/****** Object:  StoredProcedure [dbo].[VT_SP_PELICULA]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[VT_SP_PELICULA]
(
  @i_operacion INT,
  @PeliculaId INT = NULL,
  @Titulo NVARCHAR(255) = NULL,
  @Duracion TIME = NULL,
  @ts DATETIME = NULL
)
AS
BEGIN
  IF @i_operacion = 1
  BEGIN 
    SELECT [PeliculaId],
           [Titulo],
             CONVERT(VARCHAR(5),CAST(Duracion AS TIME), 108) as Duracion,
           [ts]
           ,'' AS [Eliminar]
          ,'' AS [Editar]
      FROM [dbo].[Pelicula]
  END

  IF @i_operacion = 2
  BEGIN 
    INSERT INTO [dbo].[Pelicula] (
      [Titulo],
      [Duracion],
      [ts]
    )
    VALUES (
      @Titulo,
      @Duracion,
      @ts
    )

    SELECT SCOPE_IDENTITY() AS LastInsertedId
  END

  IF @i_operacion = 3
  BEGIN
    UPDATE [dbo].[Pelicula]
    SET [Titulo] = @Titulo,
        [Duracion] = @Duracion,
        [ts] = @ts
    WHERE [PeliculaId] = @PeliculaId

	select @PeliculaId [modificado]
  END

  IF @i_operacion = 4
  BEGIN
    DELETE FROM [dbo].[Pelicula]
    WHERE [PeliculaId] = @PeliculaId
  END

  IF @i_operacion = 5
  BEGIN
    SELECT [PeliculaId],
           [Titulo],
           CONVERT(VARCHAR(5),CAST(Duracion AS TIME), 108) as Duracion,
           [ts]
    FROM [dbo].[Pelicula]
    WHERE [PeliculaId] = @PeliculaId
  END

END
GO
/****** Object:  StoredProcedure [dbo].[VT_SP_SALA]    Script Date: 17/08/2023 00:49:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VT_SP_SALA]
(
  @i_operacion INT,
  @SalaId INT = NULL,
  @Numero INT = NULL,
  @Capacidad INT = NULL,
  @PeliculaId INT = NULL,
  @ts DATETIME = NULL
)
AS
BEGIN
  IF @i_operacion = 1
  BEGIN 
    SELECT [SalaId],
           [Numero],
           [Capacidad],
           [PeliculaId],
           [ts]
      FROM [dbo].[Sala]
  END

  IF @i_operacion = 2
  BEGIN 
    INSERT INTO [dbo].[Sala] (
      [Numero],
      [Capacidad],
      [PeliculaId],
      [ts]
    )
    VALUES (
      @Numero,
      @Capacidad,
      @PeliculaId,
      @ts
    )

    SELECT SCOPE_IDENTITY() AS LastInsertedId
  END

  IF @i_operacion = 3
  BEGIN
    UPDATE [dbo].[Sala]
    SET [Numero] = @Numero,
        [Capacidad] = @Capacidad,
        [PeliculaId] = @PeliculaId,
        [ts] = @ts
    WHERE [SalaId] = @SalaId

	select @SalaId [modificado]
  END

  IF @i_operacion = 4
  BEGIN
    DELETE FROM [dbo].[Sala]
    WHERE [SalaId] = @SalaId
  END

  IF @i_operacion = 5
  BEGIN
    SELECT [SalaId],
           [Numero],
           [Capacidad],
           [PeliculaId],
           [ts]
    FROM [dbo].[Sala]
    WHERE [SalaId] = @SalaId
  END

END
GO

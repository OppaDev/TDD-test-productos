create database dbproducto;

USE [dbproducto]
GO

/** Object:  Table [dbo].[Cliente]    Script Date: 2/4/2025 7:59:25 AM **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Direccion] [varchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Cliente_Codigo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_Insert] 
    @Cedula varchar(10),
    @Apellidos varchar(50),
    @Nombres varchar(50),
    @FechaNacimiento datetime,
    @Mail varchar(50),
    @Telefono varchar(10),
    @Direccion varchar(50) = NULL,
    @Estado bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Cliente] ([Cedula], [Apellidos], [Nombres], [FechaNacimiento], [Mail], [Telefono], [Direccion], [Estado])
	SELECT @Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Direccion, @Estado
	
	-- Begin Return Select <- do not remove
	SELECT [Codigo], [Cedula], [Apellidos], [Nombres], [FechaNacimiento], [Mail], [Telefono], [Direccion], [Estado]
	FROM   [dbo].[Cliente]
	WHERE  [Codigo] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
      IF @@rowcount > 0 SELECT 1 AS Valor  ELSE BEGIN
                                        	SELECT 0 AS Valor
                                        END
	COMMIT



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_SelectAll] 
    @Cedula varchar(10),
    @Apellidos varchar(50),
    @Nombres varchar(50),
    @FechaNacimiento datetime,
    @Mail varchar(50),
    @Telefono varchar(10),
    @Direccion varchar(50) = NULL,
    @Estado bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
		SELECT [Codigo], [Cedula], [Apellidos], [Nombres], [FechaNacimiento], [Mail], [Telefono], [Direccion], [Estado]
		FROM [dbo].[Cliente]
	COMMIT
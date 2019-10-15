USE [master]
GO
/****** Object:  Database [CONTROLE_PARCERIAS]    Script Date: 14/10/2019 21:51:03 ******/
CREATE DATABASE [CONTROLE_PARCERIAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CONTROLE_PARCERIAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CONTROLE_PARCERIAS.mdf' , SIZE = 204800KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CONTROLE_PARCERIAS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CONTROLE_PARCERIAS_log.ldf' , SIZE = 51200KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CONTROLE_PARCERIAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET  MULTI_USER 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET QUERY_STORE = OFF
GO
USE [CONTROLE_PARCERIAS]
GO
/****** Object:  User [AndersonGomes]    Script Date: 14/10/2019 21:51:03 ******/
CREATE USER [AndersonGomes] FOR LOGIN [AndersonGomes] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [anderson]    Script Date: 14/10/2019 21:51:03 ******/
CREATE USER [anderson] FOR LOGIN [anderson] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [AndersonGomes]
GO
ALTER ROLE [db_owner] ADD MEMBER [anderson]
GO
/****** Object:  Table [dbo].[Parceria]    Script Date: 14/10/2019 21:51:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parceria](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](255) NOT NULL,
	[Descricao] [text] NOT NULL,
	[URLPagina] [varchar](1000) NULL,
	[Empresa] [varchar](40) NOT NULL,
	[DataInicio] [date] NOT NULL,
	[DataTermino] [date] NOT NULL,
	[QtdLikes] [int] NOT NULL,
	[DataHoraCadastro] [datetime] NULL,
 CONSTRAINT [PK_Parceria] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vParceria]    Script Date: 14/10/2019 21:51:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParceria]
AS
SELECT 
Codigo
,Titulo
,Descricao
,URLPagina
,Empresa
,DataInicio
,DataTermino
,QtdLikes
,DataHoraCadastro
FROM Parceria
GO
/****** Object:  Table [dbo].[ParceriaLike]    Script Date: 14/10/2019 21:51:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParceriaLike](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoParceria] [int] NOT NULL,
	[DataHoraCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_ParceriaLike] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vParceriaLike]    Script Date: 14/10/2019 21:51:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParceriaLike]
AS
SELECT 
Codigo
,CodigoParceria
,DataHoraCadastro
FROM ParceriaLike
GO
ALTER TABLE [dbo].[Parceria] ADD  DEFAULT ((0)) FOR [QtdLikes]
GO
ALTER TABLE [dbo].[Parceria] ADD  DEFAULT (getdate()) FOR [DataHoraCadastro]
GO
ALTER TABLE [dbo].[ParceriaLike] ADD  DEFAULT (getdate()) FOR [DataHoraCadastro]
GO
ALTER TABLE [dbo].[ParceriaLike]  WITH CHECK ADD  CONSTRAINT [FK_Parceria] FOREIGN KEY([CodigoParceria])
REFERENCES [dbo].[Parceria] ([Codigo])
GO
ALTER TABLE [dbo].[ParceriaLike] CHECK CONSTRAINT [FK_Parceria]
GO
/****** Object:  StoredProcedure [dbo].[spParceria]    Script Date: 14/10/2019 21:51:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC spParceria 0, 'ABC PARCEIRO', 'ABC', 'HTTP://ABC', 'TESTE', 0, '2019-10-02',  '2019-10-02', NULL, 1
CREATE procedure [dbo].[spParceria] 
(
@Codigo INT
,@Titulo VARCHAR(255)
,@Descricao TEXT
,@URLPagina VARCHAR(1000)
,@Empresa VARCHAR(40)
,@QtdLikes INT
,@DataInicio DATETIME
,@DataTermino DATETIME
,@DataHoraCadastro DATETIME
,@OPERACAO INT 
)
AS 

-- SE INSERT 
IF( @OPERACAO = 1)
	BEGIN 
		INSERT INTO Parceria
		(
		Titulo
		,Descricao
		,URLPagina
		,Empresa
		,DataInicio
		,DataTermino
		)
		VALUES 
		(
		@Titulo
		,@Descricao
		,@URLPagina
		,@Empresa
		,@DataInicio
		,@DataTermino
		)
	END 

-- SE UPDATE 
IF ( @OPERACAO = 2)
 BEGIN 
		UPDATE Parceria
		SET 
			Titulo = @Titulo
			,Descricao = @Descricao
			,URLPagina = @URLPagina
			,Empresa = @Empresa
			,DataInicio = @DataInicio
			,DataTermino = @DataTermino
		WHERE Codigo = @Codigo
 END 

-- SE DELETE 
IF ( @OPERACAO = 3)
 BEGIN 
	DELETE P FROM Parceria P 
	WHERE Codigo = @Codigo 
	AND NOT EXISTS(
		SELECT CodigoParceria 
		FROM ParceriaLike PL  
		WHERE CodigoParceria = @Codigo
		AND P.Codigo = PL.CodigoParceria
	)
 END
GO
/****** Object:  StoredProcedure [dbo].[spParceriaLike]    Script Date: 14/10/2019 21:51:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spParceriaLike]
(
@CodigoParceria INT
)
AS

 INSERT INTO ParceriaLike 
 (CodigoParceria)
Values 
(@CodigoParceria)
GO
USE [master]
GO
ALTER DATABASE [CONTROLE_PARCERIAS] SET  READ_WRITE 
GO

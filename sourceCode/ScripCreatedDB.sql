USE [master]
GO
/****** Object:  Database [ALD_MFG]    Script Date: 2022-09-21 11:17:31 ******/
CREATE DATABASE [ALD_MFG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALD_TipOD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ALD_MFG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ALD_TipOD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ALD_MFG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ALD_MFG] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ALD_MFG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ALD_MFG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ALD_MFG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ALD_MFG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ALD_MFG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ALD_MFG] SET ARITHABORT OFF 
GO
ALTER DATABASE [ALD_MFG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ALD_MFG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ALD_MFG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ALD_MFG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ALD_MFG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ALD_MFG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ALD_MFG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ALD_MFG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ALD_MFG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ALD_MFG] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ALD_MFG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ALD_MFG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ALD_MFG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ALD_MFG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ALD_MFG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ALD_MFG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ALD_MFG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ALD_MFG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ALD_MFG] SET  MULTI_USER 
GO
ALTER DATABASE [ALD_MFG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ALD_MFG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ALD_MFG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ALD_MFG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ALD_MFG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ALD_MFG] SET QUERY_STORE = OFF
GO
USE [ALD_MFG]
GO
/****** Object:  Table [dbo].[tblDataLogPolishing]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDataLogPolishing](
	[Id] [uniqueidentifier] NULL,
	[Station] [nvarchar](100) NULL,
	[ShaftNumber] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Part] [nvarchar](50) NULL,
	[WorkOrder] [nvarchar](50) NULL,
	[FreqReading] [float] NULL,
	[FreqTarget] [float] NULL,
	[MortorPolishing] [float] NULL,
	[FormulaPO] [int] NULL,
	[LogType] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDataLogSanding]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDataLogSanding](
	[Id] [uniqueidentifier] NOT NULL,
	[Station] [nvarchar](100) NULL,
	[ShaftNumber] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[WorkOrder] [nvarchar](100) NULL,
	[Part] [nvarchar](100) NULL,
	[Freq01Reading] [float] NULL,
	[MotorSandingSpeed] [float] NULL,
	[Freq02Reading] [float] NULL,
	[FreqTarget] [float] NULL,
	[FormulaGId] [int] NULL,
	[LogStyle] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblDataLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDataLogTipOD]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDataLogTipOD](
	[Id] [uniqueidentifier] NOT NULL,
	[Station] [nvarchar](100) NULL,
	[ShaftNumber] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Part] [nvarchar](50) NULL,
	[WorkOrder] [nvarchar](50) NULL,
	[DiamReading] [float] NULL,
	[MeasType] [nvarchar](50) NULL,
	[DiamLL] [float] NULL,
	[DiamUL] [float] NULL,
	[PassFail] [nvarchar](20) NULL,
	[LogType] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblDataLogOD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFormulaG]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFormulaG](
	[Id] [int] NOT NULL,
	[U] [int] NULL,
	[V] [int] NULL,
	[X] [float] NULL,
	[Y] [float] NULL,
	[Z] [int] NULL,
	[P] [float] NULL,
 CONSTRAINT [PK_tblFormulaG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFormulaPo]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFormulaPo](
	[Id] [int] NOT NULL,
	[U] [int] NULL,
	[V] [int] NULL,
	[X] [float] NULL,
	[Y] [float] NULL,
	[Z] [int] NULL,
	[P] [float] NULL,
 CONSTRAINT [PK_tblFormulaPo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipOdFreq]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipOdFreq](
	[Id] [uniqueidentifier] NOT NULL,
	[ItemNumber] [nvarchar](100) NULL,
	[FreqTarget] [float] NULL,
	[DiamLL] [float] NULL,
	[DiamUl] [float] NULL,
	[TipOdLength] [nvarchar](500) NULL,
	[FormulaGId] [int] NULL,
	[FormulaPoId] [int] NULL,
 CONSTRAINT [PK_tblTipOdFreq] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblDataLogPolishing] ADD  CONSTRAINT [DF_tblDataLogPolishing_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[tblDataLogPolishing] ADD  CONSTRAINT [DF_tblDataLogPolishing_Station]  DEFAULT (N'Auto Polishing') FOR [Station]
GO
ALTER TABLE [dbo].[tblDataLogPolishing] ADD  CONSTRAINT [DF_tblDataLogPolishing_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblDataLogSanding] ADD  CONSTRAINT [DF_tblDataLog_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[tblDataLogSanding] ADD  CONSTRAINT [DF_tblDataLogSanding_Station]  DEFAULT (N'Auto Sanding') FOR [Station]
GO
ALTER TABLE [dbo].[tblDataLogSanding] ADD  CONSTRAINT [DF_tblDataLog_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblDataLogTipOD] ADD  CONSTRAINT [DF_tblDataLogOD_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[tblDataLogTipOD] ADD  CONSTRAINT [DF_tblDataLogTipOD_Station]  DEFAULT (N'Auto Tip OD') FOR [Station]
GO
ALTER TABLE [dbo].[tblDataLogTipOD] ADD  CONSTRAINT [DF_tblDataLogOD_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblTipOdFreq] ADD  CONSTRAINT [DF_tblTipOdFreq_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetFullPartInfo]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetFullPartInfo] 
	-- Add the parameters for the stored procedure here
	@partNum nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT tip.Id,
		tip.ItemNumber,
		tip.FreqTarget,
		tip.DiamLL,
		tip.DiamUL,
		(SUBSTRING(tip.TipOdLength,10, len(tip.TipOdLength)-11)) TipOdLength, --tip.TipOdLength,
		tip.FormulaGId,
		tip.FormulaPoId,
		fG.U GU,
		fG.V GV,
		fG.X GX,
		fG.Y GY,
		fG.Z GZ,
		fG.P GP,
		fPo.U PoU,
		fPo.V PoV,
		fPo.X PoX,
		fPo.Y PoY,
		fPo.Z PoZ,
		fPo.P PoP
	FROM tblTipOdFreq tip 
		LEFT JOIN tblFormulaG fG on fG.Id = tip.FormulaGId
		LEFT JOIN tblFormulaPo fPo on fPo.Id = tip.FormulaGId
	WHERE tip.ItemNumber = @partNum
	ORDER BY CAST((SUBSTRING(tip.TipOdLength,10, len(tip.TipOdLength)-11)) AS int) asc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParts]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetParts]
	-- Add the parameters for the stored procedure here
	@part nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @part = 'All'
		SELECT * from tblTipOdFreq
	else
		SELECT * from tblTipOdFreq where ItemNumber like '%'+@part+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tblDataLogPolishingInsert]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_tblDataLogPolishingInsert]
	-- Add the parameters for the stored procedure here
	@shaftNum int,
	@partNum nvarchar(100),
	@workOrder nvarchar(100),
	@freqReading float,
	@freqTarget float,
	@motorPolishing float,
	@formulaPO int,
	@logType nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [dbo].[tblDataLogPolishing]
           ([ShaftNumber]
           ,[Part]
           ,[WorkOrder]
           ,[FreqReading]
           ,[FreqTarget]
           ,[MortorPolishing]
           ,[FormulaPO]
           ,[LogType])
     VALUES
           (
		    @shaftNum,
			@partNum,
			@workOrder,
			@freqReading,
			@freqTarget,
			@motorPolishing,
			@formulaPO,
			@logType
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tblDataLogSandingInsert]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_tblDataLogSandingInsert]
	-- Add the parameters for the stored procedure here
	@shaftNum int,
	@workOrder nvarchar(100),
	@partNum nvarchar(100),
	@freq01Reading float,
	@motorSandingSpeed float,
	@freq02Reading float,
	@freqTarget float,
	@formulaG int,
	@logType nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.	

    -- Insert statements for procedure here
	INSERT INTO [dbo].[tblDataLogSanding]
           (
           [ShaftNumber]
           ,[WorkOrder]
           ,[Part]
           ,[Freq01Reading]
           ,[MotorSandingSpeed]
           ,[Freq02Reading]
           ,[FreqTarget]
           ,[FormulaGId]
           ,[LogStyle])
     VALUES
           (
			@shaftNum,
			@workOrder,
			@partNum,
			@freq01Reading,
			@motorSandingSpeed,
			@freq02Reading,
			@freqTarget,
			@formulaG,
			@logType
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tblDataLogTipOdInsert]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_tblDataLogTipOdInsert]
	-- Add the parameters for the stored procedure here
	@shaftNum int,
	@partNum nvarchar(100),
	@workOrder nvarchar(100),
	@diamReading float,
	@measType nvarchar(100),
	@diamLL float,
	@diamUL float,
	@passFail nvarchar(20),
	@logType nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [dbo].[tblDataLogTipOD]
           (
			   [ShaftNumber]
			   ,[Part]
			   ,[WorkOrder]
			   ,[DiamReading]
			   ,[MeasType]
			   ,[DiamLL]
			   ,[DiamUL]
			   ,[PassFail]
			   ,[LogType]
		   )
     VALUES
           (
			   @shaftNum,
				@partNum,
				@workOrder,
				@diamReading,
				@measType,
				@diamLL,
				@diamUL,
				@passFail,
				@logType
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tblFormulaGInsert]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_tblFormulaGInsert]
	-- Add the parameters for the stored procedure here
	@id int,
	@u int,
	@v int,
	@x float,
	@y float,
	@z int,
	@p float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [dbo].[tblFormulaG]
           ([Id]
           ,[U]
           ,[V]
           ,[X]
           ,[Y]
           ,[Z]
           ,[P])
     VALUES
           (@id
           ,@u
           ,@v
           ,@x
           ,@y
           ,@z
           ,@p
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tblFormulaPoInsert]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_tblFormulaPoInsert]
	-- Add the parameters for the stored procedure here
	@id int,
	@u int,
	@v int,
	@x float,
	@y float,
	@z int,
	@p float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [dbo].[tblFormulaPo]
           ([Id]
           ,[U]
           ,[V]
           ,[X]
           ,[Y]
           ,[Z]
           ,[P])
     VALUES
           (@id
           ,@u
           ,@v
           ,@x
           ,@y
           ,@z
           ,@p
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TipOdFreqInsert]    Script Date: 2022-09-21 11:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_TipOdFreqInsert]
	-- Add the parameters for the stored procedure here
	@itemNum nvarchar(100),
	@freq int,
	@diamLL float,
	@diamUL float,
	@tipOdLength nvarchar(500),
	@formulaGId int,
	@formulaPoId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [dbo].[tblTipOdFreq]
           (
           [ItemNumber]
           ,[FreqTarget]
           ,[DiamLL]
           ,[DiamUL]
           ,[TipOdLength]
           ,[FormulaGId]
           ,[FormulaPoId])
     VALUES
           (
           @itemNum
           ,@freq
           ,@diamLL
           ,@diamUl
           ,@tipOdLength
           ,@formulaGId
           ,@formulaPoId
		   )
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kiểu log data. production: chỉ log 5 cây; Pilot: log toàn bộ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblDataLogSanding', @level2type=N'COLUMN',@level2name=N'LogStyle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'part number, quét barcode mã này để query lấy data truyền xuống PLC chạy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblTipOdFreq', @level2type=N'COLUMN',@level2name=N'ItemNumber'
GO
USE [master]
GO
ALTER DATABASE [ALD_MFG] SET  READ_WRITE 
GO

USE [master]
GO

/****** Object:  Database [TesteMatricula]    Script Date: 01/04/2023 23:23:35 ******/
CREATE DATABASE [TesteMatricula]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TesteMatricula', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TesteMatricula.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TesteMatricula_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TesteMatricula_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TesteMatricula].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TesteMatricula] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TesteMatricula] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TesteMatricula] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TesteMatricula] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TesteMatricula] SET ARITHABORT OFF 
GO

ALTER DATABASE [TesteMatricula] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [TesteMatricula] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TesteMatricula] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TesteMatricula] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TesteMatricula] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TesteMatricula] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TesteMatricula] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TesteMatricula] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TesteMatricula] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TesteMatricula] SET  ENABLE_BROKER 
GO

ALTER DATABASE [TesteMatricula] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TesteMatricula] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TesteMatricula] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TesteMatricula] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TesteMatricula] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TesteMatricula] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [TesteMatricula] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TesteMatricula] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [TesteMatricula] SET  MULTI_USER 
GO

ALTER DATABASE [TesteMatricula] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TesteMatricula] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TesteMatricula] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TesteMatricula] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TesteMatricula] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TesteMatricula] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [TesteMatricula] SET QUERY_STORE = ON
GO

ALTER DATABASE [TesteMatricula] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [TesteMatricula] SET  READ_WRITE 
GO



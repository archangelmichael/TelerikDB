USE [master]
GO
/****** Object:  Database [UniversityDatabase]    Script Date: 22-Aug-14 12:14:22 PM ******/
CREATE DATABASE [UniversityDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityDatabase.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityDatabase] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityDatabase', N'ON'
GO
USE [UniversityDatabase]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyID] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor_Courses]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_Courses](
	[ProfessorID] [int] NOT NULL,
	[CoursesID] [int] NOT NULL,
 CONSTRAINT [PK_Professor_Courses_1] PRIMARY KEY CLUSTERED 
(
	[ProfessorID] ASC,
	[CoursesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professor_Titles]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_Titles](
	[ProfessorID] [int] NOT NULL,
	[TitlesID] [int] NOT NULL,
 CONSTRAINT [PK_Professor_Titles_1] PRIMARY KEY CLUSTERED 
(
	[ProfessorID] ASC,
	[TitlesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student_Courses]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Courses](
	[StudentID] [int] NOT NULL,
	[CoursesID] [int] NOT NULL,
 CONSTRAINT [PK_Student_Courses] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[CoursesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyID] [int] NOT NULL,
	[CoursesID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 22-Aug-14 12:14:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Professor_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Courses_Courses] FOREIGN KEY([CoursesID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Professor_Courses] CHECK CONSTRAINT [FK_Professor_Courses_Courses]
GO
ALTER TABLE [dbo].[Professor_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Courses_Professors] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[Professors] ([ID])
GO
ALTER TABLE [dbo].[Professor_Courses] CHECK CONSTRAINT [FK_Professor_Courses_Professors]
GO
ALTER TABLE [dbo].[Professor_Titles]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Titles_Professors] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[Professors] ([ID])
GO
ALTER TABLE [dbo].[Professor_Titles] CHECK CONSTRAINT [FK_Professor_Titles_Professors]
GO
ALTER TABLE [dbo].[Professor_Titles]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Titles_Titles] FOREIGN KEY([TitlesID])
REFERENCES [dbo].[Titles] ([ID])
GO
ALTER TABLE [dbo].[Professor_Titles] CHECK CONSTRAINT [FK_Professor_Titles_Titles]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Departments]
GO
ALTER TABLE [dbo].[Student_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Student_Courses_Courses] FOREIGN KEY([CoursesID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Student_Courses] CHECK CONSTRAINT [FK_Student_Courses_Courses]
GO
ALTER TABLE [dbo].[Student_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Student_Courses_Students1] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Student_Courses] CHECK CONSTRAINT [FK_Student_Courses_Students1]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
USE [master]
GO
ALTER DATABASE [UniversityDatabase] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [Tasks]    Script Date: 10/02/2025 15:24:40 ******/
CREATE DATABASE [Tasks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tasks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Tasks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Tasks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Tasks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tasks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tasks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tasks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tasks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tasks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tasks] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tasks] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tasks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tasks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tasks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tasks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tasks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tasks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tasks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tasks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tasks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tasks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tasks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tasks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tasks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tasks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tasks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tasks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tasks] SET RECOVERY FULL 
GO
ALTER DATABASE [Tasks] SET  MULTI_USER 
GO
ALTER DATABASE [Tasks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tasks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tasks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tasks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Tasks] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Tasks', N'ON'
GO
ALTER DATABASE [Tasks] SET QUERY_STORE = ON
GO
ALTER DATABASE [Tasks] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Tasks]
GO
/****** Object:  Table [dbo].[A_Priority]    Script Date: 10/02/2025 15:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Priority](
	[PriorityID] [int] NOT NULL,
	[Priority] [nvarchar](20) NULL,
 CONSTRAINT [PK_A_Priority] PRIMARY KEY CLUSTERED 
(
	[PriorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_Status]    Script Date: 10/02/2025 15:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Status](
	[StatusID] [int] NOT NULL,
	[Status] [nvarchar](20) NULL,
 CONSTRAINT [PK_A_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 10/02/2025 15:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Status] [int] NULL,
	[DueDate] [datetime] NULL,
	[Priority] [int] NULL,
	[CreationTimestamp] [datetime] NULL,
	[LastUpdatedTimestamp] [datetime] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[A_Priority] ([PriorityID], [Priority]) VALUES (1, N'LOW')
INSERT [dbo].[A_Priority] ([PriorityID], [Priority]) VALUES (2, N'MEDIUM')
INSERT [dbo].[A_Priority] ([PriorityID], [Priority]) VALUES (3, N'HIGH')
GO
INSERT [dbo].[A_Status] ([StatusID], [Status]) VALUES (1, N'TODO')
INSERT [dbo].[A_Status] ([StatusID], [Status]) VALUES (2, N'IN_PROGRESS')
INSERT [dbo].[A_Status] ([StatusID], [Status]) VALUES (3, N'DONE')
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (2, N'Backend:', N'Develop RESTful APIs using either NodeJS or ASP.NET (choose based on your expertise).', 1, CAST(N'2025-01-13T21:00:00.000' AS DateTime), 3, CAST(N'2025-02-10T15:58:17.237' AS DateTime), CAST(N'2025-02-10T16:07:52.190' AS DateTime))
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (3, N'ASSIGNMENT: SIMPLE TASK MANAGER APP', N'As part of the evaluation for the post of 249539 P-1 Assistant Information Systems Officer, DPS/ITS you are asked to complete a practical technical assignment designed to assess your skills in frontend and backend development, database integration, and code quality.', 2, CAST(N'2025-02-04T23:00:00.000' AS DateTime), 3, CAST(N'2025-02-10T16:05:14.890' AS DateTime), NULL)
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (4, N'Develop a basic Task Manager web application ', N'Develop a basic Task Manager web application that allows users to: Create, read, update, and delete (CRUD) tasks.', 3, CAST(N'2025-02-05T23:00:00.000' AS DateTime), 2, CAST(N'2025-02-10T16:06:12.323' AS DateTime), NULL)
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (5, N'Frontend:', N'Use ReactJS/NextJS, HTML5, and CSS3 to build a simple, responsive UI.  Integrate PrimeReact components to create an interactive interface. As an example:', 2, CAST(N'2025-02-09T23:00:00.000' AS DateTime), 1, CAST(N'2025-02-10T16:07:29.330' AS DateTime), NULL)
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (6, N'Database:', N'Use a documents-based DB (e.g., CouchDB or MongoDB) to store task data.
• Implement proper data schema
• Handle data persistence
• Provide a script or database dump to set up the database', 2, CAST(N'2025-02-03T23:00:00.000' AS DateTime), 3, CAST(N'2025-02-10T16:08:33.423' AS DateTime), NULL)
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (7, N'Bunya Simon', N'This is the test I have implemented ', 3, CAST(N'2025-02-04T23:00:00.000' AS DateTime), 3, CAST(N'2025-02-10T16:09:26.767' AS DateTime), NULL)
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (8, N'Submission via GitHub:', N'1. Grant read permissions to the github user “InternationalTradeCentre”.
2. Include a README file with:
• Clear setup instructions for running the application locally.', 2, CAST(N'2025-02-18T23:00:00.000' AS DateTime), 2, CAST(N'2025-02-10T16:09:52.227' AS DateTime), NULL)
INSERT [dbo].[Task] ([ID], [Title], [Description], [Status], [DueDate], [Priority], [CreationTimestamp], [LastUpdatedTimestamp]) VALUES (9, N'Submission via GitHub:', N'• Brief documentation of your API endpoints.
• A summary of your approach, assumptions, or any limitations.
• Important: Add your name in the README file.
3. Provide screenshots or screen recordings of the Task Manager application in a folder within the repository.', 2, CAST(N'2025-02-16T22:00:00.000' AS DateTime), 3, CAST(N'2025-02-10T16:10:33.600' AS DateTime), CAST(N'2025-02-10T16:45:48.673' AS DateTime))
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_A_Priority] FOREIGN KEY([Priority])
REFERENCES [dbo].[A_Priority] ([PriorityID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_A_Priority]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_A_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[A_Status] ([StatusID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_A_Status]
GO
USE [master]
GO
ALTER DATABASE [Tasks] SET  READ_WRITE 
GO

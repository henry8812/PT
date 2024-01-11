USE [PT01]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[EvaluationId] [int] NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicantProcess]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicantProcess](
	[ApplicantProcessId] [int] NOT NULL,
	[ApplicantId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[TestResult] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ApplicationProcesses] PRIMARY KEY CLUSTERED 
(
	[ApplicantProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applicants]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicants](
	[ApplicantId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Applicants] PRIMARY KEY CLUSTERED 
(
	[ApplicantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Document] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluations]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluations](
	[EvaluationId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[Score] [real] NOT NULL,
 CONSTRAINT [PK_Evaluations] PRIMARY KEY CLUSTERED 
(
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[LevelId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[LevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[OptionId] [int] IDENTITY(1,1) NOT NULL,
	[OptionText] [nvarchar](max) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NULL,
 CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED 
(
	[OptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Processes]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Processes](
	[ProcessId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[LevelId] [int] NULL,
	[NumberOfQuestions] [int] NOT NULL,
	[TestTypeId] [int] NULL,
 CONSTRAINT [PK_Processes] PRIMARY KEY CLUSTERED 
(
	[ProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessQuestion]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessQuestion](
	[ProcessesProcessId] [int] NOT NULL,
	[QuestionsQuestionId] [int] NOT NULL,
 CONSTRAINT [PK_ProcessQuestion] PRIMARY KEY CLUSTERED 
(
	[ProcessesProcessId] ASC,
	[QuestionsQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Difficulty] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[JobOfferId] [int] NOT NULL,
	[TestTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestType]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestType](
	[TestTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED 
(
	[TestTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypes](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TestTypes] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/11/2024 1:46:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Document] [nvarchar](max) NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applicants] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[Processes] ADD  DEFAULT ((0)) FOR [LanguageId]
GO
ALTER TABLE [dbo].[Processes] ADD  DEFAULT ((0)) FOR [NumberOfQuestions]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (N'') FOR [Id]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [AccessFailedCount]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [PhoneNumberConfirmed]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Evaluations_EvaluationId] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[Evaluations] ([EvaluationId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Evaluations_EvaluationId]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions_QuestionId]
GO
ALTER TABLE [dbo].[ApplicantProcess]  WITH CHECK ADD  CONSTRAINT [FK_ApplicantProcess_Applicants_ApplicantId] FOREIGN KEY([ApplicantId])
REFERENCES [dbo].[Applicants] ([ApplicantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantProcess] CHECK CONSTRAINT [FK_ApplicantProcess_Applicants_ApplicantId]
GO
ALTER TABLE [dbo].[ApplicantProcess]  WITH CHECK ADD  CONSTRAINT [FK_ApplicantProcesses_Processes] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[Processes] ([ProcessId])
GO
ALTER TABLE [dbo].[ApplicantProcess] CHECK CONSTRAINT [FK_ApplicantProcesses_Processes]
GO
ALTER TABLE [dbo].[ApplicantProcess]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationProcesses_Processes_ProcessId] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[Processes] ([ProcessId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantProcess] CHECK CONSTRAINT [FK_ApplicationProcesses_Processes_ProcessId]
GO
ALTER TABLE [dbo].[ApplicantProcess]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationProcesses_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantProcess] CHECK CONSTRAINT [FK_ApplicationProcesses_Status_StatusId]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Processes_ProcessId] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[Processes] ([ProcessId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Processes_ProcessId]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Tests_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Tests_TestId]
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Option_Answers_AnswerId] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[Answers] ([AnswerId])
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Option_Answers_AnswerId]
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Option_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Option_Questions_QuestionId]
GO
ALTER TABLE [dbo].[Processes]  WITH CHECK ADD  CONSTRAINT [FK_Processes_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Processes] CHECK CONSTRAINT [FK_Processes_Languages_LanguageId]
GO
ALTER TABLE [dbo].[Processes]  WITH CHECK ADD  CONSTRAINT [FK_Processes_Level_LevelId] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([LevelId])
GO
ALTER TABLE [dbo].[Processes] CHECK CONSTRAINT [FK_Processes_Level_LevelId]
GO
ALTER TABLE [dbo].[Processes]  WITH CHECK ADD  CONSTRAINT [FK_Processes_TestType_TestTypeId] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[TestType] ([TestTypeId])
GO
ALTER TABLE [dbo].[Processes] CHECK CONSTRAINT [FK_Processes_TestType_TestTypeId]
GO
ALTER TABLE [dbo].[ProcessQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProcessQuestion_Processes_ProcessesProcessId] FOREIGN KEY([ProcessesProcessId])
REFERENCES [dbo].[Processes] ([ProcessId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProcessQuestion] CHECK CONSTRAINT [FK_ProcessQuestion_Processes_ProcessesProcessId]
GO
ALTER TABLE [dbo].[ProcessQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProcessQuestion_Questions_QuestionsQuestionId] FOREIGN KEY([QuestionsQuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProcessQuestion] CHECK CONSTRAINT [FK_ProcessQuestion_Questions_QuestionsQuestionId]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_JobOffers_JobOfferId] FOREIGN KEY([JobOfferId])
REFERENCES [dbo].[JobOffers] ([JobOfferId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_JobOffers_JobOfferId]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_TestTypes_TestTypeId] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[TestTypes] ([TypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_TestTypes_TestTypeId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Processes_ProcessId] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[Processes] ([ProcessId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Processes_ProcessId]
GO

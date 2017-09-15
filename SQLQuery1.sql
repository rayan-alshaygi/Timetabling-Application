USE [timetableDB]
GO
/****** Object:  Table [dbo].[CourseClass]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[duration] [int] NOT NULL,
	[lab] [bit] NULL,
	[instructorId] [int] NOT NULL,
	[courseId] [int] NOT NULL,
	[roomId] [int] NULL,
	[preferredRoom] [int] NULL,
	[Tut] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseCurriculums]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCurriculums](
	[curriculumId] [int] NOT NULL,
	[courseId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[numberOfStudents] [int] NOT NULL,
	[codeArabic] [nvarchar](50) NULL,
	[codeEnglish] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoursesYD]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesYD](
	[courseId] [int] NOT NULL,
	[cs] [int] NULL,
	[stat] [int] NULL,
	[math] [int] NULL,
	[mathCS] [int] NULL,
	[statCS] [int] NULL,
	[IT] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CS]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CS](
	[year] [int] NOT NULL,
	[size] [int] NOT NULL,
	[labRoom] [int] NULL,
	[numOfGroups] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curriculum]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curriculum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[numberofstudents] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurriculumDevisions]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurriculumDevisions](
	[curriculumId] [int] NOT NULL,
	[cs] [int] NULL,
	[stat] [int] NULL,
	[math] [int] NULL,
	[mathCS] [int] NULL,
	[statCS] [int] NULL,
	[IT] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstructorPreferredTime]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorPreferredTime](
	[instructorId] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[timeStart] [int] NOT NULL,
	[timeEnd] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructors]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[TA] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IT]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IT](
	[year] [int] NOT NULL,
	[size] [int] NOT NULL,
	[labRoom] [int] NULL,
	[numOfGroups] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Math]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Math](
	[year] [int] NOT NULL,
	[size] [int] NOT NULL,
	[labRoom] [int] NULL,
	[numOfGroups] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MathCS]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MathCS](
	[year] [int] NOT NULL,
	[size] [int] NOT NULL,
	[labRoom] [int] NULL,
	[numOfGroups] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[numberofseats] [int] NOT NULL,
	[lab] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[courseClassId] [int] NOT NULL,
	[day] [nvarchar](50) NOT NULL,
	[time start] [int] NOT NULL,
	[time end] [int] NOT NULL,
	[roomId] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[courseClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STAT]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STAT](
	[year] [int] NOT NULL,
	[size] [int] NOT NULL,
	[labRoom] [int] NULL,
	[numOfGroups] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATCS]    Script Date: 8/29/2017 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATCS](
	[year] [int] NOT NULL,
	[size] [int] NULL,
	[labRoom] [int] NULL,
	[numOfGroups] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CourseClass] ON 

INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (2, N'محاضرة مبادئ علوم الحاسوب(2)', 2, 0, 49, 1, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (3, N'تمارين مبادئ علوم الحاسوب(2)', 2, 0, 55, 1, NULL, 1, 1)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (4, N'محاضرة الحسبان(2)', 3, 0, 48, 5, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (5, N'تمارين الحسبان(2)', 2, 0, 48, 5, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (6, N'محاضرة المتجهات و الميكانيكا', 2, 0, 5, 6, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (7, N'تمارين المتجهات و الميكانيكا', 2, 0, 5, 6, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (8, N'محاضرة مبادئ الحساب', 2, 0, 52, 7, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (9, N'تمارين مبادئ الحساب', 2, 0, 52, 7, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (10, N'محاضرة الجبر و الهندسة و التحليلية', 2, 0, 14, 8, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (11, N'تمارين الجبر و الهندسة و التحليلية', 2, 0, 14, 8, NULL, 1, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (12, N'محاضرة الجبر و الهندسة', 2, 0, 7, 9, NULL, 5, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (13, N'محاضرة أساسيات برمجة', 2, 0, 49, 10, NULL, 5, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (14, N'محاضرة مبادئ الفيزياء العامة', 2, 0, 40, 11, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (15, N'محاضرة بيئات و معدات الحاسوب', 2, 0, 24, 12, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (16, N'محاضرة مبادئ المحاسبة', 2, 0, 3, 13, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (17, N'محاضرة الاحصاء الأولي', 2, 0, 47, 14, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (18, N'محاضرة تحليل حقيقي(1)', 3, 0, 33, 15, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (19, N'محاضرة معادلات تفاضلية (2)', 2, 0, 45, 16, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (20, N'محاضرة تحليل متجهات', 3, 0, 48, 17, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (21, N'محاضرة رياضيات متقطعة', 2, 0, 7, 18, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (22, N'محاضرة حسابات عددية', 2, 0, 46, 19, NULL, 2, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (23, N'محاضرة ادارة وتنظيم الملفات', 2, 0, 40, 20, NULL, 7, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (24, N'محاضرة اساسيات برمجة (2)', 2, 0, 41, 21, NULL, 7, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (25, N'محاضرة التقنيات الحديثة للمعلومات ', 2, 0, 34, 22, NULL, 7, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (26, N'محاضرة تطبيقات الحاسوب في الاعمال(1', 2, 0, 2, 23, NULL, 7, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (27, N'محاضرة مبادئ النظم الالكترونية ', 2, 0, 18, 24, NULL, 7, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (28, N'محاضرة مبادئ الادارة ', 2, 0, 36, 25, NULL, 7, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (29, N'محاضرة احصاء عملي', 2, 0, 43, 26, NULL, 3, 0)
INSERT [dbo].[CourseClass] ([Id], [name], [duration], [lab], [instructorId], [courseId], [roomId], [preferredRoom], [Tut]) VALUES (30, N'محاضرة تحليل التوافيق', 2, 0, 22, 27, NULL, 3, 0)
SET IDENTITY_INSERT [dbo].[CourseClass] OFF
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (2, 1)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (2, 2)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (2, 5)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (2, 6)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (2, 7)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (2, 8)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (1, 9)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (1, 10)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (1, 11)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (1, 12)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (1, 13)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (3, 14)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (3, 15)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (3, 16)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (3, 17)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (3, 18)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (3, 19)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (4, 20)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (4, 21)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (4, 22)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (4, 23)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (4, 24)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (4, 25)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (5, 26)
INSERT [dbo].[CourseCurriculums] ([curriculumId], [courseId]) VALUES (5, 27)
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (1, N'مبادئ علوم الحاسوب(2)', 203, N'(ح 103', N'c103')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (2, N'مقدمة  الآحصاء والاحتمالات', 203, N'ا102', N's102')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (5, N'الحسبان(2)', 203, N'ت102', N'a102')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (6, N'المتجهات و الميكانيكا', 203, N'ت103', N'a103')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (7, N'مبادئ الحساب', 203, N'ا101', N's101')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (8, N'الجبر و الهندسة و التحليلية', 203, N'ب102', N'p102')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (9, N'الجبر و الهندسة', 59, N'ريض102', N'MI102')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (10, N'أساسيات برمجة', 59, N'حسب 103', N'ci103')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (11, N'مبادئ الفيزياء العامة', 59, N'هند101', N'hi101')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (12, N'بيئات و معدات الحاسوب', 59, N'هند104', N'hi104')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (13, N'مبادئ المحاسبة', 59, N'ادق102', N'ai102')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (14, N'الاحصاء الأولي', 164, N'ا202', N's202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (15, N'تحليل حقيقي(1)', 164, N'ب202', N'p202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (16, N'معادلات تفاضلية (2)', 164, N'ت202', N'a202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (17, N'تحليل متجهات', 164, N'ت203', N'a203')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (18, N'رياضيات متقطعة', 164, N'ح201', N'c201')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (19, N'حسابات عددية', 164, N'ح202', N'c202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (20, N'ادارة وتنظيم الملفات', 70, N'حسب202', N'ci202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (21, N'اساسيات برمجة (2)', 70, N'حسب204', N'ci204')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (22, N'التقنيات الحديثة للمعلومات ', 70, N'تطق201', N'ti201')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (23, N'تطبيقات الحاسوب في الاعمال(1', 70, N'تطق202', N'ti202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (24, N'مبادئ النظم الالكترونية ', 70, N'هند202', N'hi202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (25, N'مبادئ الادارة ', 70, N'ادق202', N'ai202')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (26, N'احصاء عملي', 188, N'إ302', N's302')
INSERT [dbo].[Courses] ([Id], [name], [numberOfStudents], [codeArabic], [codeEnglish]) VALUES (27, N'تحليل التوافيق', 188, N'ب303', N'p303')
SET IDENTITY_INSERT [dbo].[Courses] OFF
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (1, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (2, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (5, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (6, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (7, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (8, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (9, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (10, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (11, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (12, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (13, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (14, 2, 2, 2, 2, 2, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (15, 2, 2, 2, 2, 2, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (16, 2, 2, 1, 2, 2, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (17, 2, 2, 2, 2, 2, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (18, 2, 2, 2, 2, 2, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (19, 2, 2, 2, 2, 2, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (20, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (21, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (22, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (23, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (24, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (25, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (26, 3, 3, 3, 3, 3, NULL)
INSERT [dbo].[CoursesYD] ([courseId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (27, 3, 3, 3, 3, 3, NULL)
INSERT [dbo].[CS] ([year], [size], [labRoom], [numOfGroups]) VALUES (1, 47, NULL, 1)
INSERT [dbo].[CS] ([year], [size], [labRoom], [numOfGroups]) VALUES (2, 35, NULL, 1)
INSERT [dbo].[CS] ([year], [size], [labRoom], [numOfGroups]) VALUES (3, 48, NULL, 1)
INSERT [dbo].[CS] ([year], [size], [labRoom], [numOfGroups]) VALUES (4, 28, NULL, 1)
INSERT [dbo].[CS] ([year], [size], [labRoom], [numOfGroups]) VALUES (5, 40, NULL, 1)
SET IDENTITY_INSERT [dbo].[Curriculum] ON 

INSERT [dbo].[Curriculum] ([Id], [name], [numberofstudents]) VALUES (1, N'1It', 59)
INSERT [dbo].[Curriculum] ([Id], [name], [numberofstudents]) VALUES (2, N'1', 203)
INSERT [dbo].[Curriculum] ([Id], [name], [numberofstudents]) VALUES (3, N'2', 164)
INSERT [dbo].[Curriculum] ([Id], [name], [numberofstudents]) VALUES (4, N'2It', 70)
INSERT [dbo].[Curriculum] ([Id], [name], [numberofstudents]) VALUES (5, N'3', 188)
SET IDENTITY_INSERT [dbo].[Curriculum] OFF
INSERT [dbo].[CurriculumDevisions] ([curriculumId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (1, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[CurriculumDevisions] ([curriculumId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (3, 2, 2, 2, 2, 2, NULL)
INSERT [dbo].[CurriculumDevisions] ([curriculumId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (4, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[CurriculumDevisions] ([curriculumId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (2, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[CurriculumDevisions] ([curriculumId], [cs], [stat], [math], [mathCS], [statCS], [IT]) VALUES (5, 3, 3, 3, 3, 3, NULL)
SET IDENTITY_INSERT [dbo].[Instructors] ON 

INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (1, N'MK', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (2, N'MAMA', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (3, N'M.ALFATE7', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (4, N'OBADA', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (5, N'WD ALMKI', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (6, N'RA3D', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (7, N'MARIAM', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (8, N'AZZA', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (9, N'NASHWA', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (10, N'EMAN', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (14, N'Sara Faisal', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (15, N'MUJTABA AHMED', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (16, N'ABDULFATAH ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (17, N'ALAMIN HASSAN', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (18, N'EZZ ALDAIN KAMIL', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (19, N'M.ABDULLAH', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (20, N'LAYLA 7MADALNEEL', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (21, N'MAHMOD ALI ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (22, N'MOHAMED AHMED', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (23, N'HWAYDA ALSHOSH', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (24, N'ABUBAKR SIRAJ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (25, N'MARWA EMAD ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (26, N'ALARGAM ALRAYAH', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (27, N'MOHAMED OMER ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (28, N'AMANI ALFAKKI', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (29, N'HASEM ABDUALLAH', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (30, N'ESRAA OSAMA', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (31, N'RANDA ABDULHALIM', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (32, N'KHALID ALBADWI ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (33, N'TAJ ALSIR', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (34, N'HISHAM ABUSHAMA', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (35, N'HADYA HAMID', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (36, N'SUHAYLA ABDULLAH ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (37, N'AZZA OSMAN', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (38, N'HANAA KHALID', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (40, N'ADIL YOSUF', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (41, N'MUSTAFA BABIKER', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (43, N'KHALID OBAID', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (44, N'MOHAMED SAYID', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (45, N'SARA MOHAMED  ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (46, N'EMAN ALNAEEM', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (47, N'FATHI HEMMAT', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (48, N'EMADALDEEN MANSOR', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (49, N'ABDULHAMID ABDULHADI', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (50, N'ADIL ADAM', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (51, N'MOHSEN HASSAN', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (52, N'NOR ALHUDA ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (53, N'SAHAR', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (54, N'SANAA AHMED ', 0)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (55, N'TAC101', 1)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (56, N'TAS102', 1)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (57, N'TAP102', 1)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (58, N'TAA102', 1)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (59, N'TAA103', 1)
INSERT [dbo].[Instructors] ([Id], [name], [TA]) VALUES (60, N'', 0)
SET IDENTITY_INSERT [dbo].[Instructors] OFF
INSERT [dbo].[IT] ([year], [size], [labRoom], [numOfGroups]) VALUES (1, 59, NULL, 1)
INSERT [dbo].[IT] ([year], [size], [labRoom], [numOfGroups]) VALUES (2, 70, NULL, 1)
INSERT [dbo].[IT] ([year], [size], [labRoom], [numOfGroups]) VALUES (3, 74, NULL, 1)
INSERT [dbo].[IT] ([year], [size], [labRoom], [numOfGroups]) VALUES (4, 80, NULL, 1)
INSERT [dbo].[IT] ([year], [size], [labRoom], [numOfGroups]) VALUES (5, 69, NULL, 1)
INSERT [dbo].[Math] ([year], [size], [labRoom], [numOfGroups]) VALUES (1, 39, NULL, 1)
INSERT [dbo].[Math] ([year], [size], [labRoom], [numOfGroups]) VALUES (2, 23, NULL, 1)
INSERT [dbo].[Math] ([year], [size], [labRoom], [numOfGroups]) VALUES (3, 34, NULL, 1)
INSERT [dbo].[Math] ([year], [size], [labRoom], [numOfGroups]) VALUES (4, 13, NULL, 1)
INSERT [dbo].[Math] ([year], [size], [labRoom], [numOfGroups]) VALUES (5, 17, NULL, 1)
INSERT [dbo].[MathCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (1, 39, NULL, 1)
INSERT [dbo].[MathCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (2, 39, NULL, 1)
INSERT [dbo].[MathCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (3, 31, NULL, 1)
INSERT [dbo].[MathCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (4, 34, NULL, 1)
INSERT [dbo].[MathCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (5, 34, NULL, 1)
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (1, N'obied khtem1', 300, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (2, N'obied khtem2', 300, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (3, N'obied khtem3', 300, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (5, N'101', 100, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (7, N'102', 100, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (12, N'sr1', 80, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (13, N'sr2', 80, 0)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (14, N'Lab 201', 40, 1)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (15, N'Lab 202', 40, 1)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (16, N'Lab 5', 60, 1)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (17, N'Lab 1', 30, 1)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (18, N'Lab 2', 30, 1)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (19, N'Lab 3', 30, 1)
INSERT [dbo].[Rooms] ([Id], [name], [numberofseats], [lab]) VALUES (20, N'Lab 4', 30, 1)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (2, N'Monday', 12, 14, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (3, N'Wednesday', 10, 12, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (4, N'Tuesday', 12, 15, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (5, N'Sunday', 8, 10, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (6, N'Thursday', 14, 16, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (7, N'Tuesday', 8, 10, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (8, N'Thursday', 12, 14, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (9, N'Sunday', 14, 16, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (10, N'Wednesday', 16, 18, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (11, N'Monday', 14, 16, 2)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (12, N'Tuesday', 16, 18, 12)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (13, N'Wednesday', 14, 16, 12)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (14, N'Thursday', 16, 18, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (15, N'Wednesday', 16, 18, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (16, N'Monday', 16, 18, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (17, N'Sunday', 8, 10, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (18, N'Thursday', 8, 11, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (19, N'Tuesday', 14, 16, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (20, N'Monday', 10, 13, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (21, N'Tuesday', 12, 14, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (22, N'Wednesday', 14, 16, 3)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (23, N'Monday', 10, 12, 1)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (24, N'Wednesday', 12, 14, 1)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (25, N'Sunday', 12, 14, 1)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (26, N'Monday', 8, 10, 1)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (27, N'Wednesday', 8, 10, 1)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (28, N'Tuesday', 8, 10, 1)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (29, N'Tuesday', 8, 10, 5)
INSERT [dbo].[Schedule] ([courseClassId], [day], [time start], [time end], [roomId]) VALUES (30, N'Wednesday', 10, 12, 5)
INSERT [dbo].[STAT] ([year], [size], [labRoom], [numOfGroups]) VALUES (1, 30, NULL, 1)
INSERT [dbo].[STAT] ([year], [size], [labRoom], [numOfGroups]) VALUES (2, 29, NULL, 1)
INSERT [dbo].[STAT] ([year], [size], [labRoom], [numOfGroups]) VALUES (3, 27, NULL, 1)
INSERT [dbo].[STAT] ([year], [size], [labRoom], [numOfGroups]) VALUES (4, 22, NULL, 1)
INSERT [dbo].[STAT] ([year], [size], [labRoom], [numOfGroups]) VALUES (5, 19, NULL, 1)
INSERT [dbo].[STATCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (1, 48, NULL, 1)
INSERT [dbo].[STATCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (2, 38, NULL, 1)
INSERT [dbo].[STATCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (3, 48, NULL, 1)
INSERT [dbo].[STATCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (4, 47, NULL, 1)
INSERT [dbo].[STATCS] ([year], [size], [labRoom], [numOfGroups]) VALUES (5, 29, NULL, 1)
ALTER TABLE [dbo].[CourseClass] ADD  DEFAULT ((0)) FOR [lab]
GO
ALTER TABLE [dbo].[CourseClass] ADD  DEFAULT ((0)) FOR [Tut]
GO
ALTER TABLE [dbo].[CS] ADD  DEFAULT ((1)) FOR [numOfGroups]
GO
ALTER TABLE [dbo].[Instructors] ADD  DEFAULT ((0)) FOR [TA]
GO
ALTER TABLE [dbo].[IT] ADD  DEFAULT ((1)) FOR [numOfGroups]
GO
ALTER TABLE [dbo].[Math] ADD  DEFAULT ((1)) FOR [numOfGroups]
GO
ALTER TABLE [dbo].[MathCS] ADD  DEFAULT ((1)) FOR [numOfGroups]
GO
ALTER TABLE [dbo].[Rooms] ADD  DEFAULT ((0)) FOR [lab]
GO
ALTER TABLE [dbo].[STAT] ADD  DEFAULT ((1)) FOR [numOfGroups]
GO
ALTER TABLE [dbo].[STATCS] ADD  DEFAULT ((1)) FOR [numOfGroups]
GO
ALTER TABLE [dbo].[CourseClass]  WITH CHECK ADD  CONSTRAINT [FK_CourseClass_ToTableCourses] FOREIGN KEY([courseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseClass] CHECK CONSTRAINT [FK_CourseClass_ToTableCourses]
GO
ALTER TABLE [dbo].[CourseClass]  WITH CHECK ADD  CONSTRAINT [FK_CourseClass_ToTableRooms] FOREIGN KEY([roomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[CourseClass] CHECK CONSTRAINT [FK_CourseClass_ToTableRooms]
GO
ALTER TABLE [dbo].[CourseClass]  WITH CHECK ADD  CONSTRAINT [FK_CourseClass_ToTableRoomsP] FOREIGN KEY([preferredRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[CourseClass] CHECK CONSTRAINT [FK_CourseClass_ToTableRoomsP]
GO
ALTER TABLE [dbo].[CourseCurriculums]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumClasses_ToTableCourses] FOREIGN KEY([courseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseCurriculums] CHECK CONSTRAINT [FK_CurriculumClasses_ToTableCourses]
GO
ALTER TABLE [dbo].[CourseCurriculums]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumClasses_ToTableCurriculum] FOREIGN KEY([curriculumId])
REFERENCES [dbo].[Curriculum] ([Id])
GO
ALTER TABLE [dbo].[CourseCurriculums] CHECK CONSTRAINT [FK_CurriculumClasses_ToTableCurriculum]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD__ToTableIT] FOREIGN KEY([IT])
REFERENCES [dbo].[IT] ([year])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD__ToTableIT]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD_ToTableCourses] FOREIGN KEY([courseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD_ToTableCourses]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD_ToTableCS] FOREIGN KEY([cs])
REFERENCES [dbo].[CS] ([year])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD_ToTableCS]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD_ToTableMath] FOREIGN KEY([math])
REFERENCES [dbo].[Math] ([year])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD_ToTableMath]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD_ToTableMathCS] FOREIGN KEY([mathCS])
REFERENCES [dbo].[MathCS] ([year])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD_ToTableMathCS]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD_ToTableStat] FOREIGN KEY([stat])
REFERENCES [dbo].[STAT] ([year])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD_ToTableStat]
GO
ALTER TABLE [dbo].[CoursesYD]  WITH CHECK ADD  CONSTRAINT [FK_CoursesYD_ToTableStatCS] FOREIGN KEY([statCS])
REFERENCES [dbo].[STATCS] ([year])
GO
ALTER TABLE [dbo].[CoursesYD] CHECK CONSTRAINT [FK_CoursesYD_ToTableStatCS]
GO
ALTER TABLE [dbo].[CS]  WITH CHECK ADD  CONSTRAINT [FK_CS_ToRooms] FOREIGN KEY([labRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[CS] CHECK CONSTRAINT [FK_CS_ToRooms]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableCS] FOREIGN KEY([cs])
REFERENCES [dbo].[CS] ([year])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableCS]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableCurriculum] FOREIGN KEY([curriculumId])
REFERENCES [dbo].[Curriculum] ([Id])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableCurriculum]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableIT] FOREIGN KEY([IT])
REFERENCES [dbo].[IT] ([year])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableIT]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableMath] FOREIGN KEY([math])
REFERENCES [dbo].[Math] ([year])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableMath]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableMathCS] FOREIGN KEY([mathCS])
REFERENCES [dbo].[MathCS] ([year])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableMathCS]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableStat] FOREIGN KEY([stat])
REFERENCES [dbo].[STAT] ([year])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableStat]
GO
ALTER TABLE [dbo].[CurriculumDevisions]  WITH CHECK ADD  CONSTRAINT [FK_CurriculumDevisions_ToTableStatCS] FOREIGN KEY([statCS])
REFERENCES [dbo].[STATCS] ([year])
GO
ALTER TABLE [dbo].[CurriculumDevisions] CHECK CONSTRAINT [FK_CurriculumDevisions_ToTableStatCS]
GO
ALTER TABLE [dbo].[IT]  WITH CHECK ADD  CONSTRAINT [FK_IT_ToRooms] FOREIGN KEY([labRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[IT] CHECK CONSTRAINT [FK_IT_ToRooms]
GO
ALTER TABLE [dbo].[Math]  WITH CHECK ADD  CONSTRAINT [FK_Math_ToRooms] FOREIGN KEY([labRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Math] CHECK CONSTRAINT [FK_Math_ToRooms]
GO
ALTER TABLE [dbo].[MathCS]  WITH CHECK ADD  CONSTRAINT [FK_MathCS_ToRooms] FOREIGN KEY([labRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[MathCS] CHECK CONSTRAINT [FK_MathCS_ToRooms]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_ToTableCourseClass] FOREIGN KEY([courseClassId])
REFERENCES [dbo].[CourseClass] ([Id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_ToTableCourseClass]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_ToTableRooms] FOREIGN KEY([roomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_ToTableRooms]
GO
ALTER TABLE [dbo].[STAT]  WITH CHECK ADD  CONSTRAINT [FK_STAT_ToRooms] FOREIGN KEY([labRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[STAT] CHECK CONSTRAINT [FK_STAT_ToRooms]
GO
ALTER TABLE [dbo].[STATCS]  WITH CHECK ADD  CONSTRAINT [FK_STATCS_ToRooms] FOREIGN KEY([labRoom])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[STATCS] CHECK CONSTRAINT [FK_STATCS_ToRooms]
GO

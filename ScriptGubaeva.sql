USE [NoteTakingApp]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 13.06.2025 10:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 13.06.2025 10:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[content] [text] NULL,
	[category_id] [int] NULL,
	[user_id] [int] NULL,
	[is_delete] [bit] NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.06.2025 10:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password_hash] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [name], [user_id]) VALUES (1, N'Work', 1)
INSERT [dbo].[Categories] ([id], [name], [user_id]) VALUES (2, N'Personal', 1)
INSERT [dbo].[Categories] ([id], [name], [user_id]) VALUES (3, N'Fitness', 2)
INSERT [dbo].[Categories] ([id], [name], [user_id]) VALUES (4, N'Travel', 2)
INSERT [dbo].[Categories] ([id], [name], [user_id]) VALUES (5, N'Hobbies', 3)
INSERT [dbo].[Categories] ([id], [name], [user_id]) VALUES (6, N'—', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Notes] ON 

INSERT [dbo].[Notes] ([id], [title], [content], [category_id], [user_id], [is_delete]) VALUES (1, N'Project kickoff', N'Discuss the project goals and timeline.', 1, 1, 0)
INSERT [dbo].[Notes] ([id], [title], [content], [category_id], [user_id], [is_delete]) VALUES (2, N'Weekly report', N'Prepare the report for management meeting.', 1, 1, 0)
INSERT [dbo].[Notes] ([id], [title], [content], [category_id], [user_id], [is_delete]) VALUES (3, N'Buy groceries', N'Milk, bread, eggs', 2, 1, 0)
INSERT [dbo].[Notes] ([id], [title], [content], [category_id], [user_id], [is_delete]) VALUES (4, N'Workout schedule', N'Morning runs and evening yoga.', 3, 2, 1)
INSERT [dbo].[Notes] ([id], [title], [content], [category_id], [user_id], [is_delete]) VALUES (5, N'Trip to Japan', N'Plan the itinerary and book flights.', 4, 2, 1)
INSERT [dbo].[Notes] ([id], [title], [content], [category_id], [user_id], [is_delete]) VALUES (6, N'Learn guitar', N'Beginner lessons and practice daily.', 5, 3, 1)
SET IDENTITY_INSERT [dbo].[Notes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [password_hash]) VALUES (1, N'alice', N'1')
INSERT [dbo].[Users] ([id], [username], [password_hash]) VALUES (2, N'bob', N'2')
INSERT [dbo].[Users] ([id], [username], [password_hash]) VALUES (3, N'charlie', N'3')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Categories] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Categories]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Users]
GO

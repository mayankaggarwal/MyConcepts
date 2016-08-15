USE [Books]
GO

/****** Object:  Table [dbo].[BoodDetails]    Script Date: 27-07-2016 17:52:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookDetails](
	ID INT IDENTITY(1,1) Primary Key,
	[title] [nvarchar](50) NULL,
	[genre] [nvarchar](50) NULL,
	[author] [nvarchar](50) NULL,
	[read] [bit] NULL
) ON [PRIMARY]

GO

INSERT INTO [dbo].BookDetails VALUES('War and Peace','Historical Fiction','Lev Nik Tolstoy',0),
									('Les miserables','Historical Fiction','Victor Huge',0),
									('Life of Mississipi','History','Mark Twain',0),
									('Childhood','BiogA Journey into the Center of the Earthraphy','Lev Nikolayevich TolstoryScience Fiction',0),
									('Wind in the Willows','Fantasy','Kenneth Grahm',0),
									('The Dark World','Fantasy','Henry Kuttner',0),
									('A Journey into the Center of the Earth','Science Fiction','Jules Verna',0),
									('A Time Machine','Science Fiction','H. G. Wells',0),
									('A Time Machine','Science Fiction','H. G. Wells',0);

SELECT * FROM [dbo].[BookDetails];
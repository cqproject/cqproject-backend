﻿CREATE TABLE [dbo].[TblNotices]
(
	[ID]			INT NOT NULL IDENTITY(1,1),
	[Title]			NVARCHAR(MAX)	NULL, 
	[Text]			NVARCHAR(MAX)	NULL, 
	[CreatedDate]	DATETIME	NULL, 
	[Image]			NVARCHAR(MAX)	NULL, 
    [SchoolFK]		INT				NULL,
	CONSTRAINT [PK_NoticeID] PRIMARY KEY CLUSTERED ([ID] ASC)
)

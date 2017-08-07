﻿CREATE TABLE [dbo].[TblFloors]
(
	[ID]		INT				NOT NULL IDENTITY(1,1),
	[Name]		NVARCHAR(MAX)	NULL,
	[Image]		NVARCHAR(MAX)	NULL,
	[SchoolFK]	INT				NULL,
	CONSTRAINT [PK_FloorID] PRIMARY KEY CLUSTERED ([ID] ASC)
)

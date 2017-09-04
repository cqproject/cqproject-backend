﻿CREATE TABLE [dbo].[TblRooms]
(
	[ID]		INT				NOT NULL IDENTITY(1,1),
	[Name]		NVARCHAR(MAX)	NULL,
	[XCoord]	INT				NULL,
	[YCoord]	INT				NULL,
	[FloorFK]	INT				NULL,
	CONSTRAINT [PK_RoomID] PRIMARY KEY CLUSTERED ([ID] ASC)
)

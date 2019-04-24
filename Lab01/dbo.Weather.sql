CREATE TABLE [dbo].[Weather]
(
	[Id] INT NOT NULL , 
    [City] TEXT NOT NULL, 
    [Temperature] FLOAT NOT NULL, 
    [Wind] TEXT NOT NULL, 
    CONSTRAINT [PK_Weather] PRIMARY KEY ([Id])
)

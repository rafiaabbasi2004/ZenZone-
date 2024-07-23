# ZenZone-
This project is made using html, css and C# along with SQL local database 
To run this project open the visual Studio IDE and open project in blazor webserver .net6 and make a local database in there with the name ZENZONE and made following tables

CREATE TABLE [dbo].[User_info] (
    [Email]       NCHAR (100) NOT NULL,
    [FirstName]   NCHAR (10)  NULL,
    [LastName]    NCHAR (10)  NULL,
    [DateofBirth] NCHAR (10)  NULL,
    [Password]    NCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);


CREATE TABLE [dbo].[ContactMessages] (
    [MessageId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NULL,
    [Email]     NCHAR (100)    NULL,
    [Message]   NVARCHAR (MAX) NULL,
    [CreatedAt] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([MessageId] ASC),
    CONSTRAINT [FK_ContactMessages_ToTable] FOREIGN KEY ([Email]) REFERENCES [dbo].[User_info] ([Email])
);

and then connecting it with project run it

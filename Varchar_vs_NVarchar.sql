CREATE DATABASE [TestColumnTypeDB];
GO

USE [TestColumnTypeDB];
GO

CREATE TABLE [dbo].[UsersVarchar] (
	[name] [varchar](30) NOT NULL
	,[nationalCode] [varchar](30) NOT NULL
	,[phoneNumber] [varchar](30) NOT NULL
	,[postalCode] [varchar](30) NOT NULL
	,[email] [varchar](30) NOT NULL
	,[Age] [int] NOT NULL
	) ON [PRIMARY];
GO

CREATE TABLE [dbo].[UsersNVarchar] (
	[name] [NVarchar](30) NOT NULL
	,[nationalCode] [NVarchar](30) NOT NULL
	,[phoneNumber] [NVarchar](30) NOT NULL
	,[postalCode] [NVarchar](30) NOT NULL
	,[email] [NVarchar](30) NOT NULL
	) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [varcharIndex-users-nationalCode] 
ON [dbo].[UsersVarchar] ([nationalCode] ASC);
GO

CREATE NONCLUSTERED INDEX [NVarcharIndex-users-nationalCode] 
ON [dbo].[UsersNVarchar] ([nationalCode] ASC);
GO

WITH cte
AS (
	SELECT 1 AS id
	
	UNION ALL
	
	SELECT id + 1
	FROM cte
	WHERE id < 1000000
	)
	,personInfo
AS (
	SELECT 'jamal arghavani' name
		,'1000654222' nationalCode
		,'02166666666' phoneNumber
		,'2100065422' postalCode
		,'arghavanis.jamal@gmail.com' email
	)
INSERT INTO UsersVarchar
SELECT personInfo.*
FROM personInfo
CROSS JOIN cte
OPTION (MAXRECURSION 0);
GO

WITH cte
AS (
	SELECT 1 AS id
	
	UNION ALL
	
	SELECT id + 1
	FROM cte
	WHERE id < 1000000
	)
	,personInfo
AS (
	SELECT 'jamal arghavani' name
		,'1000654222' nationalCode
		,'22100065422' phoneNumber
		,'2100065422' postalCode
		,'arghavanis.jamal@gmail.com' email
	)
INSERT INTO UsersNVarchar
SELECT personInfo.*
FROM personInfo
CROSS JOIN cte
OPTION (MAXRECURSION 0);
GO

EXEC sp_spaceused 'dbo.UsersVarchar';

EXEC sp_spaceused 'dbo.UsersNVarchar';
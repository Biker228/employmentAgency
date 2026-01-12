USE master
	GO
	IF DB_ID('Employment_Bureau') IS NULL
	begin
	CREATE DATABASE Employment_Bureau
	ON
		PRIMARY (NAME=Employment_Bureau,
		FILENAME='F:\DB_Employment_Bureau_data.mdf',
		SIZE=5,
		FILEGROWTH=10% )
	LOG ON (
		NAME=Employment_Bureau_log,
		FILENAME='F:\DB_Employment_Bureau_log.ldf',
		SIZE=1,
		FILEGROWTH=1
		)
	end
	ELSE
			PRINT 'База данных Employment_Bureau уже существует!'
GO	
USE Employment_Bureau
	GO
	
		IF OBJECT_ID(N'dbo.Staff',N'U') IS NULL
		BEGIN
		CREATE TABLE [dbo].[Staff](
		[code_access] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[post] [varchar](14) NOT NULL)
		END
	ELSE
		PRINT 'Таблица Staff уже существует!'
		
	IF OBJECT_ID(N'dbo.Applicant',N'U') IS NULL
			BEGIN
			CREATE TABLE dbo.Applicant(
			Code_Applicant INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
			Sername CHAR(40) NOT NULL,
			Name CHAR(20),
			[password] [varchar](50),
			Qualification CHAR(40),
			Other_Data CHAR(40),
			[code_access] [int] NOT NULL FOREIGN KEY REFERENCES Staff([code_access]))
			END
		ELSE
			PRINT 'Таблица Applicant уже существует!'
			
	IF OBJECT_ID(N'dbo.Employer',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Employer(
		Code_Employer INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
		Emp_Phone CHAR(20),
		Address CHAR(40) NOT NULL,
		Title CHAR(40) NOT NULL,
		Code_Applicant INT NOT NULL FOREIGN KEY REFERENCES Applicant(Code_Applicant))
		END
	ELSE
		PRINT 'Таблица Employer уже существует!'
	
	IF OBJECT_ID(N'dbo.TypeActivity',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.TypeActivity(
		Code_Activity INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
		Type_Activity CHAR(40) NOT NULL)
		END
	ELSE
		PRINT 'Таблица TypeActivity уже существует!'
	
	IF OBJECT_ID(N'dbo.Vacancy',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Vacancy(
		Code_Vacancy INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
		Code_Employer INT NOT NULL FOREIGN KEY REFERENCES Employer(Code_Employer),
		Code_Activity INT NOT NULL FOREIGN KEY REFERENCES TypeActivity(Code_Activity), 
		Salary FLOAT)
		END
	ELSE
		PRINT 'Таблица Vacancy уже существует!'
		
	IF OBJECT_ID(N'dbo.Transactions',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Transactions(
		Code_Vacancy INT NOT NULL FOREIGN KEY REFERENCES Vacancy(Code_Vacancy),
		Code_Applicant INT NOT NULL FOREIGN KEY REFERENCES Applicant(Code_Applicant),
		Comission FLOAT NOT NULL,
		Date_Transaction DATE NOT NULL)
		END
	ELSE
		PRINT 'Таблица Transactions уже существует!'
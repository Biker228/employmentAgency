USE master
GO
	IF DB_ID('DB_EmpBureau') IS NULL
		CREATE DATABASE DB_EmpBureau
		ON
			PRIMARY (NAME=EmploymentBureau,
			FILENAME='F:\DB_EmpBureau_data.mdf',
			SIZE=5,
			FILEGROWTH=10% )
		LOG ON (
			NAME=BooksLog,
			FILENAME='F:\DB_EmpBureau_log.ldf',
			SIZE=1,
			FILEGROWTH=1
			)
	ELSE 
		PRINT 'База данных DB_EmpBureau уже существует!'
		GO
		USE DB_EmpBureau
		GO

	IF OBJECT_ID(N'dbo.TypeActivity',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.TypeActivity(
		Code_Activity INT NOT NULL PRIMARY KEY,
		Type_Activity CHAR(40) NOT NULL)
		END
	ELSE
		PRINT 'Таблица dbo.TypeActivity уже существует!'

	IF OBJECT_ID(N'dbo.Employers',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Employers(
		Code_Employer INT NOT NULL PRIMARY KEY,
		Emp_Phone INT,
		Address CHAR(40) NOT NULL,
		Title CHAR(40) NOT NULL)
		END
	ELSE
		PRINT 'Таблица dbo.Employers уже существует!'

	IF OBJECT_ID(N'dbo.Applicants',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Applicants(
		Code_Applicant INT NOT NULL PRIMARY KEY,
		Sername CHAR(20) NOT NULL,
		Name CHAR(20) NOT NULL,
		Code_Activity INT NOT NULL FOREIGN KEY REFERENCES TypeActivity(Code_Activity),
		Qualification CHAR(40) NOT NULL,
		Other_Data CHAR(40))
		END
	ELSE
		PRINT 'Таблица dbo.Applicants уже существует!'

	IF OBJECT_ID(N'dbo.Transactions',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Transactions(
		Code_Employer INT NOT NULL FOREIGN KEY REFERENCES Employers(Code_Employer),
		Code_Applicant INT NOT NULL FOREIGN KEY REFERENCES Applicants(Code_Applicant),
		Code_Activity INT NOT NULL FOREIGN KEY REFERENCES TypeActivity(Code_Activity),
		Comission FLOAT NOT NULL)
		END
	ELSE
		PRINT 'Таблица dbo.Transactions уже существует!'

	IF OBJECT_ID(N'dbo.Vacancy',N'U') IS NULL
		BEGIN
		CREATE TABLE dbo.Vacancy(
		Code_Employer INT NOT NULL FOREIGN KEY REFERENCES Employers(Code_Employer),
		Code_Activity INT NOT NULL FOREIGN KEY REFERENCES TypeActivity(Code_Activity),
		Salary FLOAT)
		END
	ELSE
		PRINT 'Таблица dbo.Vacancy уже существует!'


-- Create Database
CREATE DATABASE SampleDB;
GO
USE SampleDB;

-- Create Table
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Position NVARCHAR(100),
    Salary DECIMAL(10,2)
);

-- Insert
CREATE PROCEDURE spAddEmployee
    @Name NVARCHAR(100),
    @Position NVARCHAR(100),
    @Salary DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Employees (Name, Position, Salary)
    VALUES (@Name, @Position, @Salary)
END
GO

-- Select All
CREATE PROCEDURE spGetAllEmployees
AS
BEGIN
    SELECT * FROM Employees
END
GO

-- Select by ID
CREATE PROCEDURE spGetEmployeeById
    @Id INT
AS
BEGIN
    SELECT * FROM Employees WHERE Id = @Id
END
GO

-- Update
CREATE PROCEDURE spUpdateEmployee
    @Id INT,
    @Name NVARCHAR(100),
    @Position NVARCHAR(100),
    @Salary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Name = @Name, Position = @Position, Salary = @Salary
    WHERE Id = @Id
END
GO

-- Delete
CREATE PROCEDURE spDeleteEmployee
    @Id INT
AS
BEGIN
    DELETE FROM Employees WHERE Id = @Id

CREATE DATABASE BankingDb;
GO

USE BankingDb;
GO

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DNI NVARCHAR(20) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Customer_DNI UNIQUE (DNI)
);
GO

CREATE TABLE BankAccounts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AccountNumber INT NOT NULL,
    Balance DECIMAL(18,2) NOT NULL DEFAULT 0,
    CustomerId INT NOT NULL,
    CONSTRAINT FK_BankAccount_Customer FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    CONSTRAINT UQ_BankAccount_Number UNIQUE (AccountNumber)
);
GO

CREATE INDEX IX_BankAccounts_CustomerId ON BankAccounts(CustomerId);
GO
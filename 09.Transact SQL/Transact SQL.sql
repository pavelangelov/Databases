CREATE DATABASE BankAccounts

--Task 1. Create a database with two tables: Persons and Accounts.
USE BankAccounts
CREATE TABLE Persons(
	Id INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN INT UNIQUE,
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
)

CREATE TABLE Accounts(
	Id INT IDENTITY,
	PersonId INT,
	Balance MONEY,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId) REFERENCES Persons(Id)
)

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Pesho', 'Peshev', 123123123),
				('Gosho', 'Goshev', 111111111),
				('Misho', 'Mishev', 222222222)

INSERT INTO Accounts (PersonId, Balance)
VALUES (1, 2000),
				(2, 1000),
				(3, 500)
GO

CREATE PROC usp_SelectAllFullNames
AS
SELECT p.FirstName + ' ' + p.LastName FROM Persons p

GO

EXEC usp_SelectAllFullNames
GO

--Task 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_SelectPersonByBalance @minBalance MONEY
AS
SELECT p.FirstName + ' ' + p.LastName AS [Name], a.Balance FROM Persons p
	JOIN Accounts a
	ON p.Id = a.PersonId
WHERE a.Balance >= @minBalance

GO

EXEC usp_SelectPersonByBalance 505
GO

--Task 3. Create a function that accepts as parameters � sum, yearly interest rate and number of months.
CREATE FUNCTION ufn_CalculateBalance (
	@sum MONEY, @yearlyInterest FLOAT, @months FLOAT)
RETURNS MONEY
AS
BEGIN
	RETURN @sum * (@yearlyInterest * @months)
END

GO

USE BankAccounts
DECLARE @sum MONEY, @interest FLOAT, @months FLOAT

SET @sum = 100
SET @interest = 2
SET @months = 6

SELECT BankAccounts.dbo.ufn_CalculateBalance (@sum, @interest, @months) AS [Sum]
GO
--Task 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
CREATE PROC usp_CalculateInterest @accountId INT, @interestRate FLOAT
AS
SELECT 
	p.FirstName, 
	p.LastName, 
	a.Balance, 
	dbo.ufn_CalculateBalance (a.Balance, @interestRate, 1) AS [After]
FROM Accounts a
	JOIN Persons p
	ON p.Id = @accountId
WHERE a.Id = @accountId
	GO

	EXEC usp_CalculateInterest 2, 3

	GO

--Task 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROC usp_WithdrawMoney @accountId MONEY, @money MONEY
AS
	UPDATE Accounts 
	SET Balance = Balance - @money
	WHERE Id= @accountId
GO

CREATE PROC usp_DepositMoney @accountId MONEY, @money MONEY
AS
	UPDATE Accounts 
	SET Balance = Balance + @money
	WHERE Id= @accountId
GO

EXEC usp_WithdrawMoney 1, 111	
EXEC usp_DepositMoney 1, 112

--Task 6. Create another table � Logs(LogID, AccountID, OldSum, NewSum).Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs (
	Id INT IDENTITY,
	AccountId INT,
	OldSum MONEY,
	NewSum MONEY,
	CONSTRAINT PK_Logs PRIMARY KEY (Id),
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
)

GO

CREATE TRIGGER tr_AccountsUpdateBalance ON Accounts
	AFTER UPDATE
AS
DECLARE @oldSum MONEY, @newSum MONEY, @accountId INT
IF EXISTS (SELECT Id FROM inserted) AND EXISTS (SELECT Balance FROM deleted)
BEGIN
	SELECT @newSum = Balance FROM inserted
	SELECT @oldSum = Balance FROM deleted
	SELECT @accountId = a.Id FROM Accounts a
	WHERE a.Id = (SELECT Id FROM inserted)
	INSERT INTO Logs (AccountId, OldSum, NewSum)
		VALUES (@accountId, @oldSum, @newSum)
END
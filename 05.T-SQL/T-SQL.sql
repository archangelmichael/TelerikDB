-- WARNING! UNCOMMENT ALL COMMENTED LINES IF RUNNING THE SCRIPT FOR THE FIRST TIME --
/*
TASK 1.
Create a database with two tables: 
Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
Insert few records for testing. Write a stored procedure that selects the full names of all persons.*/CREATE DATABASE [Accounting System]
GO

USE [Accounting System]
CREATE TABLE Persons (
	PersonID INT IDENTITY,
	FirstName nvarchar(100) NOT NULL,
	LastName nvarchar(100) NOT NULL,
	SSN INT NOT NULL
	CONSTRAINT PK_PersonID PRIMARY KEY(PersonID)
)
GO

CREATE TABLE Accounts (
	AccountID INT IDENTITY,
	PersonID INT NOT NULL,
	Balance MONEY DEFAULT 0,
	CONSTRAINT AccountID PRIMARY KEY(AccountID),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
)
GO

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('MINCHO', 'KIRKOV', 12345),
('MINCHO', 'PRAZNIKOV', 23456),
('EMIL', 'CHOLAKOV', 86753),
('IVAYLO', 'KATUNCHEV', 54233),
('BATISTA', 'MILOSHEV', 99999)
GO

INSERT INTO Accounts(Balance, PersonID)
VALUES (2, 2345),
(3, 5453),
(1, 2311),
(4, 1000),
(5, 10)
GO

CREATE PROC dbo.usp_SelectUserNames
AS
  SELECT  concat(FirstName, ' ', LastName) AS [Full Name]
  FROM Persons
GO

EXEC usp_SelectUserNames
GO

/*
Task 2.
Create a stored procedure that accepts a number as a parameter and returns all persons 
who have more money in their accounts than the supplied number.
*/
CREATE PROC dbo.usp_SelectUsersWithBiggerAccounts(@balance money)
AS
  SELECT  concat(FirstName, ' ', LastName) AS [FULL Name], acc.Balance
  FROM Persons p
  JOIN Accounts acc
  ON acc.PersonId = p.PersonID
  WHERE acc.Balance > @balance
  ORDER BY acc.Balance
GO

EXEC usp_SelectUsersWithBiggerAccounts 2400
GO

/*
Task 3.
Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
It should calculate and return the new sum. 
Write a SELECT to test whether the function works as expected.
*/
CREATE FUNCTION dbo.ufn_CalculateInterest(@SUM money, @yearlyInterest NUMERIC(18, 2), @months INT)
  RETURNS NUMERIC(18, 2)
AS
BEGIN
  RETURN (@yearlyInterest / 12) * @months * @SUM + @SUM
END
GO
 
SELECT dbo.ufn_CalculateInterest(200, 0.2, 5) as [Interest]
GO

/*
Task 4.
Create a stored procedure that uses the function from the previous example 
to give an interest to a person's account for one month. 
It should take the AccountId and the interest rate as parameters.*/CREATE PROC dbo.usp_CalculatePersonAccountInterest(@accountID INT, @yearlyInterest NUMERIC(18,2))
AS
	DECLARE @accountMoney MONEY = (
        SELECT Balance
        FROM Accounts
        WHERE AccountId = @accountId)
    SELECT dbo.ufn_CalculateInterest(@accountMoney, @yearlyInterest, 1) AS [Person Account Interest]
GO

EXEC dbo.usp_CalculatePersonAccountInterest 2,0.2
GO
/*Task 5.Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.*/CREATE PROC dbo.usp_WithdrawMoney(@accountID INT, @withdrawAmount money)
AS
BEGIN TRANSACTION
    DECLARE @availableMoney MONEY =
        (SELECT Balance
        FROM Accounts
        WHERE AccountId = @accountId)
    IF (@availableMoney >= @withdrawAmount)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance - @withdrawAmount
			WHERE AccountId = @accountId
			COMMIT
		END
    ELSE
		BEGIN
			RAISERROR ('Insufficient funds.', 16, 1)
			ROLLBACK TRAN
		END
GO

EXEC dbo.usp_WithdrawMoney 2,200
GOCREATE PROC dbo.usp_DepositMoney(@accountID INT, @depositAmount money)
AS
BEGIN TRANSACTION
    IF (@depositAmount >= 0)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance + @depositAmount
			WHERE AccountId = @accountId
			COMMIT
		END
    ELSE
		BEGIN
            RAISERROR('Invalid deposit amount.', 16, 1)
            ROLLBACK TRAN
		END
GO

EXEC dbo.usp_DepositMoney 2,400
GO/*Task 6.Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.*/CREATE TABLE Logs (
	LogID INT IDENTITY,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	AccountID INT NOT NULL,
	CONSTRAINT PK_LogID PRIMARY KEY(LogID),
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
)
GOCREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
INSERT INTO Logs (OldSum, NewSum, AccountID)
SELECT d.Balance, i.Balance, d.AccountID
  FROM deleted AS d
  JOIN inserted AS i
    ON d.AccountID = i.AccountID
GO
 
EXEC dbo.usp_DepositMoney 1, 200
EXEC dbo.usp_DepositMoney 1, 300
EXEC dbo.usp_DepositMoney 1, 500
EXEC dbo.usp_WithdrawMoney 1, 900
GO/*Task 7.Define a function in the database TelerikAcademy 
that returns all Employee's names (first or middle or last name) 
and all town's names that are comprised of given set of letters. 
Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.*/USE [TelerikAcademy];
GO

-- CREATE ADDITIONAL FUNCTION TO CHECK FOR A SPECIFIC SUBSTRING IN A GIVEN STRING --
CREATE FUNCTION usp_IsComposed(
	@name nvarchar(50),
	@characters nvarchar(50)
	)
	RETURNS bit
AS
BEGIN
	DECLARE @index int = 1,
			@foundIndex int,
			@currentCharacter nvarchar(1),
			@counter int,
			@result bit;
	DECLARE @usedLetters table(LetterIndex int, Letter nvarchar(1));
	SET @characters = LOWER(@characters);
	WHILE(@index <= LEN(@name))
		BEGIN
			SET @currentCharacter = LOWER(SUBSTRING(@name, @index, 1));
			SET @foundIndex = CHARINDEX(@currentCharacter, @characters);
			IF (@foundIndex = 0)
				BEGIN
					SET @result = 0;
					BREAK;
				END
			ELSE
				BEGIN
					IF(EXISTS(SELECT * FROM @usedLetters WHERE LetterIndex = @foundIndex))
						BEGIN
							SELECT TOP 1 @foundIndex = LetterIndex
							FROM @usedLetters
							WHERE Letter = @currentCharacter
							ORDER BY Letter DESC;
							SET @foundIndex = CHARINDEX(@currentCharacter, @characters, @foundIndex + 1);
							IF (@foundIndex = 0)
							BEGIN
								SET @result = 0;
								BREAK;
							END
						END
					INSERT INTO @usedLetters
					VALUES (@foundIndex, @currentCharacter);
				END
			SET @index = @index + 1;
		END
	SELECT @counter = COUNT(*) FROM @usedLetters;
	IF(@counter = LEN(@name))
		BEGIN
			SET @result = 1;
		END
	ELSE
		BEGIN
			SET @result = 0;
		END
	RETURN @result;
END
GO

-- CREATE THE FUNCTION TO GET ANY FIRST LAST MIDDLE OR TOWN NAME THAT CONTAINS GIVEN SUBSTRING --
CREATE FUNCTION ufn_GetComposedNames (@characters nvarchar(50))
		RETURNS TABLE
AS
RETURN (
	(SELECT 'First Name: ' + e.FirstName AS Name
	FROM Employees as e
	WHERE 1 = (SELECT dbo.usp_IsComposed(e.FirstName, @characters)))
	UNION
	(SELECT 'Middle Name: ' + e.MiddleName AS Name
	FROM Employees As e
	WHERE 1 = (SELECT dbo.usp_IsComposed(e.MiddleName, @characters)))
	UNION
	(SELECT 'Last Name: ' + e.LastName AS Name
	FROM Employees AS e
	WHERE 1 = (SELECT dbo.usp_IsComposed(e.LastName, @characters)))
	UNION
	(SELECT 'Town Name: ' + t.Name AS Name
	FROM Towns AS t
	WHERE 1 = (SELECT dbo.usp_IsComposed(t.Name, @characters)))
	);
GOSELECT *
FROM dbo.ufn_GetComposedNames('oistmiahf');
GO/*Task 8.Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.*/USE [TelerikAcademy]
GO

-- CREATE TEMPORATY TABLE WITH NAMES AND TOWNS FROM EMPLOYEES, ADDRESSES AND TOWNS --
SELECT e.EmployeeID ,e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID, t.Name as TownName
INTO #TempEmployeesWithTowns
FROM Employees e 
	INNER JOIN Addresses a 
	on e.AddressID = a.AddressID
	INNER JOIN Towns t 
	on a.TownID = t.TownID 
CREATE UNIQUE CLUSTERED INDEX Idx_TemEmp ON #TempEmployeesWithTowns(EmployeeID)

-- DECLARE CURSOR TO ITERATE OVER THE TEMPORARY TABLE --
DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, EmployeeName, TownID,TownName
FROM #TempEmployeesWithTowns

OPEN empCursor
DECLARE @employeeID int, @employeeName varchar(150), @townID int,  @townName varchar(50)
FETCH NEXT FROM empCursor 
INTO @employeeID, @employeeName, @townID, @townName

-- CREATE TEMPORARY TABLE WITH PAIRS OF EMPLOYEES AND THE CITY THEY BOTH LIVE IN --
CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE @@FETCH_STATUS = 0
  BEGIN
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, EmployeeName, @townName 
	FROM #TempEmployeesWithTowns e
	WHERE e.TownID = @townID AND e.EmployeeID != @employeeID
    FETCH NEXT FROM empCursor 
	INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor


SELECT TownName, FirstEmployeeName, SecondEmployeeName 
FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs
DROP TABLE #TempEmployeesWithTowns
GO
/*Task 9.* Write a T-SQL script that shows for each town a list of all employees that live in it. 
Sample output: 55
Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
Ottawa -> Jose Saraiva
…*/USE [TelerikAcademy]
GO

SELECT e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE INDEX Idx_TemTown ON #TempEmployeesWithTowns(TownID)

DECLARE townCursor CURSOR READ_ONLY FOR
SELECT TownID, Name FROM Towns
OPEN townCursor
DECLARE @townID int, @townName varchar(50)
FETCH NEXT FROM townCursor INTO @townID, @townName
WHILE @@FETCH_STATUS = 0
  BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT EmployeeName FROM #TempEmployeesWithTowns
	WHERE TownID = @townID

	OPEN empCursor
	DECLARE @employeeName varchar(150), @employeesList varchar(MAX)
	SET @employeesList = ''
	FETCH NEXT FROM empCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0	
	  BEGIN
		SET @employeesList = CONCAT(@employeesList, @employeeName, ', ')
		FETCH NEXT FROM empCursor INTO @employeeName
	  END  
	CLOSE empCursor
	DEALLOCATE empCursor
	SET @employeesList = LEFT(@employeesList, LEN(@employeesList) - 1)
	PRINT @townName + ' -> ' + @employeesList
	FETCH NEXT FROM townCursor INTO @townID, @townName         
  END
CLOSE townCursor
DEALLOCATE townCursor
DROP TABLE #TempEmployeesWithTowns
GO/*Task 10.Define a .NET aggregate function StrConcat that 
takes as input a sequence of strings and return a 
single string that consists of the input strings 
separated by ','. For example the following SQL 
statement should return a single string:
SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees
*/

USE TelerikAcademy;
GO
-- Enable clr to execute user code in .NET Framework
sp_configure 'clr enabled', 1
GO
-- Install the changes
RECONFIGURE
GO
-- Create assembly from the StrConcat.dll
-- Change the *MYUSERNAME* in the path to create assembly
CREATE ASSEMBLY StrConcat
FROM 'C:\Users\*MYUSERNAME*\Documents\Visual Studio 2012\Projects\08.2014.DB\05.T-SQL\StrConcat.dll';
GO
-- Create Aggregate StrConcat function
CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.Concatenate;
GO
-- Use created function
SELECT [dbo].StrConcat(FirstName + ' ' + LastName)
FROM Employees;
GO
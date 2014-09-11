/* TASK 1
Create a table in SQL Server with 10 000 000 log entries (date + text). 
Search in the table by date range. 
Check the speed (without caching).
*/
-- create database.
CREATE DATABASE PerformanceDatabase
GO

USE PerformanceDatabase
-- create table.
CREATE TABLE Dates(
  DateId INT NOT NULL IDENTITY,
  DateValue datetime NOT NULL,
  TextValue nvarchar(300),
  CONSTRAINT PK_Dates_DateId PRIMARY KEY (DateId)
)

-- fill with 1000 rows.
SET NOCOUNT ON
DECLARE @RowCount int = 1000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) = 
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Dates(DateValue, TextValue)
  VALUES(@Date, @Text)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF

-- populate database with 10 000 000 entries by coping each 1000 rows.
-- executed in exactly 9 minutes 28 seconds and created a database of about 1.907 GB.
WHILE (SELECT COUNT(*) FROM Dates) < 10000000
BEGIN
  INSERT INTO Dates(DateValue, TextValue)
  SELECT DateValue, TextValue FROM Dates
END

-- Cleaning the SQL Server cache in 2 seconds.
CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- FIRST TEST => Select dates without caching in 1 minute 9 seconds.
SELECT DateValue FROM Dates
WHERE DateValue > '1-Jan-1990' and DateValue < '1-Jan-2010'

-- SECOND TEST => Select dates with caching in 24 seconds.
SELECT DateValue FROM Dates
WHERE DateValue > '1-Jan-1990' and DateValue < '1-Jan-2010'


/* TASK 2
Add an index to speed-up the search by date. 
Test the search speed (after cleaning the cache).
*/
-- create index in 1 minute 29 seconds 
CREATE INDEX IDX_Dates_DateValue ON Dates(DateValue)

-- cleaning the SQL Server cache in 25 seconds.
CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- executing previous query again in 26 seconds.
SELECT DateValue FROM Dates
WHERE DateValue > '1-Jan-1990' and DateValue < '1-Jan-2010'


/* TASK 3
Add a full text index for the text column. 
Try to search with and without the full-text index and compare the speed.
*/
--execute text query without index in 1 minute 22 seconds.
SELECT TextValue FROM Dates
WHERE TextValue LIKE '%BEEED%'

-- cleaning the SQL Server cache in under 1 second
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

-- create full text index in under 1 second
CREATE FULLTEXT CATALOG FullTextDatesCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Dates(TextValue)
KEY INDEX PK_Dates_DateId
ON FullTextDatesCatalog
WITH CHANGE_TRACKING AUTO

-- cleaning the SQL Server cache in 2 seconds
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--executing text query with fulltext index in 3 seconds
SELECT TextValue FROM Dates
WHERE CONTAINS(TextValue, '%BEEED%')
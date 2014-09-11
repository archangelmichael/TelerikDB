/* TASK 4
Create the same table in MySQL 
and partition it by date (1990, 2000, 2010). 
Fill 1 000 000 log entries. 
Compare the searching speed in all partitions (random dates) 
to certain partition (e.g. year 1995).
*/

-- create database in 0.265 seconds
CREATE DATABASE performancedatabase;

USE performancedatabase;

-- create table with partitions in 1.857 seconds
CREATE TABLE Dates(
	DateId INT NOT NULL AUTO_INCREMENT,
	DateValue datetime NOT NULL,
	TextValue nvarchar(300),
	PRIMARY KEY (DateId, DateValue))
	PARTITION BY RANGE (YEAR(DateValue))(
		PARTITION p0 VALUES LESS THAN (1990),
		PARTITION p1 VALUES LESS THAN (2000),
		PARTITION p2 VALUES LESS THAN (2010),
		PARTITION p3 VALUES LESS THAN MAXVALUE
);

-- create initial entries in 3.931 seconds
DELIMITER $$
CREATE PROCEDURE `enter_initial_entires`()
BEGIN
	DECLARE RowCount INT;
	SET RowCount = 1000;

	WHILE RowCount > 0
	DO
	BEGIN
		DECLARE Text nvarchar(100); 
		DECLARE Date datetime;
		SET Text = CONCAT('Text ', CAST(RowCount AS CHAR(100)), ': ',
		CAST(UUID() AS CHAR(100))); 
		SET Date = (now() + interval floor(rand()*(400)) MONTH);
	  INSERT INTO Dates(DateValue, TextValue)
	  VALUES(Date, Text);
	  SET RowCount = RowCount - 1;
	END;
	END WHILE;
END $$
DELIMITER ;

CALL enter_initial_entires;


-- populate database with 1 000 000 entries in 44.554 seconds.
DELIMITER $$
CREATE PROCEDURE `populate_table`()
BEGIN
	DECLARE recordCount int;
	SET recordCount = (SELECT COUNT(*) FROM Dates);

	WHILE recordCount < 1000000
	DO
	BEGIN
		INSERT INTO Dates(DateValue, TextValue)
		SELECT DateValue, TextValue FROM Dates;
		SET recordCount = (SELECT COUNT(*) FROM Dates);
	END;
	END WHILE;
END $$
DELIMITER ;

CALL populate_table;

-- clear cache
RESET QUERY CACHE

-- search for a date in 0.483 seconds execution
SELECT COUNT(*) FROM Dates WHERE YEAR(DateValue) = 2025;

-- select from partition in under a second
SELECT * FROM dates PARTITION (p3) WHERE YEAR(DateValue) = 2025;
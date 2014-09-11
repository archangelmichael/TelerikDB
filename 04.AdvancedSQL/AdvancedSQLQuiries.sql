use TelerikAcademy;

/* TASK 1. Write a SQL query to find the names and salaries of the employees 
that take the minimal salary in the company.
Use a nested SELECT statement. */
select FirstName, LastName, Salary 
from Employees
where Salary = 
	(select MIN(Salary) from Employees)

/* TASK 2. Write a SQL query to find the names and salaries of the employees 
that have a salary that is up to 10% higher than the minimal salary for the company. */
select FirstName, LastName, Salary 
from Employees
where Salary <= 
	(select MIN(Salary) from Employees) * 1.1
order by Salary desc

/* TASK 3. Write a SQL query to find the full name, salary and department of the employees 
that take the minimal salary in their department. Use a nested SELECT statement. */
select e.FirstName + ' ' + e.LastName as [Full Name], d.Name as [Department] , Salary 
from Employees e 
	join Departments d
	on e.DepartmentID = d.DepartmentID
where e.Salary = 
	(select MIN(m.Salary) from Employees m
	where m.DepartmentID = d.DepartmentID) 
order by d.DepartmentID 

/* TASK 4. Write a SQL query to find the average salary in the department #1. */
select AVG(e.Salary) as [Average Salary], d.Name as [Department]
from Employees e
	join Departments d
	on e.DepartmentID = d.DepartmentID
where e.DepartmentID = 1
group by d.Name

/* TASK 5. Write a SQL query to find the average salary in the "Sales" department.  */
select AVG(e.Salary) AS [Average Salary In Sales], d.Name as [Department]
from Employees e
    join Departments d
    on e.DepartmentID = d.DepartmentID
where d.Name = 'Sales'
group by d.Name

/* TASK 6. Write a SQL query to find the number of employees in the "Sales" department.  */
select COUNT(*) as [Employees Count], d.Name AS [Department]
from Employees e
    join Departments d
    on e.DepartmentID = d.DepartmentID
where d.Name = 'Sales'
group by d.Name

/* TASK 7. Write a SQL query to find the number of all employees that have manager.  */
-- WE HAVE 2 POSSIBLE SOLUTIONS --
select COUNT(e.managerID) as [Employees Count]
from Employees e

select COUNT(*) as [Employees Count]
from Employees
where ManagerID is not null

/* TASK 8. Write a SQL query to find the number of all employees that have no manager.  */
select COUNT(*) as [Employees Count]
from Employees
where ManagerID is null

/* TASK 9. Write a SQL query to find all departments and the average salary for each of them.  */
select AVG(e.Salary) as [Average Salary], d.Name as [Department]
from Employees e
	join Departments d
	on e.DepartmentID = d.DepartmentID
where e.DepartmentID = d.DepartmentID
group by d.Name

/* TASK 10. Write a SQL query to find the count of all employees in each department and for each town.  */
select COUNT(*) as [Employees Count], d.Name as [Department], t.Name as [Town]
from Employees e
	join Departments d
	on e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	on a.AddressID = e.AddressID
	JOIN Towns t
    on a.TownID = t.TownID
group by d.Name, t.Name
order by t.Name

/* TASK 11. Write a SQL query to find all managers that have exactly 5 employees. 
Display their first name and last name.  */

select e.FirstName as [Manager First Name], e.LastName as [Manager Last Name]
from Employees e
where 5 = 
	(select COUNT(*)
    from Employees
    where ManagerID = e.EmployeeID)

/* TASK 12. Write a SQL query to find all employees along with their managers. 
For employees that do not have manager display the value "(no manager)".  */
select e.FirstName as [Employee First Name], e.LastName as [Employee Last Name], ISNULL(m.LastName, 'no manager') as [Manager]
from Employees e
	left join Employees m
	on e.ManagerID = m.EmployeeID

/* TASK 13. Write a SQL query to find the names of all employees 
whose last name is exactly 5 characters long. 
Use the built-in LEN(str) function.  */
select e.FirstName, e.LastName
from Employees e
where LEN(e.LastName) = 5

/* TASK 14. Write a SQL query to display the current date and time in the following format 
"day.month.year hour:minutes:seconds:milliseconds". 
Search in Google to find how to format dates in SQL Server.  */
select  CONVERT(VARCHAR(25), GETDATE(), 113) as [DATE]
select  CONVERT(VARCHAR(25), GETDATE(), 121) as [DATE]

/* TASK 15. Write a SQL statement to create a table Users. 
Users should have username, password, full name and last login time. 
Choose appropriate data types for the table fields. 
Define a primary key column with a primary key constraint. 
Define the primary key column as identity to facilitate inserting records. 
Define unique constraint to avoid repeating usernames. 
Define a check constraint to ensure the password is at least 5 characters long.  */
CREATE TABLE Users
(
        UserID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        Username nvarchar(20) UNIQUE NOT NULL,
        [Password] nvarchar(20) CHECK(LEN([Password]) > 4) NOT NULL,
        Fullname nvarchar(100) NOT NULL,
        LastLogin datetime
)
go
/* TASK 16. Write a SQL statement to create a view 
that displays the users from the Users table 
that have been in the system today. 
Test if the view works correctly.  */
create view RecentUsers
as
    select Username, DAY(GETDATE() - LastLogin) as DayDifference
    from Users
    where DAY(GETDATE() - LastLogin) = 1
go
/* TASK 17. Write a SQL statement to create a table Groups. 
Groups should have unique name (use unique constraint). 
Define primary key and identity column.  */
create table Groups
(
        GroupID INT PRIMARY KEY IDENTITY(1,1),
        Name nvarchar(20) UNIQUE
)
go

/* TASK 18. Write a SQL statement to add a column GroupID to the table Users.
Fill some data in this new column and as well in the Groups table. 
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.  */
alter table Users
        add GroupID INT
 
alter table Users
        add constraint FK_UsersGroup FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)

/* TASK 19. Write SQL statements to insert several records in the Users and Groups tables.  */
insert into Groups
values('QUALITY')
 
insert into Groups
values('MOBILE')
 
insert into Groups
values('WEB')

insert into Users
values
    ('ninjaMobile', 'ninjaMobilepass', 'MOBILE NINJA', GETDATE(), 2),
    ('ninjaWEB', 'ninjaWEBpass', 'WEB NINJA', GETDATE(), 3),
	('ninjaQA', 'ninjaQApass', 'QA NINJA', GETDATE(), 1)

/* TASK 20. Write SQL statements to update some of the records in the Users and Groups tables.  */
UPDATE Users
set Username = 'MobileNinja', Password = 'MobileNinjaPass'
from Users
where Username = 'ninjaMobile'

UPDATE Groups
set Name = 'Quality Assurance'
from Groups
where GroupID = 1

/* TASK 21. Write SQL statements to delete some of the records from the Users and Groups tables.  */
begin tran
 
delete from Users
where Username = 'ninjaMobile'

delete from Groups
where GroupID = 3
 
rollback tran
go
/* TASK 22. Write SQL statements to insert in the Users table 
the names of all employees from the Employees table. 
Combine the first and last names as a full name. 
For username use the first letter of the first name + the last name (in lowercase). 
Use the same for the password, and NULL for last login time.  */
insert into Users(Username, [Password], Fullname, GroupID)
select  LOWER(LEFT(FirstName,3)+LastName),
                LOWER(LEFT(FirstName,3)+LastName),
                FirstName+' ' + LastName,
                1
from Employees

/* TASK 23. Write a SQL statement that changes the password to NULL for all users 
that have not been in the system since 10.03.2010.  */
UPDATE Users
set [Password] = null
from Users
where LastLogin < CONVERT(datetime, '10-03-2010') and [Password] is not null

/* TASK 24. Write a SQL statement that deletes all users without passwords (NULL password).  */
begin tran
delete from Users
where [Password] is null
rollback tran

/* TASK 25. Write a SQL query to display the average employee salary by department and job title.  */
select AVG(e.Salary) as [Average Salary], e.JobTitle as [Title], d.Name as [Department]
from Employees e
    join Departments d
    on e.DepartmentID = d.DepartmentID
group by JobTitle, d.Name
order by [Average Salary] DESC

/* TASK 26. Write a SQL query to display the minimal employee salary by department and job title 
along with the name of some of the employees that take it.  */

select e.FirstName, e.LastName, e.Salary, e.JobTitle, d.Name
from Employees e
    join Departments d
    on e.DepartmentID = d.DepartmentID
group by e.JobTitle, d.Name, e.Salary, e.FirstName, e.LastName, e.DepartmentID
having e.Salary =
    (
            select MIN(Salary)
            from Employees
            where JobTitle = e.JobTitle and DepartmentID = e.DepartmentID
    )
order by e.Salary desc

/* TASK 27. Write a SQL query to display the town where maximal number of employees work.  */
select top(1) t.Name, COUNT(e.EmployeeID) as [Employees]
from Towns t
    join Addresses a
    on t.TownID = a.TownID
    join Employees e
    on e.AddressID = a.AddressID
group by t.Name
order by [Employees] desc

/* TASK 28. Write a SQL query to display the number of managers from each town. */
select COUNT(distinct e.ManagerID) as [Number of managers], t.Name as [Town]
from Employees e
    join Employees m
    on e.ManagerID = m.EmployeeID
    join Addresses a
    on a.AddressID = m.AddressID
    join Towns t
    on a.TownID = t.TownID
group by t.Name

/* TASK 29. Write a SQL to create table WorkHours to store work reports 
for each employee (employee id, date, task, hours, comments). 
Don't forget to define identity, primary key and appropriate foreign key. 
 Issue few SQL statements to insert, update and delete of some data in the table. 
 Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
 For each change keep the old record data, the new record data and the command (insert / update / delete). */
  create table WorkHours 
    (
            WorkHoursID INT IDENTITY(1,1) PRIMARY KEY,
            EmployeeID INT FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) NOT NULL,
            [DATE] datetime NOT NULL,
            Task nvarchar(50) NOT NULL,
            [Hours] INT NULL,
            Comments nvarchar(250) NULL,
    )

insert into WorkHours
	values(4, '2014-08-25', 'Testing', NULL, NULL)
 
create table WorkHoursLog
(
        LogID INT IDENTITY(1,1) PRIMARY KEY,
        ExecutedCommand nvarchar(20) NULL,
        WorkHoursID INT NULL,
        OldEmployeeID INT FOREIGN KEY (OldEmployeeID) REFERENCES Employees(EmployeeID) NULL,
        [OldDate] datetime NULL,
        [OldHours] INT NULL,
        OldComments nvarchar(250) NULL,
        NewEmployeeID INT FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
        [NewDate] datetime NULL,
        NewTaskID INT FOREIGN KEY(NewTaskID) REFERENCES Tasks(TaskID) NULL,
        [NewHours] INT NULL,
        NewComments nvarchar(250) NULL
)
go

alter trigger TR_DeleteWorkHours
on WorkHours
for delete
as
    insert into WorkHoursLog
    select 'DELETE', *, NULL, NULL, NULL, NULL
        from deleted
 go
 
alter trigger TR_InsertWorkHours
on WorkHours
for insert
as
    insert into WorkHoursLog
    select 'INSERT', WorkHoursID,NULL, NULL, NULL, NULL, NULL,
                EmployeeID, [DATE], Task, [Hours], Comments
        from inserted
go
 
alter trigger TR_UpdateWorkHours
on WorkHours
for UPDATE
as
        insert into WorkHoursLog
        select 'UPDATE', d.WorkHoursID, d.EmployeeID, d.[DATE], d.Task, d.[Hours], d.Comments,
        i.EmployeeID, i.[DATE], i.Task, i.[Hours], i.Comments  
        from inserted i, deleted d
go
 

/* TASK 30. Start a database transaction, 
delete all employees from the 'Sales' department along with all dependent records from the pother tables. 
At the end rollback the transaction. */
begin tran
delete from Employees 
where DepartmentId in 
	(select DepartmentId 
	from Departments 
	where Name = 'Sales')
rollback tran
go

/* TASK 31. Start a database transaction and drop the table EmployeesProjects. 
Now how you could restore back the lost table data? */
begin tran
drop table EmployeesProjects
-- to recover lost table data place 'rollback tran' and run again
go

/* TASK 32. Find how to use temporary tables in SQL Server. 
Using temporary tables backup all records from EmployeesProjects 
and restore them back after dropping and re-creating the table. */
use TelerikAcademy;

begin tran
select * into #TempTable 
from EmployeesProjects

drop table EmployeesProjects

select * into EmployeesProjects
from #TempTable

DROP TABLE #TempTable
GO
ROLLBACK TRAN
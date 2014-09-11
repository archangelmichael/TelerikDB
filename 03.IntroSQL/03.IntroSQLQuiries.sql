use TelerikAcademy;
/* WARNING! UNCOMMENT ANY QUERY You want to check */
/* TASK 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database). */

select * from Departments

/* TASK 5. Write a SQL query to find all department names. */

--select Name as [Department Names] from Departments

/* TASK 6. Write a SQL query to find the salary of each employee. */

--select FirstName, LastName, Salary from Employees

/* TASK 7. Write a SQL to find the full name of each employee. */

--select EmployeeId, FirstName + ' ' + LastName as [Employees Full Name] from Employees

/* TASK 8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
The produced column should be named "Full Email Addresses". */

--select FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses] from Employees

/* TASK 9. Write a SQL query to find all different employee salaries. */

--select distinct Salary from Employees

/* TASK 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“. */

--select * from Employees where JobTitle = 'Sales Representative'

/* TASK 11. Write a SQL query to find the names of all employees whose first name starts with "SA". */

--select FirstName, LastName from Employees where FirstName like 'SA%'

/* TASK 12. Write a SQL query to find the names of all employees whose last name contains "ei". */

--select FirstName, LastName from Employees where LastName like '%ei%'

/* TASK 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. */

--select Salary from Employees where Salary between 20000 and 30000

/* TASK 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. */

--select FirstName, Salary from Employees where Salary in (25000, 14000, 12500, 23600)

/* TASK 15. Write a SQL query to find all employees that do not have manager. */

--select FirstName, LastName from Employees where ManagerID is null

/* TASK 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. */

--select FirstName, LastName, Salary from Employees where Salary > 50000 order by Salary desc 

/* TASK 17. Write a SQL query to find the top 5 best paid employees. */

--select top 5 FirstName, LastName, Salary from Employees order by Salary desc

/* TASK 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause. */
/* 
select e.FirstName, e.LastName, a.AddressText as [Employee Addresses] 
from Employees e 
inner join Addresses a 
on e.AddressID = a.AddressID
*/

/* TASK 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).*/
/*
select e.FirstName, e.LastName, 
a.AddressText as [Employee Adresses]
from Employees e, Addresses a
where e.AddressID = a.AddressID
*/

/* TASK 20. Write a SQL query to find all employees along with their manager.*/
/*
select e.FirstName, e.LastName, m.LastName as [Manager]
from Employees e, Employees m
where e.ManagerID = m.EmployeeID
*/

/* TASK 21. Write a SQL query to find all employees, along with their manager and their address. 
Join the 3 tables: Employees e, Employees m and Addresses a. */
/*
select e.FirstName, e.LastName, m.LastName as [Managers], a.AddressText as [Address]
from Employees e
inner join Employees m
	ON e.ManagerID = m.EmployeeID
inner join Addresses a
	ON a.AddressID = e.AddressID
*/

/* TASK 22. Write a SQL query to find all departments and all town names as a single list. Use UNION. */
/*
select Name
from Departments
union
select name
from Towns
*/

/* TASK 23. Write a SQL query to find all the employees and the manager for each of them along with the employees 
that do not have manager. Use right outer join. Rewrite the query to use left outer join. */
/*
select e.FirstName, e.LastName, m.LastName as [Manager]
from Employees m
right outer join Employees e
	on e.ManagerID = m.EmployeeID

select e.FirstName, e.LastName, m.LastName as [Manager]
from Employees e
left outer join Employees m
	on e.ManagerID = m.EmployeeID
*/

/* TASK 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005. *//*select e.FirstName, e.LastName, d.Name as [Department Names]from Employees e	inner join Departments d	on e.DepartmentID = d.DepartmentIDwhere (d.Name IN ('Sales', 'Finance')) and (YEAR(e.HireDate) between 1995 and 2005)*/
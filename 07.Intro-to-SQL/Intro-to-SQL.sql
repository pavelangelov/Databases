USE TelerikAcademy
-----------------Task 4. Write a SQL query to find all information about all departments------------------------------
SELECT * FROM Departments

-----------------Task 5. Write a SQL query to find all department names.----------------------------------------------
SELECT Name AS [Departament Name] FROM Departments

-----------------Task 6. Write a SQL query to find the salary of each employee.---------------------------------------
SELECT FirstName, LastName, Salary FROM Employees

-----------------Task 7. Write a SQL to find the full name of each employee.------------------------------------------
SELECT FirstName + ' ' + COALESCE(MiddleName, '') + ' ' + LastName AS [Fullname] FROM Employees

-----------------Task 8. Write a SQL query to find the email addresses of each employee (by his first and last name).-
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM Employees

-----------------Task 9. Write a SQL query to find all different employee salaries.-----------------------------------
SELECT DISTINCT Salary FROM Employees

-----Task 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.-
SELECT e.FirstName, e.LastName, e.JobTitle, d.Name AS [Department Name], m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e 
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
WHERE e.JobTitle = 'Sales Representative'

-----------------Task 11. Write a SQL query to find the names of all employees whose first name starts with "SA".-------
SELECT FirstName + ' ' + COALESCE(MiddleName, '') + ' ' + LastName AS [Fullname] FROM Employees
WHERE LEFT(FirstName, 2) = 'SA'

-----------------Task 12. Write a SQL query to find the names of all employees whose last name contains "ei".-----------
SELECT FirstName + ' ' + COALESCE(MiddleName, '') + ' ' + LastName AS [Fullname] FROM Employees
WHERE LastName LIKE '%ei%'

----------Task 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].----
SELECT FirstName + ' ' + LastName AS [Employee], Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

----------Task 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.---
SELECT FirstName + ' ' + LastName AS [Employee], Salary FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-----------------Task 15. Write a SQL query to find all employees that do not have manager.------------------------------
SELECT FirstName + ' ' + LastName AS [Employee], ManagerID AS [Manager] FROM Employees
WHERE ManagerID IS NULL

--Task 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.--
SELECT FirstName + ' ' + LastName AS [Employee], Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-----------------Task 17. Write a SQL query to find the top 5 best paid employees.---------------------------------------
SELECT TOP 5 FirstName + ' ' + LastName AS [Employee], Salary FROM Employees
ORDER BY Salary DESC

------------Task 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.-----
SELECT FirstName + ' ' + LastName AS [Employee], a.AddressText AS [Address] FROM Employees e
	JOIN Addresses a
	ON e.AddressID = A.AddressID

-----Task 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).---
SELECT e.FirstName + ' ' + e.LastName AS [Employee], a.AddressText AS [Address] FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID


-----------------Task 20. Write a SQL query to find all employees along with their manager.--------------------------------
SELECT e.FirstName + ' ' + e.LastName AS [Employee], m.FirstName + ' ' + m.LastName AS [Manager] FROM Employees e, Employees m
WHERE e.ManagerID = m.EmployeeID

-----------------Task 21. Write a SQL query to find all employees, along with their manager and their address.--------------
SELECT 
e.FirstName + ' ' + e.LastName AS [Employee],
m.FirstName + ' ' + m.LastName AS [Manager],
a.AddressText AS [Address]
FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
	ON e.AddressID = a.AddressID

-----------------Task 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.----------

USE TelerikAcademy
--Task 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary < (SELECT MIN(Salary) FROM Employees)

--Task 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary < (SELECT (MIN(Salary) * 1.1) FROM Employees)

--Task 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
SELECT e.FirstName + ' ' + e.LastName AS [Fullname], e.Salary, DepartmentID
FROM Employees e
WHERE Salary = 
		(SELECT MIN(Salary) FROM Employees
			WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID DESC

--Task 4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average salary] FROM Employees
WHERE DepartmentID = 1

--Task 5. Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) AS [Average salary], d.Name AS [Department name] FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--Task 6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS [Employees in 'Sales'] FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--Task 7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employees without Manager] FROM Employees e
WHERE e.ManagerID IS NULL

--Task 8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employees with Manager] FROM Employees e
WHERE e.ManagerID IS NOT NULL

--Task 9. Write a SQL query to find all departments and the average salary for each of them.
SELECT AVG(Salary) AS [Average Salary], d.Name FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY "Average Salary"

--Task 10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT COUNT(e.EmployeeID) AS [Employees Count],
		d.Name AS [Department name],
		t.Name AS [Town] FROM Employees e
			JOIN Departments d ON e.DepartmentID = d.DepartmentID
			JOIN Addresses a ON e.AddressID = a.AddressID
			JOIN Towns t ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY [Employees Count]
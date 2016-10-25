USE TelerikAcademy
--Task 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
USE TelerikAcademy
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary < (SELECT MIN(Salary) FROM Employees)

--Task 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
USE TelerikAcademy
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary < (SELECT (MIN(Salary) * 1.1) FROM Employees)

--Task 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Fullname], e.Salary, DepartmentID
FROM Employees e
WHERE Salary = 
		(SELECT MIN(Salary) FROM Employees
			WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID DESC

--Task 4. Write a SQL query to find the average salary in the department #1.
USE TelerikAcademy
SELECT AVG(Salary) AS [Average salary] FROM Employees
WHERE DepartmentID = 1

--Task 5. Write a SQL query to find the average salary in the "Sales" department.
USE TelerikAcademy
SELECT AVG(Salary) AS [Average salary], d.Name AS [Department name] FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--Task 6. Write a SQL query to find the number of employees in the "Sales" department.
USE TelerikAcademy
SELECT COUNT(*) AS [Employees in 'Sales'] FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--Task 7. Write a SQL query to find the number of all employees that have manager.
USE TelerikAcademy
SELECT COUNT(*) AS [Employees without Manager] FROM Employees e
WHERE e.ManagerID IS NULL

--Task 8. Write a SQL query to find the number of all employees that have no manager.
USE TelerikAcademy
SELECT COUNT(*) AS [Employees with Manager] FROM Employees e
WHERE e.ManagerID IS NOT NULL

--Task 9. Write a SQL query to find all departments and the average salary for each of them.
USE TelerikAcademy
SELECT AVG(Salary) AS [Average Salary], d.Name FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY "Average Salary"

--Task 10. Write a SQL query to find the count of all employees in each department and for each town.
USE TelerikAcademy
SELECT COUNT(e.EmployeeID) AS [Employees Count],
		d.Name AS [Department name],
		t.Name AS [Town] FROM Employees e
			JOIN Departments d ON e.DepartmentID = d.DepartmentID
			JOIN Addresses a ON e.AddressID = a.AddressID
			JOIN Towns t ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY [Employees Count]

--Task 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
USE TelerikAcademy
SELECT m.FirstName + ' ' + m.LastName AS [Manager name], COUNT(e.EmployeeID) AS [Empoyees]  FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) = 5

--Task 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Employee], 
		ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager] 
FROM Employees m
	RIGHT JOIN Employees e
	ON e.ManagerID = m.EmployeeID

--Task 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS [Fullname] FROM Employees e
WHERE LEN(e.LastName) = 5

--Task 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(VARCHAR(24), GETDATE(), 13)

--Task 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
USE TelerikAcademy
IF EXISTS (
	SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = 'Users')
DROP TABLE Users

CREATE TABLE Users (
	Id INT IDENTITY,
	Username NVARCHAR(50) NOT NULL UNIQUE,
	Password NVARCHAR(50) NOT NULL CHECK (LEN(Password) > 5),
	Fullname NVARCHAR(50) NOT NULL,
	LastLogin SMALLDATETIME,
	CONSTRAINT PK_Users PRIMARY KEY(Id)
)

GO

--Task 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
USE TelerikAcademy
IF EXISTS (
	SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS 
	WHERE TABLE_NAME = 'LoggedUsers')
DROP VIEW AllUsersFromToday

GO

CREATE VIEW LoggedUsers AS
SELECT u.Username FROM Users u
WHERE YEAR(u.LastLogin) = YEAR(GETDATE()) AND
		MONTH(u.LastLogin) = MONTH(GETDATE()) AND
		DAY(u.LastLogin) = DAY(GETDATE())

GO

--Task 17. Write a SQL statement to create a table Groups. Groups should have unique name
USE TelerikAcademy
IF EXISTS (
	SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = 'Groups')
DROP TABLE Users

CREATE TABLE Groups (
	Id INT IDENTITY,
	Name NVARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_Groups PRIMARY KEY(Id)
)

GO

--Task 18. Write a SQL statement to add a column GroupID to the table Users.
USE TelerikAcademy
ALTER TABLE Users
ADD GroupId INT

GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY(GroupId) 
REFERENCES Groups(Id)

GO

--Task 19. Write SQL statements to insert several records in the Users and Groups tables.
USE TelerikAcademy
INSERT INTO Users(Username, Password, Fullname, LastLogin, GroupId)
VALUES ('kiroUsera', 'aaaaaa', 'Kiro Kirov', NULL, 2),
		('mitko', 'mitkuu', 'Mitko Mitashki', GETDATE(), 1),
		('temenuga', 'nujkaa', 'Temenuga Temenugova', GETDATE(), 2)

GO

INSERT INTO Groups(Name)
VALUES ('All-day'),
		('Night-group')
GO

--Task 20. Write SQL statements to update some of the records in the Users and Groups tables.
USE TelerikAcademy
UPDATE Users
SET Username = 	Username + 'Up'
WHERE Username LIKE 'user%'

GO

--Task 21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'userUp'

--Task 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
USE TelerikAcademy
INSERT INTO Users (Username, Password, Fullname, LastLogin)
	(SELECT  LOWER(LEFT(e.FirstName, 1)) + LOWER(e.LastName) + CONVERT(NVARCHAR, e.EmployeeID,13),
			 ISNULL(LOWER(e.FirstName) + LOWER(e.LastName), 'parola'),
			 e.FirstName + ' ' + e.LastName,
			 NULL
	FROM Employees e)
GO
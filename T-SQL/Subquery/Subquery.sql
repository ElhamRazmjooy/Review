CREATE TABLE Employees
(
	EmployeeId INT PRIMARY KEY,
	Name NVARCHAR(50),
	DepartmentId INT,
	Salary DECIMAL(10, 2)
);
GO
INSERT INTO Employees (EmployeeId, Name, DepartmentId, Salary)
VALUES
(1, 'Ali',     1, 12000),
(2, 'Sara',    1, 8000),
(3, 'Reza',    1, 5000),
(4, 'Maryam',  2, 6000),
(5, 'Nima',    2, 4000),
(6, 'Zahra',   2, 3000),
(7, 'Amir',    3, 15000),
(8, 'Mina',    3, 9000),
(9, 'Hamed',   3, 7000),
(10, 'Sina',   4, 11000),
(11, 'Leila',  4, 5000),
(12, 'Pouya',  4, 4000);
GO
CREATE TABLE Departments
(
	DepartmentId INT PRIMARY KEY,
	DepartmentName NVARCHAR(50)
);
GO
INSERT INTO Departments (DepartmentId, DepartmentName)
VALUES
(1, 'IT'),
(2, 'HR'),
(3, 'Finance'),
(4, 'Marketing');
GO
CREATE TABLE Projects
(
	ProjectId INT PRIMARY KEY,
	ProjectName NVARCHAR(50),
	EmployeeId INT,
	Budget DECIMAL(10, 2)
);
GO
INSERT INTO Projects (ProjectId, ProjectName, EmployeeId, Budget)
VALUES
(1, 'E-Commerce',       1, 50000),
(2, 'API Development',  2, 30000),
(3, 'Security Audit',   3, 20000),
(4, 'Recruitment',      4, 15000),
(5, 'Training System',  5, 10000),
(6, 'Accounting App',   7, 45000),
(7, 'Budget Analysis',  8, 25000),
(8, 'Reports',          9, 10000),
(9, 'Campaign',         10, 35000),
(10, 'SEO Project',     11, 15000);
GO
--SUBQUERY
SELECT
	E.EmployeeId, E.Salary
FROM Employees AS E
WHERE E.Salary > (SELECT AVG(Salary) FROM Employees);
GO
SELECT
	E.EmployeeId, E.Name
FROM Employees AS E
WHERE E.DepartmentId = (SELECT D.DepartmentId FROM Departments AS D
							WHERE D.DepartmentName = 'IT');
GO
SELECT
	E.EmployeeId,E.Name, E.Salary
FROM Employees AS E
WHERE E.Salary = (SELECT MAX(Salary) FROM Employees);
GO
SELECT 
	E.EmployeeId, E.Name, E.Salary, E.DepartmentId
FROM Employees AS E
WHERE E.Salary > (SELECT AVG(E2.Salary) FROM Employees AS E2
					WHERE E2.DepartmentId = E.DepartmentId);
GO
SELECT 
	D.DepartmentId, D.DepartmentName
FROM Departments AS D
WHERE EXISTS
(
	SELECT 1
	FROM Employees AS E
	WHERE E.DepartmentId = D.DepartmentId
		AND E.Salary > 10000
);
GO
--NOT EXISTS
SELECT
	D.DepartmentId, D.DepartmentName
FROM Departments AS D
WHERE NOT EXISTS
(
	SELECT 1
	FROM Employees AS E
	WHERE E.DepartmentId = D.DepartmentId
	AND E.Salary > 10000
);
GO
SELECT
	E.EmployeeId, E.Name, E.Salary
FROM Employees AS E
WHERE E.Salary > (SELECT AVG(E2.Salary) FROM Employees AS E2)
AND E.Salary < (SELECT AVG(E3.Salary) FROM Employees AS E3
					WHERE E3.DepartmentId = E.DepartmentId);
GO
--ALL
SELECT
	E.EmployeeId, E.Name, E.Salary
FROM Employees AS E
WHERE E.Salary > ALL (SELECT E2.Salary FROM Employees AS E2
						WHERE E2.DepartmentId = 
						(SELECT D.DepartmentId 
							FROM Departments AS D
						 WHERE D.DepartmentName = 'HR'));
GO
--ANY
SELECT
	E.EmployeeId, E.Name, E.Salary
FROM Employees AS E
WHERE E.Salary > ANY (SELECT E2.Salary FROM Employees AS E2
					  WHERE E2.DepartmentId =
					  (SELECT D.DepartmentId FROM Departments AS D
					   WHERE D.DepartmentName = 'Finance'));
GO
--NOT EXISTS
SELECT 
	E.EmployeeId
FROM Employees AS E
WHERE NOT EXISTS
(SELECT 1 
 FROM Projects AS P
 WHERE P.EmployeeId = E.EmployeeId
 AND P.Budget > 30000);
GO
SELECT
	D.DepartmentId, D.DepartmentName
FROM Departments AS D
WHERE (SELECT AVG(Salary) FROM Employees AS E
			WHERE E.DepartmentId = D.DepartmentId) > 
		(SELECT AVG(E2.Salary) FROM Employees AS E2);
GO
SELECT
	P.EmployeeId, P.Budget
FROM Projects AS P
WHERE P.Budget > (SELECT AVG(P2.Budget) FROM Projects AS P2);
GO
SELECT DISTINCT
	E.DepartmentId
FROM Employees AS E
WHERE NOT EXISTS
(SELECT 1
	FROM Employees AS E2
	WHERE E2.DepartmentId = E.DepartmentId
	AND E2.Salary <= (SELECT AVG(E3.Salary) FROM Employees AS E3));
GO

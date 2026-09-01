--SIMPLE CTE
WITH HighSalaryEmployees AS
(
	SELECT
		E.EmployeeId, E.Name, E.DepartmentId, E.Salary 
	FROM Employees AS E
	WHERE E.Salary > 10000
)
SELECT * FROM HighSalaryEmployees;
GO
--CTE WITH GROUP BY
WITH DepartmentSalary AS
(
	SELECT
		E.DepartmentId, AVG(E.Salary) AS AvgSalary
	FROM Employees AS E
	GROUP BY E.DepartmentId
)
SELECT 
	DepartmentId, AvgSalary
FROM DepartmentSalary
WHERE AvgSalary > 10000;
GO
--MULTIPLE CTE
WITH EmployeeSalary AS
(
	SELECT
		E.EmployeeId, E.Name, E.DepartmentId, E.Salary
	FROM Employees AS E
),
DepartmentAverage AS
(
	SELECT
		E.DepartmentId, AVG(E.Salary) AS AvgSalary
	FROM Employees AS E
	GROUP BY E.DepartmentId
)
SELECT
	ES.EmployeeId, ES.Name, ES.Salary, DA.AvgSalary
FROM EmployeeSalary AS ES
JOIN DepartmentAverage AS DA
	ON ES.DepartmentId = DA.DepartmentId
WHERE ES.Salary > DA.AvgSalary;
GO
--RECURSIVE CTE
WITH EmployeeHierarchy AS
(
    -- Anchor
    SELECT
        E.EmployeeId,
        Name,
        E.ManagerId,
        0 AS Level
    FROM Employees AS E
    WHERE E.ManagerId IS NULL

    UNION ALL

    -- Recursive
    SELECT
        E.EmployeeId,
        E.Name,
        E.ManagerId,
        EH.Level + 1
    FROM Employees AS E
    INNER JOIN EmployeeHierarchy AS EH
        ON E.ManagerId = EH.EmployeeId
)
SELECT
    EmployeeId,
    Name,
    ManagerId,
    Level
FROM EmployeeHierarchy
ORDER BY Level, EmployeeId;
GO

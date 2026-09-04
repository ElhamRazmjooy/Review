--FIND DUPLICATE DATA
SELECT
	Name, DepartmentId, COUNT(*) AS DuplicateCount
FROM Employees
GROUP BY Name, DepartmentId
HAVING COUNT(*) > 1;
GO
--FIND DUPLICATE ROWS WITH ROW_NUMBER()
WITH DuplicateEmployees AS
(
	SELECT
		EmployeeId, Name, DepartmentId, Salary,
		ROW_NUMBER() OVER
		(
			PARTITION BY Name, DepartmentId
			ORDER BY EmployeeId
		) AS RowNum
	FROM Employees
)
SELECT
	EmployeeId, Name, DepartmentId, Salary
FROM DuplicateEmployees
WHERE RowNum > 1;
GO
--DELETE DUPLICATE ROWS
WITH DuplicateEmployees AS
(
    SELECT
        EmployeeId,
        ROW_NUMBER() OVER
        (
            PARTITION BY Name, DepartmentId
            ORDER BY EmployeeId
        ) AS RowNum
    FROM Employees
)
DELETE FROM DuplicateEmployees
WHERE RowNum > 1;
GO
--Unnormalized Table
CREATE TABLE StudentCourses
(
    StudentId INT,
    StudentName NVARCHAR(100),
    StudentPhone NVARCHAR(20),
    CourseId INT,
    CourseName NVARCHAR(100),
    InstructorName NVARCHAR(100),
    Semester NVARCHAR(50)
);
--Normalized Table
CREATE TABLE Students
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(100),
    Phone NVARCHAR(20)
);
GO
CREATE TABLE Courses
(
	CourseId INT PRIMARY KEY,
	CourseName NVARCHAR(100),
	InstructorName NVARCHAR(100)
);
GO
CREATE TABLE Semesters
(
    SemesterId INT PRIMARY KEY,
    Name NVARCHAR(50)
);
GO
CREATE TABLE Enrollments
(
	StudentId INT,
	CourseId INT,
	SemesterId INT,
	PRIMARY KEY(StudentId, CourseId, SemesterId),

	FOREIGN KEY (StudentId)
        REFERENCES Students(Id),

    FOREIGN KEY (CourseId)
        REFERENCES Courses(CourseId),

    FOREIGN KEY (SemesterId)
        REFERENCES Semesters(SemesterId)
);
GO
SELECT * FROM Enrollments
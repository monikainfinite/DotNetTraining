
create Table Students (
StudentId int identity(1,1) primary key,
FullName varchar(100) not null,
Email varchar(100) unique,
Department varchar(50) not null,
YearOfStudy int not null
)

insert into students values 
('monika','moni@gmail.com','cse',1),
('Teja sri','Tejasri@gmail.com','ece',4),
('manu','manu123@gmail.com','eee',3),
('varshu','varshini@gmail.com','IT',2),
('Krishna','krish243@gmail.com','cse',1);

Create table Courses
(CourseId int identity(1,1) primary key,
CoursreName varchar(50) not null,
Credits int not null,
Semester varchar(20) not null)

insert into Courses values 
('DBMS',3,'First'),
('C',3,'Second'),
('OS',5,'Third'),
('Java',3,'Fourth'),
('C#',4,'First');

Create table Enrollments (
EnrollmentId int identity(1,1) primary key,
StudentId int foreign key references Students(StudentId),
CourseId int foreign key references Courses(CourseId),
EnrollDate DateTime not null,
Grade varchar(10) null)

insert into Enrollments values 
(1,1,getdate(),null),
(2,1,'05-08-2024',null),
(1,2,'06-07-2025',null),
(3,4,'12-12-2025',null),
(4,1,getdate(),null);


create procedure usp_GetCoursesBySemester
(@semester varchar(30))
as
select CourseId,CoursreName,Credits,Semester
from Courses
where Semester =@semester;


CREATE DATABASE University;

USE University;

CREATE TABLE Student (
    SID INT PRIMARY KEY,
    FullName VARCHAR(50),
    Semester VARCHAR(10),
    GPA DECIMAL(3, 2)
);

CREATE TABLE Contact (
    SID INT,
    PhoneNo VARCHAR(15),
    Email VARCHAR(50),
    FOREIGN KEY (SID) REFERENCES Student(SID)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);


CREATE TABLE Address (
    SID INT,
    Address VARCHAR(100),
    FOREIGN KEY (SID) REFERENCES Student(SID)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);



INSERT INTO Student (SID, FullName, Semester, GPA) VALUES
(100, 'Muhammad Maaz Khan', 'First', 3.99),
(101, 'Farrukh Iqbal', 'Second', 3.97),
(102, 'Shayan Adnan', 'Third', 3.98),
(103, 'Mahnoor Arshad', 'Fourth', 3.52),
(104, 'Hafiz Minhal', 'Fifth', 3.66),
(105, 'Rumaisa Fatima', 'Sixth', 3.78),
(106, 'Raif ul Haq', 'Seventh', 3.12),
(107, 'Maria Abid', 'Eighth', 3.34);


INSERT INTO Contact (SID, PhoneNo, Email) VALUES
(100, '0300-1234567', 'mmaazk111.com'),
(101, '0300-1234568', 'farrukh@iqbal.com'),
(102, '0300-1234569', 'shayan@adnan.com'),
(103, '0300-1234570', 'mahnoor@arshad.com'),
(104, '0300-1234571', 'hafiz@minhal.com'),
(105, '0300-1234572', 'rumaisa@fatima.com'),
(106, '0300-1234573', 'raif@ulhaq.com'),
(107, '0300-1234574', 'maria@abid.com');



INSERT INTO Address (SID, Address) VALUES
(100, 'R-290, Block-06, Gulshan, Karachi'),
(101, 'R-101, Block-07, DHA, Karachi'),
(102, 'R-102, Block-04, Khadda Market, Karachi'),
(103, 'R-103, Block-02, DHA, Karachi'),
(104, 'R-104, Block-09, Malir, Karachi'),
(105, 'R-105, Block-04, North Nazimabad, Karachi'),
(106, 'R-106, Block-09, Johar, Karachi'),
(107, 'R-107, Block-09, North Nazimabad, Karachi');



SELECT * FROM Student;
SELECT * FROM Address;
SELECT * FROM Contact;

-- To Get the Data From the table
SELECT 
    s.SID, 
    s.FullName, 
    s.Semester, 
    s.GPA, 
    c.PhoneNo, 
    c.Email, 
    a.Address
FROM 
    Student s
INNER JOIN 
    Contact c ON s.SID = c.SID
INNER JOIN 
    Address a ON s.SID = a.SID
WHERE S.SID = 100;


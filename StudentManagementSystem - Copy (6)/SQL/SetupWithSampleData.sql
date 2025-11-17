-- =====================================================
-- Student Management System - Database Schema
-- Skills International School
-- =====================================================

-- =====================================================
-- STEP 1: Create Database
-- =====================================================

-- Drop database if exists (WARNING: This will delete all data!)
-- USE master;
-- GO
-- DROP DATABASE IF EXISTS Student;
-- GO

-- Create new database
CREATE DATABASE Student;
GO

USE Student;
GO

-- =====================================================
-- STEP 2: Create Tables
-- =====================================================

-- Registration Table (Student Records)
CREATE TABLE Registration (
    regNo INT PRIMARY KEY,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    dateOfBirth DATETIME NOT NULL,
    gender VARCHAR(50) NOT NULL,
    address VARCHAR(50),
    email VARCHAR(50),
    mobilePhone INT,
    homePhone INT,
    parentName VARCHAR(50),
    nic VARCHAR(50),
    contactNo INT
);
GO

-- Users Table (Authentication)
CREATE TABLE Users (
    username VARCHAR(50) PRIMARY KEY,
    password VARCHAR(100) NOT NULL
);
GO

-- =====================================================
-- STEP 3: Insert Default Admin User
-- =====================================================

INSERT INTO Users (username, password) 
VALUES ('Admin', 'Skills@123');
GO

-- =====================================================
-- STEP 4: Insert Sample Student Data (Optional)
-- =====================================================

-- Sample Student 1
INSERT INTO Registration (
    regNo, firstName, lastName, dateOfBirth, gender,
    address, email, mobilePhone, homePhone,
    parentName, nic, contactNo
) VALUES (
    1001, 'Saman', 'Perera', '2005-01-15', 'Male',
    '123 Galle Road, Colombo 03', 'saman.perera@email.com', 771234567, 112345678,
    'Nimal Perera', '200512345678', 779876543
);
GO

-- Sample Student 2
INSERT INTO Registration (
    regNo, firstName, lastName, dateOfBirth, gender,
    address, email, mobilePhone, homePhone,
    parentName, nic, contactNo
) VALUES (
    1002, 'Nimali', 'Fernando', '2004-03-20', 'Female',
    '456 Kandy Road, Kandy', 'nimali.fernando@email.com', 772345678, 812345678,
    'Kamal Fernando', '200412345679', 778876543
);
GO

-- Sample Student 3
INSERT INTO Registration (
    regNo, firstName, lastName, dateOfBirth, gender,
    address, email, mobilePhone, homePhone,
    parentName, nic, contactNo
) VALUES (
    1003, 'Kasun', 'Silva', '2005-07-10', 'Male',
    '789 Negombo Road, Negombo', 'kasun.silva@email.com', 773456789, 313456789,
    'Sunil Silva', '200512345680', 777876543
);
GO

-- Sample Student 4
INSERT INTO Registration (
    regNo, firstName, lastName, dateOfBirth, gender,
    address, email, mobilePhone, homePhone,
    parentName, nic, contactNo
) VALUES (
    1004, 'Dilini', 'Rajapaksha', '2004-11-25', 'Female',
    '321 Main Street, Galle', 'dilini.r@email.com', 774567890, 914567890,
    'Anura Rajapaksha', '200412345681', 776876543
);
GO

-- Sample Student 5
INSERT INTO Registration (
    regNo, firstName, lastName, dateOfBirth, gender,
    address, email, mobilePhone, homePhone,
    parentName, nic, contactNo
) VALUES (
    1005, 'Tharindu', 'Wickramasinghe', '2005-05-18', 'Male',
    '654 Beach Road, Matara', 'tharindu.w@email.com', 775678901, 414567890,
    'Pradeep Wickramasinghe', '200512345682', 775876543
);
GO

-- =====================================================
-- STEP 5: Verify Installation
-- =====================================================

-- Check Users table
SELECT * FROM Users;
-- Expected: Admin | Skills@123

-- Check Registration table
SELECT * FROM Registration;
-- Expected: 5 sample students

-- Count total students
SELECT COUNT(*) AS TotalStudents FROM Registration;
-- Expected: 5

-- =====================================================
-- Useful Queries for Testing
-- =====================================================

-- View all students ordered by RegNo
SELECT regNo, firstName, lastName, gender, email 
FROM Registration 
ORDER BY regNo;

-- Find student by registration number
SELECT * FROM Registration WHERE regNo = 1001;

-- Find students by gender
SELECT regNo, firstName, lastName 
FROM Registration 
WHERE gender = 'Male';

-- Find students by name (partial match)
SELECT regNo, firstName, lastName 
FROM Registration 
WHERE firstName LIKE '%a%';

-- Get students born after a specific date
SELECT regNo, firstName, lastName, dateOfBirth 
FROM Registration 
WHERE dateOfBirth > '2005-01-01'
ORDER BY dateOfBirth;

-- Count students by gender
SELECT gender, COUNT(*) AS Count 
FROM Registration 
GROUP BY gender;

-- Get all registration numbers (for ComboBox)
SELECT regNo FROM Registration ORDER BY regNo;

-- Check if registration number exists
SELECT COUNT(*) FROM Registration WHERE regNo = 1001;
-- Returns 1 if exists, 0 if not

-- =====================================================
-- Maintenance Queries
-- =====================================================

-- Clear all student records (WARNING!)
-- DELETE FROM Registration;

-- Reset identity (if using IDENTITY column)
-- DBCC CHECKIDENT ('Registration', RESEED, 0);

-- Drop and recreate tables (WARNING: Deletes all data!)
-- DROP TABLE Registration;
-- DROP TABLE Users;

-- =====================================================
-- Backup and Restore
-- =====================================================

-- Backup database
-- BACKUP DATABASE Student 
-- TO DISK = 'C:\Backup\Student.bak'
-- WITH FORMAT, NAME = 'Student Database Backup';

-- Restore database
-- USE master;
-- RESTORE DATABASE Student
-- FROM DISK = 'C:\Backup\Student.bak'
-- WITH REPLACE;

-- =====================================================
-- Performance Indexes (Optional)
-- =====================================================

-- Create index on firstName for faster search
-- CREATE INDEX IX_Registration_FirstName 
-- ON Registration(firstName);

-- Create index on lastName for faster search
-- CREATE INDEX IX_Registration_LastName 
-- ON Registration(lastName);

-- Create index on email for faster lookup
-- CREATE INDEX IX_Registration_Email 
-- ON Registration(email);

-- =====================================================
-- Additional Users (Optional)
-- =====================================================

-- Add more admin users if needed
-- INSERT INTO Users (username, password) VALUES ('Teacher1', 'Pass123');
-- INSERT INTO Users (username, password) VALUES ('Staff1', 'Staff456');

-- =====================================================
-- Table Schema Reference
-- =====================================================

/*
Registration Table:
------------------
regNo         INT          PRIMARY KEY (Student ID)
firstName     VARCHAR(50)  NOT NULL (Required)
lastName      VARCHAR(50)  NOT NULL (Required)
dateOfBirth   DATETIME     NOT NULL (Required)
gender        VARCHAR(50)  NOT NULL (Required)
address       VARCHAR(50)  NULL (Optional)
email         VARCHAR(50)  NULL (Optional)
mobilePhone   INT          NULL (Optional)
homePhone     INT          NULL (Optional)
parentName    VARCHAR(50)  NULL (Optional)
nic           VARCHAR(50)  NULL (Optional)
contactNo     INT          NULL (Optional)

Users Table:
-----------
username      VARCHAR(50)  PRIMARY KEY
password      VARCHAR(100) NOT NULL
*/

-- =====================================================
-- Database Statistics
-- =====================================================

-- View table information
EXEC sp_help 'Registration';

-- View table size
EXEC sp_spaceused 'Registration';

-- View all tables in database
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE';

-- View all columns in Registration table
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Registration';

-- =====================================================
-- Connection String Reference
-- =====================================================

/*
Windows Authentication (Recommended):
Data Source=localhost;Initial Catalog=Student;Integrated Security=True;TrustServerCertificate=True

SQL Server Express:
Data Source=.\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True;TrustServerCertificate=True

LocalDB:
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Student;Integrated Security=True;TrustServerCertificate=True

SQL Server Authentication:
Data Source=localhost;Initial Catalog=Student;User Id=sa;Password=YourPassword;TrustServerCertificate=True
*/

-- =====================================================
-- END OF SCRIPT
-- =====================================================

PRINT 'Database setup completed successfully!';
PRINT 'Default Login: Admin / Skills@123';
PRINT 'Sample students: 1001 - 1005';
GO

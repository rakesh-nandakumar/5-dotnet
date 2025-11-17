-- =====================================================
-- Student Management System Database Setup Script
-- Skills International School
-- =====================================================

-- Switch to master database to create the Student database
USE master;
GO

-- Drop database if it exists (CAUTION: This will delete all data!)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Student')
BEGIN
    ALTER DATABASE Student SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Student;
    PRINT 'Existing Student database dropped.';
END
GO

-- Create the Student database
CREATE DATABASE Student;
GO

PRINT 'Student database created successfully.';
GO

-- Switch to the newly created database
USE Student;
GO

-- =====================================================
-- Create Registration Table
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Registration')
BEGIN
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
    PRINT 'Registration table created successfully.';
END
ELSE
BEGIN
    PRINT 'Registration table already exists.';
END
GO

-- =====================================================
-- Create Users Table for Authentication
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        username VARCHAR(50) PRIMARY KEY,
        password VARCHAR(100) NOT NULL
    );
    PRINT 'Users table created successfully.';
END
ELSE
BEGIN
    PRINT 'Users table already exists.';
END
GO

-- =====================================================
-- Insert Default Admin User
-- =====================================================
IF NOT EXISTS (SELECT * FROM Users WHERE username = 'Admin')
BEGIN
    INSERT INTO Users (username, password) VALUES ('Admin', 'Skills@123');
    PRINT 'Default admin user created: Admin / Skills@123';
END
ELSE
BEGIN
    PRINT 'Admin user already exists.';
END
GO

-- =====================================================
-- Verify Installation
-- =====================================================
PRINT '';
PRINT '========================================';
PRINT 'Database Setup Complete!';
PRINT '========================================';
PRINT '';

-- Check Users table
IF EXISTS (SELECT * FROM Users WHERE username = 'Admin')
BEGIN
    PRINT '✓ Users table exists';
    PRINT '✓ Admin user exists';
    PRINT '  Username: Admin';
    PRINT '  Password: Skills@123';
END
ELSE
BEGIN
    PRINT '✗ ERROR: Admin user not found!';
END

-- Check Registration table
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Registration')
BEGIN
    DECLARE @studentCount INT;
    SELECT @studentCount = COUNT(*) FROM Registration;
    PRINT '✓ Registration table exists';
    PRINT '  Total students: ' + CAST(@studentCount AS VARCHAR(10));
END
ELSE
BEGIN
    PRINT '✗ ERROR: Registration table not found!';
END

PRINT '';
PRINT '========================================';
PRINT 'You can now run the application!';
PRINT '========================================';
GO

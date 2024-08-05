-- Check if the database exists, and create it if it doesn't
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'EduTimeDB')
BEGIN
    CREATE DATABASE EduTimeDB;
END

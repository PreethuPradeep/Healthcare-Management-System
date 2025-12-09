-- Fix Migration Script for HealthCareDbContext
-- Run this in SQL Server Management Studio or via sqlcmd
-- Database: HealthCareDbContext

USE [HealthCareDbContext];
GO

-- Step 1: Drop the failed foreign key constraint if it exists
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_AspNetUsers_Roles_RoleId')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Roles_RoleId];
    PRINT 'Dropped FK_AspNetUsers_Roles_RoleId constraint';
END
GO

-- Step 2: Drop indexes if they exist
IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_AspNetUsers_RoleId' AND object_id = OBJECT_ID('AspNetUsers'))
BEGIN
    DROP INDEX [IX_AspNetUsers_RoleId] ON [AspNetUsers];
    PRINT 'Dropped IX_AspNetUsers_RoleId index';
END
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_AspNetUsers_SpecializationId' AND object_id = OBJECT_ID('AspNetUsers'))
BEGIN
    DROP INDEX [IX_AspNetUsers_SpecializationId] ON [AspNetUsers];
    PRINT 'Dropped IX_AspNetUsers_SpecializationId index';
END
GO

-- Step 3: Check if RoleId column exists and make it nullable
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AspNetUsers') AND name = 'RoleId')
BEGIN
    -- Make RoleId nullable
    ALTER TABLE [AspNetUsers] ALTER COLUMN [RoleId] int NULL;
    PRINT 'Made RoleId nullable';
    
    -- Set existing users' RoleId to NULL (they can be assigned later)
    UPDATE [AspNetUsers] SET [RoleId] = NULL WHERE [RoleId] = 0 OR [RoleId] IS NULL;
    PRINT 'Updated existing users RoleId to NULL';
END
ELSE
BEGIN
    PRINT 'RoleId column does not exist - migration may not have run yet';
END
GO

-- Step 4: Check current state
PRINT 'Current state:';
SELECT 
    COUNT(*) as TotalUsers,
    COUNT(CASE WHEN [RoleId] IS NOT NULL THEN 1 END) as UsersWithRole,
    COUNT(CASE WHEN [RoleId] IS NULL THEN 1 END) as UsersWithoutRole
FROM [AspNetUsers];
GO

PRINT 'Migration fix completed. You can now run: Remove-Migration and Add-Migration again';
GO


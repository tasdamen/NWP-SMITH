/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------

SET QUOTED_IDENTIFIER ON;
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON; ALTER TABLE ? NOCHECK CONSTRAINT ALL'  
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON; ALTER TABLE ? DISABLE TRIGGER ALL'  
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON; DELETE FROM ?'  
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON; ALTER TABLE ? CHECK CONSTRAINT ALL'  
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON; ALTER TABLE ? ENABLE TRIGGER ALL' 
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON;

IF NOT EXISTS (
    SELECT
        *
    FROM
        SYS.IDENTITY_COLUMNS
        JOIN SYS.TABLES ON SYS.IDENTITY_COLUMNS.Object_ID = SYS.TABLES.Object_ID
    WHERE
        SYS.TABLES.Object_ID = OBJECT_ID(''?'') AND SYS.IDENTITY_COLUMNS.Last_Value IS NULL
)
AND OBJECTPROPERTY( OBJECT_ID(''?''), ''TableHasIdentity'' ) = 1

    DBCC CHECKIDENT (''?'', RESEED, 0) WITH NO_INFOMSGS'
	*/
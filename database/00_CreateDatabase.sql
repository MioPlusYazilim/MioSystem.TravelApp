/*
    Project  : MioSystem.TravelApp
    Database : $(DB_NAME)

    This script supports optional physical data/log paths when executed with sqlcmd:
    -v DB_NAME="MioSystem_TravelApp" DATA_PATH="C:\SqlData" LOG_PATH="C:\SqlLog"

    If DATA_PATH or LOG_PATH is empty, SQL Server default paths are used.
*/

DECLARE @DatabaseName SYSNAME = N'$(DB_NAME)';
DECLARE @DataPath NVARCHAR(4000) = NULLIF(N'$(DATA_PATH)', N'');
DECLARE @LogPath NVARCHAR(4000) = NULLIF(N'$(LOG_PATH)', N'');

IF DB_ID(@DatabaseName) IS NULL
BEGIN
    DECLARE @Sql NVARCHAR(MAX);

    IF @DataPath IS NOT NULL AND @LogPath IS NOT NULL
    BEGIN
        SET @Sql = N'CREATE DATABASE ' + QUOTENAME(@DatabaseName) + N'
ON PRIMARY
(
    NAME = N''' + @DatabaseName + N'_Data'',
    FILENAME = N''' + @DataPath + N'\' + @DatabaseName + N'.mdf''
)
LOG ON
(
    NAME = N''' + @DatabaseName + N'_Log'',
    FILENAME = N''' + @LogPath + N'\' + @DatabaseName + N'_log.ldf''
);';
    END
    ELSE
    BEGIN
        SET @Sql = N'CREATE DATABASE ' + QUOTENAME(@DatabaseName) + N';';
    END

    PRINT @Sql;
    EXEC sys.sp_executesql @Sql;
END
GO

DECLARE @DatabaseName SYSNAME = N'$(DB_NAME)';
DECLARE @Sql NVARCHAR(MAX);

SET @Sql = N'ALTER DATABASE ' + QUOTENAME(@DatabaseName) + N' SET RECOVERY SIMPLE;';
EXEC sys.sp_executesql @Sql;
GO

DECLARE @DatabaseName SYSNAME = N'$(DB_NAME)';
DECLARE @Sql NVARCHAR(MAX);

SET @Sql = N'ALTER DATABASE ' + QUOTENAME(@DatabaseName) + N' SET READ_COMMITTED_SNAPSHOT ON WITH ROLLBACK IMMEDIATE;';
EXEC sys.sp_executesql @Sql;
GO

PRINT 'Database ready.';
GO

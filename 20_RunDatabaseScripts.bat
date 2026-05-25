@echo off
cd /d "%~dp0"
call "%~dp000_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - RUN DATABASE SCRIPTS
echo ==============================================================
echo SQL Server : %SQL_SERVER%
echo Database   : %DB_NAME%
echo Auth       : %DB_AUTH%
echo.

where sqlcmd >nul 2>nul
if errorlevel 1 goto SQLCMD_NOT_FOUND

if /I "%DB_AUTH%"=="SQL" goto RUN_SQL_AUTH
goto RUN_WINDOWS_AUTH

:RUN_SQL_AUTH
echo [1/4] Create database...
sqlcmd -S "%SQL_SERVER%" -U "%DB_USER%" -P "%DB_PASSWORD%" -b -v DB_NAME="%DB_NAME%" DATA_PATH="%SQL_DATA_PATH%" LOG_PATH="%SQL_LOG_PATH%" -i "database\00_CreateDatabase.sql"
if errorlevel 1 exit /b 1

echo [2/4] Localization core...
sqlcmd -S "%SQL_SERVER%" -U "%DB_USER%" -P "%DB_PASSWORD%" -b -d "%DB_NAME%" -i "database\01_Localization_Core.sql"
if errorlevel 1 exit /b 1

echo [3/4] Lookup core...
sqlcmd -S "%SQL_SERVER%" -U "%DB_USER%" -P "%DB_PASSWORD%" -b -d "%DB_NAME%" -i "database\02_Lookup_Core.sql"
if errorlevel 1 exit /b 1

echo [4/4] Seed data...
sqlcmd -S "%SQL_SERVER%" -U "%DB_USER%" -P "%DB_PASSWORD%" -b -d "%DB_NAME%" -i "database\03_Seed_RequestWorkflow_Localization.sql"
if errorlevel 1 exit /b 1
goto RUN_DONE

:RUN_WINDOWS_AUTH
echo [1/4] Create database...
sqlcmd -S "%SQL_SERVER%" -E -b -v DB_NAME="%DB_NAME%" DATA_PATH="%SQL_DATA_PATH%" LOG_PATH="%SQL_LOG_PATH%" -i "database\00_CreateDatabase.sql"
if errorlevel 1 exit /b 1

echo [2/4] Localization core...
sqlcmd -S "%SQL_SERVER%" -E -b -d "%DB_NAME%" -i "database\01_Localization_Core.sql"
if errorlevel 1 exit /b 1

echo [3/4] Lookup core...
sqlcmd -S "%SQL_SERVER%" -E -b -d "%DB_NAME%" -i "database\02_Lookup_Core.sql"
if errorlevel 1 exit /b 1

echo [4/4] Seed data...
sqlcmd -S "%SQL_SERVER%" -E -b -d "%DB_NAME%" -i "database\03_Seed_RequestWorkflow_Localization.sql"
if errorlevel 1 exit /b 1
goto RUN_DONE

:RUN_DONE
echo.
echo Database scripts completed.
pause
exit /b 0

:SQLCMD_NOT_FOUND
echo ERROR: sqlcmd was not found.
echo Install SQL Server Command Line Utilities or run the SQL files manually in SSMS.
pause
exit /b 1

@echo off
cd /d "%~dp0"
call "%~dp000_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - SQL CONNECTION TEST
echo ==============================================================
echo SQL Server : %SQL_SERVER%
echo DB Auth    : %DB_AUTH%
echo.

where sqlcmd >nul 2>nul
if errorlevel 1 goto SQLCMD_NOT_FOUND

if /I "%DB_AUTH%"=="SQL" goto TEST_SQL_AUTH
goto TEST_WINDOWS_AUTH

:TEST_SQL_AUTH
sqlcmd -S "%SQL_SERVER%" -U "%DB_USER%" -P "%DB_PASSWORD%" -b -Q "SELECT @@SERVERNAME AS ServerName, SUSER_SNAME() AS LoginName;"
goto TEST_DONE

:TEST_WINDOWS_AUTH
sqlcmd -S "%SQL_SERVER%" -E -b -Q "SELECT @@SERVERNAME AS ServerName, SUSER_SNAME() AS LoginName;"
goto TEST_DONE

:TEST_DONE
if errorlevel 1 goto CONNECTION_FAILED

echo.
echo CONNECTION SUCCESSFUL.
pause
exit /b 0

:SQLCMD_NOT_FOUND
echo ERROR: sqlcmd was not found.
echo Install SQL Server Command Line Utilities or run database scripts manually in SSMS.
pause
exit /b 1

:CONNECTION_FAILED
echo.
echo CONNECTION FAILED.
echo Check SQL_SERVER, DB_AUTH, DB_USER and DB_PASSWORD in 00_SetVariables.bat.
pause
exit /b 1

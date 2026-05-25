@echo off
cd /d "%~dp0"
call "%~dp000_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - DATABASE FIRST SCAFFOLD
echo ==============================================================
echo SQL Server : %SQL_SERVER%
echo Database   : %DB_NAME%
echo Auth       : %DB_AUTH%
echo.

if not exist "%INFRASTRUCTURE_PROJECT%" goto INFRA_NOT_FOUND
if not exist "%API_PROJECT%" goto API_NOT_FOUND

where dotnet >nul 2>nul
if errorlevel 1 goto DOTNET_NOT_FOUND

dotnet tool restore

dotnet ef dbcontext scaffold "%DB_CONNECTION_STRING%" Microsoft.EntityFrameworkCore.SqlServer ^
  --project "%INFRASTRUCTURE_PROJECT%" ^
  --startup-project "%API_PROJECT%" ^
  --context "%DB_CONTEXT_NAME%" ^
  --context-dir "Data" ^
  --output-dir "Data\Entities" ^
  --use-database-names ^
  --no-onconfiguring ^
  --force

if errorlevel 1 goto SCAFFOLD_FAILED

echo.
echo Scaffold completed.
pause
exit /b 0

:INFRA_NOT_FOUND
echo ERROR: Infrastructure project was not found.
pause
exit /b 1

:API_NOT_FOUND
echo ERROR: API project was not found.
pause
exit /b 1

:DOTNET_NOT_FOUND
echo ERROR: dotnet was not found.
pause
exit /b 1

:SCAFFOLD_FAILED
echo.
echo Scaffold failed.
echo Run 00_TestDatabaseConnection.bat and 20_RunDatabaseScripts.bat first.
pause
exit /b 1

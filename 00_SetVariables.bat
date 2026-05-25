@echo off

REM ==============================================================
REM MioSystem.TravelApp - MAIN SETTINGS
REM ==============================================================

set "SOLUTION_NAME=MioSystem.TravelApp"
set "DB_NAME=MioSystem_TravelApp"
set "CONNECTION_KEY=MioSystemTravelAppDb"
set "DB_CONTEXT_NAME=TravelAppDbContext"
set "DOTNET_FRAMEWORK=net8.0"

REM ==============================================================
REM SQL SERVER SETTINGS
REM ==============================================================

REM Use one of these values:
REM SQL Express : .\SQLEXPRESS
REM Default SQL : .
REM Remote SQL  : 192.168.1.10,1433
REM LocalDB     : (localdb)\MSSQLLocalDB

set "SQL_SERVER=portal.mioarge.com,9867"

REM Use WINDOWS or SQL
set "DB_AUTH=SQL"

REM Only used when DB_AUTH=SQL
set "DB_USER=sa"
set "DB_PASSWORD=MioPlus2023!!"

REM Optional physical database paths.
REM Leave empty to use SQL Server default paths.
set "SQL_DATA_PATH=C:\MioTravelAppDB\MioSqlData"
set "SQL_LOG_PATH=C:\MioTravelAppDB\MioSqlLog"

REM ==============================================================
REM FOLDER SETTINGS
REM ==============================================================

set "ROOT_DIR=%~dp0"
if "%ROOT_DIR:~-1%"=="\" set "ROOT_DIR=%ROOT_DIR:~0,-1%"

set "SRC_DIR=src"
set "TEST_DIR=tests"
set "DATABASE_DIR=database"

set "API_PROJECT=%SRC_DIR%\%SOLUTION_NAME%.Api\%SOLUTION_NAME%.Api.csproj"
set "APPLICATION_PROJECT=%SRC_DIR%\%SOLUTION_NAME%.Application\%SOLUTION_NAME%.Application.csproj"
set "DOMAIN_PROJECT=%SRC_DIR%\%SOLUTION_NAME%.Domain\%SOLUTION_NAME%.Domain.csproj"
set "INFRASTRUCTURE_PROJECT=%SRC_DIR%\%SOLUTION_NAME%.Infrastructure\%SOLUTION_NAME%.Infrastructure.csproj"
set "CONTRACTS_PROJECT=%SRC_DIR%\%SOLUTION_NAME%.Contracts\%SOLUTION_NAME%.Contracts.csproj"
set "TEST_PROJECT=%TEST_DIR%\%SOLUTION_NAME%.Tests\%SOLUTION_NAME%.Tests.csproj"

REM Build connection string without IF parenthesis blocks.
REM This prevents LocalDB value from breaking CMD parsing.

if /I "%DB_AUTH%"=="SQL" goto BUILD_SQL_AUTH
goto BUILD_WINDOWS_AUTH

:BUILD_SQL_AUTH
set "DB_CONNECTION_STRING=Server=%SQL_SERVER%;Database=%DB_NAME%;User Id=%DB_USER%;Password=%DB_PASSWORD%;TrustServerCertificate=True;MultipleActiveResultSets=True;"
goto END_CONNECTION_BUILD

:BUILD_WINDOWS_AUTH
set "DB_CONNECTION_STRING=Server=%SQL_SERVER%;Database=%DB_NAME%;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
goto END_CONNECTION_BUILD

:END_CONNECTION_BUILD

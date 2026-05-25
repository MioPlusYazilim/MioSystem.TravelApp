@echo off
cd /d "%~dp0"
call "%~dp000_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - CURRENT SETTINGS
echo ==============================================================
echo ROOT_DIR      : %ROOT_DIR%
echo DATABASE_DIR  : %DATABASE_DIR%
echo SQL_SERVER    : %SQL_SERVER%
echo DB_NAME       : %DB_NAME%
echo DB_AUTH       : %DB_AUTH%
echo DB_USER       : %DB_USER%
echo SQL_DATA_PATH : %SQL_DATA_PATH%
echo SQL_LOG_PATH  : %SQL_LOG_PATH%
echo.
echo Connection string:
echo %DB_CONNECTION_STRING%
echo.
pause

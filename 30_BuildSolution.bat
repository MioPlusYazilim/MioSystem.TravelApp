@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Build
echo ==============================================================

dotnet restore "%SOLUTION_NAME%.sln"
if errorlevel 1 exit /b 1

dotnet build "%SOLUTION_NAME%.sln" --no-restore
if errorlevel 1 exit /b 1

echo Build tamamlandi.

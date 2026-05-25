@echo off
cd /d "%~dp0"
call "%~dp090_Git_Settings.bat"

echo ==============================================================
echo MioSystem.TravelApp - Pull Latest Changes
echo ==============================================================

where git >nul 2>nul
if errorlevel 1 goto GIT_NOT_FOUND

if not exist ".git" goto NOT_A_REPO

git pull origin "%GIT_BRANCH%"
if errorlevel 1 goto FAILED

echo.
echo Pull completed.
pause
exit /b 0

:GIT_NOT_FOUND
echo ERROR: Git was not found.
pause
exit /b 1

:NOT_A_REPO
echo ERROR: This folder is not a Git repository.
pause
exit /b 1

:FAILED
echo ERROR: Git pull failed.
pause
exit /b 1

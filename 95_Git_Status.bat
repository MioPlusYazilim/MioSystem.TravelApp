@echo off
cd /d "%~dp0"

echo ==============================================================
echo MioSystem.TravelApp - Git Status
echo ==============================================================

where git >nul 2>nul
if errorlevel 1 goto GIT_NOT_FOUND

if not exist ".git" goto NOT_A_REPO

git status
echo.
git remote -v
echo.
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

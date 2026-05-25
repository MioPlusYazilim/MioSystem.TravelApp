@echo off
cd /d "%~dp0"
call "%~dp090_Git_Settings.bat"

echo ==============================================================
echo MioSystem.TravelApp - Set GitHub Remote
echo ==============================================================

where git >nul 2>nul
if errorlevel 1 goto GIT_NOT_FOUND

if not exist ".git" goto NOT_A_REPO

echo Remote URL:
echo %GIT_REMOTE_URL%
echo.

git remote remove origin >nul 2>nul
git remote add origin "%GIT_REMOTE_URL%"
if errorlevel 1 goto FAILED

git remote -v

echo.
echo GitHub remote is ready.
pause
exit /b 0

:GIT_NOT_FOUND
echo ERROR: Git was not found.
pause
exit /b 1

:NOT_A_REPO
echo ERROR: This folder is not a Git repository.
echo Run 92_Git_Init_LocalRepository.bat first.
pause
exit /b 1

:FAILED
echo ERROR: Could not set remote.
pause
exit /b 1

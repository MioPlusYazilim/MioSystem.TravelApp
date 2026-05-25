@echo off
cd /d "%~dp0"
call "%~dp090_Git_Settings.bat"

echo ==============================================================
echo MioSystem.TravelApp - Git Check
echo ==============================================================

where git >nul 2>nul
if errorlevel 1 goto GIT_NOT_FOUND

git --version
echo.
echo Git is installed.
echo.
pause
exit /b 0

:GIT_NOT_FOUND
echo ERROR: Git was not found.
echo Install Git for Windows first:
echo https://git-scm.com/download/win
echo.
pause
exit /b 1

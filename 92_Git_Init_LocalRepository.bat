@echo off
cd /d "%~dp0"
call "%~dp090_Git_Settings.bat"

echo ==============================================================
echo MioSystem.TravelApp - Init Local Git Repository
echo ==============================================================

where git >nul 2>nul
if errorlevel 1 goto GIT_NOT_FOUND

if not exist ".gitignore" (
    echo ERROR: .gitignore was not found.
    echo Copy the .gitignore file from this package into the project root.
    pause
    exit /b 1
)

if exist ".git" (
    echo Git repository already exists.
) else (
    git init
    if errorlevel 1 goto FAILED
)

git branch -M "%GIT_BRANCH%"

echo.
echo Local Git repository is ready.
pause
exit /b 0

:GIT_NOT_FOUND
echo ERROR: Git was not found.
pause
exit /b 1

:FAILED
echo ERROR: Git init failed.
pause
exit /b 1

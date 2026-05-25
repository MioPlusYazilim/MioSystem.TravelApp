@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Git init
echo ==============================================================

git --version >nul 2>nul
if errorlevel 1 (
    echo HATA: Git bulunamadi.
    exit /b 1
)

if not exist ".git" (
    git init
) else (
    echo Git repository zaten var.
)

git add .
git status

echo.
echo Git hazir. Commit atmak istersen:
echo git commit -m "Initial MioSystem.TravelApp structure"

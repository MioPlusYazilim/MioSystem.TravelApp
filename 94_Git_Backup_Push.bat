@echo off
cd /d "%~dp0"
call "%~dp090_Git_Settings.bat"

echo ==============================================================
echo MioSystem.TravelApp - Backup to GitHub
echo ==============================================================

where git >nul 2>nul
if errorlevel 1 goto GIT_NOT_FOUND

if not exist ".git" goto NOT_A_REPO

echo IMPORTANT:
echo - appsettings.Development.json should not be committed.
echo - Passwords, pfx files, certificates and local database files should not be committed.
echo - Check the file list carefully before pushing.
echo.

git status --short
echo.
pause

git add .
if errorlevel 1 goto FAILED

git status --short
echo.
echo Files above will be committed.
pause

git commit -m "%GIT_COMMIT_MESSAGE%"
if errorlevel 1 goto COMMIT_WARNING

:PUSH
git push -u origin "%GIT_BRANCH%"
if errorlevel 1 goto PUSH_FAILED

echo.
echo Backup completed successfully.
pause
exit /b 0

:COMMIT_WARNING
echo.
echo Commit may have failed because there are no changes.
echo Trying to push current branch anyway...
goto PUSH

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
echo ERROR: Git add or commit failed.
pause
exit /b 1

:PUSH_FAILED
echo.
echo Push failed.
echo Possible reasons:
echo 1. GitHub repository does not exist yet.
echo 2. Remote URL is wrong in 90_Git_Settings.bat.
echo 3. You are not logged in to GitHub.
echo 4. GitHub asked for authentication and it was cancelled.
echo.
pause
exit /b 1

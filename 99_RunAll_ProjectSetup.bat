@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Tum proje setup adimlari
echo ==============================================================
echo Bu script sadece proje iskeletini kurar.
echo Database icin 20_RunDatabaseScripts.bat ayrica calistirilabilir.
echo.

call "01_CheckEnvironment.bat"
if errorlevel 1 exit /b 1

call "02_CreateSolutionAndProjects.bat"
if errorlevel 1 exit /b 1

call "03_AddProjectReferences.bat"
if errorlevel 1 exit /b 1

call "04_AddNugetPackages.bat"
if errorlevel 1 exit /b 1

call "05_CreateProjectFolders.bat"
if errorlevel 1 exit /b 1

call "06_CreateConfigFiles.bat"
if errorlevel 1 exit /b 1

call "40_InstallEfTool.bat"
if errorlevel 1 exit /b 1

call "30_BuildSolution.bat"
if errorlevel 1 exit /b 1

echo.
echo Tum proje setup adimlari tamamlandi.
echo Sonraki onerilen adim: 20_RunDatabaseScripts.bat

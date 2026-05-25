@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - dotnet ef local tool
echo ==============================================================

if not exist ".config" mkdir ".config"
if not exist ".config\dotnet-tools.json" (
    dotnet new tool-manifest
)

dotnet tool install dotnet-ef --version 8.*
if errorlevel 1 (
    echo dotnet-ef zaten kurulu olabilir. Update deneniyor...
    dotnet tool update dotnet-ef --version 8.*
)

dotnet tool restore

echo dotnet ef hazir.

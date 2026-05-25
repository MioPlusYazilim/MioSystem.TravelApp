@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Solution ve project olusturma
echo ==============================================================

if not exist "%SRC_DIR%" mkdir "%SRC_DIR%"
if not exist "%TEST_DIR%" mkdir "%TEST_DIR%"

if not exist "%SOLUTION_NAME%.sln" (
    echo Solution olusturuluyor...
    dotnet new sln -n "%SOLUTION_NAME%"
    if errorlevel 1 exit /b 1
) else (
    echo Solution zaten var, geciliyor.
)

if not exist "%API_PROJECT%" (
    echo API project olusturuluyor...
    dotnet new webapi -n "%SOLUTION_NAME%.Api" -o "%SRC_DIR%\%SOLUTION_NAME%.Api" --framework "%DOTNET_FRAMEWORK%"
    if errorlevel 1 exit /b 1
) else echo API project zaten var.

if not exist "%APPLICATION_PROJECT%" (
    echo Application project olusturuluyor...
    dotnet new classlib -n "%SOLUTION_NAME%.Application" -o "%SRC_DIR%\%SOLUTION_NAME%.Application" --framework "%DOTNET_FRAMEWORK%"
    if errorlevel 1 exit /b 1
) else echo Application project zaten var.

if not exist "%DOMAIN_PROJECT%" (
    echo Domain project olusturuluyor...
    dotnet new classlib -n "%SOLUTION_NAME%.Domain" -o "%SRC_DIR%\%SOLUTION_NAME%.Domain" --framework "%DOTNET_FRAMEWORK%"
    if errorlevel 1 exit /b 1
) else echo Domain project zaten var.

if not exist "%INFRASTRUCTURE_PROJECT%" (
    echo Infrastructure project olusturuluyor...
    dotnet new classlib -n "%SOLUTION_NAME%.Infrastructure" -o "%SRC_DIR%\%SOLUTION_NAME%.Infrastructure" --framework "%DOTNET_FRAMEWORK%"
    if errorlevel 1 exit /b 1
) else echo Infrastructure project zaten var.

if not exist "%CONTRACTS_PROJECT%" (
    echo Contracts project olusturuluyor...
    dotnet new classlib -n "%SOLUTION_NAME%.Contracts" -o "%SRC_DIR%\%SOLUTION_NAME%.Contracts" --framework "%DOTNET_FRAMEWORK%"
    if errorlevel 1 exit /b 1
) else echo Contracts project zaten var.

if not exist "%TEST_PROJECT%" (
    echo Test project olusturuluyor...
    dotnet new xunit -n "%SOLUTION_NAME%.Tests" -o "%TEST_DIR%\%SOLUTION_NAME%.Tests" --framework "%DOTNET_FRAMEWORK%"
    if errorlevel 1 exit /b 1
) else echo Test project zaten var.

echo.
echo Projectler solution'a ekleniyor...
dotnet sln "%SOLUTION_NAME%.sln" add "%API_PROJECT%" || echo API zaten ekli olabilir.
dotnet sln "%SOLUTION_NAME%.sln" add "%APPLICATION_PROJECT%" || echo Application zaten ekli olabilir.
dotnet sln "%SOLUTION_NAME%.sln" add "%DOMAIN_PROJECT%" || echo Domain zaten ekli olabilir.
dotnet sln "%SOLUTION_NAME%.sln" add "%INFRASTRUCTURE_PROJECT%" || echo Infrastructure zaten ekli olabilir.
dotnet sln "%SOLUTION_NAME%.sln" add "%CONTRACTS_PROJECT%" || echo Contracts zaten ekli olabilir.
dotnet sln "%SOLUTION_NAME%.sln" add "%TEST_PROJECT%" || echo Tests zaten ekli olabilir.

echo.
echo Solution ve project olusturma tamamlandi.

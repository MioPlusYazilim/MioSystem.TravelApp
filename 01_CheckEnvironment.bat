@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Ortam kontrolu
echo ==============================================================
echo.

echo [1/4] .NET SDK kontrol ediliyor...
dotnet --info
if errorlevel 1 (
    echo HATA: dotnet komutu calismadi. .NET SDK kurulu olmayabilir.
    exit /b 1
)

echo.
echo [2/4] Git kontrol ediliyor...
git --version
if errorlevel 1 (
    echo UYARI: git bulunamadi. Git init adimini sonra calistirabilirsin.
)

echo.
echo [3/4] sqlcmd kontrol ediliyor...
sqlcmd -? >nul 2>nul
if errorlevel 1 (
    echo UYARI: sqlcmd bulunamadi. Database scriptlerini SSMS ile de calistirabilirsin.
) else (
    echo sqlcmd bulundu.
)

echo.
echo [4/4] Degiskenler:
echo Solution        : %SOLUTION_NAME%
echo Database        : %DB_NAME%
echo SQL Server      : %SQL_SERVER%
echo Framework       : %DOTNET_FRAMEWORK%
echo Connection Key  : %CONNECTION_KEY%
echo.
echo Ortam kontrolu tamamlandi.

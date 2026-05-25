@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - NuGet paketleri
echo ==============================================================

echo Infrastructure EF Core SQL Server paketleri ekleniyor...
dotnet add "%INFRASTRUCTURE_PROJECT%" package Microsoft.EntityFrameworkCore.SqlServer --version 8.*
dotnet add "%INFRASTRUCTURE_PROJECT%" package Microsoft.EntityFrameworkCore.Design --version 8.*
dotnet add "%INFRASTRUCTURE_PROJECT%" package Microsoft.EntityFrameworkCore.Tools --version 8.*
dotnet add "%INFRASTRUCTURE_PROJECT%" package Microsoft.Extensions.Configuration.Abstractions --version 8.*
dotnet add "%INFRASTRUCTURE_PROJECT%" package Microsoft.Extensions.DependencyInjection.Abstractions --version 8.*

echo.
echo API EF design ve swagger paketleri ekleniyor...
dotnet add "%API_PROJECT%" package Microsoft.EntityFrameworkCore.Design --version 8.*
dotnet add "%API_PROJECT%" package Swashbuckle.AspNetCore --version 6.*

echo.
echo Application validasyon paketi ekleniyor...
dotnet add "%APPLICATION_PROJECT%" package FluentValidation --version 11.*

echo.
echo Paket yukleme tamamlandi.

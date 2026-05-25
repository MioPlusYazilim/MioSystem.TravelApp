@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Project reference ekleme
echo ==============================================================

REM API katmani Application, Infrastructure ve Contracts katmanlarini kullanir.
dotnet add "%API_PROJECT%" reference "%APPLICATION_PROJECT%" || echo API -> Application zaten ekli olabilir.
dotnet add "%API_PROJECT%" reference "%INFRASTRUCTURE_PROJECT%" || echo API -> Infrastructure zaten ekli olabilir.
dotnet add "%API_PROJECT%" reference "%CONTRACTS_PROJECT%" || echo API -> Contracts zaten ekli olabilir.

REM Application katmani Domain ve Contracts katmanlarini kullanir.
dotnet add "%APPLICATION_PROJECT%" reference "%DOMAIN_PROJECT%" || echo Application -> Domain zaten ekli olabilir.
dotnet add "%APPLICATION_PROJECT%" reference "%CONTRACTS_PROJECT%" || echo Application -> Contracts zaten ekli olabilir.

REM Infrastructure katmani database, external servisler ve persistence islerini tasir.
dotnet add "%INFRASTRUCTURE_PROJECT%" reference "%DOMAIN_PROJECT%" || echo Infrastructure -> Domain zaten ekli olabilir.
dotnet add "%INFRASTRUCTURE_PROJECT%" reference "%APPLICATION_PROJECT%" || echo Infrastructure -> Application zaten ekli olabilir.

REM Test project tum ana katmanlari gorebilir.
dotnet add "%TEST_PROJECT%" reference "%API_PROJECT%" || echo Tests -> API zaten ekli olabilir.
dotnet add "%TEST_PROJECT%" reference "%APPLICATION_PROJECT%" || echo Tests -> Application zaten ekli olabilir.
dotnet add "%TEST_PROJECT%" reference "%INFRASTRUCTURE_PROJECT%" || echo Tests -> Infrastructure zaten ekli olabilir.

echo.
echo Project reference islemi tamamlandi.

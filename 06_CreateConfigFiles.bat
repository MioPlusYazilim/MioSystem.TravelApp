@echo off
cd /d "%~dp0"
call "%~dp000_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - CREATE CONFIG FILES
echo ==============================================================

set "APPSETTINGS_PATH=%SRC_DIR%\%SOLUTION_NAME%.Api\appsettings.Development.json"

if not exist "%SRC_DIR%\%SOLUTION_NAME%.Api" goto API_FOLDER_NOT_FOUND

powershell -NoProfile -ExecutionPolicy Bypass -Command "$obj = [ordered]@{}; $obj.ConnectionStrings = [ordered]@{}; $obj.ConnectionStrings[$env:CONNECTION_KEY] = $env:DB_CONNECTION_STRING; $obj.Localization = [ordered]@{ DefaultCulture = 'tr-TR'; SupportedCultures = @('tr-TR','en-US') }; $obj.Logging = [ordered]@{ LogLevel = [ordered]@{ Default = 'Information'; 'Microsoft.AspNetCore' = 'Warning' } }; $json = $obj | ConvertTo-Json -Depth 10; Set-Content -Path $env:APPSETTINGS_PATH -Value $json -Encoding UTF8;"

if errorlevel 1 goto CREATE_FAILED

echo Config file created:
echo %APPSETTINGS_PATH%
echo.
echo Used connection string:
echo %DB_CONNECTION_STRING%
echo.
pause
exit /b 0

:API_FOLDER_NOT_FOUND
echo ERROR: API folder was not found.
echo Run 02_CreateSolutionAndProjects.bat first.
pause
exit /b 1

:CREATE_FAILED
echo ERROR: appsettings.Development.json could not be created.
pause
exit /b 1

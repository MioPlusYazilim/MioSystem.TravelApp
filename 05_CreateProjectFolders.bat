@echo off
call "%~dp0 00_SetVariables.bat"

echo ==============================================================
echo MioSystem.TravelApp - Klasor yapisi
echo ==============================================================

REM API
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Api\Controllers" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Api\Extensions" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Api\Middleware" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Api\Filters" 2>nul

REM Application
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Application\Abstractions" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Application\Common" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Application\Features" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Application\Services" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Application\Validation" 2>nul

REM Domain
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Domain\Common" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Domain\Enums" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Domain\ValueObjects" 2>nul

REM Infrastructure
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Infrastructure\Data" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Infrastructure\Data\Entities" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Infrastructure\Data\Scaffold" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Infrastructure\Localization" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Infrastructure\Services" 2>nul

REM Contracts
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Contracts\Common" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Contracts\Requests" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Contracts\Responses" 2>nul
mkdir "%SRC_DIR%\%SOLUTION_NAME%.Contracts\Localization" 2>nul

REM Database / docs
mkdir "database" 2>nul
mkdir "database\00_Foundation" 2>nul
mkdir "database\01_Core" 2>nul
mkdir "database\02_Request" 2>nul
mkdir "database\03_Offer" 2>nul
mkdir "database\04_Transaction" 2>nul
mkdir "database\05_Accounting" 2>nul
mkdir "database\06_Views" 2>nul
mkdir "database\07_StoredProcedures" 2>nul
mkdir "database\08_Seed" 2>nul
mkdir "docs" 2>nul
mkdir "tools" 2>nul

echo Klasor yapisi tamamlandi.

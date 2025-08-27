@echo off
echo Code Coverage Summary
echo =====================

REM Find the latest coverage file
for /f "delims=" %%i in ('dir /b /s TestResults\coverage.cobertura.xml 2^>nul') do set "COVERAGE_FILE=%%i"

if "%COVERAGE_FILE%"=="" (
    echo No coverage files found in TestResults directory
    goto :end
)

echo Coverage file: %COVERAGE_FILE%
echo.

REM Extract basic coverage info using findstr
echo Overall Coverage:
findstr "line-rate\|branch-rate\|lines-covered\|lines-valid\|branches-covered\|branches-valid" "%COVERAGE_FILE%"

echo.
echo For detailed coverage analysis, open the HTML report in your browser:
for /f "delims=" %%i in ('dir /b /s TestResults\index.html 2^>nul') do echo   %%i

:end
pause

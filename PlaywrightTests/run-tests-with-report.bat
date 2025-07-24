@echo off
REM Run Playwright tests and generate HTML report automatically

REM 1. Run tests and output TRX results

dotnet test --logger "trx;LogFileName=playwright_test_results.trx" --results-directory TestResults

REM 2. Convert TRX to HTML using trxlog2html (assumes it's installed and in PATH)

trxlog2html TestResults\playwright_test_results.trx TestResults\playwright_test_results.html

REM 3. Open the HTML report (optional, comment out if not needed)
REM start TestResults\playwright_test_results.html

echo Test run complete. HTML report generated at TestResults\playwright_test_results.html

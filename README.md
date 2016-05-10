# ReadiumTestResultsv4.0
ASP.Net application for uploading student intern spreadsheet data and displaying on screen.
Users can upload Readium test results via .xls or .xlsx spreadsheet based on the test results template found here: 
https://github.com/readium/readium.github.io/blob/master/test-results/cloudreader/spreadsheets/user-OS-version-browser-date.xlsx

Backend logic will:
1. store the spreadsheet in a folder
2. parse the data from each spreadsheet in the folder and display a summary of test results as well as a link 
to the actual test results spreadsheet.

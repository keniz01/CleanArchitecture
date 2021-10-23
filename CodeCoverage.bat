SET dotnet="C:/Program Files/dotnet/dotnet.exe"
SET opencover=%UserProfile%\.nuget\packages\OpenCover\4.7.1221\tools\OpenCover.Console.exe
SET reportgenerator=%UserProfile%\.nuget\packages\ReportGenerator\4.8.13\tools\net5.0\ReportGenerator.exe

SET targetargs="test"
SET filter="+[*]CleanArchitecture.*"
SET coveragefile=Coverage.xml
SET coveragedir=Coverage

REM Run code coverage analysis
%opencover% -oldStyle -register:user -target:%dotnet% -output:%coveragefile% -targetargs:%targetargs% -filter:%filter% -skipautoprops -hideskipped:All

REM delete old coverage files
DEL /F /Q .\coverage\*.*

REM Generate the report
%reportgenerator% -targetdir:%coveragedir% -reporttypes:Html;Badges -reports:%coveragefile% -verbosity:Error

REM Open the report
start "report" "%coveragedir%\index.htm"
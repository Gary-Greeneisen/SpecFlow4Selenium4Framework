@echo off
rem filename-DosBatchListDirs.bat
rem Dos batch file example for Executing Batch File in C#
echo "Batch file Started"
echo "Displaying Command Line Arguments"
echo "Command Line Argument(1) =" %1
echo "Command Line Argument(2) =" %2
echo "Command Line Argument(3) =" %3

rem script to List all dir under the .Net VS project and save contents to an output file#
rem #Set the source vars(No spaces between =)
set sourceDir=C:\Test1\Specflow3-Selenium-4-Framework-.Net-Core\AcceptanceTests\
echo "sourceDir = "  %sourceDir%

rem Set the target vars
set targetDir=C:\Temp\
rem set targetDir=C:\Test1\Specflow3-Selenium-4-Framework-.Net-Core\AcceptanceTests\DOSBatchFiles\
echo "targetDir = "  %targetDir%

set targetFilename=DosBatchListDirsOutput.txt

rem Set the command var
rem concatenate two variables in batch script
set "targetPath=%targetDir%%targetFilename%"
rem set target="C:\Test2\Test.txt"
echo "target path\filename= " %targetPath%

rem Run the command and pipe the output to Target Path\filename
dir %sourceDir% > %targetPath%

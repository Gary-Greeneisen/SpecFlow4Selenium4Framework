#filename=PowerShellReadFile.ps1
# This is a single line comment
<# 
  Multi-line comment
#>
#Powershell script to read external file contents and save contents to an output file#
#Set the source vars
$sourcePath = "C:\Test1\Specflow3-Selenium-4-Framework-.Net-Core\AcceptanceTests\PowerShell\"
$sourceFilename = "TestTextFile1.txt"
$targetPath = "C:\Temp\"
#$targetPath = $sourcePath
$targetFilename = "TestTextFile1Output.txt"

#Set the command var
$source = $sourcePath + $sourceFilename
$target = $targetPath + $targetFilename

#Read file contents into script var filedata
#$filedata = Get-Content C:\Test1\Specflow3-Selenium-4-Framework-.Net-Core\AcceptanceTests\PowerShell\TestTextFile1.txt

#Sets the PowerShell execution policies
#Set-ExecutionPolicy RemoteSigned

#Run the command and pipe the output to Target Path\filename
Get-Content $source | Out-File -FilePath $target

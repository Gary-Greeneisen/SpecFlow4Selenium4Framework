#filename=PowerShellListDirs.ps1
# This is a single line comment
<# 
  Multi-line comment
#>
#Powershell script to List all dir under the .Net VS project and save contents to an output file#
#Set the source vars
$sourceDir = "C:\Test1\Specflow3-Selenium-4-Framework-.Net-Core\AcceptanceTests"
#Set the target vars
$targetDir = "C:\Temp\"
#$targetDir = "C:\Test1\Specflow3-Selenium-4-Framework-.Net-Core\AcceptanceTests\PowerShell\"
$targetFilename = "PowerShellListDirsOutput.txt"

#Set the command var
$target = $targetDir + $targetFilename

#Sets the PowerShell execution policies
#Set-ExecutionPolicy RemoteSigned

#Run the command and pipe the output to Target Path\filename
Get-ChildItem -Path $sourceDir -Depth 2 | Out-File -FilePath $target



using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Diagnostics;
using AcceptanceTests.Common.Library;

namespace AcceptanceTests.Features.POC
{
    class TestPowerShell
    {

         [Test]
        ///Run PowerShell commands from C# code
        ///List all dir under the.Net VS project and save contents to an output file#
        ///
        public void RunPowerShellinCode()
        {
            /********************************************
                PowerShell.Create().AddCommand("Echo")
                     .AddParameter("This is a Test")
                    .Invoke();
            ********************************************/
            //Get the project dir (source)
            var runDir = Library.GetProjectDir();
            var sourceFilePath = runDir + @"\" + "AcceptanceTests";

            //Set target dir\filename
            var targetDir = @"C:\temp\";
            var targetFilename = "PowerShellListDirsOutput.txt";
            var targetFilePath = targetDir + targetFilename;

            //Create PowerShell command
            //Set the input
            PowerShell psinstance = PowerShell.Create();
            psinstance.AddCommand("Get-ChildItem");
            psinstance.AddParameter("Path", sourceFilePath);
            psinstance.AddParameter("Depth", 2);

            //Set output
            psinstance.AddCommand("Out-File");
            psinstance.AddParameter("FilePath", targetFilePath);

            var results = psinstance.Invoke();

            //Display results in Visual Studio TestExplorer Test Details Summary Output Window
            System.Diagnostics.Debug.Write(results.ToString());
            //TestContext.Progress.WriteLine(results.ToString());

            //Execute same PowerShell command using differnt output
            // invoke execution on the pipeline (collecting output)
            Collection<PSObject> PSOutput = psinstance.Invoke();

            //Display results in Visual Studio Tests Output Window
            // loop through each output object item
            foreach (PSObject outputItem in PSOutput)
            {
                // if null object was dumped to the pipeline during the script then a null object may be present here
                if (outputItem != null)
                {
                    Console.WriteLine($"Output line: [{outputItem}]");
                }
            }

        }


        [Test]

        ///invoke PowerShell process from C# code and pass command as argument.
        ///This example uses echo command
        /// or Executes PowerShell script

        public void RunPowerShellWindow()
        {
            //Get the project dir
            var runDir = Library.GetProjectDir();
            var filePath = runDir + @"\" + "AcceptanceTests" + @"\" + "PowerShell";
            //Powershell script to read external file contents and save contents to an output file#
            string fileName = "PowerShellReadFile.ps1";

            //Powershell script to List all dir under the .Net VS project and save contents to an output file#
            //string fileName = "PowerShellListDirs.ps1";

            string powerShellScript = filePath + @"\" + fileName;

            //execute powershell cmdlets or scripts using command arguments as process
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.FileName = "powershell.exe";
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            //execute powershell script using script file
            //processInfo.Arguments = @"& {c:\temp\Get-EventLog.ps1}";
            //Executes PowerShell script
            processInfo.Arguments = powerShellScript;

            //Use echo command
            //processInfo.Arguments = "echo This is a Test";      //Use this to pass arguments

            processInfo.WorkingDirectory = @"C:\";
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            //start powershell process using process start info
            Process process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            int ExitCode = process.ExitCode;

            //read output
            //Console.WriteLine("Output - {0}", process.StandardOutput.ReadToEnd());
            //read errors
            //Console.WriteLine("Errors - {0}", process.StandardError.ReadToEnd());

            process.Close();
        }

        [Test]
        public void RunCmdWindow()
        {
            //Open cmd window (DOS prompt)
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = @"C:\WINDOWS\system32\cmd.exe";
            processInfo.WindowStyle = ProcessWindowStyle.Normal;

            //start CMD process using process start info
            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            //Display a message
            Console.WriteLine("This is CMD message, Press any key");
            Console.ReadKey();

        }

        [Test]
        /// <summary>
        /// Execute PowerShell script file using C# code.
        /// The code just executes the PowerShell script, has no idea
        /// what the script does
        /// </summary>
        public void RunPowerShellScript()
        {
            //Get the project dir
            var runDir = Library.GetProjectDir();
            var filePath = runDir +  @"\"  + "AcceptanceTests" + @"\" + "PowerShell";
            //Powershell script to read external file contents and save contents to an output file#
            //string fileName = "PowerShellReadFile.ps1";

            //Powershell script to List all dir under the .Net VS project and save contents to an output file#
            string fileName = "PowerShellListDirs.ps1";
            
            string powerShellScript = filePath + @"\" + fileName;

            PowerShell powerShell = PowerShell.Create();
            powerShell.AddScript(System.IO.File.ReadAllText(powerShellScript));
            Collection<PSObject> PSOutput = powerShell.Invoke();

        }






        }
}

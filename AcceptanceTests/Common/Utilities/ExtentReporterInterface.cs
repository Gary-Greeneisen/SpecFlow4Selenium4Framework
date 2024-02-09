using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace AcceptanceTests.Common.Utilities
{
    public static class ExtentReporterInterface
    {
        /// <summary>
        /// Define global class vars
        /// </summary>
        //Define a reporter var
        //private static ExtentHtmlReporter htmlReporter;
        // create ExtentReport var and attach reporter(s)
        //private static ExtentReporterClass reportClass = new ExtentReporterClass();
        //private static ExtentReports _extentReport = reportClass.CreateExtentReport();

        private static ExtentReporterClass _reportClass = null;
        private static ExtentReports _extentReport = null;

        //Define a get method to return ExtentReports _report;
        /// <summary>
        /// Since this is a static class, you must do (1) of the following
        /// 1. Put the code logic in the get method
        /// 2. Or create a seperate non-static class and place the code logic in this class
        ///     and call the new operator on the non-static class as was done in the 
        ///     class = TestRunnerInterface.cs file
        ///     example
        ///     private static TestRunnerClass _testrunner = new TestRunnerClass();
        ///     
        ///     Solution
        ///     create a seperate non-static class and place the code logic in this class
        ///     now for debugging use can place a break point on the get method 
        ///     Similar to the YouTube Video
        ///     Extent Reports in C#|Selenium tutorial using C# and Nunit|Selenium Webdriver C# Nunit tutorial-3
        ///         https://www.youtube.com/watch?v=8-Q3ayH0Zo8 
        /// 
        /// </summary>
        public static ExtentReports ExtentReport
        {
            get
            {
                //If (The Extent Report instance has not be created
                // then call the methods to create the instance, and update the global class var _extentReport
                if (_extentReport == null)
                {
                    _reportClass = new ExtentReporterClass();
                    _extentReport = _reportClass.CreateExtentReport();

                    //Delete all previous sceenshot files before the test
                    //_reportClass.DeleteReportScreenShots();   //Comment out for now Date-12/16/2021
                }

                return _extentReport;
            }
        }

        /// <summary>
        /// Call the Class method to add the screen shot to the Report file
        /// </summary>
        /// <param name="test"></param>
        /// <param name="browser"></param>
        /// <param name="imageName"></param>
        public static void ScreenShot(ExtentTest test,IWebDriver browser, string imageName)
        {
            _reportClass.CaptureScreenShot(test,browser, imageName);
        }


    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Common.Library;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AcceptanceTests.Common.Utilities;

namespace AcceptanceTests.Features.POC
{
    class TestExtentReports
    {

        [Test]
        public void TestLogTestResults()
        {
            //Test case to log test results

            //1. Create ExtentReports and ExtentTest global variables
            //Get the report instance from the static class ExtentReporter
            ExtentReports report = ExtentReporterInterface.ExtentReport;

            //2. Create a test var
            ExtentTest test;

            //3. create a test based on the report instance
            test = report.CreateTest("TestLogTestResults()", "Report Example Test=Pass");

            //4. Add an info statement to the log report
            test.Log(Status.Info, "Test Started)");

            //5. log(Status, Pass/Fail)
            test.Log(Status.Pass, "Test Passed)");

            //7. calling Report flush writes everything to the log file
            report.Flush();
        }


        [Test]
        public void TestExtentReporterClass()
        {

            ExtentReporterClass reportClass = new ExtentReporterClass();
            ExtentReports _extentReport = reportClass.CreateExtentReport();

        }



        [Test]
        [Category("TestExtentReports")]
        //public void TraitCategory() { }
        
        ///Display Chrome browser, search for "Books"
        ///Verify the title page
        ///Log test = pass to the Exent Report html file

        public void TestChromePass()
        {
            //Global vars
            IWebDriver browser = null;

            //1. Create ExtentReports and ExtentTest global variables
            //Get the report instance from the static class ExtentReporter
            ExtentReports report = ExtentReporterInterface.ExtentReport;

            //2. Create a test var
            ExtentTest test;

            //3. create a test based on the report instance
            test = report.CreateTest("TestChromePass()", "Report Example Test=Pass");


            try
            {

                //4. Add an info statement to the log report
                test.Log(Status.Info, "Test Started");

                //Standard web driver instance
                browser = new ChromeDriver();

                //Set implicit wait
                browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                browser.Url = "http://www.google.com";

                //Find the Search text box UI Element
                IWebElement element = browser.FindElement(By.Name("q"));

                //Search
                element.SendKeys("books");

                // this sends an Enter to the element
                element.SendKeys(Keys.Enter);

                //Wait for page to load
                //System.Threading.Thread.Sleep(5 * 1000); //Wait 5-sec
                new WebDriverWait(browser, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                //Test if main page displayed
                element = browser.FindElement(By.Id("main"));

                //check the page title
                var pageTitle = browser.Title;
                var contains = pageTitle.Contains("books", StringComparison.OrdinalIgnoreCase);

                //As a test when searching for books, the page tile would conatin books
                //so this will Pass
                if(!contains)
                {
                    throw new Exception("Page Title =" + pageTitle);
                }

                //5. log(Status, Pass/Fail)
                test.Log(Status.Pass, "Test Passed");

                //Add Test file screen shot
                ExtentReporterInterface.ScreenShot(test,browser, "TestChromePassImage1");

            }
            catch (Exception e)
            {
                //6. log(Status, Pass/Fail)
                test.Log(Status.Fail, "Test Falied" + e.ToString());

                //Add Test file screen shot
                ExtentReporterInterface.ScreenShot(test, browser, "TestChromePassImage2");
            }

            //call quit, instead of close
            browser.Quit();

            //7. calling Report flush writes everything to the log file
            report.Flush();
        }

        [Test]
        [Category("TestExtentReports")]
        ///Display Chrome browser, search for "Books"
        ///Verify the title page
        ///Log test = pass to the Exent Report html file

        public void TestChromeFail()
        {
            //Global vars
            IWebDriver browser = null;

            //1. Create ExtentReports and ExtentTest global variables
            //Get the report instance from the static class ExtentReporter
            ExtentReports report = ExtentReporterInterface.ExtentReport;

            //2. Create a test var
            ExtentTest test;

            //3. create a test based on the report instance
            test = report.CreateTest("TestChromeFail()", "Report Example Test=Pass");


            try
            {

                //4. Add an info statement to the log report
                test.Log(Status.Info, "Test Started");

                //Standard web driver instance
                browser = new ChromeDriver();

                //Set implicit wait
                browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                browser.Url = "http://www.google.com";

                //Find the Search text box UI Element
                IWebElement element = browser.FindElement(By.Name("q"));

                //Search
                element.SendKeys("Error");

                // this sends an Enter to the element
                element.SendKeys(Keys.Enter);

                //Wait for page to load
                //System.Threading.Thread.Sleep(5 * 1000); //Wait 5-sec
                new WebDriverWait(browser, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                //Test if main page displayed
                element = browser.FindElement(By.Id("main"));

                //check the page title
                var pageTitle = browser.Title;
                var contains = pageTitle.Contains("books", StringComparison.OrdinalIgnoreCase);

                //As a test when searching for error, the page tile would conatin error
                //so this will Fail
                if (!contains)
                {
                    throw new Exception("Page Title =" + pageTitle);
                }

                //5. log(Status, Pass/Fail)
                test.Log(Status.Pass, "Test Passed");

                //Add Test file screen shot
                ExtentReporterInterface.ScreenShot(test, browser, "TestChromeFailImage1");

            }
            catch (Exception e)
            {
                //6. log(Status, Pass/Fail)
                test.Log(Status.Fail, "Test Falied" + e.ToString());

                //Add Test file screen shot
                ExtentReporterInterface.ScreenShot(test, browser, "TestChromeFailImage2");
            }

            //call quit, instead of close
            browser.Quit();

            //7. calling Report flush writes everything to the log file
            report.Flush();
        }





    }//End class TestExtentReports

}//End namespace AcceptanceTests.Features.POC

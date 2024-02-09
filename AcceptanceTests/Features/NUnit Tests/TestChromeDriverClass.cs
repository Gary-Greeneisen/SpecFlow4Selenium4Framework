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
using System.Diagnostics;

namespace AcceptanceTests.Features.NUnit_Tests
{
    class TestChromeDriverClass
    {

        [SetUp]
        public void Initialize()
        {
            
        }

        [Test]

        //Implicit Wait
        //An implicit wait is to tell WebDriver to poll the DOM for a certain amount of time when trying to
        //find an element or elements if they are not immediately available.This can be useful when certain
        //elements on the webpage are not available immediately and need some time to load.
        //The default setting is 0, meaning disabled. Once set, the implicit wait is set for the life of the session
        //
        //C# Syntax:
        //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        public void TestChromeDriver()
        {
            //If you use the default constructor of ChromeDriver, the following exception is thrown.
            //Message: OpenQA.Selenium.DriverServiceNotFoundException : The chromedriver.exe file does
            //not exist in the current directory or in a directory on the PATH environment variable.
            //The driver can be downloaded at http://chromedriver.storage.googleapis.com/index.html.
            //This happens because the NuGet packages for .NET Core projects are loaded from a global place
            //instead of the packages folder of the.NET Framework projects.To fix it, we need to specify
            //the path to the execution folder.

            //***************************************************************************************
            // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
            // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // You now have to use 
            //TestContext.CurrentContext.TestDirectory;
            //or var driverDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //***************************************************************************************

            //dir to the Chrome driver
            //var runDir = Library.GetProjectDir();
            //var driverDir = runDir + @"\packages\";
            //IWebDriver browser = new ChromeDriver(driverDir);


            //***************************************************************************************
            // I'm using the Chrome driver that copies the "chromedriver(.exe)"
            //to the target bin folder from the package folder during the build process.
            //Now use can use the default Chrome Driver default constructor
            //IWebDriver browser = new ChromeDriver();
            //No need to add code to specify the web driver location
            //For more details see Issue #5 - Default Firefox Driver Displays Run Time Exception
            //***************************************************************************************

            //Headless Browser Testing
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            //IWebDriver browser = new ChromeDriver(chromeOptions);

            //Standard web driver instance
            IWebDriver browser = new ChromeDriver();

            //Set implicit wait
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Set the browser page and goto the page
            //browser.Navigate().GoToUrl("http://www.google.com");
            browser.Url = "http://www.google.com";
            browser.Navigate();

            //Find the Search text box UI Element
            IWebElement element = browser.FindElement(By.Name("q"));

            //Search
            element.SendKeys("books");

            // this sends an Enter to the element
            element.SendKeys(Keys.Enter);

            //Wait for page to load
            //System.Threading.Thread.Sleep(5 * 1000); //Wait 5-sec
            new WebDriverWait(browser, TimeSpan.FromSeconds(15)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            //Test if main page displayed
            element = browser.FindElement(By.Id("main"));

            //check the page title
            var pageTitle = browser.Title;

            //Read #images on the page
            var listImages = browser.FindElements(By.TagName("img"));

            //call quit, instead of close
            browser.Quit();

            //Print #Images to Debug output window
            Debug.Write("Chrome #Images = ");
            Debug.WriteLine(listImages.Count);
        }

        [TearDown]
        public void EndTest()
        {
            
        }


    }
}

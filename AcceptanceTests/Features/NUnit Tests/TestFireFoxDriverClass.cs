using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcceptanceTests.Features.NUnit_Tests
{
    class TestFireFoxDriverClass
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
        public void TestFireFoxDriver()
        {

            //***************************************************************************************
            // I'm using the Firefox driver that copies the "geckodriver(.exe)" 
            //to the target bin folder from the package folder during the build process.
            //Now use can use the default FireFox Driver default constructor
            //IWebDriver browser = new FirefoxDriver();
            //No need to add code to specify the web driver location
            //For more details see Issue #5 - Default Firefox Driver Displays Run Time Exception
            //***************************************************************************************

            //Headless Browser Testing
            var options = new FirefoxOptions();
            options.AddArguments("--headless");     //Note the --headless syntax
            //IWebDriver browser = new FirefoxDriver(options);

            //Standard web driver instance
            // Implement FireFox using geckdriver file
            IWebDriver browser = new FirefoxDriver();

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

            //******************************************************************************
            //For what ever reason the document.readyState = "complete"
            //and yet the next statement element = browser.FindElement(By.Id("main"));
            //throws an exception, because the Id = main is not displayed
            //Lets wait using page element is displayed using driver.FindElement
            //******************************************************************************

            //Example wait for page element is displayed using driver.FindElement
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.FindElement(By.Id("main")));

            //Test if main page displayed
            element = browser.FindElement(By.Id("main"));

            //check the page title
            var pageTitle = browser.Title;

            //Put a wait time for the page to load before reading the #Images       
            //Read #images on the page
            Thread.Sleep(5 * 1000);
            var listImages = browser.FindElements(By.TagName("img"));

            //call quit, instead of close
            browser.Quit();

            //Print #Images to Debug output window
            Debug.Write("FireFox #Images = ");
            Debug.WriteLine(listImages.Count);
        }

        [TearDown]
        public void EndTest()
        {

        }

    }



}

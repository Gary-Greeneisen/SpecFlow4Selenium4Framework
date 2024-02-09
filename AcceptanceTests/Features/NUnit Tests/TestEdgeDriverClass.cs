using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Features.NUnit_Tests
{
    class TestEdgeDriverClass
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
        public void TestEdgeDriver()
        {

            //***************************************************************************************
            // I'm using the Edge driver that copies the "msedgedriver.exe" 
            //to the target bin folder from the package folder during the build process.
            //Now use can use the default Edge Driver default constructor
            //IWebDriver browser = new EdgeDriver();
            //No need to add code to specify the web driver location
            //For more details see Issue #5 - Default Firefox Driver Displays Run Time Exception
            //***************************************************************************************

            //Headless Browser Testing
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments("headless");
            //IWebDriver browser = new EdgeDriver(edgeOptions);

            //Standard web driver instance
            IWebDriver browser = new EdgeDriver();

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

            //Read #images on the page
            var listImages = browser.FindElements(By.TagName("img"));

            //call quit, instead of close
            browser.Quit();

            //Print #Images to Debug output window
            Debug.Write("Edge #Images = ");
            Debug.WriteLine(listImages.Count);
        }

        [TearDown]
        public void EndTest()
        {

        }

    }
}

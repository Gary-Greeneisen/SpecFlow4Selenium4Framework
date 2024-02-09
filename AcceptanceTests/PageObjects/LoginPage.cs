using AcceptanceTests.Common.Application;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.PageObjects
{
    public partial class LoginPage
    {
        //create a class var
        public IWebDriver browser = null;
        public string browserType = string.Empty;
        public bool browserClosed = false;
        public System.Drawing.Size DefaultBrowserSize;

        //Variables to set browser Height, Width
        private int browserHeight;
        private int browserHWidth;

        //define error conditions
        string errorString;
        bool isError = false;

        //************************************************************************************************
        //Implicit, Explicit, & Fluent Wait in Selenium WebDriver
        //Implicit Wait
        //An implicit wait is to tell WebDriver to poll the DOM for a certain amount of time when trying to
        //find an element or elements if they are not immediately available.This can be useful when certain
        //elements on the webpage are not available immediately and need some time to load.
        //The default setting is 0, meaning disabled. Once set, the implicit wait is set for the life of the
        //session
        //
        //C# Syntax:
        //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        //
        //Explicit Wait
        //The explicit wait is used to tell the Web Driver to wait for certain conditions (Expected Conditions)
        //or the maximum time exceeded before throwing an "ElementNotVisibleException" exception.
        //The explicit wait is an intelligent kind of wait, but it can be applied only for specified elements.
        //Explicit wait gives better options than that of an implicit wait as it will wait for dynamically
        //loaded Ajax elements.
        //The condition is called with a certain frequency until the timeout of the wait is elapsed.
        //This means that for as long as the condition returns a false value, it will keep trying and waiting
        //C# Syntax:
        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //wait.Until(drv => drv.FindElement(By.Id("main")));

        //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
        //return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        //
        //Fluent Wait
        //The fluent wait is used to tell the web driver to wait for a condition, as well as the frequencywith
        //which we want to check the condition before throwing an "ElementNotVisibleException" exception.
        //Frequency: Setting up a repeat cycle with the time frame to verify/check the condition at the regular
        //interval of time
        //C# Syntax:
        //This is a C# example from https://gist.github.com/up1/d925783ea8e5f706f3bb58c3ce1ef7eb
        // Waiting 30 seconds for an element to be present on the page, checking
        // for its presence once every 5 seconds.
        //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(30);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //************************************************************************************************

        public IWebDriver LaunchBrowser(string webPage, string browserType)
        {

            switch(browserType.ToUpper())
            {

                case "CHROME":

                    //Headless Browser Testing
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");
                    //browser = new ChromeDriver(chromeOptions);

                    //Standard web driver instance
                    browser = new ChromeDriver();

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 945   Heigth = 1026
                    //set browser Height, Width
                    browserHeight = 1026;
                    browserHWidth = 1500; 
                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 945   Heigth = 1026
                    //set browser Height, Width
                    browserHeight = 1026;
                    browserHWidth = 1500;

                    break;

                case "FIREFOX":

                    //Headless Browser Testing
                    var options = new FirefoxOptions();
                    options.AddArguments("--headless");     //Note the --headless syntax
                    //browser = new FirefoxDriver(options);

                    //Standard web driver instance
                    // Implement FireFox using geckdriver file
                    browser = new FirefoxDriver();

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 1440   Heigth = 780
                    //set browser Height, Width
                    browserHeight = 980;
                    browserHWidth = 1440;

                    break;

                case "EDGE":

                    //Headless Browser Testing
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments("headless");
                    //browser = new EdgeDriver(edgeOptions);

                    //Standard web driver instance
                    browser = new EdgeDriver();

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 1236   Heigth = 856
                    //set browser Height, Width
                    // browserHeight = 865;
                    //browserHWidth = 1236;
          
                    break;

                 case "IE":
                    isError = true;
                    errorString = "IE Driver not Implemented";

                    break;

                default:
                    //Headless Browser Testing
                    var chromeOptionss = new ChromeOptions();
                    chromeOptionss.AddArguments("headless");
                    //browser = new ChromeDriver(chromeOptions);

                    //Standard web driver instance
                    browser = new ChromeDriver();

                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 945   Heigth = 1026
                    //set browser Height, Width
                    browserHeight = 1026;
                    browserHWidth = 1500;
                    DefaultBrowserSize = browser.Manage().Window.Size;
                    //DefaultBrowserSize(Width, Height)
                    //Width = 945   Heigth = 1026
                    //set browser Height, Width
                    browserHeight = 1026;
                    browserHWidth = 1500;
                    break;
            }
            /**********************************/
            // set browser to use ImplicitWait 
            /**********************************/
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(RunTimeVars.PAGELOADWAIT);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);

            //Set Default Browser Size
            //DefaultBrowserSize(Width, Height)
            //Width = 945   Heigth = 1026
            browser.Manage().Window.Size = new System.Drawing.Size(browserHWidth, browserHeight);
            //browser.Manage().Window.FullScreen();
            DefaultBrowserSize = browser.Manage().Window.Size;


            if (isError)
            {
                throw new Exception(errorString);
            }
            else
            {
                browser.Navigate().GoToUrl(webPage);
                return browser;
            }

  
        }

    }//End public partial class LoginPage

} //End namespace AcceptanceTests.PageObjects

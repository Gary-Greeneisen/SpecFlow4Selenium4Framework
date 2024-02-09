using AcceptanceTests.Common.Application;
using AcceptanceTests.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Common.Library
{
    public static class Library
    {
        public static string GetProjectDir()
        {
            //***************************************************************************************
            // .Net 4.6 and NUnit 3.11.0 changed the way the project path is returned
            // projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // You now have to use 
            //TestContext.CurrentContext.TestDirectory;
            //***************************************************************************************
            //Get the current runtime target dir
            //this returns the same path as TestContext.CurrentContext.TestDirectory
            //var driverDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var runDir = TestContext.CurrentContext.TestDirectory.ToString();
            var dir1 = Directory.GetParent(runDir).FullName.ToString();
            var dir2 = Directory.GetParent(dir1).FullName.ToString();
            var projectDir = Directory.GetParent(dir2).FullName.ToString();

            return projectDir;
        }

        /// <summary>
        /// Get Data File based on App.config environment
        /// </summary>
        /// <returns></returns>
        public static string GetDataFileDir()
        {

            //First get the current environment from the Json Global Environment Vars Section
            var environment = JsonAppSettings.GetGlobalSectionConfig("Environment");

            //Get project/file dir
            var projectDir = GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\" + environment + "\\";

            return dataFileDir;

        }

        public static void SetBrowserSize(IWebDriver browser, System.Drawing.Size browserSize)
        {

            //Reset browser back to orginal size
            //browser.Manage().Window.Size = New System.Drawing.Size(1024, 768);
            browser.Manage().Window.Size = browserSize;
        }

        /// <summary>
        /// Return current browser size
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static System.Drawing.Size GetCurrentBrowserSize(IWebDriver browser)
        {
            //Set current browser size
            return browser.Manage().Window.Size;

        }

        /// <summary>
        /// Is Page Element Displayed with a Timeout Parameter
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="retrys"></param>
        /// <returns></returns>
        public static bool IsPageElementDisplayed(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int retrys)
        {
            var isFound = false;
            var controlWaitTime = retrys;
            IWebElement element = null;

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }

                    if (element.Displayed)
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                isFound = false;
            }

            return isFound;

        }

        /// <summary>
        /// Wait until the page element is displayed
        /// Resutn the selected page element
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="retrys"></param>
        /// <returns>IWebElement element 
        ///       element = Displayed and Enabled
        /// </returns>
        public static IWebElement GetPageElement(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int retrys)
        {
            var controlWaitTime = retrys;
            IWebElement element = null;

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }


                    if (element.Displayed && element.Enabled)
                    {
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("Web Page Search-" + element + " Was Not Found");
            }

            return element;

        }

        // ImplicitWait Wait and Find element
        /// <summary>
        /// Wait until the page element is displayed
        /// Return the selected page element
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="searchType"></param>
        /// <param name="searchString"></param>
        /// <param name="retrys"></param>
        /// <returns>IWebElement element 
        ///       element = Displayed and Enabled
        /// </returns>
        public static IWebElement ImplicitWaitGetPageElement(IWebDriver browser,
                                                    RunTimeVars.ELEMENTSEARCH searchType,
                                                    string searchString,
                                                    int seconds,
                                                    Boolean clickElement = false)
        {
            IWebElement element = null;

            //Divide the passed in time(seconds/2) to compensate for the 1-sec 
            // System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
            var controlWaitTime = seconds / 2;
            if (controlWaitTime == 0) controlWaitTime = 1;

            //Date - 12/21/18 Can't read current browser.ImplicitWait time, get not implemented
            //set the browser Implict wait time = 1-sec
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            while (controlWaitTime > 0)
            {
                try
                {
                    if (searchType == RunTimeVars.ELEMENTSEARCH.ClassName)
                    {
                        element = browser.FindElement(By.ClassName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.CssSelector)
                    {
                        element = browser.FindElement(By.CssSelector(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.ID)
                    {
                        element = browser.FindElement(By.Id(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.LinkText)
                    {
                        element = browser.FindElement(By.LinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.PartialLinkText)
                    {
                        element = browser.FindElement(By.PartialLinkText(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.NAME)
                    {
                        element = browser.FindElement(By.Name(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.TagName)
                    {
                        element = browser.FindElement(By.TagName(searchString));
                    }

                    if (searchType == RunTimeVars.ELEMENTSEARCH.XPATH)
                    {
                        element = browser.FindElement(By.XPath(searchString));
                    }

                    //include this in the try section
                    //if (the element not Displayed And not Enabled)
                    // then return element = null
                    if (element.Displayed && element.Enabled)
                    {
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //restore the browser Implict wait time = initial wait time
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);

            // Check the passed in optional parameter Boolean clickElement
            // passed in Boolean clickElement = true
            if (element == null)
            {
                throw new Exception("Web Page Search-" + "('" + searchString + "')" + " Was Not Found");
            }
            else if (clickElement)
            {
                element.Click();
            }

            return element;
        }

        /// <summary>
        /// Wait until document.readyState = complete
        /// </summary>
        /// <param name="retrys"></param>
        public static void WaitForPageLoad(IWebDriver browser,int retrys)
        {

            var controlWaitTime = retrys;
            //IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;

            while (controlWaitTime > 0)
            {
                try
                {
                    var documentState = ((IJavaScriptExecutor)browser).ExecuteScript("return document.readyState").ToString();

                    if (documentState.Equals("complete"))
                    {
                        break;
                    }
                    else
                    {
                        //if(the current page not done loading
                        System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                        controlWaitTime--;
                    }
                }
                catch
                {
                    //if (the cuurrent page status is not avaiable yet
                    System.Threading.Thread.Sleep(1 * 1000); //Wait 1-sec
                    controlWaitTime--;
                }

            }

            //Check if(Page displayed <= controlWaitTime)
            if (controlWaitTime <= 0)
            {
                throw new Exception("...Page Failed To Load in (" + retrys + ") retrys...");
            }

        }

        public static void JavaScriptNewWindow(IWebDriver browser)
        {
            var url = "https://www.google.com";

            //IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;

            //To open the window:

            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("window.open()");

            //Then to switch windows, use the window handles:

            List<string> handles = browser.WindowHandles.ToList<string>();
            browser.SwitchTo().Window(handles.Last());


            browser.Navigate().GoToUrl(url);

        }

        public static void ScollPage(IWebDriver browser, IWebElement element)
        {
            //This will scroll the page till the element is found	
            IJavaScriptExecutor jscript = (IJavaScriptExecutor)browser;
            jscript.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public static void JavaScriptClickElement(IWebDriver browser, IWebElement element)
        {
            //Short Hand notation
            //((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].click();", element);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)browser;
            jse.ExecuteScript("arguments[0].click()", element);
        }

        public static void SetWebDiverWaitTime(IWebDriver browser,int seconds)
        {
            //Implicit waits
            //IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void ReSetWebDiverWaitTime(IWebDriver browser)
        {
            //Implicit waits
            //IWebDriver browser = TestRunnerInterface.Map.loginPage.browser;
            //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(RunTimeVars.WEBDRIVERWAIT);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void WaitForElementByID(IWebDriver browser, string IDName, int seconds)
        {
            //Implicit waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id(IDName)));
        }

        public static void WaitForElementByXpath(IWebDriver browser, string xpath, int seconds)
        {
            //Implicit waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.XPath(xpath)));
        }

        public static void WaitForElementByName(IWebDriver browser, string name, int seconds)
        {
            //Implicit waits
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Name(name)));
        }

        public static void HighLightElement(IWebDriver browser, IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)browser;
            //var element = //element to be found
            //string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 4px; border-style: solid; border-color: blue"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }


    }


}

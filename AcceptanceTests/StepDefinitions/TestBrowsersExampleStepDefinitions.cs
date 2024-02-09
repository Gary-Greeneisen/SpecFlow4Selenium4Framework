using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class TestBrowsersExampleStepDefinitions
    {
        //create class vars
        public IWebDriver browser;
        public string browserType;

        [Given(@"I Open a ""([^""]*)""")]
        public void GivenIOpenA(string browserx)
        {
            browserType = browserx.ToUpper();

            switch (browserType)
            {
                case "CHROME":
                    //Standard web driver instance
                    browser = new ChromeDriver();
                    break;

                case "FIREFOX":
                    //Standard web driver instance
                    // Implement FireFox using geckdriver file
                    browser = new FirefoxDriver();
                    break;

                case "EDGE":
                    //Standard web driver instance
                    browser = new EdgeDriver();
                    break;

                default:
                    //Standard web driver instance
                    browser = new ChromeDriver();
                    break;

            }

            //Set implicit wait
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [Given(@"I Goto to ""([^""]*)""")]
        public void GivenIGotoTo(string page)
        {
            //Navigate to web page
            var url = "http://" + page;
            browser.Navigate().GoToUrl(url);
        }

        [When(@"I search for ""([^""]*)""")]
        public void WhenISearchFor(string searchItem)
        {
            //Find the Search text box UI Element
            IWebElement element = browser.FindElement(By.Name("q"));

            //Search
            element.SendKeys(searchItem);

            // this sends an Enter to the element
            element.SendKeys(Keys.Enter);

            //Wait for page to load
            //System.Threading.Thread.Sleep(5 * 1000); //Wait 5-sec
            new WebDriverWait(browser, TimeSpan.FromSeconds(5)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            //Example wait for page element is displayed using driver.FindElement
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.FindElement(By.Id("main")));

            //Test if main page displayed
            element = browser.FindElement(By.Id("main"));

        }

        [Then(@"I can count the number of page images")]
        public void ThenICanCountTheNumberOfPageImages()
        {
            //Read #images on the page
            var listImages = browser.FindElements(By.TagName("img"));

            //Close the browser, then check the results
            //browser.Close() did not close the browser
            //call quit, instead of close
            browser.Quit();

            //Print #Images to Debug output window
            Debug.Write("#Images = ");
            Debug.WriteLine(listImages.Count);

        }
    }
}

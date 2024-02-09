using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Config;
// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
//
using AcceptanceTests.PageObjects;

namespace AcceptanceTests.Common.Application
{
    public class TestRunnerClass
    {
        //Step-1
        //Define a unique UIMap/Page Object var = xxx that references each unique UI Map class
        //
        //Step-2 Initialize any vars
        //
        //Step-3
        //Create a reference to the UIMap(s)/Page Object(s)
        //
        //Step-4 - Use the UI Map/Page Object reference(s) to call the methods
        //launch the browser and login

        //Step-1
        //Define a unique UIMap/Page Object var = xxx that references each unique UI Map class

        //************************
        // Test Context Section
        //************************   



        //************************
        // Page Objects Section
        //************************   
        public LoginPage loginPage = null;
        public TestPage1 testPage1 = null;
        public TestPage2 testPage2 = null;




        public TestRunnerClass()
        {
            //Step-2 Initialize the Run-Time vars from the Config File
            //RunTimeVars.ReadAppConfig();


            //Step-3 Create a reference to the UIMap(s)/Page Object(s)
   
            //**************************
            // Test Context Section
            //************************   


            //************************
            // Page Objects Section
            //************************
            loginPage = new LoginPage();
            testPage1 = new TestPage1();
            testPage2 = new TestPage2();
     



        } //end Constructor

        //************************************************************************
        // Define Test Methods
        //************************************************************************

        //Step-4 - Use the UI Map/Page Object reference(s) to call the methods
        //populate any class member vars
        //launch the browser and login


    } //end public class TestRunnerClass

} //end namespace AcceptanceTests.Common.Application

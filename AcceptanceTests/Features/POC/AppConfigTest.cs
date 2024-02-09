using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Config;

namespace AcceptanceTests.Features.POC
{
    class AppConfigTest
    {
        [Test]
        //*******************************************************************************************
        //Using the legacy.Net framework Configuration Manager App.config in .Net Code, the run-time
        //Exception is displayed
        //.net core app.config Object reference not set to an instance of an object
        //System.NullReferenceException
        //HResult= 0x80004003
        //Message= Object reference not set to an instance of an object.
        //Source= AcceptanceTests
        //StackTrace:
        //at AcceptanceTests.Config.AppConfig.GetAppSectionValue(String key)
        //
        //Resolution 11/3/21 Convert to appSettings.json file
        //*******************************************************************************************

        public void TestAppConfig()
        {
            //*******************************************************
            // This calls the public static class AppConfig Methods
            //*******************************************************

            //Read a value from the Custom ConfigSections Section
            var test1 = AppConfig.GetGlobalSectionValue("Test");


            //Read a value from the appSettings Section
            var test2 = AppConfig.GetSpecificSectionValue("Test");
            var test3 = AppConfig.GetSpecificSectionValue("Environment");
            var test4 = AppConfig.GetSpecificSectionValue("BrowserType");
        }



    }
}

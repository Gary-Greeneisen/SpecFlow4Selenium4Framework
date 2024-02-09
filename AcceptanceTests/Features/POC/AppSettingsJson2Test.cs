using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Config;

namespace AcceptanceTests.Features.POC
{
    class AppSettingsJson2Test
    {
        /// <summary>
        /// Read Json configuration file located at project root dir
        /// There are (2)-sections Global Section and Specific Section
        /// </summary>
        [Test]
        //**************************************************************************************
        //This test uses an external class file to encapulate the IConfiguration Manager methods
        //to read the Json file contents
        //**************************************************************************************
        public void TestAppSettingsJson2()
        {
            //Read single values from Global Environment Vars Section
            //using public static class AppSettings
            var test = JsonAppSettings.GetGlobalSectionConfig("Test");
            var url = JsonAppSettings.GetGlobalSectionConfig ("URL");
            var browserType = JsonAppSettings.GetGlobalSectionConfig("BrowserType");
            var environment = JsonAppSettings.GetGlobalSectionConfig("Environment");

            //Read single values from the Specific Local/Dev/QA/Prod Environment Config Section
            //using public static class AppSettings
            var test2 = JsonAppSettings.GetSpecificSectionConfig("Test");
            var targetURL = JsonAppSettings.GetSpecificSectionConfig("TargetURL");
            var dbconnectionString = JsonAppSettings.GetSpecificSectionConfig("dbconnectionString");

        }

    }

}

using AventStack.ExtentReports.Configuration;
using Microsoft.Extensions.Configuration;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Config
{
    public static class AppConfig
    {

        //**************************************************************
        //*** Date - 2/8/2024 After repeated attempts I Give up ******
        // Just use AppSettings.json
        //**************************************************************
        ///
        /// <summary>
        /// Reads from Global Custom Config Section
        /// Get the value corresponding to the key from App.config Global setting
        /// 
        /// </summary>
        /// <param name="Global Section key">The key name</param>
        /// <returns></returns>
        public static string GetGlobalSectionValue(string key)
        {
            /************ comment out *********************************
            //Test the System.Configuration.ConfigurationManager
            var testconfig = System.Configuration.ConfigurationManager.AppSettings[key].ToString();

            //return ConfigurationSettings.AppSettings[key];
            //return System.Configuration.ConfigurationManager.AppSettings[key].ToString();

            ************ comment out *****************************/

            /************comment out ***********************************
            AppSettingsReader reader = new AppSettingsReader();
            string test = (string)reader.GetValue(key, typeof(string));
            ************comment out ***********************************/

            /************comment out ***********************************
            //Specify the location + filename of the app.config file
            //App.config copied to runtime dir
            var filePath = Directory.GetCurrentDirectory();
            filePath += @"\App.config";

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = filePath;

            //ConfigurationUserLevel.None - Gets the Configuration file that applies to all users.
            var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //var value = config.AppSettings[key].ToString();
            var test1 = config.GetSectionGroup("Test").ToString();
            var test2 = config.GetSection("Test").ToString();   



            var value = "test";

            return value;
            ************comment out ***********************************/

            /************comment out ***********************************
            //Specify the location + filename of the app.config file
            //App.config copied to runtime dir
            var filePath = Directory.GetCurrentDirectory();
            filePath += @"\App.config";

            //Set target to project dir
            //var filePath = @"C:\test\SpecFlow4Selenium4Framework\AcceptanceTests";

            // Create new instance of the ConfigurationFileMap class.
            var fileMap = new ConfigurationFileMap();
            //Set the App.config file target location
            fileMap.MachineConfigFilename = filePath;

            // Read the application configuration file to the machine configuration file.
            var config = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);

            //ConfigurationUserLevel.None - Gets the Configuration file that applies to all users.
            //var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //var value = config.AppSettings[key].ToString();
            var value = "test";

            return value;

            ************comment out ***********************************/

            /************comment out ***********************************

            //Specify the location + filename of the App.config file
            //App.config copied to runtime dir
            var filePath = Directory.GetCurrentDirectory();
            filePath += @"\App.config";

            // Get the current application configuration file.
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Map the new configuration file.
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = filePath;

            // Get the mapped configuration file
            config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            var appSettings = config.AppSettings;
            //var test1 = config.GetSectionGroup("Test");
            //var test2 = config.GetSection("Test");

             /************comment out ***********************************/



            string value = string.Empty;

            return value;  


        }


        /// <summary>
        /// Reads Specific Environment Configuration Section
        /// Get the value corresponding to the key from App.config Specific setting
        /// 
        /// </summary>
        /// <param name=" Specific Environment key">The key name</param>
        /// <returns></returns>
        public static string GetSpecificSectionValue(string key)
        {

            //First get the "environment" var from the Global appSettings section
            var environment = System.Configuration.ConfigurationManager.AppSettings["Environment"].ToString();

            //Next get the specific section value based on the Global "Environment"
            var sections = System.Configuration.ConfigurationManager.GetSection(environment) as NameValueCollection;
            return sections[key].ToString();


        }

} //end  public static class AppConfig



}  //end namespace AcceptanceTests.Config

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AcceptanceTests.Config
{
    //**************************************************************************************
    //This is an external class file to encapulate the IConfiguration Manager methods
    //to read the Json file contents
    //**************************************************************************************
    public static class JsonAppSettings
    {

        private static IConfiguration config = null;

        /// <summary>
        /// Create a connection to the Json IConfiguration Manager
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                if (config == null)
                {
                    //sets up the Configuration API with JSON
                    //Json file = Appsettings.json copied to runtime dir
                    var filePath = Directory.GetCurrentDirectory();

                    var configurationBuilder = new ConfigurationBuilder()
                        //.SetBasePath(Directory.GetCurrentDirectory.Path)
                        .SetBasePath(filePath)  //Set Json file location
                        .AddJsonFile("Appsettings.json", optional: true, reloadOnChange: true);
                        
                    //Build the configuration, Set Class var
                    config = configurationBuilder.Build();
                }
                return config;
            }

        }


        /// <summary>
        /// Get single Key value from the Json Global Environment Vars settings
        /// There are (2)-sections Global Section and Specific Section
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns></returns>
        public static string GetGlobalSectionConfig(string key)
        {
            //Return a single value element Note the .Value propertery
            var result = JsonAppSettings.Configuration.GetSection(key).Value;

            return result;
 
        }

        /// <summary>
        /// Get the Specific Configuration Section Vars value corresponding 
        /// to the key from 
        /// Local/Dev/QA/Prod Environment Config Section
        /// </summary>
        /// <param name="key">The Specific Environment key name</param>
        /// <returns></returns>
        public static string GetSpecificSectionConfig(string key)
        {

            //First get the current environment from the Environment Vars Section
            var environment = JsonAppSettings.Configuration.GetSection("Environment").Value;

            //Next get the Local/Dev/QA/Prod Environment Config Section value based on the "Environment"
            //var value = environment[key];

            //**********************************************************************
            //With .Net 7.0 the complier checks if a variable copuld be null
            // and displays a warning message
            //To surpress the warning messages, add a check for null condition
            //**********************************************************************
                var value = config.GetSection(environment)[key];
                return value;

        }

    }

}

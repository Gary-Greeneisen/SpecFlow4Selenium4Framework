using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AcceptanceTests.Features.POC
{
    class AppSettingsJsonTest
    {

        [SetUp]
        public void Initialize()
        {
            
        }

        [Test]
            //**************************************************************************************
            //This test uses the IConfiguration Manager methods to read the Json file contents
            //It does not use an external class file to encapulate the operation
            //**************************************************************************************
        public void TestAppSettingsJson()
        {
            //*****************************************************************************
            //Example of using GetSection Method GetSection("Section Name")["Value Name"]
            //to return a Section.Value
            //*****************************************************************************
            //*****************************************************************************
            //                  *** Orginal code ***
            //       IConfiguration config = new ConfigurationBuilder()      //Have to use this syntax
            //               .AddJsonFile("AppSettings.json").Build();       //Have to use this syntax
            //*****************************************************************************

            //sets up the Configuration API with JSON
            //Json file = Appsettings.json located at the project root dir
            var filePath =  Directory.GetCurrentDirectory();

            var configurationBuilder = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory.Path)
                .SetBasePath(filePath)  //Set Json file location
                .AddJsonFile("Appsettings.json", optional: true, reloadOnChange: true);

            //Build the configuration
            IConfiguration config = configurationBuilder.Build();

            //Return a single value element from Global Environment Vars Section
            //Note the .Value propertery
            var URL = config.GetSection("URL").Value;

            //Return Json format values
            var username = config.GetSection("credentials")["username"];
            var password = config.GetSection("credentials")["password"];

            //********************************************************************************************
            //Example of using GetSection Method to return the entire Section GetSection("Section Name")
            //Then return the specific ["Value Name"]
            //********************************************************************************************
            var credentials = config.GetSection("credentials");
            var username2 = credentials["username"];
            var password2 = credentials["password"];

            //*****************************************************************************
            //There's another method on the `IConfiguration` service, `.GetValue<T>()`,
            //that allows us to convert our configuration value to another type:
            //*****************************************************************************
            var times = config.GetSection("greetingTimes");

            //Test reading the values
            var morning = times["morning"];
            var afternoon = times["afternoon"];
            var night = times["night"];

            TimeSpan morningTime = times.GetValue<TimeSpan>("morning");
            TimeSpan afternoonTime = times.GetValue<TimeSpan>("afternoon");
            TimeSpan nightTime = times.GetValue<TimeSpan>("night");
        }

        [TearDown]
        public void EndTest()
        {
            
        }


    }
}

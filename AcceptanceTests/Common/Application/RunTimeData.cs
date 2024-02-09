using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AcceptanceTests.Config;

namespace AcceptanceTests.Common.Application
{
    public static class RunTimeData
    {

        public static string xmlDir
        {
            get
            {
                var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\";
                return (dataFileDir + "RunTimeData.xml");
            }
        }

        //**********************************************
        // RunTimeData.xml appSettings Section Methods *
        //**********************************************

        /// <summary>
        /// Return RunTimeData appSettings sections
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetKeyAppSettings(string key)
        {

            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            xmlDoc.Load(xmlDir);

            //var node = "//appSettings/add[@key='Test1']";
            var node = "//appSettings/add[@key='" + key + "']";
            var value = xmlDoc.SelectSingleNode(node).Attributes["value"].Value;

            return value;

        }

        /// <summary>
        /// Update RunTimeData appSettings sections
        /// Delete an existing key
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteKeyAppSettings(string key)
        {


            //Update custom configuration sections - Add a new key
            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";
   
            //Replace with get xmlDir Method()
            xmlDoc.Load(xmlDir);

            //XmlNode node = xmlDoc.SelectSingleNode("//Dev/add[@key='Key1']");  
            var nodeString = "//appSettings/add[@key='" + key + "']";

            XmlNode node = xmlDoc.SelectSingleNode(nodeString);
            node.ParentNode.RemoveChild(node);

            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            xmlDoc.Save(xmlDir);

            ConfigurationManager.RefreshSection("//appSettings");

        }


        /// <summary>
        /// Update RunTimeData appSettings sections
        /// Add a new key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddKeyAppSettings(string key, string value)
        {

            //Update custom configuration sections - Add a new key
            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            //Replace with get xmlDir Method()
            xmlDoc.Load(xmlDir);

            // create new node <add key="New Key" value="New Key Value1" />
            var node = xmlDoc.CreateElement("add");
            //node.SetAttribute("key", "New Key");
            //node.SetAttribute("value", "New Key Value1");

            node.SetAttribute("key", key);
            node.SetAttribute("value", value);

            xmlDoc.SelectSingleNode("//appSettings").AppendChild(node);


            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            xmlDoc.Save(xmlDir);

            ConfigurationManager.RefreshSection("//appSettings");

        }

        /// <summary>
        /// Update RunTimeData appSettings sections
        /// Edit an existing key's value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void UpdateKeyAppSettings(string key, string value)
        {

            // Update custom configuration sections - Edit an existing key's value
            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //this dir accesses the \bin runtime location 
            //not the project app.config file
            //xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            //Replace with get xmlDir Method()
            xmlDoc.Load(xmlDir);

            //Update the key value
            //xmlDoc.SelectSingleNode("//Local/add[@key='Test']").Attributes["value"].Value = "New Value6";
            var node = "//appSettings/add[@key='" + key + "']";
            xmlDoc.SelectSingleNode(node).Attributes["value"].Value = value;

            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            xmlDoc.Save(xmlDir);

            ConfigurationManager.RefreshSection("//appSettings");


        }

        //********************************************************
        // RunTimeData.xml custom configuration sections Methods *
        //********************************************************

        /// <summary>
        /// Return RunTimeData custom configuration sections
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetKeyConfigSectionData(string key)
        {

            //First get the current "Environment" from the appSettings Global section
            var environment = AppConfig.GetGlobalSectionValue("Environment");

            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            xmlDoc.Load(xmlDir);

            //var node = "//QA/add[@key='Test1']";
            var node = "//" + environment + "/add[@key='" + key + "']";
            var value = xmlDoc.SelectSingleNode(node).Attributes["value"].Value;

            return value;

        }

        /// <summary>
        /// Update RunTimeData custom configuration sections
        /// Delete an existing key
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteKeyConfigSectionData(string key)
        {

            //First get the current "Environment" from the appSettings Global section
            var environment = AppConfig.GetGlobalSectionValue("Environment");

            //Update custom configuration sections - Add a new key
            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            //Replace with get xmlDir Method()
            xmlDoc.Load(xmlDir);

            //XmlNode node = xmlDoc.SelectSingleNode("//Dev/add[@key='Key1']");  
            var nodeString = "//" + environment + "/add[@key='" + key + "']";

            XmlNode node = xmlDoc.SelectSingleNode(nodeString);
            node.ParentNode.RemoveChild(node);

            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            xmlDoc.Save(xmlDir);

            ConfigurationManager.RefreshSection("//" + environment);

        }




        /// <summary>
        /// Update RunTimeData custom configuration sections
        /// Add a new key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddKeyConfigSectionData(string key, string value)
        {
            //First get the current "Environment" from the appSettings Global section
            var environment = AppConfig.GetGlobalSectionValue("Environment");

            //Update custom configuration sections - Add a new key
            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            //Replace with get xmlDir Method()
            xmlDoc.Load(xmlDir);

            // create new node <add key="New Key" value="New Key Value1" />
            var node = xmlDoc.CreateElement("add");
            //node.SetAttribute("key", "New Key");
            //node.SetAttribute("value", "New Key Value1");

            node.SetAttribute("key", key);
            node.SetAttribute("value", value);

            xmlDoc.SelectSingleNode("//" + environment).AppendChild(node);


            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            xmlDoc.Save(xmlDir);

            ConfigurationManager.RefreshSection("//" + environment);

        }

        /// <summary>
        /// Update RunTimeData custom configuration sections
        /// Edit an existing key's value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void UpdateKeyConfigSectionData(string key, string value)
        {
            //First get the current "Environment" from the appSettings Global section
            var environment = AppConfig.GetGlobalSectionValue("Environment");

            // Update custom configuration sections - Edit an existing key's value
            ConfigXmlDocument xmlDoc = new ConfigXmlDocument();

            //this dir accesses the \bin runtime location 
            //not the project app.config file
            //xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            //var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var fileDir = projectDir + @"\AcceptanceTests\DataFiles\";
            //var xmlDir = fileDir + "RunTimeData.xml";

            //Replace with get xmlDir Method()
            xmlDoc.Load(xmlDir);

            //Update the key value
            //xmlDoc.SelectSingleNode("//Local/add[@key='Test']").Attributes["value"].Value = "New Value6";
            var node = "//" + environment + "/add[@key='" + key + "']";
            xmlDoc.SelectSingleNode(node).Attributes["value"].Value = value;

            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            xmlDoc.Save(xmlDir);

            ConfigurationManager.RefreshSection("//" + environment);


        }




    } //end public static class RunTimeData

} //end namespace AcceptanceTests.Common.Application

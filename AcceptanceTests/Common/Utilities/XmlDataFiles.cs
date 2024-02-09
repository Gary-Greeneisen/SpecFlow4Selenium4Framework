using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Config;


namespace AcceptanceTests.Common.Utilities
{
    public partial class XmlDataFiles
    {

        public XmlNode rootNode(string filename, string startingNode)
        {

            //Get project/file dir
            var dataDir =  Library.Library.GetDataFileDir();
            var fileDir = dataDir + filename;

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);

            if (doc.DocumentElement != null)
            {
                XmlNode root = doc.DocumentElement.SelectSingleNode(startingNode);
                return root;
            }
            else
            {
                throw new Exception("XmlDataFiles.cs public XmlNode rootNode() = Null");
            }
    

        }

        public void ExampleTestMethod1()
        {

            //Get project/file dir
            var projectDir =  Library.Library.GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\Example\";
            var fileDir = dataFileDir + "XMLTestFile1.xml";

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);

            //Find the root tag
            //The XmlNodeList reads all the nodes = "/Student"
            //This example has (1)-root node = "/Student"
            //
            //XmlNodeList allNodes = doc.DocumentElement.SelectNodes("/Student");

            if (doc.DocumentElement != null)
            {
                XmlNode root = doc.DocumentElement.SelectSingleNode("/Student");

                //Read the file data into program variables
                var firstname = root.SelectSingleNode("firstname").InnerText.Trim();
                var lastname = root.SelectSingleNode("lastname").InnerText.Trim();
                var age = Int32.Parse(root.SelectSingleNode("age").InnerText.Trim());

                //Read (1)-or more Services
                var services = root.SelectSingleNode("services").InnerText.Trim();
                services = services.Replace("\r\n", " ").Replace(" ", "");
                List<String> servicesList = services.Split(',').ToList();
            }
            else
            {
                throw new Exception("XmlDataFiles.cs public void ExampleTestMethod1() = null");
            }


        }

        public void ExampleTestMethod2()
        {
            //First get the current environment from the Json Global Environment Vars Section
            var environment = JsonAppSettings.GetGlobalSectionConfig("Environment");

            //Get project/file dir
            var projectDir = Library.Library.GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\" + environment + "\\";
            var fileDir = dataFileDir + "XMLTestFile1.xml";

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);

            //Find the root tag
            //The XmlNodeList reads all the nodes = "/Student"
            //This example has (1)-root node = "/Student"
            //
            //XmlNodeList allNodes = doc.DocumentElement.SelectNodes("/Student");
            XmlNode root = doc.DocumentElement.SelectSingleNode("/Student");

            //Read the file data into program variables
            var firstname = root.SelectSingleNode("firstname").InnerText.Trim();
            var lastname = root.SelectSingleNode("lastname").InnerText.Trim();
            var age = Int32.Parse(root.SelectSingleNode("age").InnerText.Trim());

            //Read (1)-or more Services
            var services = root.SelectSingleNode("services").InnerText.Trim();
            services = services.Replace("\r\n", " ").Replace(" ", "");
            List<String> servicesList = services.Split(',').ToList();


        }

        public void ReadRunTimeDataXml()
        {
            //Get project/file dir
            var projectDir = Library.Library.GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\Example\";
            var fileDir = dataFileDir + "RunTimeData.xml";

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);

            //Read the parent
            XmlNode parent = doc.DocumentElement.SelectSingleNode("Dev");

            //Read the file data into program variables
       





        }





    } //end public partial class XmlDataFiles

} //end namespace AcceptanceTests.Common.Utilities

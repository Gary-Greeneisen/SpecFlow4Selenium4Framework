using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Common.Application
{
    public static class RunTimeVars
    {
        //Define project constant(s)
        public const string stringTest = "...This is a test...";

        //Define Application Refresh States
        public enum Refresh
        {
            TestContext, PageRefresh, F5Refresh
        };


        //Define Selenium Element Search Types
        public enum ELEMENTSEARCH
        {
            ClassName, CssSelector, ID, LinkText, PartialLinkText, NAME, TagName, XPATH
        };


        //Define default project variable(s) 
        //can override by AppConfig vars at run-time
        public static string dbconnectionString = null;
        public static string logfilepath = null;
        public static string logfilename = null;
        public static bool logfileIsEnabled = false;
        public static long logfilesizeKbytes = 1;
        public static int WEBDRIVERWAIT = 90 * 1;   //wait 1.5 min
        public static int PAGELOADWAIT = 60 * 1;    //wait 1-min
        public static int TABLOADWAIT = 5 * 1;    //wait 5-sec
        public static int DELETE_CLIENT_WAIT = 30; //wait 30-sec
        public static int REPEAT_TIMES = 10;
        public static int FILEUPLOADDISPLAY = 5;
        public static int FILEUPLOADCOMPLETE = 5;


        public static string environment = "Local";

        //*** URL Strings ***
        // These default Run-Time vars can be overriden by the AppConfig vars
        //Local Host Environment
        public static string TargetURL = "http://localhost/OCEAN/Login.aspx";

        //IT Environment
        //public static string TargetURL = "http://v-oceanit/ocean/login.aspx";

        //UAT Environment
        //public static string TargetURL = "https://oceantest.ohio.gov/OCEAN/Login.aspx?ReturnUrl=%2fOCEAN";

        //Production Environment
        //public static string TargetURL = "https://ocean.ohio.gov/OCEAN/Login.aspx?ReturnUrl=%2fOCEAN";



    }

}

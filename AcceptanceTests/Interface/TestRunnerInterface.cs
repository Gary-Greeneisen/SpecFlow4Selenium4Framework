using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Common.Application;

namespace AcceptanceTests.Interface
{
    public static class TestRunnerInterface
    {
        //Define a global map var
        /// <summary>
        /// Rename this class = TestRunnerInterface
        /// Specflow always has a class = TestRunner
        /// </summary>
        private static TestRunnerClass _testrunner = new TestRunnerClass();

        //Define a get method to return TestRunnerClass
        public static TestRunnerClass Map
        {
            get
            {
                return _testrunner;
            }
        }


    } //end public static class InterfaceUIMap


} //end namespace AcceptanceTests.Interface

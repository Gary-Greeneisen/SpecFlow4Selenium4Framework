using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Features.NUnit_Tests
{
    class TestDrivers
    {
        [SetUp]
        public void Initialize()
        {

        }

        [Test]
        public void TestBrowserDrivers()
        {
            TestChromeDriverClass TestChrome = new TestChromeDriverClass();
            TestChrome.TestChromeDriver();

            TestFireFoxDriverClass TestFireFox = new TestFireFoxDriverClass();
            TestFireFox.TestFireFoxDriver();

            TestEdgeDriverClass TestEdge = new TestEdgeDriverClass();
            TestEdge.TestEdgeDriver();

            TestIEDriverClass TestIE = new TestIEDriverClass();
            TestIE.TestIEDriver();
        }

        [TearDown]
        public void EndTest()
        {

        }

    }
}

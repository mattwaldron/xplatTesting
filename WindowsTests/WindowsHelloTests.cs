using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTest;
using WindowsHello;
using NUnit.Framework;
using CommonFunctions;

namespace WindowsTests
{
    [TestFixture]
    public class WindowsHelloTests : ContainsFromTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            base.OneTimeSetup(WindowsHelloFactory.GetHellos(), 
                CommonTestUtil.LookupHelloType(TestContext.Parameters["helloType"]));
        }
    }
}

using CommonTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidHello;
using CommonFunctions;
using CommonTest;

namespace NUnit.Tests.AndroidHelloTests
{
    [TestFixture]
    public class AndroidHelloTests : ContainsFromTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            base.OneTimeSetup(AndroidHelloFactory.GetHellos(), 
                CommonTestUtil.LookupHelloType(MainActivity.helloType));
        }
    }
}

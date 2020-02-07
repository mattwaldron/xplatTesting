using CommonFunctions;
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CommonTest
{
    public class CommonTestUtil
    {
        public static HelloType LookupHelloType(string helloType)
        {
            switch (helloType)
            {
                case "casual":
                    return HelloType.Casual;
                case "formal":
                    return HelloType.Formal;
            }
            throw new Exception("Invaid helloType argument");
        }
    }
    public class ContainsFromTest
    {
        HelloService _helloService; // this is like DeviceInitServices
        IHello _hello; // This is like an IPG
        public void OneTimeSetup(List<IHello> hellos, HelloType ht)
        {
            _helloService = new HelloService();
            _helloService.Init(hellos);
            _hello = _helloService.ExtractOne(ht);
        }

        [Test]
        public void SayContainsFrom()
        {
            var output = _hello.Say();
            TestContext.WriteLine(output);
            Assert.IsTrue(output.Contains("from"));
        }
    }
}

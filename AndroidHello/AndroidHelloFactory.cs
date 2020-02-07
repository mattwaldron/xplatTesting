using CommonFunctions;
using System.Collections.Generic;

namespace AndroidHello
{
    public class AndroidHelloFactory
    {
        public static List<IHello> GetHellos() => new List<IHello>() {
            new AndroidHey(),
            new AndroidGoodDay()
            };
    }
}
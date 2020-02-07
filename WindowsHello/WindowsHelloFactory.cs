using CommonFunctions;
using System.Collections.Generic;

namespace WindowsHello
{
    public class WindowsHelloFactory
    {
        public static List<IHello> GetHellos() => new List<IHello>() {
            new WindowsHey(),
            new WindowsGoodDay()
            };
    }
}
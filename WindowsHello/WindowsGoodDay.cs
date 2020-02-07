using CommonFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHello
{
    public class WindowsGoodDay : IHello
    {
        public HelloType HType => HelloType.Formal;

        public string Say()
        {
            return "Good Day Sir or Madame from Windows";
        }
    }
}

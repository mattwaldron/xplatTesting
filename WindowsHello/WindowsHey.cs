using CommonFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHello
{
    public class WindowsHey : IHello
    {
        public HelloType HType => HelloType.Casual;

        public string Say()
        {
            return "Hey from Windows";
        }
    }
}

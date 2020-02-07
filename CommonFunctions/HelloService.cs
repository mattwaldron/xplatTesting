using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonFunctions
{
    public class HelloService
    {
        List<IHello> _hellos;
        public void Init(List<IHello> hellos)
        {
            _hellos = hellos;
        }

        public string SayIt(HelloType t)
        {
            return _hellos.First(h => h.HType == t).Say();
        }

        public IHello ExtractOne(HelloType t)
        {
            return _hellos.First(h => h.HType == t);
        }
    }
}

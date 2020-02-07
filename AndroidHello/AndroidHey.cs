using CommonFunctions;

namespace AndroidHello
{
    public class AndroidHey : IHello
    {
        public HelloType HType => HelloType.Casual;

        public string Say()
        {
            return "Hey from Android";
        }
    }
}
using CommonFunctions;

namespace AndroidHello
{
    public class AndroidGoodDay : IHello
    {
        public HelloType HType => HelloType.Formal;

        public string Say()
        {
            return "Good Day Sir or Madame from Android";
        }
    }
}
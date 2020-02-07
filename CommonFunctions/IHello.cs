using System;

namespace CommonFunctions
{
    public interface IHello
    {
        string Say();

        HelloType HType { get; }
    }
}

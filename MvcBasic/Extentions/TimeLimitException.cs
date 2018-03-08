using System;

namespace MvcBasic.Extentions
{
    [Serializable]
    public class TimeLimitException : Exception
    {
        public TimeLimitException(string message) : base(message)
        {
        }
    }
}
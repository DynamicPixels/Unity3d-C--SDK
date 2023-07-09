using System;

namespace models
{
    public class DynamicPixelsException : Exception
    {

        public DynamicPixelsException()
            : base("A Sdk Runtime error occurred!")
        {
        }

        public DynamicPixelsException(string msg)
            : base(msg)
        {
        }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
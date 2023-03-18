using System;

namespace models
{
    public class BlueGException : Exception
    {

        public BlueGException()
            : base("A Sdk Runtime error occurred!")
        {
        }

        public BlueGException(string msg)
            : base(msg)
        {
        }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
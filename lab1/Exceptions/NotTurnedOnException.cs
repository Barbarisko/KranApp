using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Exceptions
{
    public class NotTurnedOnException: Exception
    {
        public NotTurnedOnException(string message) : base(message)
        {
        }
    }
}

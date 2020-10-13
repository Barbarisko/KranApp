using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Exceptions
{
    public class TakeCargoException: Exception
    {
        public TakeCargoException(string message) : base(message)
        {
        }

    }
}

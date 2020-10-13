using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Exceptions
{
    public class HeavyCargoException: Exception
    {
        public HeavyCargoException(string message) : base(message)
        {
        }
    }
}

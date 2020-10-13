using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Exceptions
{
   public  class WrongActionException: Exception
    {
        public WrongActionException(string message) : base(message)
        {
        }
    }
}

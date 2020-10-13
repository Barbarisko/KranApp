using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Exceptions
{
    public class DidntChooseSideException: Exception
    {
        public DidntChooseSideException(string message) : base(message)
        {
        }
    }
}

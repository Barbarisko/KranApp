using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Business
{
    public class State
    {
        public State(angles a, uint w)
        {
            Currangle = a;
            Weight = w;
        }
        private angles currangle;
        private uint weight;
        public angles Currangle { set { currangle = value; } get { return currangle; } }
        public uint Weight { set { weight = value; } get { return weight; } }
    }
}

   
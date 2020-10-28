using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Business
{
    public class State
    {
        public State(Angles a, uint w)
        {
            Currangle = a;
            Weight = w;
        }
        private Angles currangle;
        private uint weight;
        public Angles Currangle { set { currangle = value; } get { return currangle; } }
        public uint Weight { set { weight = value; } get { return weight; } }
    }
}

   
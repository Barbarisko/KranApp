using lab1.Business;
using lab1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace lab1
{

    public enum Angles
    {
        north,
        east,
        south,
        west
    }
    
    public class KranModel
    {
        public KranModel()
        {
            history = new List<State>();
            angle = Angles.north;
        }

        private bool power;
        private const uint maxWeight = 200;
        private uint currentWeight;
        private List<State> history;
        private Angles angle;

        public bool Power{ set { power = value; } get { return power; } }
        public uint MaxWeight { get { return maxWeight; } }
        public uint CurrentWeight { set { currentWeight = value; } get { return currentWeight; } }
        public Angles Angle { set { angle = value; } get { return angle; }}// north direction
        public List<State> History { set { history = value; } get { return history; } }
    }


}

using lab1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace lab1
{

    public enum angles
    {
        north,
        east,
        south,
        west
    }
    public struct state
    {
        public state(angles a, uint w)
        {
            currangle = a;
            weight = w;
        }
        angles currangle { get; set; }
        uint weight { get; set; }

        override public string ToString()
        {
            string res = "";
            switch (currangle)
            {
                case angles.north:
                    res = "north";
                    break;
                case angles.east:
                    res = "east";
                    break;
                case angles.south:
                    res = "south";
                    break;
                case angles.west:
                    res = "west";
                    break;
            }
            return res + ", weight: " + weight.ToString();
        }
    }

    public class KranModel
    {
        public KranModel()
        {
            history = new Queue<state>();
            angle = angles.north;
        }

        private bool power;
        private const uint maxWeight = 200;
        private uint currentWeight;
        private Queue<state> history;
        private angles angle;

        public bool Power{ set { power = value; } get { return power; } }
        public uint MaxWeight { get { return maxWeight; } }
        public uint CurrentWeight { set { currentWeight = value; } get { return currentWeight; } }
        public angles Angle { set { angle = value; } get { return angle; }}// north direction
        public Queue<state> History { set { history = value; } get { return history; } }
    }


}

﻿using lab1.Business;
using lab1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class KranService : IKranService
    {
        public void turnOn(KranModel kran)
        {
            kran.Power = true;
        }

        public void turnOff(KranModel kran)
        {
            kran.Power = false;
            kran.History.Clear();
        }

        int anglecount = 0;

        public void turnAround(bool clockwise, KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("turn me on");
            }
            if (anglecount == 1)
            {
                throw new TakeCargoException("should take weight first");
            }
            if (clockwise == true)
            {
                if (kran.Angle < angles.west)
                {
                    kran.Angle += 1;
                }
                else
                {
                    kran.Angle = angles.north;
                }
            }
            else
            {
                if (kran.Angle > 0)
                    kran.Angle -= 1;
                else kran.Angle = angles.west;
            }
            anglecount += 1;

            kran.History.Add(new State(kran.Angle, kran.CurrentWeight));
        }

        public void liftWeight(uint weight, KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("turn me on");
            }

            if (weight <= kran.MaxWeight)
            {
                kran.CurrentWeight += weight;
                anglecount = 0;
                kran.History.Add(new State(kran.Angle, kran.CurrentWeight));
            }
            else
            {
                throw new HeavyCargoException("more than 200 kg");
            }
        }

        public static string stateToString(State state)
        {
            string name = "";
            switch (state.Currangle)
            {
                case angles.north:
                    name = "north";
                    break;
                case angles.east:
                    name = "east";
                    break;
                case angles.south:
                    name = "south";
                    break;
                case angles.west:
                    name = "west";
                    break;
            }
            return name + ", weight: " + state.Weight.ToString();
        }

        public string currentState(KranModel kran)
        {
            return stateToString(kran.History.Last());

        }

        public string getHistoryAtMoment(int index, KranModel kran)
        {
            if(kran.History.Count != 0 && index <= kran.History.Count)
            {
                return kran.History.ElementAt(index).ToString();
            }
           throw new IndexOutOfRangeException("Too big");
        }


    }
}

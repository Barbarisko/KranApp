using lab1.Business;
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
                throw new NotTurnedOnException("Turn me on first!");
            }
            if (anglecount == 1)
            {
                throw new TakeCargoException("First take weight, then rotate!");
            }
            if (clockwise == true)
            {
                if (kran.Angle < Angles.west)
                {
                    kran.Angle += 1;
                }
                else
                {
                    kran.Angle = Angles.north;
                }
            }
            else
            {
                if (kran.Angle > 0)
                    kran.Angle -= 1;
                else kran.Angle = Angles.west;
            }
            anglecount += 1;

            kran.History.Add(new State(kran.Angle, kran.CurrentWeight));
        }

        public void liftWeight(uint weight, KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("Turn me on first!");
            }
            if (weight <= kran.MaxWeight)
            {
                kran.CurrentWeight += weight;
                anglecount = 0;
                kran.History.Add(new State(kran.Angle, kran.CurrentWeight));
            }
            else
            {
                throw new HeavyCargoException("More than 200 kg!");
            }
        }

        public string stateToString(State state)
        {
            string name = "";
            switch (state.Currangle)
            {
                case Angles.north:
                    name = "North";
                    break;
                case Angles.east:
                    name = "East";
                    break;
                case Angles.south:
                    name = "South";
                    break;
                case Angles.west:
                    name = "West";
                    break;
            }
            return name + ", weight: " + state.Weight.ToString();
        }

        public string currentState(KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("Turn me on first!");
            }
            else if (kran.History.Count == 0)
            {
                throw new WrongActionException("No records available.");
            }
            return stateToString(kran.History.Last());
        }

        public string getHistoryAtMoment(int index, KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("Turn me on first!");
            }
            else if (kran.History.Count == 0)
            {
                throw new WrongActionException("No records available.");
            }
            if (kran.History.Count != 0 && index <= kran.History.Count)
            {
                return stateToString(kran.History.ElementAt(index));
            }
            throw new WrongActionException("Index not in the range of records.");
        }
    }
}

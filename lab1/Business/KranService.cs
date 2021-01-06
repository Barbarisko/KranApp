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
        public void TurnOn(KranModel kran)
        {
            kran.Power = true;
        }

        public void TurnOff(KranModel kran)
        {
            kran.Power = false;
            kran.History.Clear();
        }

        int anglecount = 0;

        public void TurnAround(bool clockwise, KranModel kran)
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

        public void LiftWeight(uint weight, KranModel kran)
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


        public State CurrentState(KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("Turn me on first!");
            }
            else if (kran.History.Count == 0)
            {
                throw new WrongActionException("No records available.");
            }
            return kran.History.Last();
        }

        public State GetHistoryAtMoment(int index, KranModel kran)
        {
            if (!kran.Power)
            {
                throw new NotTurnedOnException("Turn me on first!");
            }

            else if (kran.History.Count == 0)
            {
                throw new WrongActionException("No records available.");
            }            
            return kran.History[index];
        }
    }
}

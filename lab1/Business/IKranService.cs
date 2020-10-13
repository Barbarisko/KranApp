using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public interface IKranService
    {
        void turnOn(KranModel kran);
        void turnOff(KranModel kran);
        void turnAround(bool clockwise, KranModel kran);
        void liftWeight(uint weight, KranModel kran);
        string currentState(KranModel kran);
        string getHistoryAtMoment(int index, KranModel kran);

    }
}

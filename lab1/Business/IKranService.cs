using lab1.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public interface IKranService
    {
        void TurnOn(KranModel kran);
        void TurnOff(KranModel kran);
        void TurnAround(bool clockwise, KranModel kran);
        void LiftWeight(uint weight, KranModel kran);
        State CurrentState(KranModel kran);
        State GetHistoryAtMoment(int index, KranModel kran);

    }
}

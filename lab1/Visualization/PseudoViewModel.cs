using lab1.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xceed.Wpf.Toolkit;

namespace lab1.Visualization
{
    public class PseudoViewModel
    {
        public IKranService KranService;
        private KranModel kran;

        public PseudoViewModel()
        {
            KranService = new KranService();
            kran = new KranModel();
        }

        public void EnableActions()
        {
            bool work = true;

            while (work)
            {
                TextOutputs.printmenu();

                int res = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (res >= 0 && res <= 6)
                    {
                        switchfunc(res);
                    }
                    else { throw new IndexOutOfRangeException("its tooo big"); }
                }
                catch(Exception e )
                {
                    Console.WriteLine("Shos ne te. Error = " + e.Message);
                }

            }
        }

        private void switchfunc(int res)
        {
            switch (res)
            {
                case 0:
                    KranService.turnOn(kran);
                    break;

                case 1:
                    KranService.turnOff(kran);
                    break;

                case 2:
                    TextOutputs.chooseSide();
                    string s = Console.ReadLine();

                    if (s == "left") { KranService.turnAround(false, kran); }
                    else if (s == "right") { KranService.turnAround(true, kran); }
                    else
                    {
                        throw new DidntChooseSideException("choose your side");
                    }
                    
                    TextOutputs.sideChosen(s);

                    break;

                case 3:
                    TextOutputs.inputweight();

                    int w = Convert.ToInt32(Console.ReadLine());
                    KranService.liftWeight((uint)w, kran);
                    Console.WriteLine(kran.CurrentWeight);

                    break;

                case 4:
                    TextOutputs.printstate();
                    Console.WriteLine(KranService.currentState(kran));

                    break;

                case 5:
                    Console.WriteLine("Which index(max " + kran.History.Count.ToString() + ")?");
                    int index = Convert.ToInt32(Console.ReadLine()) - 1;

                    try
                    {
                        Console.WriteLine(KranService.getHistoryAtMoment(index, kran));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Error " + e.Message);
                    }
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:

                    break;
            }
        }
    }
}
            

           

            

        
    


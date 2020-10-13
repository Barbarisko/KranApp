using lab1.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xceed.Wpf.Toolkit;
using ConsoleGraphics;

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

            var popUp = new ConsoleGraphics.PopUpMultipleChoise("Select a possible option: ", TextOutputs.printmenu2());

            while (work)
            {
                //TextOutputs.printmenu();
                //int res = Convert.ToInt32(Console.ReadLine());
                int res = popUp.pop();
                try
                {
                    if (res >= 0 && res <= 6)
                    {
                        switchfunc(res);
                    }
                    else { throw new IndexOutOfRangeException("not in the range"); }
                }
                catch(Exception e )
                {
                    ConsoleGrapher.clear();
                    var errorPopUp = new PopUpInfo(e.Message);
                    errorPopUp.pop();
                }
            }
        }

        private void switchfunc(int res)
        {
            switch (res)
            {
                case 0:
                    KranService.turnOn(kran);
                    Console.WriteLine("I'm aalive!");
                    Console.Beep(2000, 2);
                    break;

                case 1:
                    KranService.turnOff(kran);
                    Console.WriteLine("I'm dead!");
                    break;

                case 2:
                    //TextOutputs.chooseSide();
                    //string s = Console.ReadLine();

                    //if (s == "left") { KranService.turnAround(false, kran); }
                    //else if (s == "right") { KranService.turnAround(true, kran); }
                    //else
                    //{
                    //    throw new DidntChooseSideException("choose your side");
                    //}

                    //TextOutputs.sideChosen(s);

                    string s;

                    var popUp = new PopUpMultipleChoise("Choose side", new string[] { "Left", "Right" });
                    int left_right = popUp.pop();
                    if(left_right == 0)
                    {
                        s = "left";
                        KranService.turnAround(false, kran);
                    }
                    else
                    {
                        s = "right";
                        KranService.turnAround(true, kran);
                    }

                    new PopUpInfo($"Turned {s}!").pop();
                    break;

                case 3:
                    TextOutputs.inputweight();

                    uint w = Convert.ToUInt32(Console.ReadLine());
                    KranService.liftWeight(w, kran);
                    TextOutputs.printweight(Convert.ToInt32(kran.CurrentWeight));
                    break;

                case 4:
                    TextOutputs.printstate();
                    Console.WriteLine(KranService.currentState(kran));
                    break;

                case 5:
                    TextOutputs.printHistoryMoment(kran.History.Count.ToString());
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
            

           

            

        
    


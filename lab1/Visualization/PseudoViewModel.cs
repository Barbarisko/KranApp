using lab1.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGraphics;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace lab1.Visualization
{
    public class PseudoViewModel
    {
        private IKranService KranService;
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
               try
                {
                    string res = Console.ReadLine();
                    

                    //if (IsAllAlphabetic(res) || res == "\n" )
                    //{
                    //    throw new WrongActionException("wtf have you typed? Digits only!");
                    //}
                    if (Check(res) && Convert.ToInt32(res) >= 0 && Convert.ToInt32(res) <= 6)
                    {
                        Swithc(Convert.ToInt32(res));
                        Console.ReadKey();
                        Console.Clear();
                    }                    
                    else 
                    {
                        throw new WrongActionException("Number not in the range of commands!");
                    }
                }
                catch(DidntChooseSideException e)
                {
                    CatchActions(e);
                }
                catch (HeavyCargoException e)
                {
                    CatchActions(e);
                }
                catch (NotTurnedOnException e)
                {
                    CatchActions(e);
                }
                catch (TakeCargoException e)
                {
                    CatchActions(e);
                }
                catch (WrongActionException e)
                {
                    CatchActions(e);
                }
                catch (FormatException e)
                {
                    CatchActions(e);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    CatchActions(e);
                }
                //catch (Exception e )
                //{
                //    Console.Clear();
                //    Console.WriteLine(e.Message);
                //    Console.ReadKey();
                //}
            }
        }

        private void Swithc(int res)
        {
            switch (res)
            {
                case 0:
                    KranService.turnOn(kran);
                    TextOutputs.alive();
                    break;

                case 1:
                    KranService.turnOff(kran);
                    TextOutputs.dead();
                    break;

                case 2:
                    TextOutputs.chooseSide();
                    string s = Console.ReadLine();

                    if (s == "left") 
                    { 
                        KranService.turnAround(false, kran); 
                    }
                    else if (s == "right") 
                    { 
                        KranService.turnAround(true, kran); 
                    }
                    else
                    {
                        throw new DidntChooseSideException("Type in only sides!");
                    }

                    TextOutputs.sideChosen(s);
                    break;

                case 3:
                    TextOutputs.inputweight();

                    var w = Console.ReadLine();
                    if(Check(w))
                    {
                    KranService.liftWeight(Convert.ToUInt32(w), kran);
                    TextOutputs.printweight(Convert.ToInt32(kran.CurrentWeight));
                    }
                    break;


                case 4:
                    TextOutputs.printstate();
                    Console.WriteLine(KranService.currentState(kran));
                    break;

                case 5:
                    TextOutputs.printHistoryMoment(kran.History.Count.ToString());
                    int index = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine(KranService.getHistoryAtMoment(Convert.ToInt32(index), kran));
                    break;

                case 6:
                    Environment.Exit(0);
                    break;
                default:

                    break;
            }            
        }
        public void CatchActions(Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            Console.ReadKey();
            Console.Clear();
        }

        bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        bool Check(string res)
        {

            if (IsAllAlphabetic(res) || res == "\n")
            {
                throw new WrongActionException("wtf have you typed? Digits only!");
            }
            return true;
        }
    }
}
            

           

            

        
    


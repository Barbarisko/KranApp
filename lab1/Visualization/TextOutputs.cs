using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Visualization
{
    public static class TextOutputs
    {
        public static void Printmenu()
        {
            Console.WriteLine("You are in a kran simulator.\n " +
                " Kran will not work properly unless you switch in on\n" +
                " Select a possible option: \n"
                    + "0 - turn on\n"
                    + "1 - turn off\n"
                    + "2 - turn around\n"
                    + "3 - lift weight\n"
                    + "4 - current state\n"
                    + "5 - history\n"
                    + "6 - exit\n");
        }
       
        public static void Alive()
        {
            Console.WriteLine("I'm aalive!\n");
        }
        public static void Dead()
        {
            Console.WriteLine("I'm dead :(\n");
        }
        public static void ChooseSide()
        {
            Console.WriteLine("left or right?");
        }

        public static void SideChosen(string s)
        {
            Console.WriteLine($"Turned {s} !\n");
        }

        public static void Inputweight()
        {
            Console.WriteLine("input weight");
        }

        public static void Printstate()
        {
          Console.WriteLine("the current state and weight is : ");
        }

        public static void Printhistory(int index)
        {
            Console.WriteLine($"the state and weight at step {index} is : ");
        }

        public static void Printweight(int weight)
        {
            Console.WriteLine($"There's {weight} kg on me\n");
        }
        public static void PrintHistoryMoment(string index)
        {
            Console.WriteLine($"At which index(max {index})?");
        }
    }
}

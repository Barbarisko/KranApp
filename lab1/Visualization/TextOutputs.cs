using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Visualization
{
    public static class TextOutputs
    {
        public static void printmenu()
        {
            Console.WriteLine("Select a possible option: \n"
                    + "0 - turn on\n"
                    + "1 - turn off\n"
                    + "2 - turn around\n"
                    + "3 - lift weight\n"
                    + "4 - current state\n"
                    + "5 - history\n"
                    + "6 - exit\n");
        }
        public static void alive()
        {
            Console.WriteLine("I'm aalive!\n");
        }
        public static void dead()
        {
            Console.WriteLine("I'm dead!\n");
        }
        public static void chooseSide()
        {
            Console.WriteLine("left or right?");
        }

        public static void sideChosen(string s)
        {
            Console.WriteLine($"Turned {s} !\n");
        }

        public static void inputweight()
        {
            Console.WriteLine("input weight");
        }

        public static void printstate()
        {
          Console.WriteLine("the current state and weight is : ");
        }

        public static void printhistory(int index)
        {
            Console.WriteLine($"the state and weight at step {index} is : ");
        }

        public static void printweight(int weight)
        {
            Console.WriteLine($"There's {weight} kg on me\n");
        }
        public static void printHistoryMoment(string index)
        {
            Console.WriteLine($"At which index(max {index})?");
        }
    }
}

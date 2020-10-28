using lab1.Visualization;
using System;
using System.Linq.Expressions;
using ConsoleGraphics;

namespace lab1
{
    class Program
    {      
        static void Main(string[] args)
        {            
            PseudoViewModel model = new PseudoViewModel();
            model.EnableActions();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double d;

            Console.Write("Please input a number or string of text: ");
            var var = Console.ReadLine();

            if (Int32.TryParse(var, out n)) { Console.WriteLine("\nYour integer is: {0}", n + 1); }
            else if (Double.TryParse(var, out d)) { Console.WriteLine("\nYour double is: {0}", d + 1); }
            else { Console.WriteLine("\nYour string is: \"{0}\"", var + "*"); }

            Console.ReadKey();
        }
    }
}

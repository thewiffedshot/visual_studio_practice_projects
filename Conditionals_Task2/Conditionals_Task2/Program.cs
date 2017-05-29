using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.Write("Please input 3 numbers:\n\n");

            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());

            if ((a < 0 && b < 0 && c < 0) || (a < 0 && b > 0 && c > 0)  || (a > 0 && b < 0 && c > 0) || (a > 0 && b > 0 && c < 0))
            {
                Console.WriteLine("\n-");
            }
            else if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c > 0) || (a > 0 && b < 0 && c < 0) || (a < 0 && b > 0 && c < 0))
            {
                Console.WriteLine("\n+");
            }
            else
            {
                Console.WriteLine("\n" + 0);
            }

            Console.ReadKey();
        }
    }
}

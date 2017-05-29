using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d, e;

            Console.Write("Please input 5 numbers:\n\n");

            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());
            d = Convert.ToDouble(Console.ReadLine());
            e = Convert.ToDouble(Console.ReadLine());

            if (a > b && a > c && a > d && a > e) Console.WriteLine("\n" + a);
            else if (b > a && b > c && b > d && b > e) Console.WriteLine("\n" + b);
            else if (c > a && c > b && c > d && c > e) Console.WriteLine("\n" + c);
            else if (d > a && d > b && d > c && d > e) Console.WriteLine("\n" + d);
            else if (e > a && e > c && e > d && e > b) Console.WriteLine("\n" + e);
            else Console.WriteLine("\nPlease input 5 discrete numbers.");

            Console.ReadKey();
        }
    }
}

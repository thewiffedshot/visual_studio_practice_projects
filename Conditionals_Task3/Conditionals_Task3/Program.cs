using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task3
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

            if (a > b && a > c)
                Console.WriteLine("\n" + a);

            else if (b > a && b > c)
                Console.WriteLine("\n" + b);

            else if (c > b && c > a)
                Console.WriteLine("\n" + c);

            else
                Console.WriteLine("\n" + a);

            Console.ReadKey();
        }
    }
}

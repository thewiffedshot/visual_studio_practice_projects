using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task4
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

            if (a > b && b > c)
                Console.WriteLine("\n" + a + ", " + b + ", " + c);

            else if (a < b && b < c)
                Console.WriteLine("\n" + c + ", " + b + ", " + a);

            else if (a > b && b < c && a > c)
                Console.WriteLine("\n" + a + ", " + c + ", " + b);

            else if (a > b && b < c && a < c)
                Console.WriteLine("\n" + c + ", " + a + ", " + b);

            else if (a < b && b > c && a > c)
                Console.WriteLine("\n" + b + ", " + a + ", " + c);

            else if (a < b && b > c && a < c)
                Console.WriteLine("\n" + b + ", " + c + ", " + a);
            else
                Console.WriteLine("\n" + a + ", " + b + ", " + c);

            Console.ReadKey();

            /*  
             *  a > b > c
             *  a < b < c
             *  a > b < c but a > c
             *  a > b < c but a < c
             *  a < b > c but a > c
             *  a < b > c but a < c
             */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.WriteLine("Please input quadratic equation 'ax^2 + bx + c = 0' coefficients:");

            Console.Write("\na = ");
            a = Convert.ToDouble(Console.ReadLine());

            while (a == 0)
            {
                Console.WriteLine("'a' coefficient cannot be 0. Please input 'a' again.\n");
                Console.Write("a = ");
                a = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("b = ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("c = ");
            c = Convert.ToDouble(Console.ReadLine());

            if (getDiscriminant(a, b, c) > 0)
            {
                Console.WriteLine("\nFirst root of the equation is {0}.", (-1 * b + Math.Sqrt(getDiscriminant(a, b, c))) / (2 * a));
                Console.WriteLine("Second root of the equation is {0}.", (-1 * b - Math.Sqrt(getDiscriminant(a, b, c))) / (2 * a));
            }
            else if (getDiscriminant(a, b, c) == 0)
            {
                Console.WriteLine("\nThe root of the equation is {0}.", (-1 * b) / (2 * a));
            }
            else
            {
                Console.WriteLine("\nSpecified equation does not have any roots in the real number space.");
            }

            Console.ReadKey();
        }

        static double getDiscriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }
    }
}

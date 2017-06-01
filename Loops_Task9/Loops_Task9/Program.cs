using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n': ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            while (n < 2)
            {
                Console.Write("\nPlease input number 'n' that is greater than or equal to 1: ");
                n = Convert.ToUInt32(Console.ReadLine());
            }
            Console.WriteLine();

            Console.Write("Please input number 'x': ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            long nFactorial = 1;
            double sum = 1;

            for (int i = 1; i <= n; i++)
            {
                nFactorial *= i;
                sum += nFactorial / Math.Pow(x, i);
            }

            Console.WriteLine("The result of the sum is: " + sum);

            Console.ReadKey();
        }
    }
}

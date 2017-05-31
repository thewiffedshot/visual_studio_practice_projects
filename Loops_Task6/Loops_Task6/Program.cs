using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n': ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            while (n < 2)
            {
                Console.Write("\nPlease input number 'n' that is larger than 1: ");
                n = Convert.ToUInt32(Console.ReadLine());
            }
            Console.WriteLine();

            Console.Write("Please input number 'k': ");
            uint k = Convert.ToUInt32(Console.ReadLine());
            while (k < 2)
            {
                Console.Write("\nPlease input number 'k' that is larger than 1: ");
                k = Convert.ToUInt32(Console.ReadLine());
            }
            while (k >= n)
            {
                Console.Write("\nPlease input number 'k' that is smaller than " + n + ": ");
                k = Convert.ToUInt32(Console.ReadLine());
            }
            Console.WriteLine();

            long nFactorial = 1, kFactorial = 1;

            for (int i = 2; i <= n; i++)
                nFactorial *= i;

            for (int i = 2; i <= k; i++)
                kFactorial *= i;

            Console.WriteLine("\nResult of " + n + "! / " + k + "! is: " + nFactorial / kFactorial);

            Console.ReadKey();
        }
    }
}

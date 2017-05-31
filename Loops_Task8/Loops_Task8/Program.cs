using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n' that's greater than or equal to 0: ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            
            BigInteger topFactorial = 1, botFactorial = 1, nFactorial = 1;

            for (int i = 2; i <= 2 * n; i++)
                topFactorial *= i;

            for (int i = 2; i <= n + 1; i++)
                botFactorial *= i;

            for (int i = 2; i <= n; i++)
                nFactorial *= i;

            Console.WriteLine("\nThe requested Catalan number is: " + topFactorial / (botFactorial * nFactorial));

            Console.ReadKey();
        }
    }
}

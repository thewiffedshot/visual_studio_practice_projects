using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task11
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

            long nFactorial = 1;
            uint zeroCount = 0;

            for (int i = 2; i <= n; i++)
            {
                nFactorial *= i;
            }

            while (nFactorial % 10 == 0)
            {
                nFactorial /= 10;
                zeroCount++;
            }

            Console.WriteLine("The number of zeros in specified factorial is: " + zeroCount);

            Console.ReadKey();
        }
    }
}

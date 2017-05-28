using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIO_Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            float sum = 0;

            Console.Write("Please input sum count integer 'n': ");
            n = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(); // Cosmetic touch.

            for (int i = 1; i <= n; i++)
            {
                sum += 1f / i;
            }

            Console.WriteLine("The specified sum is equal to {0:F3}.", sum);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter number 'n': ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(); // Cosmetic touch.

            for (int i = 1; i <= n; i++)
            {
                if ((i % 3 != 0) && (i % 7 != 0))
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIO_Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.Write("Please input number 'n': ");
            n = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(); // Cosmetic touch.

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

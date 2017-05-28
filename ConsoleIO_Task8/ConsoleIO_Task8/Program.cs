using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIO_Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int v1, v2, v3, v4, v5;

            Console.WriteLine("Please enter 5 numbers.\n");
           
            v1 = Convert.ToInt32(Console.ReadLine());
            v2 = Convert.ToInt32(Console.ReadLine());
            v3 = Convert.ToInt32(Console.ReadLine());
            v4 = Convert.ToInt32(Console.ReadLine());
            v5 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nThe sum of the 5 numbers is {0}.", v1 + v2 + v3 + v4 + v5);
            Console.ReadKey();
        }
    }
}

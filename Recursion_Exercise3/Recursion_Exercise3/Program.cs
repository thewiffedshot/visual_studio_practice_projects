using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Multiply(2, 1));

            Console.ReadKey();
        }

        static int Multiply(int a, int b)
        {
            if (a == 1) return b;

            int product = b + Multiply(a - 1, b);

            return product;
        }
    }
}

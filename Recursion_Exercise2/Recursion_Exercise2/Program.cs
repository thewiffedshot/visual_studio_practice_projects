using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Recursion_Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a natural number: ");
            string result = Factorial(int.Parse(Console.ReadLine())).ToString();
            Console.WriteLine("The factorial is: {0}", result);

            Console.ReadKey();
        }

        static BigInteger Factorial(int n)
        {
            if (n < 1) return 1;

            BigInteger product = n;
            product *= Factorial(n - 1);

            return product;
        }
    }
}

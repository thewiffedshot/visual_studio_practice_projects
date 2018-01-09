using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Моля въведете число: ");

            Console.WriteLine("Стойността е: {0}", GetFactorial(uint.Parse(Console.ReadLine())));

            Console.ReadKey();
        }

        static BigInteger GetFactorial(uint n)
        {
            BigInteger factorial = 1;

            for (int i = 2; i <= n; i++) factorial *= i;
            
            return factorial;
        }
    }
}

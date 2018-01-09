using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете номера на члена: ");
            Console.WriteLine("Вашият член е на стойност: {0}", GetFibonacciNum(uint.Parse(Console.ReadLine())));
            Console.Write("Въведете номера за сумата: ");
            Console.WriteLine("Вашата сума е на стойност: {0}", GetFibonacciSum(uint.Parse(Console.ReadLine())));

            Console.ReadLine();
        }

        static ulong GetFibonacciNum(uint n)
        {
            ulong value1 = 0;
            ulong value2 = 1;
            ulong value3;

            if (n > 2)
            {
                for (uint i = 3; i <= n; i++)
                {
                    value3 = value1 + value2;
                    value1 = value2;
                    value2 = value3;
                }

                return value2;
            }
            else if (n == 1)
            {
                return value1;
            }
            else if (n == 2)
            {
                return value2;
            }
            else return 0;
        }

        static ulong GetFibonacciSum(uint n)
        {
            ulong value1 = 0;
            ulong value2 = 1;
            ulong value3;
            ulong sum = value1 + value2;

            if (n > 2)
            {
                for (uint i = 3; i <= n; i++)
                {
                    value3 = value1 + value2;
                    value1 = value2;
                    value2 = value3;
                    sum += value2;
                }

                return sum;
            }
            else if (n == 1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }
            else return 0;
        }
    }
}

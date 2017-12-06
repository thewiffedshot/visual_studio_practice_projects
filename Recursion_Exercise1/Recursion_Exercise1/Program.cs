using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 'n' as the number of integers you want summed starting from 1: ");
            string sum = RecursiveSum(int.Parse(Console.ReadLine())).ToString();

            Console.WriteLine("\n{0}", sum);
            Console.ReadKey();
        }

        static int RecursiveSum(int integer)
        {
            int sum = integer;

            if (integer < 1) return 0;
            
            sum += RecursiveSum(integer - 1);

            return sum;
        }
    }
}

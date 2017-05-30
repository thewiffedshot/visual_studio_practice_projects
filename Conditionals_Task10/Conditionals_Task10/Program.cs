using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input an integer between 0 (exclusive) and 9 (inclusive): ");

            uint p = Convert.ToUInt32(Console.ReadLine());

            switch (p)
            {
                case 1:
                    Console.WriteLine("\n{0}", p * 10);
                    break;
                case 2:
                    Console.WriteLine("\n{0}", p * 10);
                    break;
                case 3:
                    Console.WriteLine("\n{0}", p * 10);
                    break;
                case 4:
                    Console.WriteLine("\n{0}", p * 100);
                    break;
                case 5:
                    Console.WriteLine("\n{0}", p * 100);
                    break;
                case 6:
                    Console.WriteLine("\n{0}", p * 100);
                    break;
                case 7:
                    Console.WriteLine("\n{0}", p * 1000);
                    break;
                case 8:
                    Console.WriteLine("\n{0}", p * 1000);
                    break;
                case 9:
                    Console.WriteLine("\n{0}", p * 1000);
                    break;
                default:
                    Console.WriteLine("\nError! Number must be between 0 (exclusive) and 9 (inclusive).");
                    break;
            }

            Console.ReadKey();
        }
    }
}

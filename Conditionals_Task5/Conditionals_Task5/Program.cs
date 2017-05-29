using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;

namespace Conditionals_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n;

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Please input a digit: ");

            n = Convert.ToUInt16(Console.ReadLine());

            switch (n)
            {
                case 0:
                    Console.WriteLine("\nНула");
                    break;
                case 1:
                    Console.WriteLine("\nЕдно");
                    break;
                case 2:
                    Console.WriteLine("\nДве");
                    break;
                case 3:
                    Console.WriteLine("\nТри");
                    break;
                case 4:
                    Console.WriteLine("\nЧетири");
                    break;
                case 5:
                    Console.WriteLine("\nПет");
                    break;
                case 6:
                    Console.WriteLine("\nШест");
                    break;
                case 7:
                    Console.WriteLine("\nСедем");
                    break;
                case 8:
                    Console.WriteLine("\nОсем");
                    break;
                case 9:
                    Console.WriteLine("\nДевет");
                    break;
                default:
                    Console.WriteLine("\nДе да знам, брат.");
                    break;
            }

            Console.ReadKey();
        }
    }
}

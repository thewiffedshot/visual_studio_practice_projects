using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number in hexadecimal: ");
            string hex = Console.ReadLine();
            string reversedHex = null;

            for (int i = hex.Length - 1; i >= 0; i--)
                reversedHex += hex[i];

            int num = 0;
            int n = 0;

            foreach (char hexChar in reversedHex)
            {
                switch (hexChar)
                {
                    case '1':
                        num += 1 * (int)Math.Pow(16, n);
                        break;
                    case '2':
                        num += 2 * (int)Math.Pow(16, n);
                        break;
                    case '3':
                        num += 3 * (int)Math.Pow(16, n);
                        break;
                    case '4':
                        num += 4 * (int)Math.Pow(16, n);
                        break;
                    case '5':
                        num += 5 * (int)Math.Pow(16, n);
                        break;
                    case '6':
                        num += 6 * (int)Math.Pow(16, n);
                        break;
                    case '7':
                        num += 7 * (int)Math.Pow(16, n);
                        break;
                    case '8':
                        num += 8 * (int)Math.Pow(16, n);
                        break;
                    case '9':
                        num += 9 * (int)Math.Pow(16, n);
                        break;
                    case 'A':
                        num += 10 * (int)Math.Pow(16, n);
                        break;
                    case 'a':
                        num += 10 * (int)Math.Pow(16, n);
                        break;
                    case 'B':
                        num += 11 * (int)Math.Pow(16, n);
                        break;
                    case 'b':
                        num += 11 * (int)Math.Pow(16, n);
                        break;
                    case 'C':
                        num += 12 * (int)Math.Pow(16, n);
                        break;
                    case 'c':
                        num += 12 * (int)Math.Pow(16, n);
                        break;
                    case 'D':
                        num += 13 * (int)Math.Pow(16, n);
                        break;
                    case 'd':
                        num += 13 * (int)Math.Pow(16, n);
                        break;
                    case 'E':
                        num += 14 * (int)Math.Pow(16, n);
                        break;
                    case 'e':
                        num += 14 * (int)Math.Pow(16, n);
                        break;
                    case 'F':
                        num += 15 * (int)Math.Pow(16, n);
                        break;
                    case 'f':
                        num += 15 * (int)Math.Pow(16, n);
                        break;
                    default:
                        Console.WriteLine("\nInvalid number input. Please try again...");
                        goto end;
                }

                n++;
            }

            Console.WriteLine("\nThe decimal value of the number you've entered is: " + num);

            end: Console.ReadKey();
        }
    }
}

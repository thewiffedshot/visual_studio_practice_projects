using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            List<char> reversedChars = new List<char>();
            List<char> chars = new List<char>();
            string revHex = "";
            string hex = "";

            while (n >= 1)
            {
                revHex += getHex(n % 16);
                n /= 16;
            }

            for (int i = revHex.Length - 1; i >= 0; i--)
            {
                hex += revHex[i];
            }

            Console.WriteLine("\nThe decimal number represented in hexadecimal is: " + hex);

            Console.ReadKey();
        }

        private static string getHex(int remainder)
        {
            switch (remainder)
            {
                case 0:
                    return remainder.ToString();
                case 1:
                    return remainder.ToString();
                case 2:
                    return remainder.ToString();
                case 3:
                    return remainder.ToString();
                case 4:
                    return remainder.ToString();
                case 5:
                    return remainder.ToString();
                case 6:
                    return remainder.ToString();
                case 7:
                    return remainder.ToString();
                case 8:
                    return remainder.ToString();
                case 9:
                    return remainder.ToString();
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return remainder.ToString();
            }
        }
    }
}

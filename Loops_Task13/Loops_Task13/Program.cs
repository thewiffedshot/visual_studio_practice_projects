using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number in binary: ");
            string bits = Console.ReadLine();
            List<int> reversedBits = new List<int>(bits.Length);

            for (int i = bits.Length - 1; i >= 0; i--)
                reversedBits.Add((int)(char.GetNumericValue(bits[i])));

            int num = 0;
            int n = 0;

            foreach (int bit in reversedBits)
            {
                switch (bit)
                {
                    case 1:
                        num += (int)Math.Pow(2, n);
                        break;
                }

                n++;
            }

            Console.WriteLine("\nThe decimal value of the number you've entered is: " + num);

            Console.ReadKey();
        }
    }
}

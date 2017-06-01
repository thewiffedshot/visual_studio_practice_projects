using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n' that is between 1 (inclusive) and 20 (exclusive): ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            while (n > 20 || n < 1)
            {
                Console.Write("\nPlease input number 'n' that is between 1 (inclusive) and 20 (exclusive): ");
                n = Convert.ToUInt32(Console.ReadLine());
            }
            Console.WriteLine();

            for (int row = 0, startNum = 1 ; row < n; row++, startNum++)
            {
                Console.SetCursorPosition(Console.CursorLeft = 0, Console.CursorTop + 1);

                for (int col = 0; col < n; col++)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);

                    Console.Write(startNum + col);
                }
            }

            Console.ReadKey();
        }
    }
}

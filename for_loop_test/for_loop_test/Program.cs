using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_loop_test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 0; b <= 9; b++)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        int d = a + b - c;

                        if (d >= 0 && d <= 9)
                            Console.WriteLine(a + " " + b + " " + c + " " + d);
                    }
                }
            }

            Console.ReadKey();

            // a + b = c + d
            // d = a + b - c
        }
    }
}

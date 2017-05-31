using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            uint v1 = 0, v2 = 1, v3;

            Console.Write("Please input number 'n': ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            Console.Write("\n" + v1 + "\n" + v2 + "\n");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(v1 + v2);

                v3 = v2;
                v2 = v1 + v2;
                v1 = v3;
            }

            Console.ReadKey();
        }
    }
}

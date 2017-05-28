using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIO_Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            uint v1 = 0, v2 = 1, v3;

            Console.WriteLine(v1);
            Console.WriteLine(v2);

            for (int i = 0; i < 98; i++)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int v1 = 3, v2 = 4, v3;

            if (v1 > v2)
            {
                v3 = v1;
                v1 = v2;
                v2 = v3;
            }

            Console.Write("Value 1 is: {0}. Value 2 is: {1}.", v1, v2);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber rn = new RationalNumber(6, 8);
            RationalNumber rn1 = new RationalNumber(24, 36);

            RationalNumber rn2 = rn1 - rn;

            Console.ReadKey();
        }
    }
}

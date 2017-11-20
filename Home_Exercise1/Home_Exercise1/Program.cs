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
            RationalNumber rn = new RationalNumber(2, 8);
            RationalNumber rn1 = new RationalNumber(7, 28);

            RationalNumber rn2 = rn.Add(rn1);

            Console.ReadKey();
        }
    }
}

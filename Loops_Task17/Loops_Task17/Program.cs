using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter two numbers:");
            int n = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            List<uint> nDividers = new List<uint>();
            List<uint> kDividers = new List<uint>();

            uint maxCommonDivider = 1;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    nDividers.Add((uint)i);
            }

            for (int i = 1; i <= n; i++)
            {
                if (k % i == 0)
                    kDividers.Add((uint)i);
            }

            foreach (uint nDivider in nDividers)
            {
                foreach (uint kDivider in kDividers)
                {
                    if (nDivider == kDivider)
                        maxCommonDivider = nDivider;
                }
            }

            Console.WriteLine("The max common divider is: " + maxCommonDivider);

            Console.ReadKey();
        }
    }
}

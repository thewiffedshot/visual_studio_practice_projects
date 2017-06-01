using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n': ");
            int n = Convert.ToInt32(Console.ReadLine());
 
            Console.WriteLine();

            List<int> reversedBits = new List<int>();
            List<int> bits = new List<int>();

            while (n >= 1)
            {
                reversedBits.Add(n % 2);
                n /= 2; 
            }

            for (int i = reversedBits.Capacity - 1; i >= 0; i--)
            {
                bits.Add(reversedBits[i]);
            }

            foreach (int bit in bits)
            {
                Console.Write(bit);
            }

            Console.ReadKey();
        }
    }
}

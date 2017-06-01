using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n': ");
            uint n = Convert.ToUInt32(Console.ReadLine());
            while (n < 2)
            {
                Console.Write("\nPlease input number 'n' that is larger than 1: ");
                n = Convert.ToUInt32(Console.ReadLine());
            }
            Console.WriteLine();

            Random randy = new Random();
            uint[] nums = new uint[n];
            uint[] shuffledNums = new uint[n];

            for (int i = 0; i < n; i++)
                nums[i] = (uint)(i + 1);

            foreach (uint num in nums)
            {
                uint index = (uint)(randy.Next(0, (int)n));

                while (shuffledNums[index] != 0)
                {
                    index = (uint)(randy.Next(0, (int)n));
                }

                shuffledNums[index] = num;
            }
            
            for (int i = 0; i < n; i++)
            {
                if (i != n - 1)
                    Console.Write(shuffledNums[i] + ", ");
                else
                    Console.Write(shuffledNums[i]);
            }

            Console.ReadKey();
        }
    }
}

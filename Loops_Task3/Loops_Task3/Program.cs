using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            Console.WriteLine("Please enter some integers (enter submit to get result):");

            while (true)
            {
                var n = Console.ReadLine();
                int num;

                if (int.TryParse(n, out num))
                    nums.Add(num);
                else if (n == "submit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again:\n");
                }
            }

            int max = 0;
            int min;

            foreach (int num in nums)
            {
                if (num > max) max = num;
            }

            min = max;

            foreach (int num in nums)
            {
                if (num < min) min = num;
            }

            Console.WriteLine("Max: " + max + "  Min: " + min);

            Console.ReadKey();
        }
    }
}

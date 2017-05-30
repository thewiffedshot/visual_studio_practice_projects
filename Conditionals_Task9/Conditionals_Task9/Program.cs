using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[5];

            Console.Write("Please input 5 integers:\n\n");

            for (int i = 0; i < 5; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine(); // Cosmetic touch.

            foreach (int n in nums)
            {
                if (n == 0)
                {
                    Console.WriteLine("\n" + 0 + "\n");
                    break;
                }
            }

            if (nums.Sum() == 0)
                Console.WriteLine(nums[0] + ", " + nums[1] + ", " + nums[2] + ", " + nums[3] + ", " + nums[4] + "\n");


            if (nums[0] + nums[1] == 0)
                Console.WriteLine(nums[0] + ", " + nums[1] + "\n");

            if (nums[0] + nums[2] == 0)
                Console.WriteLine(nums[0] + ", " + nums[2] + "\n");

            if (nums[0] + nums[3] == 0)
                Console.WriteLine(nums[0] + ", " + nums[3] + "\n");

            if (nums[0] + nums[4] == 0)
                Console.WriteLine(nums[0] + ", " + nums[4] + "\n");

            if (nums[1] + nums[2] == 0)
                Console.WriteLine(nums[1] + ", " + nums[2] + "\n");
 
            if (nums[1] + nums[3] == 0)
                Console.WriteLine(nums[1] + ", " + nums[3] + "\n");

            if (nums[1] + nums[4] == 0)
                Console.WriteLine(nums[1] + ", " + nums[4] + "\n");

            if (nums[2] + nums[3] == 0)
                Console.WriteLine(nums[2] + ", " + nums[3] + "\n");

            if (nums[2] + nums[4] == 0)
                Console.WriteLine(nums[2] + ", " + nums[4] + "\n");

            if (nums[3] + nums[4] == 0)
                Console.WriteLine(nums[3] + ", " + nums[4] + "\n");

            if (nums[0] + nums[1] + nums[2] == 0)
                Console.WriteLine(nums[0] + ", " + nums[1] + ", " + nums[2] + "\n");

            if (nums[1] + nums[2] + nums[3] == 0)
                Console.WriteLine(nums[1] + ", " + nums[2] + ", " + nums[3] + "\n");

            if (nums[2] + nums[3] + nums[4] == 0)
                Console.WriteLine(nums[2] + ", " + nums[3] + ", " + nums[4] + "\n");

            if (nums[0] + nums[1] + nums[4] == 0)
                Console.WriteLine(nums[0] + ", " + nums[1] + ", " + nums[4] + "\n");

            if (nums[4] + nums[2] + nums[0] == 0)
                Console.WriteLine(nums[0] + ", " + nums[2] + ", " + nums[4] + "\n");

            if (nums[0] + nums[4] + nums[3] == 0)
                Console.WriteLine(nums[0] + ", " + nums[3] + ", " + nums[4] + "\n");

            if (nums[0] + nums[1] + nums[3] == 0)
                Console.WriteLine(nums[0] + ", " + nums[1] + ", " + nums[3] + "\n");

            if (nums[1] + nums[2] + nums[4] == 0)
                Console.WriteLine(nums[1] + ", " + nums[2] + ", " + nums[4] + "\n");

            if (nums[3] + nums[4] + nums[1] == 0)
                Console.WriteLine(nums[1] + ", " + nums[3] + ", " + nums[4] + "\n");

            if (nums[0] + nums[3] + nums[2] == 0)
                Console.WriteLine(nums[0] + ", " + nums[2] + ", " + nums[3] + "\n");

            Console.ReadKey();
        }
    }
}

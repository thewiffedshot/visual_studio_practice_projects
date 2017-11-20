using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        private static int[] nums = new int[1000];
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            PopulateArray();

            int userNum = 1;

            while (userNum <= nums.Length && userNum >= 1)
            {
                Console.Write("Моля въведете число от 1 до 100: ");

                while (!int.TryParse(Console.ReadLine(), out userNum))
                {
                    Console.Write("\nМоля въведете число от 1 до 100: ");
                }

                GetNumInstances(userNum);
            }
        }

        static void PopulateArray()
        {
            for (int index = 0; index < nums.Length; index++)
            {
                nums[index] = rand.Next(1, nums.Length + 1);
            }
        }

        static void GetNumInstances(int _num)
        {
            int count = 0;
            int[] pos = new int[nums.Length];

            string result;

            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] == _num)
                {
                    pos[count] = index;
                    count++;
                }
            }

            result = count.ToString() + ";";

            for (int i = 0; i < count; i++)
            {
                result += " " + pos[i].ToString();
            }

            Console.WriteLine(result);
        }
    }
}

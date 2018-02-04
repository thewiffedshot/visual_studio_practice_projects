using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task7
{
    class Program
    {
        static int[] nums;
        static int n, k;

        static void Main(string[] args)
        {
            n = ReadInt("Въведете дължината на масива: ");

            nums = new int[n];

            k = ReadInt("Въведете дължината на поредицата за сумиране: ");

            PopulateArray(nums);

            int maxSum = int.MinValue, sum = 0, j = 0;

            for (int i = 0; i < nums.Length; i++, sum = 0, j = 0)
            {
                while (j < k)
                {
                    if (i + j == nums.Length)
                    {
                        break;
                    }
                    else
                    {
                        sum += nums[i + j];
                    }

                    j++;
                }

                if (sum > maxSum && j == k) maxSum = sum;
            }

            Console.WriteLine("Максималната сума при поредица дълга {0} е {1}.", k, maxSum);

            Console.ReadKey();
        }

        static void PopulateArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadInt("a[" + i + "] = ");
            }
        }

        static int ReadInt(string prompt)
        {
            int num;

            Console.Write(prompt);

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write(prompt);
            }

            return num;
        }
    }
}

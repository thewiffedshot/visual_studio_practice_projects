using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIO_Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.Write("Please input number 'n': ");
            n = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("\nPlease input " + n + " integers.\n");

            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nThe sum of the numbers you've entered is {0}.", nums.Sum());
            Console.ReadKey();
        }
    }
}

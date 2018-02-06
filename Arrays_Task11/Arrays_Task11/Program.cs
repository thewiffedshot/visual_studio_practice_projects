using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task11
{
    class Program
    {
        static int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        static int targetRangeStart, targetRangeEnd, rangeStart = 0, rangeEnd = array.Length - 1, targetSum, sum = 0;

        static void Main(string[] args)
        {
            targetSum = ReadInt("Please input target sum to search for: ");

            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = rangeEnd; j > rangeStart; --j)
                {
                    sum = CheckSum(array, rangeStart, j);

                    if (sum == targetSum)
                    {
                        targetRangeStart = rangeStart;
                        targetRangeEnd = j;
                    }
                }

                rangeStart++;
            }

            for (int i = targetRangeStart; i <= targetRangeEnd; ++i)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.Write("--> {0}", targetSum);

            Console.ReadKey();
        }

        static int CheckSum(int[] a, int _rangeStart, int _rangeEnd)
        {
            int _sum = 0;

            for (int i = _rangeStart; i <= _rangeEnd; ++i)
            {
                _sum += a[i];
            }

            return _sum;
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

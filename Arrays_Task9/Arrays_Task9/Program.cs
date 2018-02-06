using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task9
{
    class Program
    {
        static int[] array = { 2, 3, - 6, -1, 2, -1, 6, 4, -8, 8 }; // 2 - 1 + 6 + 4 = 11

        static int maxSumRangeStart, maxSumRangeEnd, rangeStart = 0, rangeEnd = array.Length - 1, maxSum = int.MinValue, sum = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = rangeEnd; j > rangeStart; --j)
                {
                    sum = CheckSum(array, rangeStart, j);

                    if (sum >= maxSum)
                    {
                        maxSumRangeStart = rangeStart;
                        maxSumRangeEnd = j;

                        maxSum = sum;
                    }
                }

                rangeStart++;
            }

            for (int i = maxSumRangeStart; i <= maxSumRangeEnd; ++i)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.Write("--> {0}", maxSum);

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
    }
}

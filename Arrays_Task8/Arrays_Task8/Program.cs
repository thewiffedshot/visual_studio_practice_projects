using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task8
{
    class Program
    {
        static int[] nums = { 1, 3, 3, 7, 4, 2, 0, 6, 9 };

        static void Main(string[] args)
        {
            SelectionSort(nums);
            PrintArray(nums);

            Console.ReadKey();
        }

        static void SelectionSort(int[] a)
        {
            int placeHolder;
            int minElement = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < a.Length - 1; i++, minElement = int.MaxValue)
            {
                placeHolder = a[i];

                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < minElement)
                    {
                        minElement = a[j];
                        minIndex = j;
                    }
                }

                a[i] = minElement;
                a[minIndex] = placeHolder;         
            }
        }

        static void PrintArray(int[] a)
        {
            foreach (int num in a)
            {
                Console.Write("{0} ", num);
            }
        }
    }
}

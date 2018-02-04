using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task6
{
    class Program
    {
        static int[] array = { 9, 6, 2, 7, 4, 7, 6, 5, 8, 4 }; // 2, 4, 5, 8
        static int[][] chains = new int[array.Length][];
        static int[] chainsSortedIndexes = new int[array.Length];
        static List<int> chain = new List<int>();

        static void Main(string[] args)
        {
            int num = 1;
            int biggerIndex = 0;

            for (int i = 0; i < array.Length; ++i)
            {
                num = 1;
                chains[i] = new int[CheckBiggerCount(array, i)];

                while (true)
                {
                    biggerIndex = LookupBigger(array, i, num);

                    if (biggerIndex != int.MinValue) chains[i][num - 1] = biggerIndex;
                    else break;

                    num++;
                }
            }

            PopulateArrayIndexes(chainsSortedIndexes);
            BubbleSort(chains);

            BuildChain();
            PrintChain();

            Console.ReadKey();
        }
        
        static void BuildChain()
        {
            for (int i = 0; i < chains.Length; ++i)
            {
                if (i == 0) chain.Add(array[chainsSortedIndexes[0]]);
                else if (chainsSortedIndexes[i] > chainsSortedIndexes[i - 1] && array[chainsSortedIndexes[i]] > chain.Last())
                {
                    chain.Add(array[chainsSortedIndexes[i]]);
                }
            }
        }

        static void BubbleSort(int[][] a)
        {
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;

                for (int i = 0; i < a.Length - 2; ++i)
                {
                    if (a[i + 1].Length > a[i].Length)
                    {
                        int i1Length = a[i + 1].Length;

                        int[] placeHolder = a[i];
                        int[] placeHolder2 = a[i + 1];
                        int indexPlaceHolder = chainsSortedIndexes[i];

                        chainsSortedIndexes[i] = chainsSortedIndexes[i + 1];
                        chainsSortedIndexes[i + 1] = indexPlaceHolder;

                        a[i + 1] = new int[a[i].Length];
                        a[i] = new int[i1Length];

                        a[i] = placeHolder2;
                        a[i + 1] = placeHolder;

                        sorted = false;
                    }
                }
            }
        }

        static void PopulateArrayIndexes(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i;
            }
        }

        static uint CheckBiggerCount(int[] a, int index)
        {
            uint k = 0;

            for (int i = index; i < a.Length - 1; ++i)
            {
                if (a[i + 1] > a[index])
                {
                    k++;
                }
            }

            return k;
        }

        static int LookupBigger(int[] a, int index, int num)
        {
            num--;

            for (int i = index; i < a.Length; ++i)
            {
                if (a[i] > a[index] && num == 0)
                {
                    return i;
                }
                else if (a[i] > a[index]) num--;
            }

            return int.MinValue;
        }

        static void PrintChain()
        {
            foreach (int number in chain)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }
    }
}

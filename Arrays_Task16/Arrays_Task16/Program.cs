using System;

namespace Arrays_Task16
{
    class MainClass
    {
        static int[] array = { 1, 5, 5, 7, 9, 10, 11, 15, 35, 35, 39, 42 };

        public static void Main(string[] args)
        {
            int index = BinarySearch(array, 39);

            Console.ReadKey();
        }

        static int BinarySearch(int[] _array, int a)
        {
            int start = 0, end = _array.Length - 1, mid, n = 0;

            while (start < end && n < _array.Length / 2)
            {
                mid = start + (end - start) / 2;

                if (_array[mid] == a)
                    return mid;
                
                if (a < _array[mid])
                {
                    end = mid;
                }
                else if (a > _array[mid])
                {
                    start = mid;
                }

                if (a > _array[mid] && a == _array[end])
                    return end;

                n++;
            }

            if (_array[start] == a) return start;

            return int.MinValue;
        }
    }
}

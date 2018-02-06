using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task10
{
    class Program
    {
        static int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        static int selectedValue = array[0], mod = 0, valueCount = 0, maxValueCount = valueCount;

        static void Main(string[] args)
        {
            for (int i = 0; i < array.Length; ++i, valueCount = 0)
            {
                selectedValue = array[i];

                for (int j = 0; j < array.Length; ++j)
                {
                    if (array[j] == selectedValue) valueCount++;
                }

                if (valueCount > maxValueCount)
                {
                    maxValueCount = valueCount;
                    mod = selectedValue;
                }
            }

            Console.WriteLine("{0}", mod);

            Console.ReadKey();
        }
    }
}

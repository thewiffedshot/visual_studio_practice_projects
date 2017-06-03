using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray;
            int[] secondArray;
            bool equal = true;

            Console.Write("Please enter length for first 'int' array: ");
            firstArray = new int[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine();

            Console.Write("Please enter length for second 'int' array: ");
            secondArray = new int[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine();

            if (firstArray.Length == secondArray.Length)
            {
                Console.WriteLine("Please enter values for first 'int' array:");

                for (int i = 0; i < firstArray.Length; i++)
                    firstArray[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Please enter values for first 'int' array:");

                for (int i = 0; i < secondArray.Length; i++)
                    secondArray[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();


                for (int i = 0; i < firstArray.Length; i++)
                    if (firstArray[i] != secondArray[i])
                    {
                        equal = false;
                        break;
                    }

                if (equal)
                    Console.WriteLine("Arrays are equal.");
                else
                    Console.WriteLine("Arrays are NOT equal.");
            }
            else
                Console.WriteLine("Arrays are NOT equal.");

            Console.ReadKey();
        }
    }
}

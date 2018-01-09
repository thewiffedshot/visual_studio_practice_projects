using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise13
{
    class Program
    {
        static decimal[] array;

        static void Main(string[] args)
        {
            int n = ReadInt("Въведете дължината на масива: ");

            array = new decimal[n];

            PopulateArray(array);

            Console.WriteLine("\nПървоначални стойности: ");
            PrintArray(array);

            BubbleSort(array);

            Console.WriteLine("\nРезултат: ");
            PrintArray(array);

            Console.ReadKey();
        }

        static void PopulateArray(decimal[] a)
        {
            Random randy = new Random();

            int i = 0;
            foreach(decimal num in a)
            {
                a[i] = randy.Next(1, a.Length + 1);

                i++;
            }
        }

        static void BubbleSort(decimal[] a)
        {
            bool sorted = false;
            uint counter = 0;

            while (!sorted)
            {
                sorted = true;

                for(int i = 0; i < a.Length - 1; ++i)
                {
                    if (a[i + 1] < a[i])
                    {
                        decimal placeHolder = a[i];

                        a[i] = a[i + 1];
                        a[i + 1] = placeHolder;

                        sorted = false;                 
                    }
                }

                counter++;
                if (counter == a.Length - 1) return;
            }
        }

        static void PrintArray(decimal[] a)
        {
            string result = "";

            foreach (decimal num in a) result += num.ToString() + " ";

            Console.WriteLine(result);
        }

        static int ReadInt(string prompt)
        {
            int result;

            Console.Write(prompt);

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(prompt);
            }

            return result;
        }
    }
}

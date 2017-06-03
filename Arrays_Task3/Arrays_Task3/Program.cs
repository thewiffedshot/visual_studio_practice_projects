using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArray;
            char[] secondArray;

            int firstArrayPoints = 0;
            int secondArrayPoints = 0;

            Console.Write("Please enter length for first 'int' array: ");
            firstArray = new char[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine();

            Console.Write("Please enter length for second 'int' array: ");
            secondArray = new char[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine();

            if (firstArray.Length == secondArray.Length)
            {
                Console.WriteLine("Please enter values for first 'int' array:");

                for (int i = 0; i < firstArray.Length; i++)
                    firstArray[i] = Convert.ToChar(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Please enter values for first 'int' array:");

                for (int i = 0; i < secondArray.Length; i++)
                    secondArray[i] = Convert.ToChar(Console.ReadLine());

                Console.WriteLine();

                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] < secondArray[i])
                        firstArrayPoints++;

                    else if (firstArray[i] > secondArray[i])
                        secondArrayPoints++;
                }
                
                if (firstArrayPoints > secondArrayPoints)
                    Console.WriteLine("firstArray\nsecondArray");

                else if (firstArrayPoints < secondArrayPoints)
                    Console.WriteLine("secondArray\nfirstArray");

                else Console.WriteLine("firstArray\nsecondArray");
            }
            else
            {
                if (firstArray.Length <= secondArray.Length)
                    Console.WriteLine("firstArray\nsecondArray");
                else
                    Console.WriteLine("secondArray\nfirstArray");
            }

            Console.ReadKey();
        }
    }
}

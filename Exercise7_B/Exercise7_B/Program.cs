using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_B
{
    class Program
    {
        static int rows, cols;
        static int[,] matrix;

        static void Main(string[] args)
        {
            Console.Write("Въведете броя редове на матрицата: ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Въведете броя стълбове на матрицата: ");
            cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];

            Console.WriteLine("Въведете елементите на матрицата: ");

            for (uint i = 0; i < rows; i++)
            {
                string[] sn = Console.ReadLine().Split();

                int n = 0;

                foreach (string c in sn)
                {
                    if (n < cols)
                    {
                        matrix[i, n] = int.Parse(c);
                    }

                    n++;
                }
            }

            int max = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] >= max)
                    {
                        maxRow = i;
                        maxCol = j;

                        max = matrix[i, j];
                    }
                }

            Console.WriteLine("\nПозиция на максималния елемент е [{0}, {1}] = {2}", ++maxRow, ++maxCol, max);

            Console.ReadKey();
        }
    }
}

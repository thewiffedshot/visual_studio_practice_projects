using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9
{
    class Program
    {
        static decimal[,] matrix;

        static void Main(string[] args)
        {
            int choice = 0;

            do
            {
                if (choice == 0) Console.WriteLine("1. Въвеждане на матрица 'n x n', 0 < n < 1000.");
                else Console.WriteLine("\n1. Въвеждане на матрица 'n x n', 0 < n < 1000.");
                Console.WriteLine("2. Извеждане на сумата на елементите по главния диагонал.");
                Console.WriteLine("3. Извеждане на стойността на най-малкия елемент по вторичния диагонал.");
                Console.WriteLine("4. Проверка дали матрицата е диагонална.");
                Console.WriteLine("0. Изход\n");

                choice = ReadInt("\nВъведете команда: ");

                try
                {
                    switch (choice)
                    {
                        case 1:

                            PopulateMatrix(ReadInt("\nВъведете размерност на матрицата и след това стойностите й: "));

                            break;

                        case 2:

                            Console.WriteLine("\nСумата е: {0}", PrimaryDiagonalSum());

                            break;

                        case 3:

                            Console.WriteLine("\nСтойността е: {0}", SecondaryDiagonalMinValue());

                            break;

                        case 4:

                            if (IsDiagonal()) Console.WriteLine("\nМатрицата е диагонална.");
                            else Console.WriteLine("\nМатрицата НЕ Е диагонална.");

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Възникна неочаквана грешка: {0}", e.Message);
                }
            } while (choice != 0);
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

        static decimal ReadDecimal(string prompt)
        {
            decimal result;

            Console.Write(prompt);

            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(prompt);
            }

            return result;
        }

        static void PopulateMatrix(int n)
        {
            if (n < 1 || n > 999) throw new ArgumentOutOfRangeException("Стойността за 'n' трябва да е между 0 и 1000.");

            matrix = new decimal[n, n];

            for (uint i = 0; i < n; i++)
            {
                string[] sn = Console.ReadLine().Split();

                int j = 0;

                foreach (string c in sn)
                {
                    if (j < n)
                    {
                        matrix[i, j] = int.Parse(c);
                    }

                    j++;
                }
            }
        }

        static decimal PrimaryDiagonalSum()
        {
            decimal sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        static decimal SecondaryDiagonalMinValue()
        {
            decimal minValue = decimal.MaxValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(0) - (i + 1)] < minValue) minValue = matrix[i, matrix.GetLength(0) - (i + 1)];
            }

            return minValue;
        }

        static bool IsDiagonal()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (i != j)
                    {
                        if (matrix[i, j] != 0) return false;
                    }
                }
            }

            return true;
        }
    }
}

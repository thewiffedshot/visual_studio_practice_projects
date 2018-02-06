using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task12
{
    class Program
    {
        static int n;
        static int[,] matrix1, matrix2, matrix3, matrix4;

        static void Main(string[] args)
        {
            n = ReadInt("Въведете размерността на матриците: ");

            matrix1 = new int[n, n];
            matrix2 = new int[n, n];
            matrix3 = new int[n, n];
            matrix4 = new int[n, n];

            try
            {
                PopulateMatrix(matrix1, 1);
                PopulateMatrix(matrix2, 2);
                PopulateMatrix(matrix3, 3);
                PopulateMatrix(matrix4, 4);

                Console.WriteLine();

                PrintMatrix(matrix1);
                PrintMatrix(matrix2);
                PrintMatrix(matrix3);
                PrintMatrix(matrix4);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        static void PrintMatrix(int[,] matrix)
        {
            int maxLength = (n * n).ToString().Length;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int intervalLength = maxLength - matrix[i, j].ToString().Length;
                    string interval = " ";

                    for (int o = 0; o < intervalLength; o++) interval += " ";

                    Console.Write(matrix[i, j].ToString() + interval);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n");
        }

        static void PopulateMatrix(int[,] matrix, int type)
        {
            switch (type)
            {
                case 1:
                    int counter = 1;

                    for (int j = 0; j < matrix.GetLength(1); ++j)
                    {
                        for (int i = 0; i < matrix.GetLength(0); ++i)
                        {
                            matrix[i, j] = counter;
                            counter++;
                        }
                    }

                    break;
                case 2:
                    bool down = true;
                    counter = 1;

                    for (int j = 0; j < matrix.GetLength(1); ++j)
                    {
                        if (down)
                            for (int i = 0; i < matrix.GetLength(0); ++i)
                            {
                                matrix[i, j] = counter;
                                counter++;
                            }
                        else
                            for (int i = matrix.GetLength(0) - 1; i >= 0; --i)
                            {
                                matrix[i, j] = counter;
                                counter++;
                            }

                        down = !down;
                    }

                    break;
                case 3:
                    counter = 1;
                    
                    for (int diagonal = n - 1, i = diagonal; diagonal >= 0; diagonal--)
                    {
                        i = diagonal;

                        for (int j = 0; j < n; j++, i++)
                        {
                            if (i == n) break;

                            matrix[i, j] = counter;
                            counter++;
                        }
                    }

                    for (int diagonal = 1, j = diagonal; diagonal < n; diagonal++)
                    {
                        j = diagonal;

                        for (int i = 0; i < n; i++, j++)
                        {
                            if (j == n) break;

                            matrix[i, j] = counter;
                            counter++;
                        }
                    }

                    break;
                case 4:
                    counter = 1;
                    int leftBorder = 0, rightBorder = n - 1, topBorder = 0, botBorder = n - 1;

                    bool horizontal = false;
                    bool right = true;
                    bool _down = true;

                    while (counter <= n * n)
                    {
                        if (horizontal)
                        {
                            if (right)
                            {
                                for (int i = leftBorder; i <= rightBorder; i++)
                                {
                                    if (_down)
                                    {
                                        matrix[topBorder, i] = counter;

                                        counter++;
                                    }
                                    else
                                    {
                                        matrix[botBorder, i] = counter;

                                        counter++;
                                    }
                                }

                                botBorder--;
                                right = !right;
                            }
                            else
                            {
                                for (int i = rightBorder; i >= leftBorder; i--)
                                {
                                    if (_down)
                                    {
                                        matrix[topBorder, i] = counter;

                                        counter++;
                                    }
                                    else
                                    {
                                        matrix[botBorder, i] = counter;

                                        counter++;
                                    }
                                }

                                topBorder++;
                                right = !right;
                            }

                            horizontal = !horizontal;
                        }
                        else
                        {
                            if (_down)
                            {
                                for (int i = topBorder; i <= botBorder; i++)
                                {
                                    if (right)
                                    {
                                        matrix[i, leftBorder] = counter;                  

                                        counter++;
                                    }
                                    else
                                    {
                                        matrix[i, rightBorder] = counter;

                                        counter++;
                                    }
                                }

                                leftBorder++;
                                _down = !_down;
                            }
                            else
                            {
                                for (int i = botBorder; i >= topBorder; i--)
                                {
                                    if (right)
                                    {
                                        matrix[i, leftBorder] = counter;

                                        counter++;
                                    }
                                    else
                                    {
                                        matrix[i, rightBorder] = counter;

                                        counter++;
                                    }
                                }

                                rightBorder--;
                                _down = !_down;
                            }

                            horizontal = !horizontal;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        static int ReadInt(string prompt)
        {
            int num;

            Console.Write(prompt);

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write(prompt);
            }

            return num;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input number 'n': ");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n <= 1)
            {
                Console.Write("\nPlease input number 'n' that is greater than 1: ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();

            bool right = true;
            bool down = true;
            bool horizontal = true;
            bool firstMove = true;

            int interval = Math.Pow(n, 2).ToString().Length + 1;

            if (Console.BufferWidth < interval * n) Console.BufferWidth = interval * n;
            if (Console.BufferHeight < interval * n + 5) Console.BufferHeight = interval * n + 5;

            int leftMargin = 0;
            int rightMargin = n * interval;
            int topMargin = Console.CursorTop;
            int botMargin = Console.CursorTop + (n * interval) - interval;

            int counter = 1;

            while (true)
            {
                if (horizontal)
                {
                    if (right)
                    {
                        for (int i = leftMargin; i < rightMargin; i += interval)
                        {
                            if (counter == Math.Pow(n, 2) + 1) goto End; // Forgive me.

                            if (firstMove && i == 0)
                                Console.SetCursorPosition(leftMargin, topMargin);
                            else
                                Console.SetCursorPosition(Console.CursorLeft + interval, Console.CursorTop);

                            Console.Write(counter);
                            Console.SetCursorPosition(Console.CursorLeft - counter.ToString().Length, Console.CursorTop);

                            counter++;
                        }

                        right = false;
                        firstMove = false;
                        leftMargin += interval;
                    }
                    else // Left
                    {
                        for (int i = rightMargin; i > leftMargin; i -= interval)
                        {
                            if (counter == Math.Pow(n, 2) + 1) goto End; // For I have sinned.

                            Console.SetCursorPosition(Console.CursorLeft - interval, Console.CursorTop);
                            Console.Write(counter);
                            Console.SetCursorPosition(Console.CursorLeft - counter.ToString().Length, Console.CursorTop);

                            counter++;
                        }

                        right = true;
                        rightMargin -= interval;
                    }

                    horizontal = false;
                }
                else // Vertical
                {
                    if (down)
                    {
                        for (int i = topMargin; i < botMargin; i += interval)
                        {
                            if (counter == Math.Pow(n, 2) + 1) goto End; // It was a one time only thing.

                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + interval);
                            Console.Write(counter);
                            Console.SetCursorPosition(Console.CursorLeft - counter.ToString().Length, Console.CursorTop);

                            counter++;
                        }


                        topMargin += interval;
                        down = false;
                    }
                    else // Up
                    {
                        for (int i = botMargin; i > topMargin; i -= interval)
                        {
                            if (counter == Math.Pow(n, 2) + 1) goto End; // I hope you understand...

                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - interval);
                            Console.Write(counter);
                            Console.SetCursorPosition(Console.CursorLeft - counter.ToString().Length, Console.CursorTop);

                            counter++;
                        }

                        botMargin -= interval;
                        down = true;
                    }

                    horizontal = true;
                }
            }

            End: Console.ReadKey();
        }
    }
}

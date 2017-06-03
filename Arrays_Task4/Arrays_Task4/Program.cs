﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 11, 22, 22, 22, 22, 3, 3, 3, 5, 4, 5, 5, 5, 7, 6 };

            long previousNum = long.MinValue;
            int index = 0;
            int previousChainLength = int.MinValue;
            int chainLength = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (previousNum == array[i])
                {
                    chainLength++;
                    if (chainLength > previousChainLength) index = i - chainLength;
                }
                else
                {
                    if (i != array.Length - 1)
                    {
                        if (chainLength >= previousChainLength) previousChainLength = chainLength;
                        chainLength = 0;
                    }
                }

                previousNum = array[i];
            }

            for (int i = index; i <= index + previousChainLength; i++)
            {
                if (i == index)
                    Console.Write(array[i]);
                else
                    Console.Write(", " + array[i]);
            }

            Console.ReadKey();
        }
    }
}

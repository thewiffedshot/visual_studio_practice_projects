using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[20];

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i * 5;
            }

            bool firstIteration = true;

            foreach (int num in ints)
            {
                if (firstIteration)
                    Console.Write(num);
                else
                    Console.Write(", " + num);

                firstIteration = false;
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics.PerformanceData;
using System.Diagnostics;
using System.ComponentModel;

namespace Exercise2
{
    class Program
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryProcessCycleTime(IntPtr ProcessHandle, out ulong CycleTime);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        static void Main(string[] args)
        {
            var r = new Random();
            int num = r.Next(1, 2);
            int userNum = 0;
            uint n = 0;

            while (userNum != num)
            {
                Console.Write("Въведете число от 1 до 100: ");

                while (!int.TryParse(Console.ReadLine(), out userNum))
                {
                    Console.Write("\nМоля въведете число: ");

                }

                if (userNum > num)
                    Console.WriteLine("\nНадолу!");
                else if (userNum < num)
                    Console.WriteLine("\nНагоре!");

                n++;

                Console.WriteLine();
            }

            QueryProcessCycleTime(GetCurrentProcess(), out ulong cpuCycleCount);

            if (n == 1)
                Console.WriteLine("Поздравления! Отне ви {0} опит и {1} цикъла на процесора.", n, cpuCycleCount.ToString());
            else
                Console.WriteLine("Поздравления! Отне ви {0} опита и {1} цикъла на процесора. Тъпи ли се чувствате сега?", n, cpuCycleCount.ToString());

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class Program
    {
        static uint diskCount;
        static Disk[] disks;

        static void Main(string[] args)
        {
            Console.Write("Въведете броя на дисковете: ");
            diskCount = uint.Parse(Console.ReadLine());

            disks = new Disk[diskCount];

            //PopulateDiskArray();
            Console.WriteLine();

            Move(diskCount, 'A', 'B', 'C');

            Console.ReadKey();
        }

        static void PopulateDiskArray()
        {
            for (uint i = 0; i < diskCount; i++)
            {
                disks[i] = new Disk(i + 1);
            }
        }

        static void Move(uint n, char from, char through, char to)
        {
            if (n == 0)
            {
                return;
            }

            Move(n - 1, from, to, through);
            Console.WriteLine(from + " --> " + to);
            Move(n - 1, through, from, to);
        }
    }
}

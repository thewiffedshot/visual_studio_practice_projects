using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedArray s = new SortedArray();

            for (int i = 0; i < n; i++)
            {
                s.Add(decimal.Parse(Console.ReadLine()));
                Console.WriteLine(s);
            }

            foreach (var element in s.ToArray())
                Console.Write("{0} ", element);

            Console.ReadLine();
        }
    }
}

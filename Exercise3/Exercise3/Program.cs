using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = ReadInt("a = "), b = ReadInt("b = ");

            Console.WriteLine("a = {0}; b = {1}", a, b);

            Swap(ref a, ref b);

            Console.WriteLine("a = {0}; b = {1}", a, b);
        }

        static void Swap(ref int _a, ref int _b)
        {
            /*
             
            int placeHolder = _a;

            _a = _b;
            _b = placeHolder;

            _a = _a + _b;
            _b = _a - _b;
            _a -= _b;
            
            */

            _a = _a ^ _b;
            _b = _a ^ _b;
            _a = _a ^ _b;
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
    }
}

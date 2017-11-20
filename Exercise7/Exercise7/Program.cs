using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7
{
    class Program
    {
        static string word = "";

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Дума: ");
                word = Console.ReadLine();

                if (word != "")
                {
                    if (isPalindrome(word))
                        Console.WriteLine("Думата {0} е палиндром.", word);
                    else
                        Console.WriteLine("Думата {0} НЕ Е палиндром.", word);
                }
                else Console.WriteLine("Довиждане!");

            } while (word != "");

            Console.ReadKey();
        }

        static bool isPalindrome(string _word)
        {
            for (int i = 0, u = _word.Length - 1; i < _word.Length / 2; i++, u--)
            {
                if (_word[i] == _word[u])
                {
                    // Do nothing
                }
                else
                    return false;
            }

            return true;
        }
    }
}

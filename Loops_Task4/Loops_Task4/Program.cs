using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cards = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

            for (int i = 0; i < 4; i++)
                for (int o = 0; o < 13; o++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine(cards[o] + " of Spades");
                            break;
                        case 1:
                            Console.WriteLine(cards[o] + " of Diamond");
                            break;
                        case 2:
                            Console.WriteLine(cards[o] + " of Hearts");
                            break;
                        case 3:
                            Console.WriteLine(cards[o] + " of Clubs");
                            break;
                    }
                }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1B
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = null;
            uint num2 = 0;

            getInput(ref num, ref num2, "num = ");

            uint sum = (uint)Char.GetNumericValue(num[0]) + (uint)Char.GetNumericValue(num[1]) + (uint)Char.GetNumericValue(num[2]);

            char letter = getLetter(sum);

            //char letter = Convert.ToChar(sum);
            //--letter;
            //letter += 'А';

            Console.WriteLine("\nСумата ти е {0}. А буквата е: {1}", sum, letter);

            Console.ReadKey();
        }

        static char getLetter(uint sum)
        {
            switch (sum)
            {
                case 1:
                    return 'А';
                case 2:
                    return 'Б';
                case 3:
                    return 'В';
                case 4:
                    return 'Г';
                case 5:
                    return 'Д';
                case 6:
                    return 'Е';
                case 7:
                    return 'Ж';
                case 8:
                    return 'З';
                case 9:
                    return 'И';
                case 10:
                    return 'Й';
                case 11:
                    return 'К';
                case 12:
                    return 'Л';
                case 13:
                    return 'М';
                case 14:
                    return 'Н';
                case 15:
                    return 'О';
                case 16:
                    return 'П';
                case 17:
                    return 'Р';
                case 18:
                    return 'С';
                case 19:
                    return 'Т';
                case 20:
                    return 'У';
                case 21:
                    return 'Ф';
                case 22:
                    return 'Х';
                case 23:
                    return 'Ц';
                case 24:
                    return 'Ч';
                case 25:
                    return 'Ш';
                case 26:
                    return 'Щ';
                case 27:
                    return 'Ъ';
                case 28:
                    return 'Ь';
                case 29:
                    return 'Ю';
                case 30:
                    return 'Я';
                default:
                    return '!';
            }
        }

        static void getInput(ref string num, ref uint num2, string arg)
        {
            Error:
            Console.Write(arg);

            while (!UInt32.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("\n" + arg);
            }

            num = num2.ToString();

            if (num[0] == num[1] || num[0] == num[2] || num[1] == num[2])
            {

                goto Error;
            }
        }
    }
}

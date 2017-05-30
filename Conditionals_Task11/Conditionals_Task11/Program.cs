using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals_Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] digits = { "нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет" };
            string[] decimals = { "десет", "двадесет", "тридесет", "четирдесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет" };
            string[] hundreds = { "сто", "двеста", "триста", "четиристотин", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин" };

            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Моля въведете цяло число в интервала [0; 999]: ");

            uint num = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(); // Cosmetic touch.

            if (num < 0 || num > 999)
                Console.WriteLine("Грешка! Въведете число в интервала [0; 999].");

            if (num.ToString().Length == 1)
            switch (num)
            {
                case 0:
                    Console.WriteLine(digits[0]);
                    break;
                case 1:
                    Console.WriteLine(digits[1]);
                    break;
                case 2:
                    Console.WriteLine(digits[2]);
                    break;
                case 3:
                    Console.WriteLine(digits[3]);
                    break;
                case 4:
                    Console.WriteLine(digits[4]);
                    break;
                case 5:
                    Console.WriteLine(digits[5]);
                    break;
                case 6:
                    Console.WriteLine(digits[6]);
                    break;
                case 7:
                    Console.WriteLine(digits[7]);
                    break;
                case 8:
                    Console.WriteLine(digits[8]);
                    break;
                case 9:
                    Console.WriteLine(digits[9]);
                    break;
            }

            else if (num.ToString().Length == 2)
            {
                switch ((int)Char.GetNumericValue(num.ToString()[0]))
                {
                    case 1:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[0]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine("единайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine("дванайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine("тринайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine("четиринайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine("петнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine("шестнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine("седемнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine("осемнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine("деветнайсет");

                        break;

                    case 2:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[1] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[1] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[1] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[1] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[1] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[1] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[1] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[1] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[1] + " и " + digits[9]);

                        break;

                    case 3:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[2] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[2] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[2] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[2] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[2] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[2] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[2] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[2] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[2] + " и " + digits[9]);

                        break;

                    case 4:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[3] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[3] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[3] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[3] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[3] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[3] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[3] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[3] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[3] + " и " + digits[9]);

                        break;

                    case 5:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[4] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[4] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[4] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[4] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[4] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[4] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[4] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[4] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[4] + " и " + digits[9]);

                        break;

                    case 6:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[5] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[5] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[5] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[5] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[5] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[5] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[5] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[5] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[5] + " и " + digits[9]);

                        break;

                    case 7:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[6] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[6] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[6] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[6] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[6] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[6] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[6] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[6] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[6] + " и " + digits[9]);

                        break;

                    case 8:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[7] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[7] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[7] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[7] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[7] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[7] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[7] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[7] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[7] + " и " + digits[9]);

                        break;

                    case 9:

                        if ((int)Char.GetNumericValue(num.ToString()[1]) == 0)
                            Console.WriteLine(decimals[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 1)
                            Console.WriteLine(decimals[8] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 2)
                            Console.WriteLine(decimals[8] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 3)
                            Console.WriteLine(decimals[8] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 4)
                            Console.WriteLine(decimals[8] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 5)
                            Console.WriteLine(decimals[8] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 6)
                            Console.WriteLine(decimals[8] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 7)
                            Console.WriteLine(decimals[8] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 8)
                            Console.WriteLine(decimals[8] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[1]) == 9)
                            Console.WriteLine(decimals[8] + " и " + digits[9]);

                        break;

                }
            }

            else if (num.ToString().Length == 3)
            {
                switch ((int)Char.GetNumericValue(num.ToString()[1]))
                {

                    case 0:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и едно");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и две");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и три");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и четири");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и пет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и шест");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и седем");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и осем");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и девет");

                        break;

                    case 1:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и десет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и единайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и дванайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и тринайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и четиринайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и петнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и шестнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и седемнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и осемнайсет");

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + "и деветнайсет");

                        break;

                    case 2:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[1] + " и " + digits[9]);

                        break;

                    case 3:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[2] + " и " + digits[9]);

                        break;

                    case 4:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[3] + " и " + digits[9]);

                        break;

                    case 5:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[4] + " и " + digits[9]);

                        break;

                    case 6:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[5] + " и " + digits[9]);

                        break;

                    case 7:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[6] + " и " + digits[9]);

                        break;

                    case 8:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[7] + " и " + digits[9]);

                        break;

                    case 9:

                        if ((int)Char.GetNumericValue(num.ToString()[2]) == 0)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " и " + decimals[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 1)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[1]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 2)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[2]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 3)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[3]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 4)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[4]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 5)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[5]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 6)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[6]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 7)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[7]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 8)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[8]);

                        else if ((int)Char.GetNumericValue(num.ToString()[2]) == 9)
                            Console.WriteLine(hundreds[(int)Char.GetNumericValue(num.ToString()[0]) - 1] + " " + decimals[8] + " и " + digits[9]);

                        break;

                }
            }

            Console.ReadKey();
        }              
    }
}

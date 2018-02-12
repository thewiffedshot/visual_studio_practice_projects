using System;

namespace Arrays_Task15
{
    class MainClass
    {
        static char[] alphabet = new char[26];

        public static void Main(string[] args)
        {
            PopulateArray(alphabet);

            Console.WriteLine("Please input a word: ");
            string str = Console.ReadLine();

            foreach (char c in str)
            {
                Console.Write("{0} ", (int)(c - 'a'));
            }


            Console.ReadKey();
        }

        static void PopulateArray(char[] a)
        {
            for (int i = 'a'; i <= 'z'; i++)
            {
                alphabet[i - 'a'] = Convert.ToChar(i);
            }
        }
    }
}

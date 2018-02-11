using System;

namespace Arrays_Task14
{
	class MainClass
	{
		static string[,] matrix = { { "ha", "ho", "ha", "hi" }, 
									{ "ho", "ho", "hi", "ha" }, 
									{ "xxx", "as", "ho", "ha" } };

		static bool[,] dummy = new bool[matrix.GetLength (0), matrix.GetLength (1)];

        static int longestChain = 1;
        static string str = "";

		static void Main (string[] args)
		{
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    int currentChain = GetChain(matrix, i, j);

                    if (currentChain > longestChain)
                    {
                        longestChain = currentChain;
                        str = matrix[i, j];
                    }
                }
            }

            for (int i = 0; i < longestChain; i++)
            {
                if (i != longestChain - 1)
                    Console.Write("{0}, ", str);
                else
                    Console.Write("{0}", str);
            }

            Console.WriteLine();
            Console.ReadKey ();
		}

		static int GetChain (string[,] _matrix, int i, int j)
		{
			dummy [i, j] = true;

            int count = 1;

			for (int o = i - 1; o < i + 2; ++o) {
				for (int p = j - 1; p < j + 2; ++p) {
					if((o >= 0 && p >= 0 && o < _matrix.GetLength(0) && p < _matrix.GetLength(1)) && _matrix[o, p] == _matrix[i, j] && !dummy[o, p])
					{
                        count += GetChain(_matrix, o, p);		
					}
				}
			}

            return count;
		}
	}
}

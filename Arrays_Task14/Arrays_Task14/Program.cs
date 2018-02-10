using System;
using System.Collections.Generic;

namespace Arrays_Task14
{
	class MainClass
	{
		static string[,] matrix = { { "ha", "ho", "ho", "hi" }, 
									{ "ha", "ha", "hi", "ha" }, 
									{ "xxx", "ha", "ha", "ha" } };

		static bool[,] dummy = new bool[matrix.GetLength (0), matrix.GetLength (1)];
		
		static List<string> longestChain = new List<string> ();
		static List<string> currentChain = new List<string> ();

		static void Main (string[] args)
		{
			int chainCount = GetChain (matrix, 0, 0) + 1;

			Console.ReadKey ();
		}

		static int GetChain (string[,] _matrix, int i, int j)
		{
			dummy [i, j] = true;

			int count = 1;

			for (int o = i - 1; o < i + 2; ++o) {
				for (int p = j - 1; p < j + 2; ++p) {
					if((o > 0 && p > 0 && o < _matrix.GetLength(0) && p < _matrix.GetLength(1)) && _matrix[o, p] == _matrix[i, j] && !dummy[o, p])
					{
						dummy [o, p] = true;
					
						count += GetChain (_matrix, o, p);

						//currentChain.Add (_matrix[o, p]);			
					}
				}
			}

			return count;
		}
	}
}

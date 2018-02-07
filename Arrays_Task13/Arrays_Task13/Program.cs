using System;

namespace Arrays_Task13
{
	class MainClass
	{
		static int[,] matrix, subMatrix = new int[3, 3];
		static int maxSum = int.MinValue;
		static int n, m;

		public static void Main (string[] args)
		{
			
			n = ReadInt ("Въведете броя редове на матрицата (мин. 3): ");
			m = ReadInt ("Въведете броя колони на матрицата (мин. 3): ");

			matrix = new int[n, m];

			PopulateMatrix (matrix);

			subMatrix = FindMaxSubMatrix (matrix);

			Console.WriteLine ();

			PrintMatrix (matrix);

			PrintMatrix (subMatrix);

			Console.WriteLine ("Сумата на тази подматрица е равна на {0}.", maxSum);

			Console.ReadKey ();
		}

		static int ReadInt (string prompt)
		{
			int num;

			Console.Write(prompt);

			while (!int.TryParse(Console.ReadLine(), out num))
			{
				Console.Write(prompt);
			}

			return num;
		}

		static void PopulateMatrix (int[,] _matrix)
		{
			Console.WriteLine ();

			for (int i = 0; i < _matrix.GetLength(0); i++) 
			{
				for (int j = 0; j < _matrix.GetLength (1); j++) 
				{
					_matrix [i, j] = ReadInt ("[" + i + ", " + j + "] = ");
				}	
			}
		}

		static int[,] FindMaxSubMatrix (int[,] __matrix)
		{
			int sum = 0, maxY = 0, maxX = 0;

			for (int originY = 1; originY < __matrix.GetLength(0) - 1; originY++)
			{
				for (int originX = 1; originX < __matrix.GetLength (1) - 1; originX++) 
				{
					sum += __matrix [originY, originX];
					sum += __matrix [originY - 1, originX - 1];
					sum += __matrix [originY - 1, originX];
					sum += __matrix [originY - 1, originX + 1];
					sum += __matrix [originY, originX + 1];
					sum += __matrix [originY + 1, originX + 1];
					sum += __matrix [originY + 1, originX];
					sum += __matrix [originY + 1, originX - 1];
					sum += __matrix [originY, originX - 1];

					if (sum > maxSum) 
					{
						maxSum = sum;
						maxY = originY;
						maxX = originX;
					}

					sum = 0;
				}
			}

			return BuildSubMatrix (__matrix ,maxY, maxX);
		}

		static int[,] BuildSubMatrix (int[,] initial, int y, int x)
		{
			int[,] subMatrix = new int[3, 3];

			subMatrix [0, 0] = initial [y - 1, x - 1];
			subMatrix [0, 1] = initial [y - 1, x];
			subMatrix [0, 2] = initial [y - 1, x + 1];
			subMatrix [1, 0] = initial [y, x - 1];
			subMatrix [1, 1] = initial [y, x];
			subMatrix [1, 2] = initial [y, x + 1];
			subMatrix [2, 0] = initial [y + 1, x - 1];
			subMatrix [2, 1] = initial [y + 1, x];
			subMatrix [2, 2] = initial [y + 1, x + 1];

			return subMatrix;
		}

		static void PrintMatrix(int[,] matrix)
		{
			int maxLength = (n * n).ToString().Length;

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					int intervalLength = maxLength - matrix[i, j].ToString().Length;
					string interval = " ";

					for (int o = 0; o < intervalLength; o++) interval += " ";

					Console.Write(matrix[i, j].ToString() + interval);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n");
		}
	}
}

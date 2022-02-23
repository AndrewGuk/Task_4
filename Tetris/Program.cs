using System;
using static System.Console;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] place = new int[18, 17];
            Random random = new Random();
            string shablon = " | | ";

            int valueShablon = shablon.Length;
            for (int i = 0; i < place.GetLength(0); i++)
            {
                Write("$$");
                for (int j = 0; j < place.GetLength(1); j++)
                {
                    place[i, j] = random.Next(0, 10);
                    Write($" |{place[i, j]}| ");
                }
                Write("$$");
                WriteLine();
            }
            Write("$$");
            for (int i = 0; i < place.GetLength(1); i++)
            {
                for (int j = 0; j < valueShablon; j++)
                {
                    Write("$");
                }
            }
            Write("$$");
            WriteLine();

        }

    }
}
using System;
using static System.Console;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] place = new string[10, 20];
            Random random = new Random();
            string shablon = "    ";
            string block = "[][]";
            //создаем место в которое генерируется куб
            int vectorX = random.Next(0, place.GetLength(1));
            int valueShablon = shablon.Length;

            for (int i = 0; i < place.GetLength(0); i++)
            {
                Write("$$");
                for (int j = 0; j < place.GetLength(1); j++)
                {
                    place[i, j] = shablon;
                    Write($"{place[i, j]}");
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

            WriteLine();
            place[0, vectorX] = block;
            for (int i = 0; i < place.GetLength(0); i++)
            {
                Write("$$");
                for (int j = 0; j < place.GetLength(1); j++)
                {
                    Write($"{place[i, j]}");
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







            //ИСПРАВНЫЙ ТАБЛИЦ:
            //for (int i = 0; i < place.GetLength(0); i++)
            //{
            //    Write("$$");
            //    for (int j = 0; j < place.GetLength(1); j++)
            //    {
            //        //place[i, j] = random.Next(0, 10);
            //        //Write($" |{place[i, j]}| ");
            //        Write(block);
            //    }
            //    Write("$$");
            //    WriteLine();
            //}
            //Write("$$");
            //for (int i = 0; i < place.GetLength(1); i++)
            //{
            //    for (int j = 0; j < valueShablon; j++)
            //    {
            //        Write("$");
            //    }
            //}
            //Write("$$");
            //WriteLine();




        }

    }
}
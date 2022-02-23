using System;
using static System.Console;
using static System.Threading.Thread;

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
            int vectorX; 
            int valueShablon = shablon.Length;
            //ЗАПОЛНЕНИЕ ПОЛЯ
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
            ReadLine();
            Clear();

            for (int i = 0; ; i++)
            {
                vectorX = random.Next(0, place.GetLength(1));

                for (int j = 0; j < place.GetLength(0); j++)
                {
                    
                    place[j, vectorX] = block;
                    PlayingField();
                    if (j + 1 == place.GetLength(0))
                    {
                        break;
                    }
                    else if (place[j + 1, vectorX] == block)
                    {
                        break;
                    }
                    else if (j >= place.GetLength(0))
                    {
                        j = 0;
                    }
                    place[j, vectorX] = shablon;
                }
            }




            void PlayingField()
            {
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
                //ReadLine();
                Sleep(1000);
                Clear();
            }





        }

    }
}
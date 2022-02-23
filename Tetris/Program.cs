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
            int vectorX; //= random.Next(0, place.GetLength(1));
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
            ReadLine();
            Clear();

            //Рабочий код, с падающим

            //for (int i = 0; ; i++)
            //{
            //    if (i == place.GetLength(0))
            //    {
            //        i = 0;
            //        vectorX = random.Next(0, place.GetLength(1));
            //    }
            //    place[i, vectorX] = block;
            //    PlayingField();
            //    place[i, vectorX] = shablon;
            //}

            //Конец кода
            for (int i = 0; ; i++)
            {
                if (i == place.GetLength(0))
                    i = 0;
                vectorX = random.Next(0, place.GetLength(1));

                for (int j = 0; j < place.GetLength(0); j++)
                {
                    place[j, vectorX] = block;
                    PlayingField();
                    if (j+1 == place.GetLength(0))
                    {
                        break;
                    }
                    else if(place[j+1,vectorX] == block)
                    {
                        break;
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
            void AddNewObject(int x)
            {
                if (x == 3)
                {
                    vectorX = random.Next(0, place.GetLength(1));
                    place[0, vectorX] = block;
                }
            }




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
            //КОНЕЦ ТАБЛИЦЫ



        }

    }
}
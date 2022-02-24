using System;
using static System.Console;
using static System.Threading.Thread;
using System.Text;
using System.Timers;
using System.Diagnostics;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] place = new string[10, 15];
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
            
            //работающий код
            //for (int i = 0; ; i++)
            //{
            //    vectorX = random.Next(0, place.GetLength(1));

            //    for (int j = 0; j < place.GetLength(0); j++)
            //    {

            //        place[j, vectorX] = block;
            //        PlayingField();
            //        if (j + 1 == place.GetLength(0))
            //        {
            //            break;
            //        }
            //        else if (place[j + 1, vectorX] == block)
            //        {
            //            break;
            //        }
            //        else if (j >= place.GetLength(0))
            //        {
            //            j = 0;
            //        }
            //        place[j, vectorX] = shablon;
            //    }
            //}
            //конец
            //впихиваем управление
            for (int i = 0; ; i++)
            {
                vectorX = random.Next(0, place.GetLength(1));

                for (int j = 0; j < place.GetLength(0); j++)
                {

                    place[j, vectorX] = block;
                    vectorX = Control(j, vectorX);

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
            
            //int Control(int j, int vector)
            //{
            //    string usEnter = ReadLine();
            //    switch (usEnter)
            //    {
            //        case "d":
            //            if (vector == place.GetLength(1) - 1)
            //                break;
            //            if (place[j, vector + 1] != shablon)
            //                break;

            //            place[j, vector + 1] = block;
            //            place[j, vector] = shablon;
            //            vector += 1;
            //            break;
            //        case "a":
            //            if (vector == 0)
            //                break;
            //            if (place[j, vector - 1] != shablon)
            //                break;

            //            place[j, vector - 1] = block;
            //            place[j, vector] = shablon;
            //            vector -= 1;
            //            break;
            //        default:
            //            break;
            //    }
            //    return vector;
            //}
            int Control(int j, int vector)
            {
                var sec = 0.1;
                bool bo = true;
                do
                {
                    if (KeyAvailable)
                    {
                        ConsoleKeyInfo proba = ReadKey(true);
                        if (proba.Key == ConsoleKey.A)
                        {
                            if (vector == 0)
                                return vector;
                            if (place[j, vector - 1] != shablon)
                                return vector;

                            place[j, vector - 1] = block;
                            place[j, vector] = shablon;
                            vector -= 1;
                        }
                        else if(proba.Key == ConsoleKey.D)
                        {
                            if (vector == place.GetLength(1) - 1)
                                return vector;
                            if (place[j, vector + 1] != shablon)
                                return vector;

                            place[j, vector + 1] = block;
                            place[j, vector] = shablon;
                            vector += 1;
                        }
                    }
                    Sleep(100);
                    if (sec++ > 0.1)
                    {
                        break;
                    }



                    //var press = ReadKey(true);
                    //if (press.KeyChar == 'a' || press.KeyChar == 'A')
                    //{
                    //    if (vector == 0)
                    //        return vector;
                    //    if (place[j, vector - 1] != shablon)
                    //        return vector;

                    //    place[j, vector - 1] = block;
                    //    place[j, vector] = shablon;
                    //    vector -= 1;

                    //}
                    //else if (press.KeyChar == 'd' || press.KeyChar == 'D')
                    //{
                    //    if (vector == place.GetLength(1) - 1)
                    //        return vector;
                    //    if (place[j, vector + 1] != shablon)
                    //        return vector;

                    //    place[j, vector + 1] = block;
                    //    place[j, vector] = shablon;
                    //    vector += 1;
                    //}
                    bo = false;
                } while (bo);
                return vector;
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

                Sleep(1000);
                Clear();
            }






        }

    }
}
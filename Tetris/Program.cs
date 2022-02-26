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
            string[,] place = new string[10,5];
            Random random = new Random();
            string shablon = "    ";
            string block = "[][]";
            int vectorX; 
            int valueShablon = shablon.Length;
            Zastavka();
            int Control(int j, int vector)
            {
                var sec = 0.01;
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
                        else if (proba.Key == ConsoleKey.Escape)
                            Zastavka();
                    }
                    Beep();
                    Sleep(10);
                    if (sec++ > 0.01)
                        break;
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
                CheckAndClean();
                Sleep(500);
                Clear();
            }
            void CheckAndClean()
            {
                bool vs = false;
                for (int i = place.GetLength(0)-1, j = 0; j < place.GetLength(1); j++)
                {
                    if (place[i, j] == shablon)
                        return;
                    vs = true;
                }
                if (vs)
                {
                    for (int i = place.GetLength(0)-1, j = 0; j < place.GetLength(1); j++)
                    {
                        place[i, j] = shablon;
                    }
                    for (int i = 1; i < place.GetLength(0)-1; i++)
                    {
                        for (int j = 0; j < place.GetLength(1); j++)
                        {
                            if (place[i,j] == block )
                            {
                                place[i, j] = shablon;
                                place[i+1, j] = block;
                            }
                        }
                    }
                }
            }
            void PaintPlayingField()
            {
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
                        Write("$");
                }
                Write("$$");
                Clear();
            }
            void StartGame()
            {
                for (int i = 0; ; i++)
                {
                    vectorX = random.Next(0, place.GetLength(1));

                    for (int j = 0; j < place.GetLength(0); j++)
                    {
                        place[j, vectorX] = block;
                        vectorX = Control(j, vectorX);

                        PlayingField();
                        if (j + 1 == place.GetLength(0))
                            break;
                        else if (place[j + 1, vectorX] == block)
                            break;
                        else if (j >= place.GetLength(0))
                            j = 0;
                        place[j, vectorX] = shablon;
                    }
                }
            }
            void Play()
            {
                PaintPlayingField();
                StartGame();
            }
            void Zastavka()
            {
                string[,] zastavka = new string[,] {

                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", },
                    {" ","#","#","#"," ","#","#","#"," ","#","#","#"," ","#","#","#"," ","#"," ","#","#","#"," "," "," "," "," ", },                   
                    {" "," ","#"," "," ","#"," "," "," "," ","#"," "," ","#"," ","#"," ","#"," ","#"," "," "," "," "," "," "," ", },
                    {" "," ","#"," "," ","#","#"," "," "," ","#"," "," ","#","#","#"," ","#"," ","#","#","#"," "," "," "," "," ", },
                    {" "," ","#"," "," ","#"," "," "," "," ","#"," "," ","#"," ","#"," ","#"," "," "," ","#"," "," "," "," "," ", },                   
                    {" "," ","#"," "," ","#","#","#"," "," ","#"," "," ","#"," ","#"," ","#"," ","#","#","#"," "," "," "," "," ", },
                    {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ", }
                };
                ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < zastavka.GetLength(0); i++)
                {
                    for (int j = 0; j < zastavka.GetLength(1); j++)
                    {
                        Write(zastavka[i, j]);
                    }
                    WriteLine();
                    Sleep(700);
                }
                ResetColor();
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("If you want to start playing enter: <play>" +
                    "or <exit> to exit " +
                    "\n Use A and D to control, press <esc> to return to the main menu");
                ResetColor();
                string answer = ReadLine().ToLower();
                if (answer == "play")
                    Play();
                if (answer == "exit")
                    Exit();
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("sorry( , unknown command ");
                    ResetColor();
                    Main(args);
                }
            }
            void Exit()
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Goodbye!");
                ResetColor();
                Environment.Exit(0);
            }
        }
    }
}
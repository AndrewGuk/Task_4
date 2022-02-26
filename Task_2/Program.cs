using System;
using static System.Console;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("The program looks for all numbers from 200 to 500 that are evenly divisible by 17!");
            var minRange = 200;
            var maxRange = 500;
            int value = 17;
            string answer;
            List<string> list = new List<string>();

            while (minRange <= maxRange)
            {
                if (minRange % value == 0)
                    list.Add(minRange.ToString());
                minRange++;
            }
            ForegroundColor = ConsoleColor.Green;
            answer = String.Join(", ", list);
            WriteLine(answer);
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Goodbye!");
            ResetColor();
            ReadLine();
        }
    }
}

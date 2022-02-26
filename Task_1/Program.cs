using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("\tHello, this program will display the range of the entered number!" +
            "\nTo exit the application please type <exit>" +
            "\nPlease enter value: ");

        int Validation()
        {
            bool usEnterIsInt;
            int receivedValue;
            string usEnter;
            do
            {
                ResetColor();
                usEnter = ReadLine();
                if (usEnter.ToLower() == "exit")
                    Exit();
                usEnterIsInt = Int32.TryParse(usEnter, out receivedValue);
                
                if (!usEnterIsInt)
                {
                    NotCorrect();
                }
            }
            while (!usEnterIsInt);
            receivedValue = int.Parse(usEnter);
            if (receivedValue < 0)
            {
                NotCorrect();
                Validation();
            }
            return receivedValue;
        }
        void NotCorrect()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("You have entered incorrect data! try again.");
            ResetColor();
        }
        int userEnter = Validation();
        var firstRange = 30;
        var secondRange = 60;
        var thredRange = 100;

        for (int i = int.MaxValue; i >= 0; i--)
        {
            if (userEnter <= firstRange)
            {
                Range(userEnter, "first", "(from 0 to 30)");
                return;
            }
            else if (userEnter >= ++firstRange && userEnter <= secondRange)
            {
                Range(userEnter, "second", "(from 31 to 60)");
                return ;
            }
            else if (userEnter >= ++secondRange && userEnter <= thredRange)
            {
                Range(userEnter, "thirds", "(from 61 to 100)");
                return;
            }
            else if (userEnter > ++thredRange)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("I don't know that number! Try again:");
                ResetColor();
                Main(args);
            }
        }
        void Range(int x,string value, string ranges)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"your number <{x}> is in the {value} range {ranges}!");
            ResetColor();
            Main(args);
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
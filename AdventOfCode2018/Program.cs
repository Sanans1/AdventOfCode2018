using AdventOfCode2018.Helpers;
using System;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi!");
            PuzzlePicker.PuzzleCaller();
        }

        public static void AnswerDisplay (string answer)
        {
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();

            Console.WriteLine("\nHere is the answer to the puzzle: " + answer);
            Console.WriteLine("Merry Christmas! Press any key to continue or press ESC to quit.");

            keyinfo = Console.ReadKey();

            if (keyinfo.Key != ConsoleKey.Escape)
            {
                PuzzlePicker.PuzzleCaller();
            }
        }
    }
}

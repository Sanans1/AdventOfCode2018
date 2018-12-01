using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Helpers
{
    public static class PuzzlePicker
    {
        public static int DayPick()
        {
            string userInput;
            int daysParsed = 0;
            int daysSolvable = 1;
            bool isSuccessful = false;

            Console.WriteLine("\nPlease tell me which day's puzzles you'd like to solve or press Esc to exit!");

            while (!isSuccessful)
            {
                userInput = Console.ReadLine();

                try
                {
                    daysParsed = int.Parse(userInput);

                    if (daysParsed > daysSolvable || daysParsed < 0)
                    {
                        throw new InvalidOperationException();
                    }

                    isSuccessful = true;
                }
                catch
                {
                    Console.WriteLine("\nOops! That was an invalid input... Please try again by just entering the number of the day!");
                }
            }

            return daysParsed;
        }

        public static int PuzzlePick()
        {
            string userInput;
            int puzzleParsed = 0;
            bool isSuccessful = false;

            Console.WriteLine("\nAnd now tell me which puzzle of the day you'd like to solve out of puzzle 1 and puzzle 2!");

            while (!isSuccessful)
            {
                userInput = Console.ReadLine();

                try
                {
                    puzzleParsed = int.Parse(userInput);

                    if (puzzleParsed > 2 || puzzleParsed < 0)
                    {
                        throw new InvalidOperationException();
                    }

                    isSuccessful = true;
                }
                catch
                {
                    Console.WriteLine("\nOops! That was an invalid input... Please try entering just the numbers 1 or 2!");
                }
            }

            return puzzleParsed;
        }

        public static void PuzzleSwitch()
        {
            int dayPicked = DayPick();
            int puzzlePicked = PuzzlePick();

            Type dayClass = Type.GetType("AdventOfCode2018.Services.Day" + dayPicked + "Puzzles");
            MethodInfo puzzleMethod = dayClass.GetMethod("Puzzle" + puzzlePicked);
            puzzleMethod.Invoke(null, null);
        }
    }
}

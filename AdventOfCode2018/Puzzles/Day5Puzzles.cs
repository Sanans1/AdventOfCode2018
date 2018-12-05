using AdventOfCode2018.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Puzzles
{
    public static class Day5Puzzles
    {
        public static void Puzzle1()
        {
            string userInput = FileReader.OneLineReader();
            int answer = 0;
            bool isReacting;

            do
            {
                isReacting = false;

                for(int i = 0; i < userInput.Length-1; i++)
                {
                    char currentInput = userInput[i];
                    char nextInput = userInput[i + 1];

                    if (!currentInput.Equals(nextInput) && 
                        char.ToUpper(currentInput).Equals(char.ToUpper(nextInput)))
                    {
                        isReacting = true;
                        userInput = userInput.Remove(i,2);
                    }
                }
            }
            while (isReacting);

            answer = userInput.Length;

            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            string userInput = FileReader.OneLineReader();
            int answer = 0;
            bool isReacting;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            List<int> lengths = new List<int>();

            foreach (char letter in alphabet)
            {
                string currentUserInput = userInput.Replace(letter.ToString(), string.Empty).Replace(char.ToLower(letter).ToString(), string.Empty);
                do
                {
                    isReacting = false;

                    for (int i = 0; i < currentUserInput.Length - 1; i++)
                    {
                        char currentInput = currentUserInput[i];
                        char nextInput = currentUserInput[i + 1];

                        if (!currentInput.Equals(nextInput) &&
                            char.ToUpper(currentInput).Equals(char.ToUpper(nextInput)))
                        {
                            isReacting = true;
                            currentUserInput = currentUserInput.Remove(i, 2);
                        }
                    }
                }
                while (isReacting);
                lengths.Add(currentUserInput.Length);
            }

            answer = lengths.Min(x => x);

            Program.AnswerDisplay(answer.ToString());
        }

    }
}

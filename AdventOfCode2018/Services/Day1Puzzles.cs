using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2018.Services
{
    public static class Day1Puzzles
    {
        public static void Puzzle1()
        {
            int answer = 0;
            string[] userInput;

            userInput = FileReader.MultiLineReader();

            while (true)
            {
                foreach (string numberOperation in userInput)
                {
                    answer += int.Parse(numberOperation);
                }
                break;
            }

            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            int answer = 0;
            bool isSuccessful = false;
            string[] userInput;
            HashSet<int> frequencyList = new HashSet<int>();

            userInput = FileReader.MultiLineReader();

            while (!isSuccessful)
            {
                foreach (string numberOperation in userInput)
                {
                    answer += int.Parse(numberOperation);

                    if (frequencyList.Contains(answer))
                    {
                        isSuccessful = true;
                        break;
                    }
                    else
                    {
                        frequencyList.Add(answer);
                    }
                }
            }

            Program.AnswerDisplay(answer.ToString());
        }
    }
}

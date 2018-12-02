using AdventOfCode2018.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2018.Puzzles
{
    public static class Day1Puzzles
    {
        public static void Puzzle1()
        {
            int answer = 0;
            string[] userInput = FileReader.MultiLineReader(); 

            foreach (string numberOperation in userInput)
            {
                answer += int.Parse(numberOperation);
            }
            
            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            int answer = 0;
            bool isSuccessful = false;
            string[] userInput = FileReader.MultiLineReader();
            HashSet<int> frequencyList = new HashSet<int>();

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

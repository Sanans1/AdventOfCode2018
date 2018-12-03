using AdventOfCode2018.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Puzzles
{
    public static class Day2Puzzles
    {
        public static void Puzzle1()
        {
            string[] userInput = FileReader.MultiLineReader();
            int answer = 0;
            List<int> intList = new List<int>();

            foreach (string packageID in userInput)
            {
                List<char> chars = new List<char>(packageID);
                HashSet<char> charHashSet = new HashSet<char>(packageID);
                HashSet<int> intHashSet = new HashSet<int>();

                foreach (char characters in charHashSet)
                {
                    intHashSet.Add(chars.Count(x => x == characters));
                }

                foreach (int number in intHashSet)
                {
                    if (number == 2 || number == 3)
                    {
                        intList.Add(number);
                    }
                }
            }

            int twos = intList.Count(x => x == 2);
            int threes = intList.Count(x => x == 3);

            answer = twos * threes;

            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            string[] userInput = FileReader.MultiLineReader();
            string answer = null;

            foreach (string packageID in userInput)
            {
                foreach (string otherPackageID in userInput)
                {
                    if (packageID == otherPackageID)
                    {
                        continue;
                    }

                    int difference = packageID.Where((t, i) => t != otherPackageID[i]).Count();

                    if (difference == 1)
                    {
                        for (int i = 0; i < packageID.Length; i++)
                        {
                            if (packageID[i] == otherPackageID[i])
                            {
                                answer += packageID[i];
                                Program.AnswerDisplay(answer);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
 
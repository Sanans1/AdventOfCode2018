using AdventOfCode2018.Helpers;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Puzzles
{
    public static class Day3Puzzles
    {
        public static List<Day3Model> ClaimCreator(string[] userInput)
        {
            List<Day3Model> claims = new List<Day3Model>();

            foreach (string input in userInput)
            {
                char[] badCharacters = new char[] { '#', '@', ',', ':', 'x' };
                string[] values = input.Split(badCharacters, StringSplitOptions.RemoveEmptyEntries);
                claims.Add(
                    new Day3Model
                    {
                        ID = int.Parse(values[0]),
                        XAxis = int.Parse(values[1]),
                        YAxis = int.Parse(values[2]),
                        Width = int.Parse(values[3]),
                        Height = int.Parse(values[4])
                    });
            }

            return claims;
        }

        public static int[,] fabricClaimer(List<Day3Model> claims)
        {
            int[,] fabric = new int[1000, 1000];

            foreach (Day3Model claim in claims)
            {
                for (int x = claim.XAxis; x < claim.XAxis + claim.Width; x++)
                {
                    for (int y = claim.YAxis; y < claim.YAxis + claim.Height; y++)
                    {
                        fabric[x, y]++;
                    }
                }
            }

            return fabric;
        }

        public static void Puzzle1()
        {
            List<Day3Model> claims = ClaimCreator(FileReader.MultiLineReader());
            int answer = 0;
            int[,] fabric = fabricClaimer(claims);

            answer = fabric.Cast<int>().Where(x => x > 1).Count();

            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            List<Day3Model> claims = ClaimCreator(FileReader.MultiLineReader());
            int answer = 0;
            bool hasFailed;
            int[,] fabric = fabricClaimer(claims);

            foreach (Day3Model claim in claims)
            {
                hasFailed = false;
                for (int x = claim.XAxis; x < claim.XAxis + claim.Width; x++)
                {
                    for (int y = claim.YAxis; y < claim.YAxis + claim.Height; y++)
                    {
                        if (fabric[x, y] != 1)
                        {
                            hasFailed = true;
                            break;
                        }    
                    }
                    if(hasFailed)
                    {
                        break;
                    }
                }
                if (!hasFailed)
                {
                    answer = claim.ID;
                    Program.AnswerDisplay(answer.ToString());
                    return;
                }
            }
        }
    }
}

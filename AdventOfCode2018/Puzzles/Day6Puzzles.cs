using AdventOfCode2018.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2018.Puzzles
{
    public static class Day6Puzzles
    {
        private static double ManhattanDistance(Point first, Point second)
        {
            return Math.Abs(first.X - second.X) + Math.Abs(first.Y - second.Y);
        }

        public static void Puzzle1()
        {
            string[] userInput = FileReader.MultiLineReader();
            int answer = 0;

            List<Point> coordinates = new List<Point>(50);
            int maxX = 400;
            int maxY = 400;
            Point[,] closestCoordinate = new Point[maxX, maxY];
            Dictionary<Point, int> CoordinatesDictionary = new Dictionary<Point, int>();

            foreach (string input in userInput)
            {
                coordinates.Add(new Point
                (
                    int.Parse(input.Substring(0, input.IndexOf(','))),
                    int.Parse(input.Substring(input.IndexOf(',') + 1))
                ));
            }

            for (int x = 0; x < maxX; x++)
            {
                for(int y = 0; y < maxY; y++)
                {
                    Point point = new Point(x, y);
                    var ordered = coordinates.Select(i => new { coordinate = i, distance = ManhattanDistance(i, point) }).OrderBy(i => i.distance);

                    if (ordered.First().distance == (ordered.ElementAt(1)).distance)
                    {
                        closestCoordinate[x, y] = new Point(-1, -1);
                    }
                    else
                    {
                        closestCoordinate[x, y] = ordered.First().coordinate;
                    }
                }
            }

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (CoordinatesDictionary.ContainsKey(closestCoordinate[x, y]))
                    {
                        CoordinatesDictionary[closestCoordinate[x, y]]++;
                    }
                    else
                    {
                        CoordinatesDictionary[closestCoordinate[x, y]] = 1;
                    }
                }
            }

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (x == 0 || y == 0 || x == maxX - 1 || y == maxY - 1)
                    {
                        CoordinatesDictionary[closestCoordinate[x, y]] = -1;
                    }
                }
            }

            answer = CoordinatesDictionary.Max(x => x.Value);

            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            string[] userInput = FileReader.MultiLineReader();
            int answer = 0;

            List<Point> coordinates = new List<Point>(50);
            int maxX = 400;
            int maxY = 400;

            foreach (string input in userInput)
            {
                coordinates.Add(new Point
                (
                    int.Parse(input.Substring(0, input.IndexOf(','))),
                    int.Parse(input.Substring(input.IndexOf(',') + 1))
                ));
            }

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    Point point = new Point(x, y);
                    double totalDistance = coordinates.Select(i => ManhattanDistance(i, point)).Sum();

                    if (totalDistance < 10000)
                    {
                        answer++;
                    }
                }
            }

            Program.AnswerDisplay(answer.ToString());
        }
    }
}

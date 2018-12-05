using AdventOfCode2018.Helpers;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Puzzles
{
    public static class Day4Puzzles
    {
        public static List<Day4ModelGuard> InputSorter()
        {
            List<string> userInput = new List<string>(FileReader.MultiLineReader());

            List<Day4ModelAction> day4Actions = new List<Day4ModelAction>();

            foreach (string entry in userInput)
            {
                day4Actions.Add(new Day4ModelAction
                {
                    TimeOfAction = DateTime.ParseExact("2018" + entry.Substring(5, 12), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    Action = entry.Substring(19)
                });
            }

            List<Day4ModelAction> day4ActionsSorted = day4Actions.OrderBy(x => x.TimeOfAction).ToList();
            int currentGuard;
            Day4ModelGuard guard = null;
            List<Day4ModelGuard> guards = new List<Day4ModelGuard>();

            for (var i = 0; i < day4ActionsSorted.Count; i++)
            {
                Day4ModelAction currentAction = day4ActionsSorted[i];

                if (currentAction.Action.EndsWith(" begins shift"))
                {
                    currentGuard = int.Parse(currentAction.Action.Replace("Guard #", "").Replace(" begins shift", ""));

                    guard = guards.FirstOrDefault(x => x.ID == currentGuard);

                    if (guard == null)
                    {
                        guard = new Day4ModelGuard()
                        {
                            ID = currentGuard,
                            Month = currentAction.TimeOfAction.Month,
                            Date = currentAction.TimeOfAction.Day
                        };

                        guards.Add(guard);
                    }
                }
                else if (currentAction.Action == "falls asleep")
                {
                    if (i + 1 < day4ActionsSorted.Count && day4ActionsSorted[i + 1].Action == "wakes up")
                    {
                        for (int j = currentAction.TimeOfAction.Minute; j < day4ActionsSorted[i + 1].TimeOfAction.Minute; j++)
                        {
                            guard.Minutes[j]++;
                        }
                    }
                }
            }

            return guards;
        }

        public static void Puzzle1()
        {
            List<Day4ModelGuard> guardsSortedByMinutes = InputSorter().OrderBy(x => x.MinutesAsleep).ToList();
            int maxID = 0;
            int max = 0;
            int maxMinute = 0;
            int answer = 0;

            Day4ModelGuard guard = guardsSortedByMinutes[guardsSortedByMinutes.Count - 1];

            for (int i = 0; i < 60; i++)
            {
                int min = guard.Minutes[i];

                if (min > max)
                {
                    maxID = guard.ID;
                    max = min;
                    maxMinute = i;
                }
            }

            answer = maxID * maxMinute;

            Program.AnswerDisplay(answer.ToString());
        }

        public static void Puzzle2()
        {
            List<Day4ModelGuard> guardsSortedByDate = InputSorter().OrderBy(x => x.FormattedDate).ToList();
            int maxID = 0;
            int max = 0;
            int maxMinute = 0;
            int answer = 0;

            foreach (Day4ModelGuard guard in guardsSortedByDate)
            {
                for (int i = 0; i < 60; i++)
                {
                    int min = guard.Minutes[i];

                    if (min > max)
                    {
                        maxID = guard.ID;
                        max = min;
                        maxMinute = i;
                    }
                }
            }

            answer = maxID * maxMinute;

            Program.AnswerDisplay(answer.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2018.Helpers
{
    public static class FileReader
    {
        public static string[] MultiLineReader()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nPlease tell me the directory of a .txt file with your puzzle data in. E.g. C:\\Users\\Bob\\Desktop\\Puzzle1.txt");
                    return File.ReadAllLines(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nOops! Something is wrong with the path you entered or the file itself. Please try again or check the file.");
                }
            }
        }
    }
}

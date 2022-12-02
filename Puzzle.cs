using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_of_code
{
    public abstract class Puzzle
    {
        //-- Puzzles can have multiple parts. Solve them all
        public abstract List<Action> SolveParts();
        public string? LoadData(int day)
        {
            try
            {
                return System.IO.File.ReadAllText(@$".\data\day{day}.txt");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Can't find text file for day {day}");
            }

            return null;
        }
    }
}
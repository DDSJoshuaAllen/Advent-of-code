using System.Linq;
using AdventOfCode;
using AdventOfCode.Advent;

namespace AdventOfCodeDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Puzzle> puzzles = new List<Puzzle> { new Day1() };

            puzzles.ForEach(puzzle =>
            {
                Parallel.Invoke(puzzle.SolveParts().ToArray());
            });
        }
    }
}
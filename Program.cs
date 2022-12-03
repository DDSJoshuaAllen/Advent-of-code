using System.Diagnostics;
using System.Linq;
using AdventOfCode;
using AdventOfCode.Advent;

namespace AdventOfCodeDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Puzzle> puzzles = new List<Puzzle> { new Day1(), new Day2(), new Day3() };

            puzzles.ForEach(puzzle =>
            {
                puzzle.SolveParts().ForEach(solution =>
                {
                    var stopwatch = Stopwatch.StartNew();
                    solution();
                    stopwatch.Stop();
                    Console.WriteLine($"Duration {stopwatch.ElapsedMilliseconds} ms \n");
                });
            });
        }
    }
}
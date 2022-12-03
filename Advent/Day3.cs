using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Advent
{
    public class Day3 : Puzzle
    {
        private List<Rucksack>? _rucksacks = new List<Rucksack>();
        public Day3()
        {
            string? puzzleData = LoadData(3);
            puzzleData = puzzleData?.Replace("\r", "");
            List<string>? rucksacks = puzzleData?.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();

            _rucksacks = rucksacks?.Select(x => new Rucksack { Compartments = x }).ToList();
        }

        public Action SolvePart1()
        {
            return () =>
            {
                var total = _rucksacks.SelectMany(x => x.CompartmentOne.ToList().Intersect(x.CompartmentTwo.ToList()))
                                        .Select(x => Priority(x))
                                        .Sum();

                ConsoleHelper.PrintAnswer<int>(3, 1, total);
            };
        }

        public Action SolvePart2()
        {
            return () =>
            {
                var total = _rucksacks.Select((rucksack, index) => new { rucksack, index })
                                        .GroupBy(x => x.index / 3)
                                        .Select(group => group.Aggregate(new HashSet<char>(group.First().rucksack.Compartments), (set, tuple) =>
                                        {
                                            set.IntersectWith(tuple.rucksack.Compartments.ToList());
                                            return set;
                                        }))
                                        .SelectMany(chars => chars.Select(Priority))
                                        .Sum();

                ConsoleHelper.PrintAnswer<int>(3, 2, total);
            };
        }

        public override List<Action> SolveParts()
        {
            return new List<Action>() { SolvePart1(), SolvePart2() };
        }

        private int Priority(char ch) => char.IsLower(ch) ? ch - 96 : ch - 38;
    }

    public class Rucksack
    {
        public string Compartments { get; set; }

        public string CompartmentOne
        {
            get
            {
                return Compartments.Substring(0, (int)(Compartments.Length / 2));
            }
        }

        public string CompartmentTwo
        {
            get
            {
                return Compartments.Substring((int)(Compartments.Length / 2), (int)(Compartments.Length / 2));
            }
        }
    }
}
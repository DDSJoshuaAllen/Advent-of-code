using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Advent
{
    public class Day4 : Puzzle
    {
        private List<ElfPair>? _pairs;

        public Day4()
        {
            string? puzzleData = LoadData(4);
            puzzleData = puzzleData?.Replace("\r", "");
            List<string>? assignments = puzzleData?.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
            _pairs = assignments?.Select(assigment =>
            {
                string[] splitAssignment = assigment.Split(",");
                return new ElfPair
                {
                    FirstElf = splitAssignment[0],
                    SecondElf = splitAssignment[1]
                };
            }).ToList();
        }

        public Action SolvePart1()
        {
            return () =>
            {
                var existsInBoth = _pairs.Where(ExistsInBoth).ToList().Count;
                ConsoleHelper.PrintAnswer(4, 1, existsInBoth);
            };
        }

        public Action SolvePart2()
        {
            return () =>
            {
                var overlaps = _pairs.Where(DoesOverlap).ToList().Count;
                ConsoleHelper.PrintAnswer(4, 2, overlaps);
            };
        }

        public bool ExistsInBoth(ElfPair pair)
        {
            return (pair.FirstElfNumbers[0] >= pair.SecondElfNumbers[0] && pair.FirstElfNumbers[1] <= pair.SecondElfNumbers[1] || pair.SecondElfNumbers[0] >= pair.FirstElfNumbers[0] && pair.SecondElfNumbers[1] <= pair.FirstElfNumbers[1]);
        }

        public bool DoesOverlap(ElfPair pair)
        {
            bool firstElfOverlapWithSecond = pair.FirstElfNumbers[0] <= pair.SecondElfNumbers[1] && pair.SecondElfNumbers[0] <= pair.FirstElfNumbers[1];
            bool secondElfOverlapWithFirst = pair.SecondElfNumbers[0] <= pair.FirstElfNumbers[1] && pair.FirstElfNumbers[0] <= pair.SecondElfNumbers[1];

            return firstElfOverlapWithSecond || secondElfOverlapWithFirst;
        }

        public override List<Action> SolveParts()
        {
            return new List<Action>() { SolvePart1(), SolvePart2() };
        }
    }

    public class ElfPair
    {
        public string? FirstElf { get; set; }
        public string? SecondElf { get; set; }

        public int[] FirstElfNumbers
        {
            get
            {
                string[] elfSectionRange = FirstElf.Split("-");
                return elfSectionRange.Select(int.Parse).ToArray();
            }
        }

        public int[] SecondElfNumbers
        {
            get
            {
                string[] elfSectionRange = SecondElf.Split("-");
                return elfSectionRange.Select(int.Parse).ToArray();
            }
        }
    }
}
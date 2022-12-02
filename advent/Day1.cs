using Advent_of_code.Helpers;

namespace Advent_of_code.advent
{
    public class Day1 : Puzzle
    {
        private List<Elf> Elves = new List<Elf>();

        public Day1()
        {
            //-- Prep data
            string? puzzleData = LoadData(1);
            puzzleData = puzzleData?.Replace("\r", "");
            List<string>? caloriesSplitByNewLine = puzzleData?.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();

            //-- Build list of elves 
            int totalCalories = 0;
            caloriesSplitByNewLine?.ForEach(calories =>
            {
                //-- If there is an empty line then we create an elf.
                if (string.IsNullOrEmpty(calories))
                {
                    Elves.Add(new Elf { Calories = totalCalories });
                    totalCalories = 0; //-- Reset total calories so the next elf starts at 0
                    return;
                }

                totalCalories += int.Parse(calories);
            });
        }

        public Action SolvePart1()
        {
            return () =>
            {
                int answer = Elves.Max(x => x.Calories);
                ConsoleHelper.PrintAnswer(1, 1, answer);
            };
        }

        public Action SolvePart2()
        {
            return () =>
            {
                int answer = Elves.OrderByDescending(x => x.Calories)
                                .Take(3)
                                .ToList()
                                .Sum(x => x.Calories);

                ConsoleHelper.PrintAnswer(1, 2, answer);

            };
        }

        public override List<Action> SolveParts()
        {
            return new List<Action>() { SolvePart1(), SolvePart2() };
        }
    }

    public class Elf
    {
        public int Calories { get; set; }
    }
}
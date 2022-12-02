using AdventOfCode.Helpers;

namespace AdventOfCode.Advent
{
    public class Day2 : Puzzle
    {
        private List<Round>? _rounds = new List<Round>();

        public Day2()
        {
            //-- Prep data
            string? puzzleData = LoadData(2);
            puzzleData = puzzleData?.Replace("\r", "");
            List<string>? roundsAsString = puzzleData?.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
            _rounds = roundsAsString?.Select(round =>
            {
                var choices = round.Split(" ");
                return new Round { Player = choices[1], Opponent = choices[0] };
            }).ToList();
        }

        public Action SolvePart1()
        {
            return () =>
            {
                int? total = _rounds?.Select(x =>
                {
                    Choice playerChoice = GetChoiceFromString(x.Player);
                    Choice opponentChoice = GetChoiceFromString(x.Opponent);
                    GameResult result = PlayRound(opponentChoice, playerChoice);

                    return (int)result + (int)playerChoice;
                }).ToList().Sum();

                ConsoleHelper.PrintAnswer<int>(2, 1, total.GetValueOrDefault());
            };
        }

        public Action SolvePart2()
        {
            return () =>
            {
                int? total = _rounds?.Select(x =>
                {
                    Choice playerChoice = GetChoiceFromString(x.Player);
                    Choice opponentChoice = GetChoiceFromString(x.Opponent);
                    int result = PlayRoundPart2(opponentChoice, playerChoice);

                    return result;
                }).ToList().Sum();

                ConsoleHelper.PrintAnswer<int>(2, 2, total.GetValueOrDefault());
            };
        }

        public override List<Action> SolveParts()
        {
            return new List<Action> { SolvePart1(), SolvePart2() };
        }

        private Choice GetChoiceFromString(string choice)
        {
            switch (choice)
            {
                case "A":
                case "X":
                    return Choice.Rock;
                case "B":
                case "Y":
                    return Choice.Paper;
                case "C":
                case "Z":
                    return Choice.Scissors;
            }

            return Choice.Rock;
        }

        private int PlayRoundPart2(Choice opponentChoice, Choice playerChoice)
        {
            //-- Draw
            if (playerChoice == Choice.Paper)
            {
                return (int)GameResult.Draw + (int)opponentChoice;
            }

            //-- Loss
            if (playerChoice == Choice.Rock)
            {
                switch (opponentChoice)
                {
                    case Choice.Rock:
                        return (int)GameResult.Loss + (int)Choice.Scissors;
                    case Choice.Paper:
                        return (int)GameResult.Loss + (int)Choice.Rock;
                    case Choice.Scissors:
                        return (int)GameResult.Loss + (int)Choice.Paper;
                }
            }

            //-- Win
            switch (opponentChoice)
            {
                case Choice.Rock:
                    return (int)GameResult.Win + (int)Choice.Paper;
                case Choice.Paper:
                    return (int)GameResult.Win + (int)Choice.Scissors;
                case Choice.Scissors:
                    return (int)GameResult.Win + (int)Choice.Rock;
            }

            return 0;
        }

        private GameResult PlayRound(Choice? opponent, Choice? player)
        {
            if (opponent == player) return GameResult.Draw;

            //-- Player Wins
            if ((player == Choice.Rock && opponent == Choice.Scissors) ||
                (player == Choice.Paper && opponent == Choice.Rock) ||
                (player == Choice.Scissors && opponent == Choice.Paper))
            {
                return GameResult.Win;
            }

            return GameResult.Loss;
        }
    }

    enum GameResult
    {
        Win = 6,
        Draw = 3,
        Loss = 0
    }

    enum Choice
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    class Round
    {
        public string? Player { get; set; }
        public string? Opponent { get; set; }
    }
}
using MathGame.YukiUchima.Models;

namespace MathGame.YukiUchima
{
    internal class UserInteraction
    {
        private static List<Game> gameHistory = new List<Game>();
        private static List<string> choiceList = ["a", "s", "m", "d", "h", "r", "e"];
        public static void StartGame()
        {
            Console.WriteLine("This is the math game!");
            bool isGameOver = false;
            do
            {
                string choice = PickGameMode();
                isGameOver = RunGameMode(choice);
            }
            while (!isGameOver);
        }

        static string PickGameMode()
        {
            string optionValue;

            Console.WriteLine("Pick Your Game Mode!");
            Console.WriteLine("\n\t[A] - Add\n\t[S] - Subtract\n\t[M] - Multiply\n\t[D] - Divide\n\t[H] - Preview Game History\n\t[R] - Random\n\t[E] - EXIT");

            // Requests user input until valid input has been chosen
            while (true)
            {
                try
                {
                    optionValue = Console.ReadLine().ToLower();
                    if (!choiceList.Contains(optionValue))
                    {
                        throw new Exception();
                    }
                    return optionValue;
                }
                catch
                {
                    Console.WriteLine($"Invalid user input, please pick Game Mode:");
                    continue;
                }
            }
        }

        static GameLevel PickDifficulty()
        {
            Console.WriteLine("Pick your difficulty level:");
            Console.WriteLine("\t(E)asy\n\t(M)edium\n\t(H)ard");
            string choice = Console.ReadLine();
            
            while (true)
            {
                switch (choice)
                {
                    case "e":
                        return GameLevel.Easy;
                    case "m":
                        return GameLevel.Medium;
                    case "h":
                        return GameLevel.Hard;
                    default:
                        Console.WriteLine("Incorrect input, try again.");
                        Console.WriteLine("Type 'e' for easy, 'm' for medium, or 'h' for hard level...");
                        choice = Console.ReadLine();
                        break;
                }
            }
        }

        static bool RunGameMode(string choice)
        {
            if (choice.Equals("h"))
            {
                Helpers.PreviewHistory();
                return false;
            }
            else if (choice.Equals("e"))
            {
                Console.WriteLine("Game Over. Thanks for playing!");
                return true;
            }
            else
            {
                string gameMode;
                Console.Clear();
                if (choice.Equals("r"))
                {
                    gameMode = choiceList[new Random().Next(0, 3)];
                }
                else
                {
                    gameMode = choice;
                }

                GameLevel level = PickDifficulty();
                switch (gameMode)
                {
                    case "a":
                        GameMode.RunMode(GameType.Addition, level);
                        break;
                    case "s":
                        GameMode.RunMode(GameType.Subtract, level);
                        break;
                    case "m":
                        GameMode.RunMode(GameType.Multiply, level);
                        break;
                    case "d":
                        GameMode.RunMode(GameType.Divide, level);
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
    }

}

using MathGame.YukiUchima.Models;

namespace MathGame.YukiUchima
{
    class UserInteraction
    {
        private static List<Game> gameHistory = new List<Game>();
        public static void StartGame()
        {
            Console.WriteLine("This is the math game!");
            bool isGameOver = false;
            do
            {
                int choice = PickGameMode();
                isGameOver = RunGameMode(choice);
            }
            while (!isGameOver);
        }

        static int PickGameMode()
        {
            List<int> choiceList = [0, 1, 2, 3, 4, 5];
            int optionValue;

            Console.WriteLine("Pick Your Game Mode!");
            Console.WriteLine("\n\t[1] - Add\n\t[2] - Subtract\n\t[3] - Multiply\n\t[4] - Divide\n\t[5] - Preview Game History\n\t[0] - EXIT");

            // Requests user input until valid input has been chosen
            while (true)
            {
                try
                {
                    optionValue = Convert.ToInt32(Console.ReadLine());
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
            GameLevel level;
            Console.WriteLine("Pick your difficulty level:");
            Console.WriteLine("\t(E)asy\n\t(M)edium\n\t(H)ard");
            string choice = Console.ReadLine();
            bool invalidLevelChoice = true;

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
                        break;
                };
                choice = Console.ReadLine();
            }
        }

        static bool RunGameMode(int choice)
        {
            if (choice == 5)
            {
                Helpers.PreviewHistory();
                return false;
            }
            else if (choice == 0)
            {
                Console.WriteLine("Game Over. Thanks for playing!");
                return true;
            }
            else
            {
                Console.Clear();
                GameLevel level = PickDifficulty();

                switch (choice)
                {
                    case 1:
                        GameModes.RunMode(GameType.Addition, level);
                        break;
                    case 2:
                        GameModes.RunMode(GameType.Subtract, level);
                        break;
                    case 3:
                        GameModes.RunMode(GameType.Multiply, level);
                        break;
                    case 4:
                        GameModes.RunMode(GameType.Divide, level);
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
    }
}
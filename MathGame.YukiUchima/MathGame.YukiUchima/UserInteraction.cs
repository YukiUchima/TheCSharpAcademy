using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.YukiUchima
{
    class UserInteraction
    {
        private static List<string> gameHistory = [];
        public static void start()
        {
            Console.WriteLine("This is the math game!");
            bool isGameOver = false;
            do
            {
                int choice = MenuChoice();
                isGameOver = PickGameModes(choice);
            }
            while (!isGameOver);
        }

        private static int MenuChoice()
        {
            List<int> choiceList = [0, 1, 2, 3, 4, 5];
            int optionValue;

            Console.WriteLine("\nPick Your Game Mode!");
            Console.WriteLine("[1] - Add\n[2] - Subtract\n[3] - Multiply\n[4] - Divide\n[5] - Preview Game History\n[0] - EXIT");

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
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Console.WriteLine($"Invalid user input, please pick Game Mode:");
                    continue;
                }
            }
        }


        private static bool PickGameModes(int choice)
        {
            if (choice == 5)
            {
                PreviewHistory();
                return false;
            }
            else if (choice == 0)
            {
                Console.WriteLine("Exiting Game.");
                return true;
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        gameHistory.Add(GameModes.add());
                        break;
                    case 2:
                        gameHistory.Add(GameModes.subtract());
                        break;
                    case 3:
                        gameHistory.Add(GameModes.mult());
                        break;
                    case 4:
                        gameHistory.Add(GameModes.div());
                        break;
                    default:
                        Console.WriteLine("You've decided to exit the game. Thanks for playing!");
                        return true;
                }
            }
            return false;
        }

        public static void PreviewHistory()
        {
            if (gameHistory.Count > 0)
            {
                Console.WriteLine("\nPreviewing History\n---------------[Start History]---------------");
                foreach (var history in gameHistory)
                {
                    Console.WriteLine(history);
                }
                Console.WriteLine("----------------[End History]----------------\n");
            }
            else
            {
                Console.WriteLine("\n No History Preview Available...\n");
            }
        }
    }
}
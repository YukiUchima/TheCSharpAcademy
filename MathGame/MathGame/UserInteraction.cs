using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    class UserInteraction
    {
        private static List<string> gameHistory = [];
        public static void start()
        {
            Console.WriteLine("This is the math game!");
            bool keepPlaying = true;
            do
            {
                int choice = MenuChoice();
                keepPlaying = PickOperation(choice);
            }
            while (keepPlaying);
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
                    Console.WriteLine($"Invalid user input, try again:");
                    continue;
                }
            }
        }

        
        private static bool PickOperation(int choice)
        {
            if (choice == 5)
            {
                PreviewHistory();
                return true;
            }
            else if (choice == 0)
            {
                Console.WriteLine("Exiting Game.");
                return false;
            }
            else
            {
                Console.WriteLine("To exit, enter '0'... Good luck!");
                switch (choice)
                {
                    case 1:
                        gameHistory.Add(Operation.add());
                        break;
                    case 2:
                        gameHistory.Add(Operation.subtract());
                        break;
                    case 3:
                        gameHistory.Add(Operation.mult());
                        break;
                    case 4:
                        gameHistory.Add(Operation.div());
                        break;
                    default:
                        Console.WriteLine("You've decided to exit the game. Thanks for playing!");
                        return false;
                }
            }
            return true;
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

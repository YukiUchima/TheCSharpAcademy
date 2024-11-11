using MathGame.YukiUchima.Models;

namespace MathGame.YukiUchima
{
    internal class Helpers
    {
        internal static List<Game> GameHistory = new List<Game>();
        internal static void PreviewHistory()
        {
            if (GameHistory.Count > 0)
            {
                Console.WriteLine("\nPreviewing History\n---------------[Start History]---------------");

                foreach (Game game in GameHistory)
                {
                    Console.WriteLine($"{game.Time} - {game.Type} Mode Score: {game.Score}/{game.PossibleScore} pts [GameTime: {game.ElapsedTime}]");
                }
                Console.WriteLine("----------------[End History]----------------\n");
            }
            else
            {
                Console.WriteLine("\n---------------- No History Preview Available ----------------\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static string ValidateAnswer(string userIn)
        {
            while (string.IsNullOrEmpty(userIn) || !Int32.TryParse(userIn, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again or (E)nd.");
                userIn = Console.ReadLine().ToLower();

                if (userIn.Equals("e"))
                {
                    return userIn;
                }
            }
            return userIn;
        }
    }

}

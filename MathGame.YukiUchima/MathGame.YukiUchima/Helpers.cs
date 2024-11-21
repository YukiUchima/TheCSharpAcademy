using MathGame.YukiUchima.Models;
using System.Text;

namespace MathGame.YukiUchima
{
    internal class Helpers
    {
        internal static List<Game> GameHistory = new List<Game>();
        
        internal static void PreviewHistory()
        {
            Console.Clear();
            if (GameHistory.Count > 0)
            {
                Console.WriteLine("\nPreviewing History\n---------------[Start History]---------------");
                
                foreach (Game game in GameHistory)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{game.Time}")
                        .Append(" - ")
                        .Append(game.Type)
                        .Append(" Mode Score:")
                        .Append(game.Score)
                        .Append('/')
                        .Append(game.PossibleScore)
                        .Append($" pts [Gametime: {game.ElapsedTime}]");

                    Console.WriteLine(sb.ToString());
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
                userIn = Console.ReadLine()!.ToLower();

                if (userIn.Equals("e"))
                {
                    return userIn;
                }
            }
            return userIn;
        }
    }

}

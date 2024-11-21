

using MathGame.YukiUchima.Models;
using static MathGame.YukiUchima.Enums;

namespace MathGame.YukiUchima;

internal class RunGameMode
{

    private static bool isModeOver;
    private static int x, y;
    private static int ans;
    private static int minValue, maxValue;
    public static void RunMode(GameType type, DifficultyLevel level)
    {
        Game currentGame = new Game();
        currentGame.Type = type;
        currentGame.Score = 0;
        currentGame.PossibleScore = 0;
        DateTime startTime = DateTime.Now;

        switch (level) 
        {
            case DifficultyLevel.Easy:
                minValue = 1;
                maxValue = 10;
                break;
            case DifficultyLevel.Medium:
                minValue = 11;
                maxValue = 20;
                break;
            case DifficultyLevel.Hard:
                minValue = 21;
                maxValue = 30;
                break;
        }

        isModeOver = false;
        var random = new Random();

        while (!isModeOver)
        {
            if (type == GameType.Divide)
            {
                int multiplier = random.Next(1, maxValue);
                do
                {
                    x = random.Next(minValue, maxValue) * multiplier;
                    y = random.Next(minValue, maxValue);
                }
                while (x % y != 0 || x == y);
                ans = x / y;

                Console.WriteLine($"What is the quotient of {x} and {y}? ");
            }
            else
            {
                x = random.Next(minValue, maxValue);
                y = random.Next(minValue, maxValue);
                if (type == GameType.Addition)
                {
                    ans = x + y;
                    Console.WriteLine($"What is the sum of {x} and {y}? ");
                }
                else if (type == GameType.Subtract)
                {
                    ans = x - y;
                    Console.WriteLine($"What is the difference of {x} and {y}? ");
                }
                else if (type == GameType.Multiply)
                {
                    ans = x * y;
                    Console.WriteLine($"What is the product of {x} and {y}? ");
                }
            }

            string userIn = Console.ReadLine();
            userIn = Helpers.ValidateAnswer(userIn);

            if (!userIn.Equals("e"))
            {
                currentGame.Score += CheckAnswer(ans, int.Parse(userIn));
                Console.WriteLine($"(Score: {currentGame.Score}/{++currentGame.PossibleScore})");
            }
            else
            {
                EndMode(type);
                isModeOver = true;
            }
        }

        DateTime endTime = DateTime.Now;
        currentGame.Time = endTime.ToString("h:mm");
        TimeSpan ElapsedTime = (endTime - startTime).Duration();
        currentGame.ElapsedTime = $"{ElapsedTime:mm\\:ss}";
        Helpers.GameHistory.Add(currentGame);
    }

    static int CheckAnswer(int answer, int userAnswer)
    {
        if (answer == userAnswer)
        {
            Console.Write("Correct! ");
            return 1;
        }
        else
        {
            Console.Write($"Incorrect! The answer is {answer}. ");
            return 0;
        }
    }

    static void EndMode(GameType type)
    {
        Console.WriteLine($"Ending {type} Mode - Thank you!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

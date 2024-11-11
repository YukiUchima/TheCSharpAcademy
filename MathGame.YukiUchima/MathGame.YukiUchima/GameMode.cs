

using MathGame.YukiUchima.Models;

namespace MathGame.YukiUchima
{
    internal class GameMode
    {

        private static bool isModeOver;
        private static int x, y;
        private static int ans;
        private static int minValue, maxValue;
        public static void RunMode(GameType type, GameLevel level)
        {
            Game currentMode = new Game();
            currentMode.Type = type;
            currentMode.Score = 0;
            currentMode.PossibleScore = 0;
            DateTime startTime = DateTime.Now;

            if (level == GameLevel.Easy)
            {
                minValue = 1;
                maxValue = 10;
            }
            else if (level == GameLevel.Medium)
            {
                minValue = 11;
                maxValue = 20;
            }
            else if (level == GameLevel.Hard)
            {
                minValue = 21;
                maxValue = 30;
            }

            isModeOver = false;
            var random = new Random();

            while (!isModeOver)
            {
                if (currentMode.Type == GameType.Divide)
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
                    if (currentMode.Type == GameType.Addition)
                    {
                        ans = x + y;
                        Console.WriteLine($"What is the sum of {x} and {y}? ");
                    }
                    else if (currentMode.Type == GameType.Subtract)
                    {
                        ans = x - y;
                        Console.WriteLine($"What is the difference of {x} and {y}? ");
                    }
                    else if (currentMode.Type == GameType.Multiply)
                    {
                        ans = x * y;
                        Console.WriteLine($"What is the product of {x} and {y}? ");
                    }
                }

                string userIn = Console.ReadLine();
                userIn = Helpers.ValidateAnswer(userIn);

                if (!userIn.Equals("e"))
                {
                    currentMode.Score += CheckAnswer(ans, int.Parse(userIn));
                    Console.WriteLine($"(Score: {currentMode.Score}/{++currentMode.PossibleScore})");
                }
                else
                {
                    EndMode(currentMode.Type);
                    isModeOver = true;
                }
            }

            DateTime endTime = DateTime.Now;
            currentMode.Time = endTime.ToString("h:mm");
            TimeSpan ElapsedTime = (endTime - startTime).Duration();
            currentMode.ElapsedTime = $"{ElapsedTime:mm\\:ss}";
            Helpers.GameHistory.Add(currentMode);
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

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    class Operation
    {
        public static string add()
        {
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");

            bool isGameOver = false;

            while (!isGameOver)
            {
                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                int ans = x + y;

                Console.WriteLine($"What is the sum of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    if (userIn == ans)
                    {
                        Console.WriteLine($"The answer is correct! (Current Score: {++score}/{++scorePossible})");
                    }
                    else if (userIn == 0)
                    {
                        Console.WriteLine("Thank you for playing!");
                        isGameOver = true;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The answer is {ans}. (Current Score: {score}/{++scorePossible})");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, let's try a new problem...");
                    continue;
                }

            }

            return $"Time({playTime}) - 'Add' Game Score: {score}/{scorePossible}";
        }

        public static string subtract()
        {
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");

            bool isGameOver = false;

            while (!isGameOver)
            {
                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                int ans = x - y;

                Console.WriteLine($"What is the difference of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    if (userIn == ans)
                    {
                        Console.WriteLine($"The answer is correct! (Current Score: {++score}/{++scorePossible})");
                    }
                    else if (userIn == 0)
                    {
                        Console.WriteLine("Thank you for playing!");
                        isGameOver = true;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The answer is {ans}. (Current Score: {score}/{++scorePossible})");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, let's try a new problem...");
                    continue;
                }

            }

            return $"Time({playTime}) - 'Subtract' Game Score: {score}/{scorePossible}";
        }

        public static string mult()
        {
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");

            bool isGameOver = false;

            while (!isGameOver)
            {
                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                int ans = x * y;

                Console.WriteLine($"What is the product of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    if (userIn == ans)
                    {
                        Console.WriteLine($"The answer is correct! (Current Score: {++score}/{++scorePossible})");
                    }
                    else if (userIn == 0)
                    {
                        Console.WriteLine("Thank you for playing!");
                        isGameOver = true;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The answer is {ans}. (Current Score: {score}/{++scorePossible})");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, let's try a new problem...");
                    continue;
                }

            }

            return $"Time({playTime}) - 'Multiply' Game Score: {score}/{scorePossible}";
        }

        public static string div()
        {
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");

            bool isGameOver = false;

            while (!isGameOver)
            {
                int x, y;
                do
                {
                    x = random.Next(0, 100);
                    y = random.Next(1, 100);
                }
                while (x % y != 0);
                int ans = x / y;              

                Console.WriteLine($"What is the product of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    if (userIn == ans)
                    {
                        Console.WriteLine($"The answer is correct! (Current Score: {++score}/{++scorePossible})");
                    }
                    else if (userIn == 0)
                    {
                        Console.WriteLine("Thank you for playing!");
                        isGameOver = true;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The answer is {ans}. (Current Score: {score}/{++scorePossible})");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, let's try a new problem...");
                    continue;
                }

            }

            return $"Time({playTime}) - 'Divide' Game Score: {score}/{scorePossible}";
        }

    }   
}

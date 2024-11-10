using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    class Operation
    {

        static bool isModeOver;
        public static string add()
        {
            isModeOver = false;
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");


            while (!isModeOver)
            {

                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                int ans = x + y;

                Console.WriteLine($"What is the sum of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    score += CheckAnswer(ans, userIn);
                    Console.WriteLine($"(Current Score: {score}/{++scorePossible})");
                }
                catch
                {
                    Console.WriteLine("Invalid input, do you want to try another problem? (Y/N)...");
                    if (!Console.Read().Equals('y'))
                    {
                        isModeOver = true;
                        Console.WriteLine("Leaving Game Mode - Thank you!");
                    }
                    Console.ReadLine();
                }

            }

            return $"Time({playTime}) - 'Add' Game Score: {score}/{scorePossible}";
        }

        public static string subtract()
        {
            isModeOver = false;
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");



            while (!isModeOver)
            {

                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                int ans = x - y;

                Console.WriteLine($"What is the difference of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    score += CheckAnswer(ans, userIn);
                    Console.WriteLine($"(Current Score: {score}/{++scorePossible})");
                }
                catch
                {
                    Console.WriteLine("Invalid input, do you want to try another problem? (Y/N)...");
                    if (!Console.Read().Equals('y'))
                    {
                        isModeOver = true;
                        Console.WriteLine("Leaving Game Mode - Thank you!");
                    }
                    Console.ReadLine();
                }

            }

            return $"Time({playTime}) - 'Subtract' Game Score: {score}/{scorePossible}";
        }

        public static string mult()
        {
            isModeOver = false;
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");

            while (!isModeOver)
            {

                int x = random.Next(1, 9);
                int y = random.Next(1, 9);
                int ans = x * y;

                Console.WriteLine($"What is the product of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    score += CheckAnswer(ans, userIn);
                    Console.WriteLine($"(Current Score: {score}/{++scorePossible})");
                }
                catch
                {
                    Console.WriteLine("Invalid input, do you want to try another problem? (Y/N)...");
                    if (!Console.Read().Equals('y'))
                    {
                        isModeOver = true;
                        Console.WriteLine("Leaving Game Mode - Thank you!");
                    }
                    Console.ReadLine();
                }

            }

            return $"Time({playTime}) - 'Multiply' Game Score: {score}/{scorePossible}";
        }

        public static string div()
        {
            isModeOver = false;
            var random = new Random();
            int score = 0;
            int scorePossible = 0;
            string playTime = DateTime.Now.ToString("h:mm");

            while (!isModeOver)
            {
                int x, y;
                do
                {
                    x = random.Next(0, 100);
                    y = random.Next(1, 100);
                }
                while (x % y != 0);
                int ans = x / y;              

                Console.WriteLine($"What is the quotient of {x} and {y}? ");
                try
                {
                    int userIn = Convert.ToInt32(Console.ReadLine());
                    score += CheckAnswer(ans, userIn);
                    Console.WriteLine($"(Current Score: {score}/{++scorePossible})");
                }
                catch
                {
                    Console.WriteLine("Invalid input, do you want to try another problem? (Y/N)...");
                    if (!Console.Read().Equals('y'))
                    {
                        isModeOver = true;
                        Console.WriteLine("Leaving Game Mode - Thank you!");
                    }
                    Console.ReadLine();
                }
            }

            return $"Time({playTime}) - 'Divide' Game Score: {score}/{scorePossible}";
        }

        private static int CheckAnswer(int answer, int userAnswer)
        {
            if (answer == userAnswer)
            {
                Console.Write("The answer is correct! ");
                return 1;
            }
            else
            {
                Console.Write($"Incorrect! The answer is {answer}. ");
                return 0;
            }
        }

    }   
}

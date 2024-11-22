
using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace Calculator.YukiUchima;

internal class CalculatorProgram
{
    private static char _operation;
    private static double _result;
    static void Main(string[] args)
    {
        bool endApp = false;

        // Display title
        Console.WriteLine("Console Calculator in C#");
        Console.WriteLine("------------------------\n");

        //Create ONE instance of a calculator object
        //CalculatorLibrary.Calculator calculator = new CalculatorLibrary.Calculator();
        CalculatorLibrary.Calculator calculator = new CalculatorLibrary.Calculator() ;

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            
            //Get user's first number
            numInput1 = GetCalculateNumber(1);
            double cleanNum1 = 0;

            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("Invalid input. Please enter numerical value: ");
                numInput1 = Console.ReadLine();
            }

            //Get user's second number
            numInput2 = GetCalculateNumber(2);
            double cleanNum2 = 0;

            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("Invalid input. Please enter numerical value: ");
                numInput2 = Console.ReadLine();
            }

            // Ask user to pick an option
            Console.WriteLine("Choose an option from following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option?: ");

            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    _result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    
                    if (double.IsNaN(_result))
                    {
                        Console.WriteLine("The operation yields a mathematical error.\n");
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", _result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            Console.WriteLine("------------------------\n");
            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        calculator.Finish();
        return;
    }
        internal static string GetCalculateNumber(int currentInputNumber)
        {
            if (currentInputNumber > 1)
            {
                Console.Write("Type your second number, and press enter: ");
            }
            else
            {
                Console.Write("Type a number and press enter: ");
            }

            return Console.ReadLine();
        }
}
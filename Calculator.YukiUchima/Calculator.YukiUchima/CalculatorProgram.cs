using CalculatorLibrary.Models;
using Spectre.Console;

namespace CalculatorLibrary.YukiUchima;

internal class CalculatorProgram
{
    private static char s_operation;
    private static double s_newResult;
    private static double? s_previousResult = null;
    private static double s_userInput1;
    private static double? s_userInput2 = null;
    
    static void Main(string[] args)
    {
        bool endApp = false;

        Console.WriteLine("Console Calculator in C#");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new Calculator();

        string usePreviousResult;
        while (!endApp)
        {
            if (Calculator.calculationsCount > 0)
            {
                Console.WriteLine($"Calculation(s) Completed: {Calculator.calculationsCount}");
            }

            var selectedOp = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Choose an option from the following list: ")
                .AddChoices(Enums.OpDescription.Values.ToList())
                );
            Enums.OperationType selectedOpType = Enums.OpDescription.First(opDesc => opDesc.Value == selectedOp).Key;

            if (selectedOpType == Enums.OperationType.ShowCalculations)
            {
                calculator.PreviewCalculations();
            }
            else if (selectedOpType == Enums.OperationType.DeleteCalculations)
            {
                Calculator.calculationsList.Clear();
                s_previousResult = null;
                Console.Clear();
                Console.WriteLine("Memory Deleted - Removed Previous Calculations");
            }
            else
            {
                try
                {
                    if (selectedOpType.Equals(Enums.OperationType.Cosine) || selectedOpType.Equals(Enums.OperationType.Sine))
                    {
                        s_userInput1 = Calculation.GetCalculateNumber(1);
                        s_userInput1 = Calculator.CheckTrigValue(s_userInput1);
                        s_newResult = calculator.DoOperation(s_userInput1, selectedOpType);
                    }
                    else if (selectedOpType.Equals(Enums.OperationType.SquareRoot) || selectedOpType.Equals(Enums.OperationType.TenX))
                    {
                        s_userInput1 = Calculation.GetCalculateNumber(1);
                        s_newResult = calculator.DoOperation(s_userInput1, selectedOpType);
                    }
                    else
                    {
                        usePreviousResult = "No";
                        if (s_previousResult.HasValue)
                        {
                            usePreviousResult = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Would you like to use the previous result for your next calculation? ")
                                .AddChoices(new[] {"Yes", "No"})
                                );
                        }
                        s_userInput1 = usePreviousResult == "Yes" ? (double) s_previousResult : Calculation.GetCalculateNumber(1);
                        s_userInput2 = Calculation.GetCalculateNumber(2);
                        s_newResult = calculator.DoOperation(s_userInput1, selectedOpType, s_userInput2);
                    }
                    Calculation newCalculation = new Calculation(s_userInput1, selectedOpType, s_newResult, s_userInput2);
                    Calculator.calculationsList.Add(newCalculation);
                    Calculator.calculationsCount++;
                    s_previousResult = s_newResult;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            Console.WriteLine("------------------------\n");
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;
            Console.Clear();
        }
        calculator.Finish();
        return;
    }
}
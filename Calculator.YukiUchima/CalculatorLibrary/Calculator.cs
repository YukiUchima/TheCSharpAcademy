using CalculatorLibrary.Models;
using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
    private static int s_calculatorUseCount;
    public static List<Calculation> calculationsList = new List<Calculation>();
    public static int calculationsCount = 0;

    JsonWriter writer;
    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
    }
    public double DoOperation(double num1, Enums.OperationType op, double? num2 = null)
    {
        double? result = double.NaN;

        Func<double, double?, double> sumOp = (x, y) =>  x + y ?? 0;
        Func<int, int, int> multiplyOp = (x, y) =>  x * y ;

        if (!num2.HasValue)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case Enums.OperationType.SquareRoot:
                    result = Math.Sqrt(num1);
                    writer.WriteValue("Square Root");
                    break;
                case Enums.OperationType.TenX:
                    result = num1 * 10;
                    writer.WriteValue("10(x) Multiplier");
                    break;
                case Enums.OperationType.Cosine:
                    result = Math.Cos(num1); 
                    writer.WriteValue("Cosine()");
                    break;
                case Enums.OperationType.Sine:
                    result = Math.Sin(num1);
                    writer.WriteValue("Sin()");
                    break;
                default:
                    break;
            }
        }
        else
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case Enums.OperationType.Add:
                    result = sumOp(num1, num2);
                    writer.WriteValue("Add");
                    break;
                case Enums.OperationType.Subtract:
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    break;
                case Enums.OperationType.Multiply:
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    break;
                case Enums.OperationType.Divide:
                    while (num2 == 0)
                    {
                        Console.WriteLine("The operation yields a mathematical error - cannot divide by zero!\n");
                        num2 = Calculation.GetCalculateNumber(2);
                    }
                    result = num1 / num2;
                    writer.WriteValue("Divide");
                    break;
                case Enums.OperationType.Power:
                    result = Math.Pow(num1, num2 ?? 0);
                    writer.WriteValue("Power");
                    break;
                default:
                    break;
            }
        }
        writer.WritePropertyName("Result");
        writer.WriteValue(result);
        writer.WriteEndObject();
        s_calculatorUseCount++;

        return Math.Round(result ?? 0, 2);
    }

    public void PreviewCalculations()
    {
        foreach (Calculation calc in calculationsList)
        {
            calc.GetDetails();
        }
    }

    public void Finish()
    {
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }

    public static double CheckTrigValue(double trigValue)
    {
        bool valid = false;
        while (!valid)
        {
            if (trigValue >= -1 && trigValue <= 1) valid = true;
            else
            {
                Console.Write($"The value for the trigonometry function has to be between -1 to 1... ");
                trigValue = Calculation.GetCalculateNumber(1);
            }
        }
        return trigValue;
    }
}


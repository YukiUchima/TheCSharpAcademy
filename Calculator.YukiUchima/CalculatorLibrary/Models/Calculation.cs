﻿using static CalculatorLibrary.Enums;

namespace CalculatorLibrary.Models;

public class Calculation
{
    public double? Operand1 { get; set; }
    public double? Operand2 { get; set; }
    public double CalculationResult { get; set; }
    public char Sign { get; set; }
    public string? OpName { get; set; }

    private string? _OpString { get; set; }

    public Calculation(double? operand1, OperationType operation, double calculationResult, double? operand2 = null)
    {
        Operand1 = operand1;
        Operand2 = operand2;
        CalculationResult = calculationResult;

        switch (operation)
        {
            case Enums.OperationType.Add:
                this.Sign = '+';
                this.OpName = "ADD";
                this._OpString = $"{Operand1} {Sign} {Operand2}";
                break;
            case Enums.OperationType.Subtract:
                this.Sign = '-';
                this.OpName = "SUBTRACT";
                this._OpString = $"{Operand1} {Sign} {Operand2}";
                break;
            case Enums.OperationType.Multiply:
                this.Sign = '*';
                this.OpName = "MULTIPLY";
                this._OpString = $"{Operand1} {Sign} {Operand2}";
                break;
            case Enums.OperationType.Divide:
                this.Sign = '/';
                this.OpName = "DIVIDE";
                this._OpString = $"{Operand1} {Sign} {Operand2}";
                break;
            case Enums.OperationType.Power:
                this.OpName = "POWER";
                this._OpString = $"{Operand1}^{Operand2}";
                break;
            case Enums.OperationType.SquareRoot:
                this.OpName = "ROOT";
                this._OpString = $"{Operand1}^(1/2)";
                break;
            case Enums.OperationType.TenX:
                this.OpName = "MULTIPLER(10X)";
                this._OpString = $"{Operand1} x 10";
                break;
            case Enums.OperationType.Cosine:
                this.OpName = "COS()";
                this._OpString = $"cos({Operand1})";
                break;
            case Enums.OperationType.Sine:
                this.OpName = "SIN()";
                this._OpString = $"sin({Operand1})";
                break;
        }
        GetDetails();
    }

    public void GetDetails()
    {
        Console.WriteLine($"Operation {OpName}\t:\t{_OpString}\t= {CalculationResult}");
    }

    public static double GetCalculateNumber(int currentInputNumber)
    {
        double cleanNum;
        if (currentInputNumber > 1)
        {
            Console.Write("Type your second number, and press enter: ");
        }
        else
        {
            Console.Write("Type a number and press enter: ");
        }

        while (!double.TryParse(Console.ReadLine(), out cleanNum))
        {
            Console.Write("Invalid input. Please enter numerical value: ");
        }
        return cleanNum;
    }
}

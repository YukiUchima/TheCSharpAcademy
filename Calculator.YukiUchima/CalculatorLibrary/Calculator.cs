using Newtonsoft.Json;
//using System.Diagnostics;

namespace CalculatorLibrary;

public class Calculator
{
    JsonWriter writer;
    public Calculator()
    {
        //JSON Logging
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();

        //Trace.Listeners.Add(new TextWriterTraceListener(logFile));
        //Trace.AutoFlush = true;
        //Trace.WriteLine("Starting calculator Log");
        //Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
    }
    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN;
        writer.WriteStartObject();
        writer.WritePropertyName("Operand1");
        writer.WriteValue(num1);
        writer.WritePropertyName("Operand2");
        writer.WriteValue(num2);
        writer.WritePropertyName("Operation");

        switch (op)
        {
            case "a":
                result = num1 + num2;
                //Trace.WriteLine($"{num1} + {num2} = {result}");
                writer.WriteValue("Add");
                break;
            case "s":
                result = num1 - num2;
                writer.WriteValue("Subtract");
                //Trace.WriteLine($"{num1} - {num2} = {result}");
                break;
            case "m":
                result = num1 * num2;
                writer.WriteValue("Multiply");
                //Trace.WriteLine(String.Format("{0} * {1} = {2:0.##}", num1, num2, result));
                break;
            case "d":
                if (num2 != 0)
                {
                    result = num1 / num2;
                    //Trace.WriteLine(String.Format("{0} / {1} = {2:0.##}", num1, num2, result)); 
                }
                writer.WriteValue("Divide");
                break;
            default:
                break;
        }
        writer.WritePropertyName("Result");
        writer.WriteValue(result);
        // -------------- TESTING NEW OBJECT
        // Adds more property/value pairs to current object
        //writer.WritePropertyName("NewObject");
        //writer.WriteStartArray();
        //writer.WriteStartObject();
        //writer.WritePropertyName("Test1");
        //writer.WriteValue("Value1");
        //writer.WritePropertyName("Test2");
        //writer.WriteValue("Value2");
        //writer.WriteEndObject();

        //writer.WriteStartObject();
        //writer.WritePropertyName("Test3");
        //writer.WriteValue("Value3");
        //writer.WriteEndObject();
        //writer.WriteEndArray();

        // END TEST
        writer.WriteEndObject();

        return result;
    }

    public void Finish()
    {
        // Closes previously opened object (Operations) and its array of operations that were written
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }
}

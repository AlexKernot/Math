using System.Text.RegularExpressions;

namespace AlexMath;
internal class Evaluator
{
    // Post fix stack evaluator: https://www.youtube.com/watch?v=bebqXO8H4eA
    public static string StackEval(string[] postfix)
    {
        Regex function = new(@"(sin)|(cos)|(tan)|(abs)|(floor)|(!)");
        string[] compute = new string[3];
        Stack eval = new(); 

        // Pop 2nd number, then first number

        for (int i = 0; i < postfix.Length; i++)
        {

            string currentValue = postfix[i];

            if (String.IsNullOrWhiteSpace(currentValue) || currentValue == ",")
            {
                continue;
            }
            if (currentValue == "NaN")
            {
                return "NaN";
            }
            if(decimal.TryParse(currentValue, out _))
            {
                eval.Push(currentValue);
                continue;
            }
            if (function.IsMatch(currentValue))
            {
                compute[0] = currentValue;
                compute[1] = eval.Pop();
                eval.Push(Funct(compute));
                continue;
            }
            try
            {
                compute[1] = currentValue;
                compute[2] = eval.Pop();
                compute[0] = eval.Pop();
                eval.Push(Simple(compute));
            } catch (Exception)
            {
                Console.WriteLine("There was an error with your inputs at: " + currentValue);
            }
        }
        return eval.Pop();
    }

    // Function for calculating with style number | operator | number
    static string Simple(string[] compute)
    {
        // Checks if the first and third inputs are numbers
        if (decimal.TryParse(compute[0], out decimal a) && decimal.TryParse(compute[2], out decimal b)) {
            switch (compute[1])
            {
                case "+":
                    return (a + b).ToString();

                case "-":
                    return (a - b).ToString();

                case "*":
                    return (a * b).ToString();

                case "/":
                    return (a / b).ToString();

                case "%":
                    return (Functions.Modulo(a, b)).ToString();

                case "mod":
                    return (Functions.Modulo(a, b)).ToString();

                case "GCD":
                    if (int.TryParse(a.ToString(), out int inta) && int.TryParse(b.ToString(), out int intb))
                    {
                        return (Functions.GCD(inta, intb).ToString());
                    }
                    Console.WriteLine("GCD operation can only be between two integers.");
                    return "NaN";

                case "LCM":
                    if (int.TryParse(a.ToString(), out inta) && int.TryParse(b.ToString(), out intb))
                    {
                        return (Functions.LCM(inta, intb).ToString());
                    }
                    Console.WriteLine("LCM operation can only be between two integers.");
                    return "NaN";

                case "^":
                    if (int.TryParse(compute[2], out int number)) {
                        return Functions.Exponents(a, number).ToString();
                    }
                    Console.WriteLine("A power must be raised to a integer.");
                    return "NaN";

                default:
                    Console.WriteLine("Unkown operator detected at: " + compute[0] + compute[1] + compute[2] + " Please check your input and try again.");
                    return "NaN";
            }
        }
        Console.WriteLine("Unkown operator detected at: " + compute[0] + compute[1] + compute[2] + " Please check your input and try again.");
        return "NaN";
    }

    // function for calculating operator | number or number | operator
    static string Funct(string[] compute)
    {
        if (decimal.TryParse(compute[1], out decimal num))
        {
            switch (compute[0])
            {
                case "floor":
                    return (Functions.Floor(num)).ToString();
                case "abs":
                    return (Functions.Absolute(num)).ToString();   
                case "sin":
                    return (Functions.Sin(num)).ToString();
                case "cos":
                    return (Functions.Cos(num)).ToString();
                case "tan":

                case "!":
                    if (int.TryParse(compute[1], out int temp))
                    {
                        return (Functions.Factorial(temp)).ToString();
                    }
                    Console.WriteLine("A factorial must a positive integer");
                    return "NaN";

                default:
                    Console.WriteLine("Unrecognised function at " + compute[0] + compute[1]);
                    return "NaN";
            }
        }
        Console.WriteLine("Unkown function detected at: " + compute[0] + compute[1] + " Please check your input and try again.");
        return "NaN";
    }

}

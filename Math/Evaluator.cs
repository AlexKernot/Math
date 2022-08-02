using System.Text.RegularExpressions;

namespace AlexMath
{
    internal class Evaluator
    {
        // Post fix stack evaluator: https://www.youtube.com/watch?v=bebqXO8H4eA
        public static string StackEval(string[] postfix)
        {
            Regex function = new(@"(sin)|(cos)|(tan)|(abs)|(floor)");
            string[] compute = new string[3];
            stack eval = new(); 

            // Pop 2nd number, then first number

            for (int i = 0; i < postfix.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(postfix[i]))
                {
                    continue;
                }
                if (postfix[i] == "NaN")
                {
                    return "NaN";
                }
                if(decimal.TryParse(postfix[i], out _))
                {
                    eval.Push(postfix[i]);
                    continue;
                }
                if (function.IsMatch(postfix[i]))
                {
                    compute[0] = postfix[i];
                    compute[1] = eval.Pop();
                    eval.Push(Funct(compute));
                    continue;
                }
                try
                {
                    compute[1] = postfix[i];
                    compute[2] = eval.Pop();
                    compute[0] = eval.Pop();
                    eval.Push(Simple(compute));
                } catch (Exception)
                {
                    Console.WriteLine("There was an error with your inputs at: " + postfix[i]);
                }
            }
            return eval.Pop();
        }

        // Function for calculating with style number | operator | number
        static string Simple(string[] compute)
        {
            decimal a = new();
            decimal b = new();

            int temp = 0;

            // Checks if the first and third inputs are numbers
            if (decimal.TryParse(compute[0], out a) && decimal.TryParse(compute[2], out b)) {
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
                        return (AlexMath.Mod.mod(a, b)).ToString();

                    case "mod":
                        return (AlexMath.Mod.mod(a, b)).ToString();

                    case "^":
                        if (b > 0 && int.TryParse(compute[2], out temp)) {
                            return AlexMath.Pow.pow(a, temp).ToString();
                        }
                        Console.WriteLine("For the time being, a power must be raised to a positive integer.");
                        return "NaN";

                    default:
                        Console.WriteLine("Unkown operator detected at: " + compute[0] + compute[1] + compute[2] + " Please check your input and try again. 1");
                        return "NaN";
                }
            }
            Console.WriteLine("Unkown operator detected at: " + compute[0] + compute[1] + compute[2] + " Please check your input and try again.");
            return "NaN";
        }

        // function for calculating operator | number or number | operator
        static string Funct(string[] compute)
        {
            decimal num = new();
            int temp = 0;
            if (decimal.TryParse(compute[1], out num))
            {
                switch (compute[0])
                {
                    case "floor":
                        return (AlexMath.Floor.floor(num)).ToString();
                    case "abs":
                        return (AlexMath.Absolute.abs(num)).ToString();   
                    case "sin":
                        return (AlexMath.Sin.sin(num)).ToString();
                    case "cos":
                        return (AlexMath.Cos.cos(num)).ToString();
                    case "tan":
                        return (AlexMath.Tan.tan(num)).ToString();
                    default:
                        Console.WriteLine("Unrecognised function at " + compute[0] + compute[1]);
                        return "NaN";
                }
            }
            if (compute[1] == "!")
            {
                if (int.TryParse(compute[0], out temp) && temp > 0)
                {
                    return (AlexMath.Factorial.factorial(temp)).ToString();
                }
                Console.WriteLine("A factorial must a positive integer");
                return "NaN";
            }
            Console.WriteLine("Unkown function detected at: " + compute[0] + compute[1] + " Please check your input and try again.");
            return "NaN";
        }

    }
}

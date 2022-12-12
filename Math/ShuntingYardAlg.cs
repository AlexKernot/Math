using System.Text.RegularExpressions;

namespace AlexMath;
internal class ShuntingYardAlg
{
    // Standard Shunting Yard Algorithm for processing a string for calculations. Example: https://www.youtube.com/watch?v=Wz85Hiwi5MY
    public static string[] Algorithm(string input)
    {
        Regex regex = new(@"(?(\D-\d*\.?\d+)(\d*\.?\d+)|(-?\d*\.?\d+))|(\()|(\))|(\{)|(\})|(\[)|(\])|(sin)|(cos)|(tan)|(abs)|(floor)|(\+)|(/)|(\*)|(x)|(-)|(!)|(\^)|(pi)|(GCD)|(,)|(LCM)");

        Regex function = new(@"(sin)|(cos)|(tan)|(abs)|(floor)|(GCD)|(LCM)");
        Stack stack = new();
        Queue queue = new();
        string[] split = regex.Split(input);

        int stackLength = stack.GetLength();
        string stackLastValue = stack.Get(stackLength);

        for (int i = 0; i < split.Length; i++)
        {
            string currentValue = split[i];

            // If the input is just a whitespace, continue
            if (String.IsNullOrWhiteSpace(split[i])|| split[i] == ",")
            {
                continue;
            }

            // Checks if the input is a number, if it is, push it stright to the queue
            if (decimal.TryParse(currentValue, out _))
            {
                queue.Enqueue(currentValue);
                continue;
            }

            // If the input is pi, enqueue the estimated value
            if (currentValue == "pi")
            {
                queue.Enqueue(Functions.pi.ToString());
                continue;
            }

            // If the input is an opening bracket of some kind, push it onto stack.
            if (currentValue.Contains('(') || currentValue.Contains('{') || currentValue.Contains('['))
            {
                stack.Push(currentValue);
                continue;
            }

            //If the input is a function, push it onto the stack.
            if (function.IsMatch(currentValue))
            {
                stack.Push(currentValue);
                continue;
            }

            // If there is a closing bracket, enqueue all operators before the next opening bracket and remove both brackets.
            if (currentValue == ")" || currentValue == "}" || currentValue == "]")
            {
                for (int j = 0; !(stackLastValue.Contains('(') || stackLastValue.Contains('{') || stackLastValue.Contains('[')); j++)
                {
                    string temp = stack.Pop();
                    queue.Enqueue(temp);
                }
                stack.Pop();
                continue;
            }

            // If the previous operator in the stack contains a bracket, push the current operator
            if (stackLastValue.Contains('(') || stackLastValue.Contains('{') || stackLastValue.Contains('['))
            {
                stack.Push(currentValue);
                continue;
            }

            // If the operator has a lower precendece then the operator in the stack, pop previous operation and enqueue it before pushing current operator
            if (Precedence(currentValue) <= Precedence(stackLastValue) && Left(currentValue))
            {
                for (int j =0; Precedence(currentValue) <= Precedence(stackLastValue); j++) {
                    queue.Enqueue(stack.Pop());
                }
                stack.Push(currentValue);
                continue;
            }

            // If this operator has a precendence, it is a recognised operator and is pushed to the stack
            if (Precedence(currentValue) != -1)
            {
                stack.Push(currentValue);
                continue;
            }

            // Else, throw error
            Console.WriteLine("Unknown input: '" + currentValue + "'");
            string[] error = { "NaN" };
            return error;
        }

        // Put the rest of the stack into the stack and return 
        for (int i = stackLength; i >= 0; i--)
        {
            queue.Enqueue(stack.Pop());
        }
        return queue.Flush(stackLength);
    }

    // Returns the mathematical precendence of an operator following BEDMAS
    public static int Precedence(string input)
    {
        return input switch
        {
            "!" => 7,
            "^" => 6,
            "*" => 5,
            "x" => 5,
            "/" => 5,
            "-" => 4,
            "+" => 4,
            _ => -1,
        };
    }

    // Returns true if an operator goes to the left of a number
    public static bool Left(string input)
    {
        return input switch
        {
            "^" => false,
            "*" => true,
            "x" => true,
            "/" => true,
            "-" => true,
            "+" => true,
            "!" => true,
            _ => false,
        };
    }
}

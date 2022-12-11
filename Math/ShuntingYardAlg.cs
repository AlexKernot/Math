using System.Text.RegularExpressions;

namespace AlexMath;
internal class ShuntingYardAlg
{
    const decimal pi = 3.141592653589793M;
    // Standard Shunting Yard Algorithm for processing a string for calculations. Example: https://www.youtube.com/watch?v=Wz85Hiwi5MY
    public static string[] Algorithm(string input)
    {
        Regex regex = new(@"(?(\D-\d*\.?\d+)(\d*\.?\d+)|(-?\d*\.?\d+))|(\()|(\))|(\{)|(\})|(\[)|(\])|(sin)|(cos)|(tan)|(abs)|(floor)|(\+)|(/)|(\*)|(x)|(-)|(!)|(\^)|(pi)|(GCD)|(,)|(LCM)");

        Regex function = new(@"(sin)|(cos)|(tan)|(abs)|(floor)|(GCD)|(LCM)");
        Stack stack = new();
        Queue queue = new();
        string[] split = regex.Split(input);

        for (int i = 0; i < split.Length; i++)
        {
            // If the input is just a whitespace, continue
            if (String.IsNullOrWhiteSpace(split[i])|| split[i] == ",")
            {
                continue;
            }

            // Checks if the input is a number, if it is, push it stright to the queue
            if (decimal.TryParse(split[i], out _))
            {
                queue.Enqueue(split[i]);
                continue;
            }

            // If the input is pi, enqueue the estimated value
            if (split[i] == "pi")
            {
                queue.Enqueue(pi.ToString());
                continue;
            }

            // If the input is an opening bracket of some kind, push it onto stack.
            if (split[i].Contains('(') || split[i].Contains('{') || split[i].Contains('['))
            {
                stack.Push(split[i]);
                continue;
            }

            //If the input is a function, push it onto the stack.
            if (function.IsMatch(split[i]))
            {
                stack.Push((split[i]));
                continue;
            }

            // If there is a closing bracket, enqueue all operators before the next opening bracket and remove both brackets.
            if (split[i] == ")" || split[i] == "}" || split[i] == "]")
            {
                for (int j = 0; !(stack.Get(stack.length).Contains('(') || stack.Get(stack.length).Contains('{') || stack.Get(stack.length).Contains('[')); j++)
                {
                    string temp = stack.Pop();
                    queue.Enqueue(temp);
                }
                stack.Pop();
                continue;
            }

            // If the previous operator in the stack contains a bracket, push the current operator
            if (stack.Get(stack.length).Contains('(') || stack.Get(stack.length).Contains('{') || stack.Get(stack.length).Contains('['))
            {
                stack.Push(split[i]);
                continue;
            }

            // If the operator has a lower precendece then the operator in the stack, pop previous operation and enqueue it before pushing current operator
            if (Precedence(split[i]) <= Precedence(stack.Get(stack.length)) && Left(split[i]))
            {
                for (int j =0; Precedence(split[i]) <= Precedence(stack.Get(stack.length)); j++) {
                    queue.Enqueue(stack.Pop());
                }
                stack.Push(split[i]);
                continue;
            }

            // If this operator has a precendence, it is a recognised operator and is pushed to the stack
            if (Precedence(split[i]) != -1)
            {
                stack.Push(split[i]);
                continue;
            }

            // Else, throw error
            Console.WriteLine("Unknown input: '" + split[i] + "'");
            string[] error = { "NaN" };
            return error;
        }

        // Put the rest of the stack into the stack and return 
        for (int i = stack.length; i >= 0; i--)
        {
            queue.Enqueue(stack.Pop());
        }
        return queue.Flush(stack.length);
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

public class Stack
{
    string[] data = new string[32];
    public int length = 0;

    public void Push(string input)
    {
        data[length] = input;
        length++;
        return;

    }

    public string Pop()
    {
        if (length == 0)
        {
            return "";
        }
        string temp = data[length-1];
        data[length-1] = "";
        length--;
        return temp;
    }

    public string Get(int index)
    {
        if (length == 0)
        {
            return "";
        }
        if (data[index - 1] == null)
        {
            return "";
        }
        return data[index - 1];
    }
}

public class Queue
{
    string[] data = new string[32];
    int beginning = 0;
    int length = 0;

    public void Enqueue (string input)
    {
        data[length] = input;
        length++;
        return;
    }

    public string[] Flush(int stackSize)
    {
        string[] final = new string[stackSize + length];
        int j = 0;
        for(int i = beginning; i < length; i++)
        {
            final[j] = data[i];
            j++;
        }
        return final;
    }
}

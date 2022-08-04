using System.Text.RegularExpressions;

namespace AlexMath
{
    internal class ShuntingYardAlg
    {
        const decimal pi = 3.141592653589793M;
        // Standard Shunting Yard Algorithm for processing a string for calculations. Example: https://www.youtube.com/watch?v=Wz85Hiwi5MY
        public static string[] Algorithm(string input)
        {
            Regex regex = new(@"(?(\D-\d*\.?\d+)(\d*\.?\d+)|(-?\d*\.?\d+))|(\()|(\))|(\{)|(\})|(\[)|(\])|(sin)|(cos)|(tan)|(abs)|(floor)|(\+)|(/)|(\*)|(x)|(-)|(!)|(\^)|(pi)|(GCD)|(,)|(LCM)");

            Regex function = new(@"(sin)|(cos)|(tan)|(abs)|(floor)|(GCD)|(LCM)");
            stack stack = new();
            queue queue = new();
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

                if (split[i] == "pi")
                {
                    queue.Enqueue(pi.ToString());
                    continue;
                }

                // If the input is an opening bracket of some kind, send it stright to the stack
                if (split[i].Contains('(') || split[i].Contains('{') || split[i].Contains('['))
                {
                    stack.Push(split[i]);
                    continue;
                }

                //If the input is a function, throw it onto the stack
                if (function.IsMatch(split[i]))
                {
                    stack.Push((split[i]));
                    continue;
                }

                // If there is a closing bracket, push all operators before the next opening bracket to the queue and remove both brackets.
                if (split[i] == ")" || split[i] == "}" || split[i] == "]")
                {
                    for (int j = 0; !(stack.Get(stack.length).Contains("(") || stack.Get(stack.length).Contains("{") || stack.Get(stack.length).Contains("[")); j++)
                    {
                        string temp = stack.Pop();
                        queue.Enqueue(temp);
                    }
                    stack.Pop();
                    continue;
                }

                // If the previous operator in the stack contains a bracket, push the current operator to the stack
                if (stack.Get(stack.length).Contains("(") || stack.Get(stack.length).Contains("{") || stack.Get(stack.length).Contains("["))
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

                // My lazy way of saying: if this is a recognised operator, push it to the stack
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
            for (int i = stack.length; i >= 0; i--)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue.Flush(stack.length);
        }

        public static int Precedence(string input)
        {
            switch(input)
            {
                case ("^"):
                    return 6;
                case ("*"):
                    return 5;
                case ("x"):
                    return 5;
                case ("/"):
                    return 5;
                case ("-"):
                    return 4;
                case ("+"):
                    return 4;
                default:
                    return -1;
            }
        }
        public static bool Left(string input)
        {
            switch (input)
            {
                case ("^"):
                    return false;
                case ("*"):
                    return true;
                case ("x"):
                    return true;
                case ("/"):
                    return true;
                case ("-"):
                    return true;
                case ("+"):
                    return true;
                case ("!"):
                    return false;
                default:
                    return false;
            }
        }
    }

    public class stack
    {
        string[] data = new string[32];
        public int length = 0;

        // Adds a value to the end of the stack
        public void Push(string input)
        {
            try
            {
                data[length] = input;
                length++;
                return;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }

        // Returns the last variable in the stack and removes it
        public string Pop()
        {
            if (length == 0)
            {
                return "";
            }
            try
            {
                string temp = data[length-1];
                data[length-1] = "";
                length--;
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
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

    public class queue
    {
        string[] data = new string[32];
        int beginning = 0;
        int length = 0;

        // Adds a value to the end of the queue
        public void Enqueue (string input)
        {
            try
            {
                data[length] = input;
                length++;
                return;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
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
}

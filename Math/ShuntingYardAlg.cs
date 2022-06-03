using System.Text.RegularExpressions;

namespace AlexMath
{
    internal class ShuntingYardAlg
    {
        // Standard Shunting Yard Algorithm for processing a string for calculations. Example: https://www.youtube.com/watch?v=Wz85Hiwi5MY
        public static string Algorithm(string input)
        {
            Regex regex = new Regex(@"(\d*\.?\d+)|(|)");
            stack stack = new stack();
            queue queue = new queue();
            string[] split = regex.Split(input);


            // TODO: change to a switch function
            for (int i = 0; i < split.Length; i++)
            {
                Console.WriteLine(split[i]);
                // If the input is just a whitespace, continue
                if (split[i] == " " || split[i] == "" || split[i] == null)
                {
                    continue;
                }
                // Checks if the input is a number, if it is, push it stright to the queue
                if (int.TryParse(split[i], out _))
                {
                    queue.Enqueue(split[i]);
                    continue;
                }

                // If the input is an opening bracket of some kind, send it stright to the stack
                if (split[i].Contains("(") || split[i].Contains("{") || split[i].Contains("["))
                {
                    stack.Push(split[i]);
                    continue;
                }
                // TODO: Closing brackets

                if (split[i] == ")" || split[i] == "}" || split[i] == "]")
                {
                    for (int j = 0; !(stack.Get(stack.length).Contains("(") || stack.Get(stack.length).Contains("{") || stack.Get(stack.length).Contains("[")); j++)
                    {
                        queue.Enqueue(stack.Pop());
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
                if (Precedence(split[i]) <= Precedence(stack.Get(stack.length)))
                {
                    queue.Enqueue(stack.Pop());
                    stack.Push(split[i]);
                    continue;
                }

                // Else, push to operator stack
                stack.Push(split[i]);
            }
            for (int i = 0; i < stack.length; i++)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue.Flush();
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
                Console.WriteLine("Push " + input);
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
                Console.WriteLine("Enqueue " + input + " " + length);
                return;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }

        public string Flush()
        {
            string final = "";

            for(int i = beginning; i <= length; i++)
            {
                final += data[i];
            }
            Console.WriteLine(final);
            return final;
        }
    }
}

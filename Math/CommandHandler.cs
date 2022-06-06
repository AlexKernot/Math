using System.Text.RegularExpressions;

namespace AlexMath
{
    internal class CommandHandler
    {
        const double pi = 3.141592653589793;

        // Searches for word + space OR ( + number OR pi
        static Regex rx = new(@"\w+(\s|\()([-]?\d+\.?\d*|pi)", RegexOptions.IgnoreCase);

        public static string Handler(string equation)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(equation))
                {
                    return "No equation specified. Please try again.";
                }
                string[] postFix = ShuntingYardAlg.Algorithm(equation);

                string postFixPrint = "Postfix = ";

                for (int i = 0; i < postFix.Length; i++)
                {
                    postFixPrint += postFix[i];
                }
                Console.WriteLine(postFixPrint);

                return Evaluator.StackEval(postFix);
            } catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}

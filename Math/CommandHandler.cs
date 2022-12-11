using System.Text.RegularExpressions;

namespace AlexMath
{
    internal class CommandHandler
    {
        public static string Handler(string equation)
        {
            if (String.IsNullOrWhiteSpace(equation))
            {
                return "No equation specified. Please try again.";
            }
            string[] postFix = ShuntingYardAlg.Algorithm(equation);

            // Purely for debugging odd behaviour
            string postFixPrint = "Postfix = ";

            for (int i = 0; i < postFix.Length; i++)
            {
                postFixPrint += postFix[i];
            }

            // Purely for debugging odd behaviour
            Console.WriteLine(postFixPrint);

            return Evaluator.StackEval(postFix);
        }
    }
}

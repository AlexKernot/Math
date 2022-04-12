using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AlexMath
{
    internal class CommandHandler
    {
        const double pi = 3.141592653589793;

        // Searches for word + space OR ( + number OR pi
        static Regex rx = new Regex(@"\w+(\s|\()([-]?\d+\.?\d*|pi)", RegexOptions.IgnoreCase);

        static Regex mod = new Regex(@"\d\s?(%|mod)\s?\d", RegexOptions.IgnorePatternWhitespace);

        // Searches for space or ( just for splitting arguments from functions.
        static Regex split = new Regex(@"(\s|\()", RegexOptions.IgnoreCase);

        public static double handler(string equation)
        {
            string match = rx.Match(equation).ToString();

            if (rx.IsMatch(equation))
            {
                return Function(match);
            }

            match = mod.Match(equation).ToString();

            if (mod.IsMatch(equation))
            {
                return Modulo(match);
            }

            Console.WriteLine("The equation could not be correctly decoded. Please try again");
            return double.NaN;
        }

        public static double Function(string equation)
        {
            string[] output = split.Split(equation);

            if (output[2] == "pi")
                output[2] = pi.ToString();

            double argument;
            if (!double.TryParse(output[2], out argument))
            {
                Console.WriteLine("Invalid argument detected.");
                return double.NaN;
            }

            switch (output[0].ToLower(new System.Globalization.CultureInfo("en-US", false)))
            {
                case ("sin"):
                    return Sin.sin(argument);

                case ("abs"):
                    return Absolute.abs(argument);

                case ("floor"):
                    return Floor.floor(argument);

                case ("cos"):
                    return Cos.cos(argument);

                case ("tan"):
                    return Tan.tan(argument);
                default:
                    Console.WriteLine("The equation could not be correctly decoded. Please try again");
                    return double.NaN;
            }
        }
        public static double Modulo(string equation)
        {
            string[] output = Regex.Split(equation, pattern: @"%|\s%\s");

            double argument1 = 0;
            double argument2 = 0;

            if (!double.TryParse(output[0], out argument1) || !double.TryParse(output[1], out argument2))
            {
                Console.WriteLine("An error occured processing modulo.");
                return Double.NaN;
            }

            return Mod.mod(argument1, argument2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal class Tan
    {
        public static double tan(double input)
        {
            double sin = Math.Sin(input);
            double cos = Math.Cos(input);

            return sin / cos;
        }
    }
}

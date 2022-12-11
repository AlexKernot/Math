using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal partial class Functions
    {
        public static decimal Tan(decimal input)
        {
            decimal sin = Functions.Sin(input);
            decimal cos = Functions.Cos(input);

            return sin / cos;
        }
    }
}

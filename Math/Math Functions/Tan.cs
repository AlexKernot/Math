using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal class Tan
    {
        public static decimal tan(decimal input)
        {
            decimal sin = Sin.sin(input);
            decimal cos = Cos.cos(input);

            return sin / cos;
        }
    }
}

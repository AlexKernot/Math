using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal class Cos
    {
        const double pi = 3.141592653589793;
        public static double cos(double input)
        {
            input += pi / 2;

            return Sin.sin(input);

        }
    }
}

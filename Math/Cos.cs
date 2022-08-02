using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal class Cos
    {
        const decimal pi = 3.141592653589793M;
        public static decimal cos(decimal input)
        {
            input += pi / 2;

            return Sin.sin(input);

        }
    }
}

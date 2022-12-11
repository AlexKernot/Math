using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal partial class Functions
    {
        public static decimal Cos(decimal input)
        {
            input += pi / 2;

            return Functions.Sin(input);

        }
    }
}

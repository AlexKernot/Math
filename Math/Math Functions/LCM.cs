using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal partial class Functions
    {
        public static decimal LCM(int a, int b)
        {
            if (a == 0)
            {
                return Functions.Floor(Functions.Absolute(b));
            }

            if (b == 0)
            {
                return Functions.Floor(Functions.Absolute(a));
            }

            if (a == 0 && b == 0)
            {
                return 0;
            }
           return Functions.Floor((Functions.Absolute(a * b) / Functions.GCD(a, b)));
        }
    }
}

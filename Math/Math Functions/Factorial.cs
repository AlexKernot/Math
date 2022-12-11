using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal partial class Functions
    {
        public static ulong Factorial(int n)
        {
            uint start = (uint)n;

            ulong fact = start;
            if (start == 0)
            {
                return 1;
            }
            for (uint i = start - 1; i > 0; i--)
            {
                fact *= i;
            }

            return fact;
        }
    }
}

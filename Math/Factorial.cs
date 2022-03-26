using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal class Factorial
    {
        public static int factorial(int n)
        {
            for (int i = n - 1; i > 0; i--)
            {
                n *= i;
            }

            return n;
        }
    }
}

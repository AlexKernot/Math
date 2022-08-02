using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal class Factorial
    {
        public static long factorial(int n)
        {
            long fact = n;
            for (int i = n - 1; i > 0; i--)
            {
                fact *= i;
            }

            return fact;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    public class LCM
    {
        public static int lcm(int a, int b)
        {
            if (a == 0)
            {
                return Floor.floor(Absolute.abs(b));
            }

            if (b == 0)
            {
                return Floor.floor(Absolute.abs(a));
            }

            if (a == 0 && b == 0)
            {
                return 0;
            }
           return Floor.floor((Absolute.abs(a * b) / GCD.gcd(a, b)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    public class GCD
    {
        public static int gcd(int a, int b)
        {
            int tempA = a;
            int tempB = b;
            int temp = 0;

            while (true)
            {
                if (tempA == 0)
                {
                    return tempB;
                }
                if (tempB == 0)
                {
                    return tempA;
                }

                temp = tempA;
                tempA = tempB;
                tempB = (int)Mod.mod(temp, tempB);
            }
        }
    }
}

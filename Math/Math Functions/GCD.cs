using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    internal partial class Functions
    {
        public static int GCD(int a, int b)
        {
            int tempA = a;
            int tempB = b;
            int temp;

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
                tempB = (int)Functions.Modulo(temp, tempB);
            }
        }
    }
}

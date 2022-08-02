using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexMath
{
    public class Test
    {
        public static void test(int powers)
        {
            double one = 0;
            double two = 0;

            for (int i = 0; i < powers; i++)
            {
                one = Sin.sin(Math.PI, i);
                two = Math.Sin(Math.PI);

                Console.WriteLine(one + " " + two + " " + Absolute.abs(two - one));
            }
        }

    }
}

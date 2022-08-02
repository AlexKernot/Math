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
            decimal one = 0;
            decimal two = 0;

            for (int i = 0; i < powers; i++)
            {
                one = Sin.sin(2, i);
                two = (decimal)Math.Sin(2);
                Console.WriteLine(i + " " + one + " " + two + " " + Absolute.abs(two - one));
            }
        }

    }
}

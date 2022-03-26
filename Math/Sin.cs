namespace AlexMath
{
    // Taylor series: x - x^3/3! + x^5/5! - x^7/7! + x^9/9! - x^11/11! + x^13/13!
    // Domain: mod(x + pi, 2pi) - pi

    public class Sin
    {
        const double pi = 3.141592653589793;

        public static double sin(double n)
        {
            if (n > pi || n < -pi)
                n = Mod.mod(n + pi, 2 * pi) - pi;

            double sinx = 0;
            double num = 0;

            for (int i = 1; i < 14; i += 2)
            {
                num = Pow.pow(n, i) / Factorial.factorial(i);

                if (i == 3 || i == 7 || i == 11)
                    num *= -1;

                sinx += num;
            }

            return sinx;
        }
    }
}

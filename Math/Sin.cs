namespace AlexMath
{
    // Taylor series: x - x^3/3! + x^5/5! - x^7/7! + x^9/9! - x^11/11! + x^13/13!
    // Domain: mod(x + pi, 2pi) - pi

    public class Sin
    {
        const double pi = 3.141592653589793;

        public static decimal sin(double n, int pow = 14)
        {
            if (n > Math.PI || n < -Math.PI)
                n = Mod.mod(n + pi, 2 * pi) - pi;

            decimal sinx = 0;
            decimal num = 0;

            for (int i = 0; i < pow; i++)
            {
                num = (Pow.pow(-1, i) * Pow.pow(n, 2 * i + 1)) / (Factorial.factorial(2 * i + 1));
                sinx += num;
                Console.WriteLine((Pow.pow(-1, i) * Pow.pow(n, 2 * i + 1)) + " " + (Factorial.factorial(2 * i + 1)) + " " + i + " " + num + " " + sinx);
            }

            return sinx;
        }
    }
}

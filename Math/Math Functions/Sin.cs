namespace AlexMath;

// Taylor series: x - x^3/3! + x^5/5! - x^7/7! + x^9/9! - x^11/11! + x^13/13!
// Domain: mod(x + pi, 2pi) - pi

internal partial class Functions
{
    public static decimal Sin(decimal n, int pow = 11)
    {
        if (n > pi || n < -pi)
            n = Functions.Modulo(n + pi, 2 * pi) - pi;

        decimal sinx = 0;
        decimal num = 0;

        for (int i = 0; i < pow; i++)
        {
            num = (Functions.Exponents(-1, i) * Functions.Exponents(n, 2 * i + 1)) / (Functions.Factorial(2 * i + 1));
            sinx += num;
        }

        return sinx;
    }
}

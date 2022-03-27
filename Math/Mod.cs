namespace AlexMath
{
    // Euclidian modulo: r = a - |b| floor(a/|b|)
    internal class Mod
    {
        public static double mod(double a, double b)
        {
            b = Absolute.abs(b);

            double r = a - b * Floor.floor(a / b);
            return r;
        }
    }
}

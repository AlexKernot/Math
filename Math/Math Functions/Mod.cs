namespace AlexMath
{
    // Euclidian modulo: r = a - |b| floor(a/|b|)
    internal class Mod
    {
        public static decimal mod(decimal a, decimal b)
        {
            b = Absolute.abs(b);

            decimal r = a - b * Floor.floor(a / b);
            return r;
        }
    }
}

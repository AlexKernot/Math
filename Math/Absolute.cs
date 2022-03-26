namespace AlexMath
{
    internal class Absolute
    {
        public static double abs(double n)
        {
            if (n < 0)
                n *= -1;
            return n;
        }
    }
}

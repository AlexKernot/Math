namespace AlexMath
{
    internal class Absolute
    {
        public static decimal abs(decimal n)
        {
            if (n < 0)
                n *= -1;
            return n;
        }
    }
}

namespace AlexMath
{
    internal class Floor
    {
        public static int floor(double n)
        {
            return (int)Decimal.Truncate((decimal)n);
        }
    }
}

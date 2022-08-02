namespace AlexMath
{
    internal class Floor
    {
        public static int floor(decimal n)
        {
            return (int)Decimal.Truncate(n);
        }
    }
}

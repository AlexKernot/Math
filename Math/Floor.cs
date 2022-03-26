namespace AlexMath
{
    // TODO: Find a better way to do a floor function
    internal class Floor
    {
        public static int floor(double n)
        {
            return (int)Decimal.Truncate((decimal)n);
        }
    }
}

namespace AlexMath
{
    internal class Pow
    {
        // TODO: implement the ability to do fraction/roots with powers
        public static decimal pow(decimal a, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            decimal RunningTotal = a;

             for (int i = 1; i < n; i++)
            {
                RunningTotal *= a;
            }

             return RunningTotal;
        }
    }
}

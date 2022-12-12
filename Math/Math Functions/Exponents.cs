namespace AlexMath;
internal partial class Functions
{
    public static decimal Exponents(decimal a, int n)
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

        if (n < 0)
        {
            RunningTotal = 1 / RunningTotal;
        }
            return RunningTotal;
    }
}

namespace AlexMath
{
    internal class Pow
    {
        // TODO: implement the ability to do fraction/roots with powers
        public static double pow(double a, int n)
        {
            double RunningTotal = a;

             for (int i = 1; i < n; i++)
            {
                RunningTotal *= a;
            }

             return RunningTotal;
        }
    }
}

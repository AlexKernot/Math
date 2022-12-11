namespace AlexMath;
internal partial class Functions
{
    public static decimal Absolute(decimal n)
    {
        if (n < 0)
            n *= -1;
        return n;
    }
}

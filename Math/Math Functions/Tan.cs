namespace AlexMath;
internal partial class Functions
{
    public static decimal Tan(decimal input)
    {
        decimal sin = Functions.Sin(input);
        decimal cos = Functions.Cos(input);

        return sin / cos;
    }
}
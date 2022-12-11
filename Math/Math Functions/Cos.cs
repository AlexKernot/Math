namespace AlexMath;
internal partial class Functions
{
    public static decimal Cos(decimal input)
    {
        input += pi / 2;

        return Functions.Sin(input);

    }
}

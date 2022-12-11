namespace AlexMath;

// Euclidian modulo: r = a - |b| floor(a/|b|)
internal partial class Functions
{
    public static decimal Modulo(decimal a, decimal b)
    {
        b = Functions.Absolute(b);

        decimal r = a - b * Functions.Floor(a / b);
        return r;
    }
}
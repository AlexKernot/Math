namespace AlexMath;
internal partial class Functions
{
    public static int GCD(int a, int b)
    {
        int tempA = a;
        int tempB = b;
        int temp = 0;

        while (true)
        {
            if (tempA == 0)
            {
                return tempB;
            }
            if (tempB == 0)
            {
                return tempA;
            }

            temp = tempA;
            tempA = tempB;
            tempB = (int)Functions.Modulo(temp, tempB);
        }
    }
}

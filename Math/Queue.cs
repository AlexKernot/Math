namespace AlexMath;
public class Queue
{
    readonly string[] data = new string[32];
    int length = 0;

    public void Enqueue(string input)
    {
        data[length] = input;
        length++;
        return;
    }

    public string[] Flush(int stackSize)
    {
        string[] final = new string[stackSize + length];
        int j = 0;
        for (int i = 0; i < length; i++)
        {
            final[j] = data[i];
            j++;
        }
        return final;
    }
}

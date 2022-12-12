namespace AlexMath;
public class Stack
{
    readonly string[] data = new string[32];
    private int length = 0;

    public void Push(string input)
    {
        data[length] = input;
        length++;
        return;

    }

    public string Pop()
    {
        if (length == 0)
        {
            return "";
        }
        string temp = data[length - 1];
        data[length - 1] = "";
        length--;
        return temp;
    }

    public string Get(int index)
    {
        if (length == 0)
        {
            return "";
        }
        if (data[index - 1] == null)
        {
            return "";
        }
        return data[index - 1];
    }

    public int GetLength()
    {
        return length;
    }
}

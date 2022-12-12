using System.Diagnostics;

namespace AlexMath;
public class Math
{
    static void Main()
    {
        Stopwatch stopWatch = new();
        while (true)
        {
            Console.WriteLine("Please enter an equation to solve");
            string response = Console.ReadLine() + "";

            stopWatch.Start();
            string answer = CommandHandler.Handler(response);
            stopWatch.Stop();

            double time = stopWatch.ElapsedTicks / 10000;

            Console.WriteLine("= " + answer + " (Processed in " + time + " ms)\n\n");
            stopWatch.Reset();
        }
    }
}

internal partial class Functions
{
    public const decimal pi = 3.141592653589793M;
}


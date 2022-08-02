using System.Diagnostics;

namespace AlexMath
{
    internal class Alex
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sin.sin(2, 20));
            Console.WriteLine(Math.Sin(2));
            Console.WriteLine(Sin.sin(Math.PI));
            Console.WriteLine(Math.Sin(Math.PI));
          //  Test.test(32);
          //  Stopwatch stopWatch = new();       
          //  while (true)
          //{
          //      Console.WriteLine("Please enter an equation to solve");
          //      string response = Console.ReadLine() + "";

          //      stopWatch.Start();
          //      string answer = CommandHandler.Handler(response);
          //      stopWatch.Stop();

          //      double time = stopWatch.ElapsedTicks / 10000;

          //      Console.WriteLine("= " + answer + " (Processed in " + time + " ms)\n\n");
          //      stopWatch.Reset();
          // }
        }
    }
}

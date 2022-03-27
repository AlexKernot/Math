using System.Diagnostics;

namespace AlexMath
{
    internal class Alex
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("Calculator Initialised. Currently testing Sin(x). Please enter an x value.");          
            while (true)
          {
                // TODO: Create response time ("Request was processed in ___ ms")
                string response = Console.ReadLine();

                stopWatch.Start();
                double answer = CommandHandler.handler(response);
                stopWatch.Stop();

                double time = stopWatch.ElapsedTicks / 10000;

                Console.WriteLine("= " + answer + " (Processed in " + time + " ms)");
                stopWatch.Reset();
           }
        }
    }
}

using System;

namespace AlexMath
{
    internal class Alex
    {
        static void Main(string[] args)
        {
            const double pi = 3.141592653589793;

            Console.WriteLine("Calculator Initialised. Currently testing Sin(x). Please enter an x value.");          
            while (true)
          {
                    string response = Console.ReadLine();

                    double n = 0;

                    bool isNum = double.TryParse(response, out n);

                    if (!isNum)
                    {
                        Console.WriteLine("Invalid number detected, please try again.");
                        continue;
                    }

                    double r = Sin.sin(n);

                    Console.WriteLine(r);
                
           }
        }
    }
}

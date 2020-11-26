using System;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputTactSize = RequestInput(Constants.Input.Size);
            var inputStaves = RequestInput(Constants.Input.Notes);
            var report = Processor.Execute(inputTactSize, inputStaves);

            Output(report);
        }

        static string RequestInput(string inputParameterName)
        {
            Console.Write($"{inputParameterName} : ");
            return Console.ReadLine();
        }

        static void Output(string report)
        {
            Console.WriteLine($"{Constants.Messages.OutputTitle} : {report}");
            Console.ReadKey();
        }
    }
}

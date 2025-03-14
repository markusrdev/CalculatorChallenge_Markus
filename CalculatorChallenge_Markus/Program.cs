using CalculatorChallenge_Markus.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorChallenge_Markus
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjectionSetup.ConfigureServices();
            var calculator = serviceProvider.GetService<ICalculatorService>();

            while (true)
            {
                Console.WriteLine("Enter numbers seperated by comma (or press Enter to exit):");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;

                try
                {
                    int result = calculator.Add(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
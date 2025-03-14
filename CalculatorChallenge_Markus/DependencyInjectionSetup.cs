using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorChallenge_Markus.Interfaces;
using CalculatorChallenge_Markus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorChallenge_Markus
{
    public static class DependencyInjectionSetup
    {
        public static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection().AddSingleton<IParserService, ParserService>()
                .AddSingleton<ICalculatorService, CalculatorService>()
                .BuildServiceProvider();


        }
    }
}

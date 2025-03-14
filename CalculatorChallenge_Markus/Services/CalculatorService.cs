using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorChallenge_Markus.Interfaces;

namespace CalculatorChallenge_Markus.Services
{
    public class CalculatorService : ICalculatorService
    {

        private readonly IParserService _parserService;

        public CalculatorService(IParserService parserService)
        {
            _parserService = parserService;
        }

        public int Add(string input)
        {
            var numbers = _parserService.ParseNumbers(input);

            return numbers.Sum();
        }
    }
}

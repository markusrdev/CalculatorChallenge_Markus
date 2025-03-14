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

        private readonly IValidatorService _validatorService;

        public CalculatorService(IParserService parserService, IValidatorService validatorService)
        {
            _parserService = parserService;
            _validatorService = validatorService;
        }

        public int Add(string input)
        {
            var numbers = _parserService.ParseNumbers(input); //Parse the input to return numbers or zero where necessary
            _validatorService.ValidateNumbers(numbers); //Validate the numbers to check if any of them is negative

            //Step 5: Filter numbers greater than 1000
            numbers = _validatorService.FilterNumbers(numbers);

            return numbers.Sum();
        }
    }
}

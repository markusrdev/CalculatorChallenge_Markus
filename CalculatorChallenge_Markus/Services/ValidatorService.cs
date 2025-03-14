using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorChallenge_Markus.Interfaces;

namespace CalculatorChallenge_Markus.Services
{
    public class ValidatorService : IValidatorService
    {
        public void ValidateNumbers(List<int> numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0).ToList();
            
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negative numbers are not allowed: {string.Join(", ", negativeNumbers)}");
            }
            
            
        }
    }
}

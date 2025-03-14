using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorChallenge_Markus.Interfaces;

namespace CalculatorChallenge_Markus.Services
{
    public class ParserService : IParserService
    {
        public List<int> ParseNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int> { 0 };
            }

            var numbers = input.Split(','); //Comma delimeter 
            if (numbers.Length > 2)
            {
                throw new ArgumentException("Only up to two numbers allowed."); //Throw exception if more than 2 numbers are supplied
            }

            return numbers.Select(n => int.TryParse(n, out int num) ? num : 0).ToList(); //Check the numbers if any of them is not an integer, return 0 in place of that
        }
    }
}

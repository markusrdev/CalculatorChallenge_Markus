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
        private static readonly char[] Delimiters = { ',', '\n' }; //Add the new line Delimeter for parsing the numbers
        public List<int> ParseNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int> { 0 };
            }

            string numbersPartOfInput = input;
            char customDelimiter = '\0'; //Default to no custom delimiter
            if (input.StartsWith("//") && input.Length > 3 && input[3] == '\n') //Check for the format of accepting a custom delimiter.
            {
                //Extract single-character delimiter
                customDelimiter = input[2];
                numbersPartOfInput = input.Substring(4); //Remove the custom delimiter part from the input

            }
            var delimiters = Delimiters.Concat(customDelimiter != '\0' ? new[] { customDelimiter } : Array.Empty<char>()).ToArray(); //Add the custom delimiter to the existing delimiters
           
            var numbers = numbersPartOfInput.Split(delimiters, StringSplitOptions.None)
                .Select(n => int.TryParse(n, out int num) ? num :0)
                .ToList();


            return numbers;
        }
    }
}

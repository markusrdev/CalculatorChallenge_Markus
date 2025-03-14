using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
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
            List<string> delimiters = Delimiters.Select(d => d.ToString()).ToList();

            // Check for custom delimiters in the format: // //[delimiter]\n{numbers}
            if (input.StartsWith("//"))
            {
                var match = Regex.Match(input, @"^//(\[.*\])\n"); // Match //[delimiter]\n
                if (match.Success)
                {
                    string delimiterSection = match.Groups[1].Value;
                    numbersPartOfInput = input.Substring(match.Length); // Remove the custom delimiter section from the input

                    delimiters.AddRange(Regex.Matches(delimiterSection, @"\[(.*?)\]").Cast<Match>().Select(m => m.Groups[1].Value));
                }
                else if(input.Length > 3 && input[3] == '\n')
                {
                   
                    delimiters.Add(input[2].ToString());
                    numbersPartOfInput = input.Substring(4);                 }
            }
            // Split the numbers part of the input using the delimiters
            var numbers = numbersPartOfInput.Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(n => int.TryParse(n, out int num) ? num :0)
                .ToList();


            return numbers;
        }
    }
}

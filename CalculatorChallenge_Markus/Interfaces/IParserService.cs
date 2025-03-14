using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorChallenge_Markus.Interfaces
{
    public interface IParserService
    {
        List<int> ParseNumbers(string input);
    }
}

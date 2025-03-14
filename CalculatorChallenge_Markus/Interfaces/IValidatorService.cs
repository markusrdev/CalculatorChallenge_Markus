using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorChallenge_Markus.Interfaces
{
    public interface IValidatorService
    {
        public void ValidateNumbers(List<int> numbers);
    }
}

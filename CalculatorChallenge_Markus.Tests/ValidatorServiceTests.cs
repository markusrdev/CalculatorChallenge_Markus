using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CalculatorChallenge_Markus.Interfaces;
using CalculatorChallenge_Markus.Services;

namespace CalculatorChallenge_Markus.Tests
{
    public class ValidatorServiceTests
    {
        private readonly IValidatorService _validatorService;

        public ValidatorServiceTests()
        {
            _validatorService = new ValidatorService();
        }

        [Fact]
        public void ValidateNumbers_PositiveNumbers_NoExceptionThrown()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var exception = Record.Exception(() => _validatorService.ValidateNumbers(numbers));
            Assert.Null(exception); // No exception should be thrown
        }

        [Fact]
        public void ValidateNumbers_SingleNegativeNumber_ThrowsArgumentException()
        {
            var numbers = new List<int> { -5 };
            var exception = Assert.Throws<ArgumentException>(() => _validatorService.ValidateNumbers(numbers));
            Assert.Equal("Negative numbers are not allowed: -5", exception.Message);
        }

        [Fact]
        public void ValidateNumbers_MultipleNegativeNumbers_ThrowsExceptionWithAllNegativesListed()
        {
            var numbers = new List<int> { 1, -2, 3, -4, 5 };
            var exception = Assert.Throws<ArgumentException>(() => _validatorService.ValidateNumbers(numbers));
            Assert.Equal("Negative numbers are not allowed: -2, -4", exception.Message);
        }
    }
}

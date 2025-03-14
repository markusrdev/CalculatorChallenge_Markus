﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CalculatorChallenge_Markus.Interfaces;
using CalculatorChallenge_Markus.Services;

namespace CalculatorChallenge_Markus.Tests
{
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorService;
        private readonly Mock<IParserService> _parserServiceMock;
        private readonly Mock<IValidatorService> _validatorServiceMock;

        public CalculatorServiceTests()
        {
            _parserServiceMock = new Mock<IParserService>();
            _validatorServiceMock = new Mock<IValidatorService>();
            _calculatorService = new CalculatorService(_parserServiceMock.Object, _validatorServiceMock.Object);
        }

        [Fact]
        public void Add_NegativeNumbers_ThrowsException()
        {
            _parserServiceMock.Setup(p => p.ParseNumbers("1, -2,3,-4")).Returns(new List<int> { 1, -2, 3, -4 });

            _validatorServiceMock.Setup(v => v.ValidateNumbers(It.IsAny<List<int>>()))
                .Throws(new ArgumentException("Negative numbers are not allowed: -2, -4"));

            var exception = Assert.Throws<ArgumentException>(() => _calculatorService.Add("1, -2,3,-4"));
            Assert.Equal("Negative numbers are not allowed: -2, -4", exception.Message);
        }

        [Fact]
        public void Add_RemoveNumbersGreaterThan1000()
        {
            _parserServiceMock.Setup(p =>p.ParseNumbers("2, 1001,6")).Returns(new List<int> { 2, 1001, 6 });

            _validatorServiceMock.Setup(v => v.FilterNumbers(It.IsAny<List<int>>()))
                .Returns(new List<int> { 2, 6 });

            var result = _calculatorService.Add("2, 1001,6");
            Assert.Equal(8, result); // 2 + 6 = 8 1001 is ignored
        }
    }
}

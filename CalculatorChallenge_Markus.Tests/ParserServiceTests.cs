using CalculatorChallenge_Markus.Interfaces;
using CalculatorChallenge_Markus.Services;

namespace CalculatorChallenge_Markus.Tests
{
    public class ParserServiceTests
    {
        private readonly IParserService _parserService;

        public ParserServiceTests()
        {
            _parserService = new ParserService();
        }

        [Fact]
        public void ParseNumbers_SingleNumber_ReturnsSameNumber()
        {
            var result = _parserService.ParseNumbers("8");
            Assert.Equal(new List<int> { 8 }, result);
        }

        [Fact]
        public void ParseNumbers_TwoNumbers_ReturnsBothNumbers()
        {
            var result = _parserService.ParseNumbers("4, 5");
            Assert.Equal(new List<int> { 4, 5 }, result);
        }

        [Fact]
        public void ParseNumbers_EmptyInput_ReturnsZero()
        {
            var result = _parserService.ParseNumbers("");
            Assert.Equal(new List<int> { 0 }, result);
        }

        [Fact]
        public void ParseNumbers_InvalidNumbers_ConvertedToZero()
        {
            var result = _parserService.ParseNumbers("4, abc");
            Assert.Equal(new List<int> { 4, 0 }, result);
        }

        [Fact]
        public void ParseNumbers_MultipleNumbersWithCommas_ReturnAllNumbers()
        {

            var result = _parserService.ParseNumbers("1,2,3,4,5,6,7,8,9,10,11,12");
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, result);
        }

        [Fact]
        public void ParseNumbers_MultipleNumbersWithNewLines_ReturnAllNumbers()
        {

            var result = _parserService.ParseNumbers("1\n2\n3");
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void ParseNumbers_MultipleNumbersWithMixedDelimiters_ReturnAllNumbers()
        {

            var result = _parserService.ParseNumbers("1\n2,3");
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }
    }
}
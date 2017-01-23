using System;
using Xunit;
using  Xunit.Abstractions;

namespace DemoCode.Tests
{
    [Trait("Category", "Calculator")]
    public class CalculatorTests
    {
        private readonly ITestOutputHelper _testOutput;

        public CalculatorTests(ITestOutputHelper helper)
        {
            _testOutput = helper;
        }

        [Fact]
        [Trait("Category", "Equal")]
        public void ShouldAdd()
        {
            _testOutput.WriteLine("Rozpoczęcie testu");

            var sut = new Calculator();

            var result = sut.Add(1, 2);

            _testOutput.WriteLine("Wykonanie obliczeń");

            Assert.Equal(3, result);
        }
    }
}
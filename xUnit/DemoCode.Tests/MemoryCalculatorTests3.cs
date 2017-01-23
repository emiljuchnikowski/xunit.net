using System;
using Xunit;
using Xunit.Abstractions;

namespace DemoCode.Tests
{
    [Collection("MemoryCalculator Collection")]
    public class MemoryCalculatorTests3 : IClassFixture<MemoryCalculatorFixture> // : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;

        //private readonly MemoryCalculator _sut;
        private readonly MemoryCalculatorFixture _fixture;

        public MemoryCalculatorTests3(ITestOutputHelper helper, MemoryCalculatorFixture fixture)
        {
            _testOutput = helper;
            _fixture = fixture;

            _fixture.Sut.Clear();

//            _testOutput.WriteLine("Creating sut");
//            _sut = new MemoryCalculator();
        }

        [Fact]
        public void ShouldAdd()
        {
            _testOutput.WriteLine("Executing ShouldAdd");

            _fixture.Sut.Add(10);
            _fixture.Sut.Add(5);

            Assert.Equal(15, _fixture.Sut.CurrentValue);
        }

        [Fact]
        public void ShouldSubtract()
        {
            _testOutput.WriteLine("Executing ShouldSubtract");

            _fixture.Sut.Subtract(5);

            Assert.Equal(-5, _fixture.Sut.CurrentValue);
        }

//        public void Dispose()
//        {
//            _testOutput.WriteLine("Disposing sut");
//            _sut.Dispose();
//        }
    }
}
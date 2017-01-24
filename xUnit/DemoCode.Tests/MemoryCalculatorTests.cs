using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Ploeh.AutoFixture.Xunit2;
using Xunit;
using Xunit.Abstractions;

namespace DemoCode.Tests
{
    public class MemoryCalculatorFixture : IDisposable
    {
        public MemoryCalculator Sut { get; private set; }

        public MemoryCalculatorFixture()
        {
            Sut = new MemoryCalculator();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }

    public class MemoryCalculatorTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
//                yield return new object[] { 5, 10, -15 };
//                yield return new object[] { -2, -1, 3 };

                var csvLinses = File.ReadAllLines("TestData.csv");

                var testCases = new List<object[]>();

                foreach (var csvLinse in csvLinses)
                {
                    var values = csvLinse.Split(',').Select(int.Parse);

                    var testCase = values.Cast<object>().ToArray();

                    testCases.Add(testCase);
                }

                return testCases;
            }
        }
    }

    public class MemoryCalculatorTests : IClassFixture<MemoryCalculatorFixture> // : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;

        //private readonly MemoryCalculator _sut;
        private readonly MemoryCalculatorFixture _fixture;

        public MemoryCalculatorTests(ITestOutputHelper helper, MemoryCalculatorFixture fixture)
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

        [Theory]
//        [InlineData(5, 10, -15)]
//        [InlineData(-2, -1, 3)]
//        [MemberData(nameof(MemoryCalculatorTestData.TestData), MemberType=typeof(MemoryCalculatorTestData))]
        [CsvTestData("TestData.csv")]
        public void ShouldSubtractTwoNumbers(int firstNumber, int secondNumber, int expectedResult)
        {
            _testOutput.WriteLine("Executing ShouldSubtractTwoNumbers");

            _fixture.Sut.Subtract(firstNumber);
            _fixture.Sut.Subtract(secondNumber);

            Assert.Equal(expectedResult, _fixture.Sut.CurrentValue);
        }

        [Theory]
        //[AutoData]
        [InlineAutoData()]
        [InlineAutoData(-5)]
        public void ShouldAddTwoNumbersAuto(int firstNumber, int secondNumber, MemoryCalculator sut)
        {
            _testOutput.WriteLine("Executing ShouldAddTwoNumbersAuto");

            sut.Add(firstNumber);
            _testOutput.WriteLine("firstNumber: " + firstNumber);
            sut.Add(secondNumber);
            _testOutput.WriteLine("secondNumber: " + secondNumber);

            Assert.Equal(firstNumber + secondNumber, sut.CurrentValue);
        }

        //        public void Dispose()
        //        {
        //            _testOutput.WriteLine("Disposing sut");
        //            _sut.Dispose();
        //        }
    }
}
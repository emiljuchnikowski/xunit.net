using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace DemoCode.Tests
{
    public class CsvTestDataAttribute : DataAttribute
    {
        private readonly string _csvFileName;

        public CsvTestDataAttribute(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var csvLinses = File.ReadAllLines(_csvFileName);

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

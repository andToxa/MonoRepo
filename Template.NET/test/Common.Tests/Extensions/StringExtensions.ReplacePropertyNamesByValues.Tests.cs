using Common.Extensions;
using Xunit;

namespace Common.Tests.Extensions
{
    /// <summary>Тесты <see cref="StringExtensions"/></summary>
    public partial class StringExtensionsTests
    {
        /// <summary>Тест <see cref="StringExtensions.ReplacePropertyNamesByValues"/></summary>
        [Fact]
        public void ReplacePropertyNamesByValuesTest()
        {
            // arrange
            var testString = "{ReplacePropertyNamesByValuesTestClass.PropertyOne} less than {ReplacePropertyNamesByValuesTestClass.PropertyTwo}";
            var testClass = new ReplacePropertyNamesByValuesTestClass();

            // act
            testString = testString.ReplacePropertyNamesByValues(testClass);

            // assert
            Assert.Equal("ValueOne less than ValueTwo", testString);
        }

        private class ReplacePropertyNamesByValuesTestClass
        {
            public string PropertyOne { get; set; } = "ValueOne";

            public string PropertyTwo { get; set; } = "ValueTwo";
        }
    }
}
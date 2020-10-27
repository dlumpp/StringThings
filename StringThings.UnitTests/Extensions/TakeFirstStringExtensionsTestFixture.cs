using FluentAssertions;
using System;
using Xunit;
using StringThings.Extensions;

namespace StringThings.UnitTests.Extensions
{
    public class TakeFirstStringExtensionsTestFixture
    {

        [Fact]
        public void WhenSubjectNull_ThenThrow()
        {
            string? value = null;
            Action act = () => value.TakeFirst(5);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WhenCharactersNegative_ThenThrow()
        {
            string? value = "test";
            Action act = () => value.TakeFirst(-1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("test", 2, "te")]
        [InlineData("testing a sentence", 10, "testing a ")]
        [InlineData(" test", 2, " t")]
        [InlineData("test", 4, "test")]
        [InlineData("test", 5, "test")]
        [InlineData("test", 999, "test")]
        [InlineData("", 5, "")]
        [InlineData("  ", 1, " ")]
        public void WhenValid_ReturnsCorrectResult(string s, short numberOfChars, string expected)
        {
            string actual = s.TakeFirst(numberOfChars);
            actual.Should().Be(expected);
        }

    }

}

using FluentAssertions;
using StringThings.Extensions;
using Xunit;

namespace StringThings.UnitTests.Extensions
{
    public class IsNullOrEmptyExtensionsTests
    {
        public static TheoryData<string?, bool> TestData => new TheoryData<string?, bool>
        {
            {null, true },
            {"", true },
            { "not empty", false }
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void WhenIsNullOrEmpty_ThenExpected(string s, bool expected)
        {
            bool actual = s.IsNullOrEmpty();
            actual.Should().Be(expected);
        }
    }

    public class IsNullOrWhiteSpaceExtensionsTests
    {
        public static TheoryData<string?, bool> TestData => new TheoryData<string?, bool>
        {
            {null, true },
            {"", true },
            {" ", true },
            {"\t\r\n", true },
            { "not empty", false }
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void WhenIsNullOrWhiteSpace_ThenExpected(string s, bool expected)
        {
            bool actual = s.IsNullOrWhiteSpace();
            actual.Should().Be(expected);
        }
    }
}

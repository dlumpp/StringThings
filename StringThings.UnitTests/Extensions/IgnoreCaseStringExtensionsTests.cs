using FluentAssertions;
using System;
using Xunit;
using StringThings.Extensions;

namespace StringThings.UnitTests.Extensions
{
    public abstract class IgnoreCaseStringExtensionsTests
    {
        protected abstract bool Act(string? s, string? other);

        [Fact]
        public void WhenSubjectNull_ThenThrow()
        {
            Action act = () => Act(null, "");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WhenCaseIsSame_ThenEqual()
        {
            Act("ABC", "ABC").Should().BeTrue();
        }

        [Fact]
        public void WhenCaseIsDifferent_ThenEqual()
        {
            Act("ABC","abc").Should().BeTrue();
        }

        [Fact]
        public void WhenMoreThanCaseDifferent_ThenNotEqual()
        {
            Act("ABC", "ab1c").Should().BeFalse();
        }
    }

    public class EqualsIgnoreCaseStringExtensionsTests : IgnoreCaseStringExtensionsTests
    {
        protected override bool Act(string? s, string? other) => s.EqualsIgnoreCase(other);
    }

    public class StartsWithIgnoreCaseStringExtensionsTests : IgnoreCaseStringExtensionsTests
    {
        protected override bool Act(string? s, string? other) => s.StartsWithIgnoreCase(other);
    }

    public class EndsWithIgnoreCaseStringExtensionsTests : IgnoreCaseStringExtensionsTests
    {
        protected override bool Act(string? s, string? other) => s.EndsWithIgnoreCase(other);
    }

    public class ContainsIgnoreCaseStringExtensionsTests : IgnoreCaseStringExtensionsTests
    {
        protected override bool Act(string? s, string? other) => s.ContainsIgnoreCase(other);
    }
}

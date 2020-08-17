using FluentAssertions;
using System;
using Xunit;
using StringThings.Extensions;

namespace StringThings.UnitTests.Extensions
{
    public abstract class IgnoreCaseStringExtensionsTestFixture
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

    public class EqualsIgnoreCaseStringExtensionsTestFixture : IgnoreCaseStringExtensionsTestFixture
    {
        protected override bool Act(string? s, string? other) => s.EqualsIgnoreCase(other);
    }

    public class StartsWithIgnoreCaseStringExtensionsTestFixture : IgnoreCaseStringExtensionsTestFixture
    {
        protected override bool Act(string? s, string? other) => s.StartsWithIgnoreCase(other);
    }

    public class EndsWithIgnoreCaseStringExtensionsTestFixture : IgnoreCaseStringExtensionsTestFixture
    {
        protected override bool Act(string? s, string? other) => s.EndsWithIgnoreCase(other);
    }

    public class ContainsIgnoreCaseStringExtensionsTestFixture : IgnoreCaseStringExtensionsTestFixture
    {
        protected override bool Act(string? s, string? other) => s.ContainsIgnoreCase(other);
    }
}

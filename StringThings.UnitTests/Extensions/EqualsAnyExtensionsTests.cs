using FluentAssertions;
using StringThings.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StringThings.UnitTests.Extensions
{
    public class EqualsAnyExtensionsTests
    {
        protected virtual (bool ParamsActual, bool EnumerableActual) Act(string? s, IEnumerable<string?>? options)
        {
            var paramsActual = s.EqualsAny(options?.ToArray());
            var enumerableActual = s.EqualsAny(options?.ToList());
            return (paramsActual, enumerableActual);
        }

        protected void Assert((bool ParamsActual, bool EnumerableActual) actual, bool expected)
        {
            actual.ParamsActual.Should().Be(expected);
            actual.EnumerableActual.Should().Be(expected);
        }

        [Fact]
        public void WhenOptionsNull_ThenFalse()
        {
            List<string>? options = null;
            var actual = Act("", options);
            Assert(actual, false);
        }

        [Fact]
        public void WhenStringNotEqualsAnyOptions_ThenFalse()
        {
            var options = new List<string> { "A", "B" };
            var actual = Act("F", options);
            Assert(actual, false);
        }

        [Fact]
        public void WhenStringIsNull_AndNullInOptions_ThenTrue()
        {
            var options = new List<string?> { "A", null };
            var actual = Act(null, options);
            Assert(actual, true);
        }

        [Fact]
        public void WhenStringEqualsAnyOptions_ThenTrue()
        {
            var options = new List<string> { "A", "B" };
            var actual = Act("A", options);
            Assert(actual, true);
        }
    }

    public class EqualsAnyIgnoreCaseExtensionsTests : EqualsAnyExtensionsTests
    {
        protected override (bool ParamsActual, bool EnumerableActual) Act(string? s, IEnumerable<string?>? options)
        {
            var paramsActual = s.EqualsAnyIgnoreCase(options?.ToArray());
            var enumerableActual = s.EqualsAnyIgnoreCase(options?.ToList());
            return (paramsActual, enumerableActual);
        }

        [Fact]
        public void WhenStringEqualsAnyOptionsOfDifferentCase_ThenTrue()
        {
            var options = new List<string> { "A", "B" };
            var actual = Act("a", options);
            Assert(actual, true);
        }
    }
}

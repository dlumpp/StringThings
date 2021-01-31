using FluentAssertions;
using System.Linq;
using Xunit;

namespace StringThings.UnitTests
{
    public class TypedStringTests
    {
        public class TestTypedString : TypedString
        {
            public static TestTypedString A => new TestTypedString("A");
            public static TestTypedString AnotherA => new TestTypedString("A");
            public static TestTypedString B => new TestTypedString("B");

            protected TestTypedString(string? value) : base(value) { }

            public static TypedString NullValue => new TestTypedString(null);
        }

        [Fact]
        public void WhenValuesAreEqual_ThenObjectsAreEqual()
        {
            TestTypedString.A.Should().Be(TestTypedString.AnotherA);
            TestTypedString.A.Equals(TestTypedString.AnotherA).Should().BeTrue();
            (TestTypedString.A == TestTypedString.AnotherA).Should().BeTrue();
        }

        [Fact]
        public void WhenValuesAreNotEqual_ThenObjectsAreNotEqual()
        {
            TestTypedString.A.Should().NotBe(TestTypedString.B);
            TestTypedString.A.Equals(TestTypedString.B).Should().BeFalse();
            (TestTypedString.A != TestTypedString.AnotherA).Should().BeFalse();
        }

        [Fact]
        public void WhenBothNull_ThenEqual()
        {
            (null == TestTypedString.NullValue).Should().BeTrue();
        }

        [Fact]
        public void WhenToStrung_ThenReturnsValue()
        {
            ((string?)TestTypedString.A).Should().Be(TestTypedString.A.ToString());
            TestTypedString.NullValue.ToString().Should().Be(string.Empty);
        }

        [Fact]
        public void WhenLinqed_ThenEqualityWorks()
        {
            var typedStrings = new TestTypedString[] { TestTypedString.A, TestTypedString.AnotherA, TestTypedString.B, TestTypedString.B };
            typedStrings.Distinct().Count().Should().Be(2);
        }
    }
}

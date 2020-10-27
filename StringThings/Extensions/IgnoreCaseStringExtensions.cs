using System;

namespace StringThings.Extensions
{
    public static class IgnoreCaseStringExtensions
    {
        private static void ThrowIfArgumentNull(string argName, string? s)
        {
            if (s == null)
                throw new ArgumentNullException(argName);
        }

        public static bool EqualsIgnoreCase(this string? s, string? other)
        {
            ThrowIfArgumentNull(nameof(s), s);
            return s!.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string? s, string? other)
        {
            ThrowIfArgumentNull(nameof(s), s);
            return s!.StartsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EndsWithIgnoreCase(this string? s, string? other)
        {
            ThrowIfArgumentNull(nameof(s), s);
            return s!.EndsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string? s, string? other)
        {
            ThrowIfArgumentNull(nameof(s), s);
            return s!.IndexOf(other, StringComparison.OrdinalIgnoreCase) > -1;
        }
    }
}

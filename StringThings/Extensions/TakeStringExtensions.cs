using System;

namespace StringThings.Extensions
{
    public static class TakeStringExtensions
    {
        private static void ThrowIfArgumentNull(string argName, string? s)
        {
            if (s == null)
                throw new ArgumentNullException(argName);
        }

        private static void ThrowIfNegative(string argName, short i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException(argName, i, "Must be greater than 0");
        }

        public static string TakeLast(this string? s, short numberOfChars)
        {
            ThrowIfArgumentNull(nameof(s), s);
            ThrowIfNegative(nameof(numberOfChars), numberOfChars);
            if (s!.Length <= numberOfChars) return s;
            return s.Substring(s.Length - numberOfChars, numberOfChars);
        }

        public static string TakeFirst(this string? s, short numberOfChars)
        {
            ThrowIfArgumentNull(nameof(s), s);
            ThrowIfNegative(nameof(numberOfChars), numberOfChars);
            if (s!.Length <= numberOfChars) return s;
            return s.Substring(0, numberOfChars);
        }
    }
}

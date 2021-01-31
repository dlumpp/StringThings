using System.Collections.Generic;
using System.Linq;

namespace StringThings.Extensions
{
    public static class EqualsAnyExtensions
    {
        public static bool EqualsAny(this string? s, params string?[]? options) =>
            EqualsAny(s, options?.ToList());

        public static bool EqualsAny(this string? s, IEnumerable<string?>? options) =>
            EqualsAny(s, options?.ToList());

        private static bool EqualsAny(this string? s, IList<string?>? options) =>
            options?.Contains(s) ?? false;

        public static bool EqualsAnyIgnoreCase(this string? s, params string?[]? options) =>
            EqualsAnyIgnoreCase(s, options?.ToList());

        public static bool EqualsAnyIgnoreCase(this string? s, IEnumerable<string?>? options) =>
            EqualsAnyIgnoreCase(s, options?.ToList());

        private static bool EqualsAnyIgnoreCase(this string? s, IList<string?>? options) =>
            options?.Any(i =>
            {
                if (s == null && i == null)
                    return true;
                return s?.EqualsIgnoreCase(i) ?? false;
            }) ?? false;
    }
}

using System;

namespace StringThings
{
    public abstract class TypedString : IEquatable<TypedString>
    {
        private readonly string? _value;

        protected TypedString(string? value)
        {
            _value = value;
        }

        public static implicit operator string?(TypedString? typedString) => typedString?._value;
        public static bool operator ==(TypedString? a, TypedString? b) => Equals(a, b);
        public static bool operator !=(TypedString? a, TypedString? b) => !Equals(a, b);

        public override bool Equals(object? obj) => obj is TypedString && Equals(obj as TypedString);

        public bool Equals(TypedString? other) => Equals(this, other);

        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        public override string ToString() => _value ?? string.Empty;

        private static bool Equals(TypedString? a, TypedString? b) => string.Equals(a, b);
    }
}

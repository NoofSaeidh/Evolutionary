using Evolutionary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Characteristics
{
    public struct CharacteristicValue<T> : IEquatable<CharacteristicValue<T>>
    {
        private readonly T _value;

        public CharacteristicValue(T value, Characteristic characteristic)
        {
            _value = value;
            Characteristic = characteristic;
        }

        [NotNull]
        public T Value
        {
            get
            {
                ThrowHelper.Check_StructNotInitalized(_value);
                return _value!;
            }
        }
        public Characteristic Characteristic { get; }

        public override bool Equals(object? obj)
        {
            return obj is CharacteristicValue<T> ch
                       && Equals(ch);
        }

        public bool Equals(CharacteristicValue<T> other)
        {
            return Characteristic.Equals(other.Characteristic)
                && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Characteristic);
        }

        public override string ToString()
        {
            return Characteristic.ToString() + ": " + Value.ToString();
        }

        public static bool operator ==(CharacteristicValue<T> left, CharacteristicValue<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CharacteristicValue<T> left, CharacteristicValue<T> right)
        {
            return !(left == right);
        }
    }
}

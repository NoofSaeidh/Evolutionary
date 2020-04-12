using Evolutionary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Characteristics
{
    public struct CharacteristicValue : IEquatable<CharacteristicValue>
    {
        public CharacteristicValue(int value, Characteristic characteristic)
        {
            Value = value;
            Characteristic = characteristic;
        }

        public int Value { get; }
        public Characteristic Characteristic { get; }

        public override bool Equals(object? obj)
        {
            return obj is CharacteristicValue ch
                       && Equals(ch);
        }

        public bool Equals(CharacteristicValue other)
        {
            return Characteristic.Equals(other.Characteristic)
                && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Characteristic);
        }

        public override string ToString()
        {
            return Characteristic.ToString() + ": " + Value.ToString(CultureInfo.InvariantCulture.NumberFormat);
        }

        public static bool operator ==(CharacteristicValue left, CharacteristicValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CharacteristicValue left, CharacteristicValue right)
        {
            return !(left == right);
        }
    }
}

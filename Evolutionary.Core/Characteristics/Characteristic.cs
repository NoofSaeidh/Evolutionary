using Evolutionary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Characteristics
{
    public struct Characteristic : IEquatable<Characteristic>
    {
        private readonly string _name;

        public Characteristic(string name, bool mutable = false)
        {
            _name = name;
            Mutable = mutable;
        }

        public string Name
        {
            get
            {
                ThrowHelper.Check_StructNotInitalized(_name);
                return _name;
            }
        }

        public bool Mutable { get; }

        public override bool Equals(object? obj)
        {
            return obj is Characteristic ch
                       && Equals(ch);
        }

        public bool Equals(Characteristic other)
        {
            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string ToString()
        {
            return $"{Name} (Mutable = {Mutable})";
        }

        public static bool operator ==(Characteristic left, Characteristic right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Characteristic left, Characteristic right)
        {
            return !(left == right);
        }
    }
}

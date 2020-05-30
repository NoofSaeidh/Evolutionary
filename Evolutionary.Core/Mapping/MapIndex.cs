using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Mapping
{
    public struct MapIndex : IEquatable<MapIndex>
    {
        public MapIndex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        public bool Equals(MapIndex other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is MapIndex index
                ? Equals(index)
                : false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        public static MapIndex Add(MapIndex left, MapIndex right)
        {
            return new MapIndex(left.X + right.X, left.Y + right.Y);
        }

        public static MapIndex Subtract(MapIndex left, MapIndex right)
        {
            return new MapIndex(left.X - right.X, left.Y - right.Y);
        }

        public static bool operator ==(MapIndex left, MapIndex right) => left.Equals(right);
        public static bool operator !=(MapIndex left, MapIndex right) => !left.Equals(right);

        public static MapIndex operator +(MapIndex left, MapIndex right) => Add(left, right);

        public static MapIndex operator -(MapIndex left, MapIndex right) => Subtract(left, right);

        public static implicit operator MapIndex((int x, int y) index) => new MapIndex(index.x, index.y);
    }
}

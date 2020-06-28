using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Global
{
    public struct Index2d : IEquatable<Index2d>
    {
        public Index2d(int x, int y)
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

        public bool Equals(Index2d other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Index2d index
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

        public static Index2d Add(Index2d left, Index2d right)
        {
            return new Index2d(left.X + right.X, left.Y + right.Y);
        }

        public static Index2d Subtract(Index2d left, Index2d right)
        {
            return new Index2d(left.X - right.X, left.Y - right.Y);
        }
        public static Index2d FromValueTuple((int x, int y) index) => new Index2d(index.x, index.y);

        public static bool operator ==(Index2d left, Index2d right) => left.Equals(right);
        public static bool operator !=(Index2d left, Index2d right) => !left.Equals(right);

        public static Index2d operator +(Index2d left, Index2d right) => Add(left, right);

        public static Index2d operator -(Index2d left, Index2d right) => Subtract(left, right);

        public static implicit operator Index2d((int x, int y) index) => FromValueTuple(index);
    }
}

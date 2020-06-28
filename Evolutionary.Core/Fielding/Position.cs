using Evolutionary.Core.Global;
using Evolutionary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Fielding
{
    public struct Position : IEquatable<Position>
    {
        public Position(int x, int y) : this(new Index2d(x, y))
        {
        }

        public Position(int xStart, int xEnd, int yStart, int yEnd) : this(new Index2d(xStart, yStart), new Index2d(xEnd, yEnd))
        {
        }

        public Position(Index2d position) : this(position, position)
        {

        }

        public Position(Index2d start, Index2d end)
        {
            ThrowHelper.Check_ArgumentOutOfRange(start, end, nameof(start));
            Start = start;
            End = end;
        }


        /// <summary>
        /// Shows than index takes only one pixel / cell
        /// </summary>
        public bool IsAtomic => Start == End;

        public Index2d Start { get; }
        public Index2d End { get; }

        public int GetIndexesCount()
        {
            if (IsAtomic)
                return 1;

            var x = End.X - Start.X + 1;
            var y = End.Y - Start.Y + 1;
            return x * y;
        }

        public bool Contain(Index2d index)
        {
            if (IsAtomic)
                return index == Start;
            if (index.X < Start.X)
                return false;
            if (index.Y < Start.Y)
                return false;
            if (index.X > End.X)
                return false;
            if (index.Y > End.Y)
                return false;
            return true;
        }

        public void Deconstruct(out Index2d start, out Index2d end)
        {
            start = Start;
            end = End;
        }

        public void Deconstruct(out int xStart, out int xEnd, out int yStart, out int yEnd)
        {
            (xStart, yStart) = Start;
            (xEnd, yEnd) = End;
        }

        public bool Equals(Position other)
        {
            return Start == other.Start
                && End == other.End;
        }

        public override bool Equals(object? obj)
        {
            return obj is Position index
                ? Equals(index)
                : false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override string ToString()
        {
            if (IsAtomic)
                return $"Atomic, X: {Start.X}, Y: {Start.Y}";
            return $"Start: {{{Start}}}, End: {{{End}}}";
        }

        public IEnumerable<Index2d> GetIndexes()
        {
            if (IsAtomic)
            {
                yield return Start;
            }
            else
            {
                for (int x = Start.X; x < End.X; x++)
                {
                    for (int y = Start.Y; y < End.Y; y++)
                    {
                        yield return new Index2d(x, y);
                    }
                }
            }
        }

        public static Position Add(Position left, Position right)
        {
            return new Position(left.Start + right.Start, left.End + right.End);
        }

        public static Position Subtract(Position left, Position right)
        {
            return new Position(left.Start - right.Start, left.End - right.End);
        }
        public static Position FromValueTuple((Index2d start, Index2d end) position) => new Position(position.start, position.end);
        public static Position FromValueTuple((int xStart, int xEnd, int yStart, int yEnd) position) => new Position(position.xStart, position.xEnd, position.yStart, position.yEnd);

        public static bool operator ==(Position left, Position right) => left.Equals(right);
        public static bool operator !=(Position left, Position right) => !left.Equals(right);

        public static Position operator +(Position left, Position right) => Add(left, right);

        public static Position operator -(Position left, Position right) => Subtract(left, right);

        public static implicit operator Position((Index2d start, Index2d end) position) => FromValueTuple(position);
        public static implicit operator Position((int xStart, int xEnd, int yStart, int yEnd) position) => FromValueTuple(position);
    }
}





//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Evolutionary.Core.Fielding
//{
//    public struct Position : IEquatable<Position>
//    {
//        public Position(int x, int y) : this(x, x, y, y)
//        {
//        }

//        public Position(int xStart, int xEnd, int yStart, int yEnd)
//        {
//            XStart = xStart;
//            XEnd = xEnd;
//            YStart = yStart;
//            YEnd = yEnd;
//        }


//        /// <summary>
//        /// Shows than index takes only one pixel / cell
//        /// </summary>
//        public bool Atomic => XStart == XEnd && YStart == YEnd;

//        public int XStart { get; }
//        public int XEnd { get; }
//        public int YStart { get; }
//        public int YEnd { get; }

//        public int X => XStart;
//        public int Y => YStart;

//        public void Deconstruct(out int x, out int y)
//        {
//            x = X;
//            y = Y;
//        }

//        public void Deconstruct(out int xStart, out int xEnd, out int yStart, out int yEnd)
//        {
//            xStart = XStart;
//            xEnd = XEnd;
//            yStart = YStart;
//            yEnd = YEnd;
//        }

//        public bool Equals(Position other)
//        {
//            return XStart == other.XStart
//                && XEnd == other.XEnd
//                && YStart == other.YStart
//                && YEnd == other.YEnd;
//        }

//        public override bool Equals(object? obj)
//        {
//            return obj is Position index
//                ? Equals(index)
//                : false;
//        }

//        public override int GetHashCode()
//        {
//            return HashCode.Combine(XStart, XEnd, YStart, YEnd);
//        }

//        public override string ToString()
//        {
//            if (Atomic)
//                return $"X: {X}, Y: {Y}";
//            return $"XStart: {XStart}, XEnd: {XEnd}, YStart: {YStart}, YEnd: {YEnd}";
//        }

//        public static Position Add(Position left, Position right)
//        {
//            return new Position(
//                left.XStart + right.XStart,
//                left.XEnd + right.XEnd,
//                left.YStart + right.YStart,
//                left.YEnd + right.YEnd);
//        }

//        public static Position Subtract(Position left, Position right)
//        {
//            return new Position(
//               left.XStart - right.XStart,
//               left.XEnd - right.XEnd,
//               left.YStart - right.YStart,
//               left.YEnd - right.YEnd);
//        }

//        public static bool operator ==(Position left, Position right) => left.Equals(right);
//        public static bool operator !=(Position left, Position right) => !left.Equals(right);

//        public static Position operator +(Position left, Position right) => Add(left, right);

//        public static Position operator -(Position left, Position right) => Subtract(left, right);

//        public static implicit operator Position((int x, int y) index) => new Position(index.x, index.y);
//        public static implicit operator Position((int xStart, int xEnd, int yStart, int yEnd) index)
//            => new Position(index.xStart, index.xEnd, index.yStart, index.yEnd);
//    }
//}

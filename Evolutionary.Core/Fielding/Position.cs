using Evolutionary.Core.Global;
using Evolutionary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Fielding
{
    [DebuggerDisplay("{ToString(),nq}")]
    public struct Position : IEquatable<Position>
    {
        // todo: virtual indexes -> vectors
        public Position(Index2d center, IEnumerable<Index2d> indexes)
        {
            Center = center;
            if (indexes == null)
            {
                Indexes = new[] { center };
            }
            else
            {
                // to remove duplicates.
                // probably should do it only for debug
                Indexes = new HashSet<Index2d>(indexes.Union(new[] { Center })).ToArray();
            }
        }

        public Position(Index2d center, params Index2d[] indexes) : this(center, (IEnumerable<Index2d>)indexes)
        {

        }


        /// <summary>
        /// Shows than index takes only one pixel / cell
        /// </summary>
        public bool IsAtomic => Indexes.Count == 1;

        public Index2d Center { get; }
        public IReadOnlyList<Index2d> Indexes { get; }

        public Position Move(Index2d center)
        {
            Position this_ = this;
            return new Position(center, Indexes.Select(i => i + center - this_.Center));
        }


        public bool Equals(Position other)
        {
            if (Indexes.Count != other.Indexes.Count)
                return false;
            for (int i = 0; i < Indexes.Count; i++)
            {
                if (Indexes[i] != other.Indexes[i])
                    return false;
            }
            return true;
        }

        public bool Intersect(Position other)
        {
            // TODO: optimize??
            return other.Indexes.Any(i => other.Indexes.Contains(i));
        }

        public override bool Equals(object? obj)
        {
            return obj is Position index
                ? Equals(index)
                : false;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            foreach (var item in Indexes)
            {
                hashCode.Add(item);
            }
            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            if (IsAtomic)
                return $"Atomic: {Center}";
            return $"{Center}"; // todo: some info about size;
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
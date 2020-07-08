using Evolutionary.Core.Fielding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Tests.Helpers
{
    public static class InputExtensions
    {
        public static IEnumerable<Position> ToPositions(this IEnumerable<int[]> items)
        {
            foreach (var indexes in items)
            {
                yield return indexes.ToPosition();
            }
        }

        public static Position ToPosition(this int[] item)
        {
            if (item.Length == 2)
            {
                return new Position(item[0], item[1]);
            }
            else if (item.Length == 4)
            {
                return new Position(item[0], item[1], item[2], item[3]);
            }
            else throw new TestDataException();

        }
    }
}

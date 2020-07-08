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
                if (indexes.Length == 2)
                { 
                    yield return new Position(indexes[0], indexes[1]);
                }
                else if (indexes.Length == 4)
                {
                    yield return new Position(indexes[0], indexes[1], indexes[2], indexes[3]);
                }
                else throw new TestDataException();
            }
        }
    }
}

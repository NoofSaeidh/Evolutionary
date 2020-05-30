using Evolutionary.Core.Entities;
using Evolutionary.Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Mapping
{
    public class Map : IEnumerable<Field>
    {
        private readonly Field[,] _matrix;

        public Map(MapIndex size)
        {
            Size = size;
            _matrix = new Field[size.X, size.Y];
        }

        public Map(Field[,] matrix)
        {
            _matrix = matrix;
            Size = new MapIndex(_matrix.GetLength(0), _matrix.GetLength(1));
        }

        public Field this[MapIndex index]
        {
            get
            {
                ThrowHelper.Check_ArgumentOutOfRange(index, Size, nameof(index));
                return _matrix[index.X, index.Y];
            }
            set
            {
                ThrowHelper.Check_ArgumentOutOfRange(index, Size, nameof(index));
                _matrix[index.X, index.Y] = value;
            }
        }

        public Field this[int x, int y]
        {
            get
            {
                ThrowHelper.Check_ArgumentOutOfRange(x, Size.X, nameof(x));
                ThrowHelper.Check_ArgumentOutOfRange(y, Size.Y, nameof(y));
                return _matrix[x, y];
            }
            set
            {
                ThrowHelper.Check_ArgumentOutOfRange(x, Size.X, nameof(x));
                ThrowHelper.Check_ArgumentOutOfRange(y, Size.Y, nameof(y));
                _matrix[x, y] = value;
            }
        }

        public MapIndex Size { get; }


        public IEnumerator<Field> GetEnumerator() => _matrix.OfType<Field>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

using Evolutionary.Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Evolutionary.Core.UI
{
    public class Frame : IEnumerable<FrameCell>
    {
        private readonly FrameCell[,] _matrix;

        public Frame(int lengthHorizontal, int lengthVertical)
        {
            LengthHorizontal = lengthHorizontal;
            LengthVertical = lengthVertical;
            _matrix = new FrameCell[lengthHorizontal, lengthVertical];
        }

        internal Frame(FrameCell[,] matrix)
        {
            _matrix = matrix;
            LengthHorizontal = _matrix.GetLength(0);
            LengthVertical = _matrix.GetLength(1);
        }

        public FrameCell this[int x, int y]
        {
            get
            {
                ThrowHelper.Check_ArgumentOutOfRange(x, LengthHorizontal, nameof(x));
                ThrowHelper.Check_ArgumentOutOfRange(y, LengthVertical, nameof(y));
                return _matrix[x, y];
            }
            internal set
            {
                ThrowHelper.Check_ArgumentOutOfRange(x, LengthHorizontal, nameof(x));
                ThrowHelper.Check_ArgumentOutOfRange(y, LengthVertical, nameof(y));
                _matrix[x, y] = value;
            }
        }

        public int LengthHorizontal { get; }
        public int LengthVertical { get; }

        public IEnumerator<FrameCell> GetEnumerator()
        {
            return _matrix.OfType<FrameCell>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _matrix.GetEnumerator();
        }
    }
}
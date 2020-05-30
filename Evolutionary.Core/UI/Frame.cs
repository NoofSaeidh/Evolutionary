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

        public Frame(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new FrameCell[height, width];
        }

        internal Frame(FrameCell[,] matrix)
        {
            _matrix = matrix;
            Height = _matrix.GetLength(0);
            Width = _matrix.GetLength(1);
        }

        public FrameCell this[int x, int y]
        {
            get
            {
                ThrowHelper.Check_ArgumentOutOfRange(x, Height, nameof(x));
                ThrowHelper.Check_ArgumentOutOfRange(y, Width, nameof(y));
                return _matrix[x, y];
            }
            internal set
            {
                ThrowHelper.Check_ArgumentOutOfRange(x, Height, nameof(x));
                ThrowHelper.Check_ArgumentOutOfRange(y, Width, nameof(y));
                _matrix[x, y] = value;
            }
        }

        public int Height { get; }
        public int Width { get; }

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
using Evolutionary.Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Evolutionary.Core.UI
{
    public class Frame : IEnumerable<FrameCell>
    {
        internal readonly FrameCell[,] _matrix;

        public Frame(int lengthHorizontal, int lengthVertical)
        {
            LengthHorizontal = lengthHorizontal;
            LengthVertical = lengthVertical;
            _matrix = new FrameCell[lengthHorizontal, lengthVertical];
        }

        public FrameCell this[int x, int y]
        {
            get
            {
                Assertion.AssertPosition(x, LengthHorizontal, nameof(x));
                Assertion.AssertPosition(y, LengthVertical, nameof(y));
                return _matrix[x, y];
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

    public class FrameCell
    {
        public FrameCell(Color color)
        {
            Color = color;
        }

        public Color Color { get; }
    }
}
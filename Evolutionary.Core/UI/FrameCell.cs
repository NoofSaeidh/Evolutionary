using System.Drawing;

namespace Evolutionary.Core.UI
{
    public class FrameCell
    {
        public FrameCell(Color color, char sign)
        {
            Color = color;
            Sign = sign;
        }

        public Color Color { get; }
        public char Sign { get; }
    }
}
using System.Drawing;

namespace Evolutionary.Core.UI
{
    public class FieldView
    {
        public FieldView(Color color, char sign)
        {
            Color = color;
            Sign = sign;
        }

        public Color Color { get; }
        public char Sign { get; }
    }
}
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Console = Colorful.Console;

namespace Evolutionary.UI
{
    public class ConsoleRenderer : IRenderer
    {
        public async Task RenderFrame(Frame frame)
        {
            await Task.Yield();
            Console.BackgroundColor = Color.Black;

            for (int x = 0; x < frame.Height; x++)
            {
                for (int y = 0; y < frame.Width; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("+", frame[x, y].Color);
                }
            }
        }
    }
}

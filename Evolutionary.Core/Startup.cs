using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionary.Core
{
    public class Startup
    {
        private readonly CancellationToken _cancellationToken;
        private readonly IRenderer _renderer;

        public Startup(IRenderer renderer, ICancellationSource cancellationSource)
        {
            _cancellationToken = cancellationSource.GetCancellationToken();
            _renderer = renderer;
        }

        public async Task Start()
        {
            while (true)
            {
                //Console.WriteLine("Slee");
                Thread.Sleep(1000);
                if (_cancellationToken.IsCancellationRequested)
                    return;

                await _renderer.RenderFrame(GetRandomFrame(10, 10));
            }
        }

        private Frame GetRandomFrame(int X, int Y)
        {
            int r = 0, g = 0, b = 0;

            var frame = new Frame(X, Y);
            var rand = new Random();
            Color color = Color.White;
            color = GetColor();
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    frame._matrix[x, y] = new FrameCell(GetColor());
                }
            }
            return frame;

            Color GetColor()
            {
                return rand.Next(0, 3) switch
                {
                    0 => Color.Red,
                    1 => Color.Blue,
                    2 => Color.Green,
                    _ => Color.White
                };

                //return Color.FromArgb((r += 30) % 255, (g += 30) % 255, (b += 30) % 255);

                //return color = Color.FromArgb(
                //    GetColorValue(color.R),
                //    GetColorValue(color.G),
                //    GetColorValue(color.B));
            }

            int GetColorValue(int baseValue)
            {
                var mod = rand.Next(0, 2);
                return mod switch
                {
                    0 => baseValue,
                    1 => (baseValue + 15) % 255,
                    2 => (baseValue + 30) % 255,
                    _ => throw null,
                };
            }
        }
    }
}

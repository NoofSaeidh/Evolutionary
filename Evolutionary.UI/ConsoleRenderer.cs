using Autofac;
using Evolutionary.Core.Turns;
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
    public class ConsoleRenderer : IRenderer, IStartable
    {
        private readonly IFieldCellMapper _fieldMapper;

        public ConsoleRenderer(IFieldCellMapper fieldMapper)
        {
            _fieldMapper = fieldMapper;
        }

        public void Start()
        {
            Console.Clear();
            ConsoleWindowsWrapper.FullScreenConsole();
        }

        public Task RenderRound(Round round)
        {
            //await Task.Yield();
            Console.BackgroundColor = Color.Black;
            Console.Clear();

            for (int x = 0; x < round.Field.Size.X; x++)
            {
                for (int y = 0; y < round.Field.Size.Y; y++)
                {
                    Console.SetCursorPosition(x, y);
                    var cellView = _fieldMapper.MapCell(round.Field[(x, y)]);
                    Console.Write(cellView.Sign, cellView.Color);
                }
            }

            return Task.CompletedTask;
        }

    }
}

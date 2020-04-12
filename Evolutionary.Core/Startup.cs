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

            }
        }
    }
}

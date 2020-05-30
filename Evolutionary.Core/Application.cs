using Evolutionary.Core.Generations;
using Evolutionary.Core.Initialization;
using Evolutionary.Core.Turns;
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
    public class Application
    {
        private readonly CancellationToken _cancellationToken;
        private readonly IRenderer _renderer;
        private readonly IInitializer _initializer;
        private readonly IGenerationProcessor _generationProcessor;

        public Application(IRenderer renderer, ICancellationSource cancellationSource, IInitializer initializer, IGenerationProcessor generationProcessor)
        {
            _cancellationToken = cancellationSource.GetCancellationToken();
            _renderer = renderer;
            _initializer = initializer;
            _generationProcessor = generationProcessor;
        }

        public async Task Start()
        {
            var gen = _initializer.InitialGeneration;
            while (true)
            {
                gen = _generationProcessor.ProcessGeneration(gen);
                //Console.WriteLine("Slee");
                Thread.Sleep(3000);
                if (_cancellationToken.IsCancellationRequested)
                    return;

            }
        }
    }
}

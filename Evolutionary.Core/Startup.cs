using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionary.Core
{
    public class Startup
    {
        private readonly CancellationToken _cancellationToken;

        public Startup(ICancellationSource cancellationSource)
        {
            _cancellationToken = cancellationSource.GetCancellationToken();
        }

        public async Task Start()
        {
            while(true)
            {
                Console.WriteLine("Wait");
                Thread.Sleep(1000);
                _cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}

using Evolutionary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionary.UI.Console
{
    public class ConsoleCancellationSource : ICancellationSource, IDisposable
    {
        private readonly CancellationTokenSource _source = new CancellationTokenSource();
        public ConsoleCancellationSource()
        {
            System.Console.CancelKeyPress += Console_CancelKeyPress;
        }

        private void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _source.Cancel();
            e.Cancel = true;
        }

        public CancellationToken GetCancellationToken()
        {
            return _source.Token;

        }

        public void Dispose()
        {
            System.Console.CancelKeyPress -= Console_CancelKeyPress;
            _source.Dispose();
        }

    }
}

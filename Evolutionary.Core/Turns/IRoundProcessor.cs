using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public interface IRoundProcessor
    {
        void ProcessRound(Round round);
    }
}

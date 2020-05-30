using Evolutionary.Core.Generations;
using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Initialization
{
    public interface IInitializer
    {
        Generation InitialGeneration { get; }
    }
}

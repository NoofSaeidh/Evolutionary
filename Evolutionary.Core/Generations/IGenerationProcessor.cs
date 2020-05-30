using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Generations
{
    public interface IGenerationProcessor
    {
        Generation ProcessGeneration(Generation generation);
    }
}

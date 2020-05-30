using Evolutionary.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Generations
{
    public class Generation
    {
        public Generation(int generationId, int roundsCount, Map map)
        {
            GenerationId = generationId;
            RoundsCount = roundsCount;
            Map = map;
        }

        public int GenerationId { get; }
        public int RoundsCount { get; }
        public Map Map { get; }
    }
}

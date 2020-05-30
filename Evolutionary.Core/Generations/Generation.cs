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
        public Generation(int generationId, Map map, int roundsCount)
        {
            GenerationId = generationId;
            Map = map;
            RoundsCount = roundsCount;
        }

        public int GenerationId { get; }
        public Map Map { get; }
        public int RoundsCount { get; }
    }
}

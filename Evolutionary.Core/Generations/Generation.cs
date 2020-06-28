using Evolutionary.Core.Fielding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Generations
{
    public class Generation
    {
        public Generation(int generationId, int roundsCount, Field field)
        {
            GenerationId = generationId;
            RoundsCount = roundsCount;
            Field = field;
        }

        public int GenerationId { get; }
        public int RoundsCount { get; }
        public Field Field { get; }
    }
}

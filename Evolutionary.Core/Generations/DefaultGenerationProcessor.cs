using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Generations
{
    public class DefaultGenerationProcessor : IGenerationProcessor
    {
        private readonly IRoundProcessor _roundProcessor;

        public DefaultGenerationProcessor(IRoundProcessor roundProcessor)
        {
            _roundProcessor = roundProcessor;
        }

        public Generation ProcessGeneration(Generation generation)
        {
            for (int i = 0; i < generation.RoundsCount; i++)
            {
                _roundProcessor.ProcessRound(new Round(generation.Map));
            }

            return new Generation(generation.GenerationId + 1, generation.Map, generation.RoundsCount);
        }
    }
}

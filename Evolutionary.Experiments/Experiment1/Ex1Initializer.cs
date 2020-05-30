using Evolutionary.Core.Generations;
using Evolutionary.Core.Initialization;
using Evolutionary.Core.Mapping;
using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1Initializer : IInitializer
    {
        public Generation InitialGeneration => new Generation(0, new Map(new Field[,]
        {
            { default, default, default, new Field(new Ex1Entity(10, 10, 10)) },
            { default, new Field(new Ex1Entity(10, 10, 10)), default, default},
            { default, default, default, default},
            { default, default, default, new Field(new Ex1Entity(10, 10, 10))},
        }), 32);
    }
}

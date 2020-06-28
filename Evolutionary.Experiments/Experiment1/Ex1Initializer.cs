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
        private Map CreateMap(Position size, int creatureCount, int speed, int vision, int maxHealth)
        {
            var map = new Map(size);
            var rand = new Random();
            for (int i = 0; i < creatureCount; i++)
            {
                while(true)
                {
                    var x = rand.Next(0, size.X);
                    var y = rand.Next(0, size.Y);
                    if(map[x,y].IsEmpty)
                    {
                        map[x, y] = new Field(new Ex1Creature(10, 10, 100));
                        break;
                    }
                }
            }
            return map;
        }

        public Generation InitialGeneration => new Generation(0, 32,
            CreateMap(
                size: (32, 32),
                creatureCount: 16,
                speed: 4,
                vision: 4,
                maxHealth: 200
            ));
    }
}

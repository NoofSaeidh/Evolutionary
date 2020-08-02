using Evolutionary.Core.Fielding;
using Evolutionary.Core.Generations;
using Evolutionary.Core.Global;
using Evolutionary.Core.Initialization;
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
        private Field CreateField(Index2d size, int creatureCount, int speed, int vision, int maxHealth)
        {
            var field = new Field(size);
            var rand = new Random();
            for (int i = 0; i < creatureCount; i++)
            {
                var creature = new Ex1Creature(speed, vision, maxHealth);
                int x, y;
                do
                {
                    x = rand.Next(0, size.X);
                    y = rand.Next(0, size.Y);
                }
                while (!field.AddEntity(creature, (x, y, x + creature.Size - 1, y + creature.Size - 1)));
            }
            return field;
        }

        public Generation InitialGeneration => new Generation(0, 32,
            CreateField(
                size: (32, 32),
                creatureCount: 16,
                speed: 4,
                vision: 4,
                maxHealth: 200
            ));
    }
}

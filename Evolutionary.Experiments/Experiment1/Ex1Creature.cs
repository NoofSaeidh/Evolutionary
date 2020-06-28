using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Entities;
using Evolutionary.Core.Fielding;
using Evolutionary.Core.Global;
using Evolutionary.Core.Mutations;
using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1Creature : Creature<Ex1Creature>
    {
        private static readonly Random _rand = new Random();
        public Ex1Creature(int speed, int vision, int maxHealth)
        {
            Speed = speed;
            Vision = vision;
            Health = MaxHealth = maxHealth;
        }

        public override string Description => nameof(Ex1Creature);
        public int Speed { get; }
        public int Vision { get; }
        public int MaxHealth { get; }
        public int Health { get; private set; }
        public int Size { get; } = 2;

        public override void TakeTurn(Round round, Position currentPosition)
        {
            var (xMin, xMax, yMin, yMax) = GetMaxPosition(currentPosition, round.Field.Size, Vision);
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = yMin; y < yMax; y++)
                {
                    var item = round.Field[(x, y)];
                    if (item.Entity is Ex1Creature creature && creature != this)
                    {
                        var diff = creature.Health - Health;
                        if (diff > MaxHealth / 2)
                            Health /= 4;
                        else if (diff > MaxHealth / 4)
                            Health -= 10;
                        else if (diff < 0)
                            Health += 10;
                        else
                            Health -= 4;
                    }
                }
            }

            // death
            if (Health <= 0)
            {
                round.Field.RemoveEntity(this);
                return;
            }

            (xMin, xMax, yMin, yMax) = GetMaxPosition(currentPosition, round.Field.Size, Speed);
            var (xMinMax, yMinMax) = GetCheckedIndex((xMin + Size - 1, yMin + Size - 1), round.Field.Size);
            var newX = _rand.Next(xMin, xMinMax);
            var newY = _rand.Next(yMin, yMinMax);
            if(!round.Field.MoveEntity(this, new Position(newX, newX + Size - 1, newY, newY + Size - 1)))
            {
                throw new InvalidOperationException();
            }

        }

        private Position GetMaxPosition(Position original, Index2d size, int modifier)
        {
            var xMin = GetCheckedIndex(original.Start.X - modifier, size.X);
            var xMax = GetCheckedIndex(original.End.X + modifier, size.X);
            var yMin = GetCheckedIndex(original.Start.Y - modifier, size.Y);
            var yMax = GetCheckedIndex(original.End.Y + modifier, size.Y);
            return (xMin, xMax, yMin, yMax);
        }

        private Index2d GetCheckedIndex(Index2d index, Index2d maxIndex)
        {
            return new Index2d(GetCheckedIndex(index.X, maxIndex.X), GetCheckedIndex(index.Y, maxIndex.Y));
        }
        private int GetCheckedIndex(int i, int maxI)
        {
            if (i < 0)
                return 0;
            if (i >= maxI)
                return maxI - 1;
            return i;
        }

        protected override CharacteristicsList GetCharacteristics()
        {
            return new CharacteristicsList(new[]
            {
                new CharacteristicValue(Speed, Ex1Characteristics.Speed),
                new CharacteristicValue(Vision, Ex1Characteristics.Vision),
                new CharacteristicValue(MaxHealth, Ex1Characteristics.MaxHealth),
            });
        }

        protected override Ex1Creature CreateSelfFromCharacteristics(CharacteristicsList chars)
        {
            return new Ex1Creature(chars[Ex1Characteristics.Speed],
                                   chars[Ex1Characteristics.Vision],
                                   chars[Ex1Characteristics.MaxHealth]);
        }
    }
}

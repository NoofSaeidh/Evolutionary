using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Entities;
using Evolutionary.Core.Mapping;
using Evolutionary.Core.Mutations;
using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
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

        public override void TakeTurn(Round round, Position currentPosition)
        {
            var (xMin, xMax, yMin, yMax) = GetMaxBorders(currentPosition, round.Map.Size, Vision);
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = yMin; y < yMax; y++)
                {
                    var item = round.Map[x, y];
                    if (item.Entity is Ex1Creature creature)
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
                round.Map[currentPosition] = default;
                return;
            }

            (xMin, xMax, yMin, yMax) = GetMaxBorders(currentPosition, round.Map.Size, Speed);
            var newX = _rand.Next(xMin, xMax);
            var xDiff = newX - currentPosition.X;
            var newY = _rand.Next(yMin, yMax);
            var yDiff = newY - currentPosition.Y;
            while(true)
            {
                if(round.Map[newX, newY].IsEmpty)
                {
                    round.Map[newX, newY] = new Field(this);
                    round.Map[currentPosition] = default;
                    break;
                }
                else
                {
                    if(xDiff == 0 && yDiff == 0)
                    {
                        break;
                    }
                    if(xDiff != 0)
                    {
                        xDiff = xDiff > 0 ? xDiff - 1 : xDiff + 1;
                        newX = currentPosition.X + xDiff;
                    }
                    if(yDiff != 0)
                    {
                        yDiff = yDiff > 0 ? yDiff - 1 : yDiff + 1;
                        newY = currentPosition.Y + yDiff;
                    }
                }
            }

        }

        private (int xMin, int xMax, int yMin, int yMax) GetMaxBorders(Position original, Position size, int modifier)
        {
            var xMin = GetCheckedIndex(original.X - modifier, size.X);
            var xMax = GetCheckedIndex(original.X + modifier, size.X);
            var yMin = GetCheckedIndex(original.Y - modifier, size.Y);
            var yMax = GetCheckedIndex(original.Y + modifier, size.Y);
            return (xMin, xMax, yMin, yMax);
        }

        private Position GetIndex(int x, int y, int maxX, int maxY)
        {
            return new Position(GetCheckedIndex(x, maxX), GetCheckedIndex(y, maxY));
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

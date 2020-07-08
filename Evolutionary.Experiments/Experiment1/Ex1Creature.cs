using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Entities;
using Evolutionary.Core.Fielding;
using Evolutionary.Core.Global;
using Evolutionary.Core.Mutations;
using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var maxPosition = GetMaxPosition(currentPosition, round.Field.Size, Vision);
            foreach (var (entity, entityPosition) in round.Field.GetEntities())
            {
                if (entity == this)
                    continue;
                if (entity is Ex1Creature creature && maxPosition.Intersect(entityPosition))
                {
                    var diff = Health - creature.Health;
                    if (diff > MaxHealth / 2)
                    {
                        creature.Health /= 4;
                        Health += 20;
                    }
                    else if (diff > MaxHealth / 4)
                        creature.Health -= 10;
                    else
                        creature.Health -= 4;
                }

            }

            // death
            if (Health <= 0)
            {
                round.Field.RemoveEntity(this);
                return;
            }

            bool moved = false;
            foreach (var pp in GetPossiblePositions(round.Field.Size, currentPosition))
            {
                if (pp == currentPosition)
                    continue;
                if (round.Field.MoveEntity(this, pp))
                {
                    moved = true;
                    break;
                }
            }

            if (!moved)
            {
                // todo: some acton?
                throw new InvalidOperationException();
            }

        }

        private IEnumerable<Position> GetPossiblePositions(Index2d fieldSize, Position currentPosition)
        {
            var maxStartPosition = GetMaxPosition(
                new Position(
                    currentPosition.Start.X,
                    currentPosition.Start.Y,
                    currentPosition.End.X - Size + 1,
                    currentPosition.End.Y - Size + 1),
                fieldSize,
                Speed);
            var indexes = maxStartPosition.GetIndexes().ToList();
            return RandomSort(indexes)
                .Select(i => new Position(i, new Index2d(i.X + Size - 1, i.Y + Size - 1)));
        }

        //todo: optimize
        private IEnumerable<T> RandomSort<T>(IEnumerable<T> items)
        {
            return items
                .Select(i => (seed: _rand.Next(), i))
                .OrderBy(i => i.seed)
                .Select(i => i.i);
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
                new CharacteristicValue(Size, Ex1Characteristics.Size),
                new CharacteristicValue(Health, Ex1Characteristics.Health),
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

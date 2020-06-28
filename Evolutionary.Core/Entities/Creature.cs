using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Mapping;
using Evolutionary.Core.Mutations;
using Evolutionary.Core.Reproduction;
using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Entities
{
    public abstract class Creature : Entity, IMutable, IReproducable, ITurnable
    {
        public abstract string Description { get; }
        // properties must be in the same order for each instance
        protected abstract CharacteristicsList GetCharacteristics();
        protected abstract Creature CreateFromCharacteristics(CharacteristicsList chars);

        public Creature Mutate(IMutator mutator)
        {
            return CreateFromCharacteristics(mutator.MutateCharacteristics(GetCharacteristics()));
        }

        public IReadOnlyCollection<Creature> Reproduce(IReproducer reproducer)
        {
            return reproducer.Reproduce(this);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Creature entity)
            {
                var ch1 = GetCharacteristics();
                var ch2 = entity.GetCharacteristics();
                if (ch1.Count != ch2.Count)
                    return false;
                for (int i = 0; i < ch1.Count; i++)
                {
                    if (!ch1[i].Equals(ch2[i]))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var code = new HashCode();
            foreach (var ch in GetCharacteristics())
            {
                code.Add(ch);
            }
            return code.ToHashCode();
        }

        public override string? ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[" + Description + "]");
            foreach (var ch in GetCharacteristics())
            {
                sb.Append(", " + ch.ToString());
            }
            return sb.ToString();
        }

        public virtual void TakeTurn(Round round, Position currentPosition)
        {
        }
    }

    public abstract class Creature<TSelf> : Creature, IMutable<TSelf>, IReproducable<TSelf>
        where TSelf : Creature<TSelf>
    {
        public new IReadOnlyCollection<TSelf> Reproduce(IReproducer reproducer)
        {
            var reproduced = reproducer.Reproduce(this);
            return reproduced as IReadOnlyCollection<TSelf>
                ?? reproduced.Cast<TSelf>().ToArray();
        }

        public new TSelf Mutate(IMutator mutator)
        {
            return CreateSelfFromCharacteristics(mutator.MutateCharacteristics(GetCharacteristics()));
        }

        protected sealed override Creature CreateFromCharacteristics(CharacteristicsList chars)
        {
            return CreateSelfFromCharacteristics(chars);
        }

        protected abstract TSelf CreateSelfFromCharacteristics(CharacteristicsList chars);
    }
}

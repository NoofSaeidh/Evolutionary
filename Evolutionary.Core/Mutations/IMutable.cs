using Evolutionary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Mutations
{
    public interface IMutable
    {
        Creature Mutate(IMutator mutator);
    }

    public interface IMutable<out T> : IMutable where T : Creature
    {
        new T Mutate(IMutator mutator);

        Creature IMutable.Mutate(IMutator mutator)
        {
            return (Creature)Mutate(mutator)!;
        }
    }
}

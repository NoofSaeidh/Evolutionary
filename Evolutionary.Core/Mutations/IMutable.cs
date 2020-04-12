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
        object Mutate(IMutator mutator);
    }

    public interface IMutable<T> : IMutable
    {
        new T Mutate(IMutator mutator);

        object IMutable.Mutate(IMutator mutator)
        {
            return (object)Mutate(mutator)!;
        }
    }
}

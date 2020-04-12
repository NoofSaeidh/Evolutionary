using Evolutionary.Core.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Entities
{
    public abstract class Entity : IMutable
    {
        public object Mutate(IMutator mutator)
        {
            return null;
        }
    }
}

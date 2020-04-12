using Evolutionary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Reproduction
{
    public interface IReproducable
    {
        IReadOnlyCollection<Creature> Reproduce(IReproducer reproducer);
    }

    public interface IReproducable<T> : IReproducable where T : Creature
    {
        new IReadOnlyCollection<T> Reproduce(IReproducer reproducer);

        IReadOnlyCollection<Creature> IReproducable.Reproduce(IReproducer reproducer)
        {
            return Reproduce(reproducer);
        }
    }
}

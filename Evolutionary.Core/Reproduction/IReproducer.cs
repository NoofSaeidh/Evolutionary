using Evolutionary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Reproduction
{
    public interface IReproducer
    {
        public IReadOnlyCollection<Creature> Reproduce(Creature creature);
    }
}

using Evolutionary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Mapping
{
    public struct Field
    {
        public Field(Entity entity)
        {
            Entity = entity;
        }
        public Entity Entity { get; }
        public bool IsEmpty => Entity is null;
    }
}

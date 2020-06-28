using Evolutionary.Core.Entities;
using Evolutionary.Core.Global;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Fielding
{
    public struct FieldCell
    {
        public FieldCell(Position? entityPosition, Entity? entity)
        {
            EntityPosition = entityPosition;
            Entity = entity;
        }

        public Position? EntityPosition { get; }
        public Entity? Entity { get; }
        public bool IsEmpty => Entity != null;
    }
}

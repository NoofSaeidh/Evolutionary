﻿using Evolutionary.Core.Entities;
using Evolutionary.Core.Global;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Fielding
{
    [DebuggerDisplay("{ToString(),nq}")]
    public struct FieldCell
    {
        public FieldCell(Position? entityPosition, Entity? entity)
        {
            EntityPosition = entityPosition;
            Entity = entity;
        }

        public Position? EntityPosition { get; }
        public Entity? Entity { get; }
        public bool IsEmpty => Entity is null;

        public override string ToString()
        {
            if (IsEmpty)
                return "[Empty]";
            return $"{EntityPosition} - {Entity}";
        }
    }
}

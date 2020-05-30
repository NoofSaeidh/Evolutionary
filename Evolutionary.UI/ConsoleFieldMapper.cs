using Evolutionary.Core.Entities;
using Evolutionary.Core.Mapping;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.UI
{
    public class ConsoleFieldMapper : IFieldMapper
    {
        public static readonly FieldView Empty = new FieldView(Color.Gray, ' ');
        public static readonly FieldView Entity = new FieldView(Color.Blue, '^');
        public static readonly FieldView Creature = new FieldView(Color.Green, '+');

        public FieldView MapField(Field field)
        {
            switch (field.Entity)
            {
                case Creature _:
                    return Creature;
                case Entity _:
                    return Entity;
                default:
                    return Empty;
            }
        }
    }
}

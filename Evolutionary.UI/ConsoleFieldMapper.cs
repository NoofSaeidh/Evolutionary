using Evolutionary.Core.Entities;
using Evolutionary.Core.Fielding;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.UI
{
    public class ConsoleFieldMapper : IFieldCellMapper
    {
        public static readonly FieldCellView Empty = new FieldCellView(Color.Gray, ' ');
        public static readonly FieldCellView Entity = new FieldCellView(Color.Blue, '^');
        public static readonly FieldCellView Creature = new FieldCellView(Color.Green, '+');

        public FieldCellView MapCell(FieldCell cell)
        {
            switch (cell.Entity)
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

using Evolutionary.Core.Fielding;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1FieldMapper : IFieldCellMapper
    {
        private readonly IFieldCellMapper _base;

        public static readonly FieldCellView Healthy = new FieldCellView(Color.Green, '+');
        public static readonly FieldCellView Hurt = new FieldCellView(Color.Orange, '+');
        public static readonly FieldCellView Dying = new FieldCellView(Color.Red, '+');

        public Ex1FieldMapper(IFieldCellMapper @base)
        {
            _base = @base;
        }

        public FieldCellView MapCell(FieldCell cell)
        {
            if(cell.Entity is Ex1Creature entity)
            {
                if (entity.Health < entity.MaxHealth / 2)
                    if (entity.Health < entity.MaxHealth / 4)
                        return Dying;
                    else
                        return Hurt;
                else
                    return Healthy;
            }

            return _base.MapCell(cell);
        }
    }
}

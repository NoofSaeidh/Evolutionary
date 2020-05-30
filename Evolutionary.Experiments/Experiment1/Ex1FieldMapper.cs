using Evolutionary.Core.Mapping;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1FieldMapper : IFieldMapper
    {
        private readonly IFieldMapper _base;

        public static readonly FieldView Healthy = new FieldView(Color.Green, '+');
        public static readonly FieldView Hurt = new FieldView(Color.Orange, '+');
        public static readonly FieldView Dying = new FieldView(Color.Red, '+');

        public Ex1FieldMapper(IFieldMapper @base)
        {
            _base = @base;
        }

        public FieldView MapField(Field field)
        {
            if(field.Entity is Ex1Creature entity)
            {
                if (entity.Health < entity.MaxHealth / 2)
                    if (entity.Health < entity.MaxHealth / 4)
                        return Dying;
                    else
                        return Hurt;
                else
                    return Healthy;
            }

            return _base.MapField(field);
        }
    }
}

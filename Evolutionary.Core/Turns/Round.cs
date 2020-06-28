using Evolutionary.Core.Fielding;
using Evolutionary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public class Round
    {
        public Round(Field field)
        {
            ThrowHelper.Check_ArgumentNull(field, nameof(field));
            Field = field;
        }

        public Field Field { get; }
    }
}
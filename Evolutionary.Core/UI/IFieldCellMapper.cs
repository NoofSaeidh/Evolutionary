using Evolutionary.Core.Fielding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.UI
{
    // todo: map position?
    public interface IFieldCellMapper
    {
        FieldCellView MapCell(FieldCell cell);
    }
}

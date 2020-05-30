using Evolutionary.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.UI
{
    public interface IFieldMapper
    {
        FieldView MapField(Field field);
    }
}

using Evolutionary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public interface ITurner
    {
        void CalculateTurn(IReadOnlyList<ITurnable> turnables);
    }
}

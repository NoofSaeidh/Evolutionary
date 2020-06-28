using Evolutionary.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public interface ITurnable
    {
        void TakeTurn(Round round, Position currentPosition);
    }
}

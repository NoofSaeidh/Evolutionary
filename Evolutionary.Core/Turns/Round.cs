using Evolutionary.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public class Round
    {
        public Round(Map map)
        {
            Map = map;
        }

        public Map Map { get; }
    }
}
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public class DefaultRoundProcessor : IRoundProcessor
    {
        public void ProcessRound(Round round)
        {
            for (int x = 0; x < round.Map.Size.X; x++)
            {
                for (int y = 0; y < round.Map.Size.Y; y++)
                {
                    var item = round.Map[x, y];
                    if (item.Entity is ITurnable turnable)
                    {
                        turnable.TakeTurn(round, new Mapping.MapIndex(x, y));
                    }
                }
            }
        }
    }
}

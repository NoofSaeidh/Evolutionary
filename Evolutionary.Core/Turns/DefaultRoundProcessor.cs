using Evolutionary.Core.Mapping;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionary.Core.Turns
{
    public class DefaultRoundProcessor : IRoundProcessor
    {

        public DefaultRoundProcessor(IRenderer renderer)
        {
            Renderer = renderer;
        }

        protected IRenderer Renderer { get; }
        
        public virtual void ProcessRound(Round round)
        {
            for (int x = 0; x < round.Map.Size.X; x++)
            {
                for (int y = 0; y < round.Map.Size.Y; y++)
                {
                    var item = round.Map[x, y];
                    if (item.Entity is ITurnable turnable)
                    {
                        turnable.TakeTurn(round, new Position(x, y));
                    }
                }
            }

            Renderer.RenderRound(round);
        }
    }
}

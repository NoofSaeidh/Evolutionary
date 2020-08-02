using Evolutionary.Core.Fielding;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            foreach (var (entity, position) in round.Field.GetEntities())
            {
                if (entity is ITurnable turnable)
                    turnable.TakeTurn(round, position);
                Debug.Write($"Previous position: {position}, new position: {round.Field.GetPosition(entity)}");
            }

            Renderer.RenderRound(round);
        }
    }
}

﻿using Evolutionary.Core.Turns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionary.Core.UI
{
    public interface IRenderer
    {
        Task RenderRound(Round round);
    }
}

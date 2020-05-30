using System;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using Evolutionary.Core;
using Evolutionary.Core.Initialization;
using Evolutionary.Core.UI;
using Evolutionary.Experiments.Experiment1;
using Evolutionary.UI;

namespace Evolutionary.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DefaultModule>();

            builder.RegisterModule<Ex1Module>();

            using (var container = builder.Build())
            {
                container.Resolve<Application>().Start().GetAwaiter().GetResult();
            }
        }
    }
}

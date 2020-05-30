using Autofac;
using Evolutionary.Core;
using Evolutionary.Core.Generations;
using Evolutionary.Core.Initialization;
using Evolutionary.Core.Turns;
using Evolutionary.Core.UI;
using Evolutionary.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Host
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ConsoleCancellationSource>()
                   .As<ICancellationSource>()
                   .SingleInstance();

            builder.RegisterType<ConsoleRenderer>()
                   .As<IRenderer>()
                   .SingleInstance();

            builder.RegisterType<Application>()
                   .AsSelf();

            builder.RegisterType<DefaultRoundProcessor>()
                   .As<IRoundProcessor>();

            builder.RegisterType<DefaultGenerationProcessor>()
                   .As<IGenerationProcessor>();
        }
    }
}

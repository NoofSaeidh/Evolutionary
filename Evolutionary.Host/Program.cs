using System;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using Evolutionary.Core;
using Evolutionary.Core.UI;
using Evolutionary.UI;

namespace Evolutionary.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleCancellationSource>()
                   .As<ICancellationSource>()
                   .SingleInstance();

            builder.RegisterType<ConsoleRenderer>()
                   .As<IRenderer>()
                   .SingleInstance();

            builder.RegisterType<Startup>()
                   .AsSelf();

            using (var container = builder.Build())
            {
                container.Resolve<Startup>().Start().GetAwaiter().GetResult();
            }
        }
    }
}

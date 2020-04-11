using System;
using System.Threading;
using Autofac;
using Evolutionary.Core;
using Evolutionary.UI.Console;

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

            builder.RegisterType<Startup>()
                   .AsSelf();

            using (var container = builder.Build())
            {
                container.Resolve<Startup>().Start().GetAwaiter().GetResult();
            }
        }
    }
}

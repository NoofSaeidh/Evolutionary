using Autofac;
using Evolutionary.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.UI
{
    public class ConsoleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ConsoleCancellationSource>()
                   .As<ICancellationSource>()
                   .SingleInstance();

            builder.RegisterType<ConsoleRenderer>()
                   .As<IRenderer>()
                   .As<IStartable>()
                   .SingleInstance()
                   .AutoActivate();

            builder.RegisterType<ConsoleFieldMapper>()
                   .As<IFieldMapper>()
                   .SingleInstance();
        }
    }
}

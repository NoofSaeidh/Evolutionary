using Autofac;
using Evolutionary.Core.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Ex1Initializer>().As<IInitializer>();
        }
    }
}

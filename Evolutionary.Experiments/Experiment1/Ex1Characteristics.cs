using Evolutionary.Core.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public static class Ex1Characteristics
    {
        public static readonly Characteristic Speed = new Characteristic(nameof(Speed), mutable: true);
        public static readonly Characteristic Vision = new Characteristic(nameof(Vision), mutable: true);
        public static readonly Characteristic MaxHealth = new Characteristic(nameof(MaxHealth), mutable: true);
        public static readonly Characteristic Size = new Characteristic(nameof(Size), mutable: false);
        public static readonly Characteristic Health = new Characteristic(nameof(Health), mutable: false);
    }
}

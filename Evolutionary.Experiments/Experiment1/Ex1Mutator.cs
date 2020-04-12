using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1Mutator : IMutator
    {
        private readonly Random _rand = new Random();
        public CharacteristicsList MutateCharacteristics(CharacteristicsList values)
        {
            var speed = values[Ex1Characteristics.Speed];
            var vision = values[Ex1Characteristics.Vision];
            if (Mutate())
            {
                if (Mutate())
                    speed++;
                else
                    speed--;
                if (Mutate())
                    vision++;
                else
                    vision--;
            }
            var health = 100 - speed - vision;
            return new CharacteristicsList(new[]
            {
                new CharacteristicValue(speed, Ex1Characteristics.Speed),
                new CharacteristicValue(vision, Ex1Characteristics.Vision),
                new CharacteristicValue(health, Ex1Characteristics.MaxHealth),
            });

            bool Mutate() => _rand.Next(0, 1) == 1;
        }
        //public CharacteristicsList MutateCharacteristics(CharacteristicsList values)
        //{
        //    var ar = new CharacteristicValue[values.Count];
        //    values.CopyTo(ar, 0);
        //    for (int i = 0; i < ar.Length; i++)
        //    {
        //        if (_rand.Next(0, 1) == 1)
        //        {
        //            var element = ar[i];
        //            ar[i] = new CharacteristicValue(element.Value, element.Characteristic);
        //        }
        //    }
        //    return new CharacteristicsList(ar);
        //}
    }
}

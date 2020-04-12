﻿using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Entities;
using Evolutionary.Core.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Experiments.Experiment1
{
    public class Ex1Entity : Creature<Ex1Entity>
    {
        public Ex1Entity(int speed, int vision, int maxHealth)
        {
            Speed = speed;
            Vision = vision;
            MaxHealth = maxHealth;
        }

        public int Speed { get; }
        public int Vision { get; }
        public int MaxHealth { get; }

        protected override CharacteristicsList GetCharacteristics()
        {
            return new CharacteristicsList(new[]
            {
                new CharacteristicValue(Speed, Ex1Characteristics.Speed),
                new CharacteristicValue(Vision, Ex1Characteristics.Vision),
                new CharacteristicValue(MaxHealth, Ex1Characteristics.MaxHealth),
            });
        }

        protected override Ex1Entity CreateSelfFromCharacteristics(CharacteristicsList chars)
        {
            return new Ex1Entity(chars[Ex1Characteristics.Speed],
                                 chars[Ex1Characteristics.Vision],
                                 chars[Ex1Characteristics.MaxHealth]);
        }
    }
}

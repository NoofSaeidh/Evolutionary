using Evolutionary.Core.Characteristics;
using Evolutionary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Tests.Mock
{
    public class TestCreature : Creature<TestCreature>
    {
        public override string Description => nameof(TestCreature);

        protected override TestCreature CreateSelfFromCharacteristics(CharacteristicsList chars)
        {
            throw new NotImplementedException();
        }

        protected override CharacteristicsList GetCharacteristics()
        {
            throw new NotImplementedException();
        }
    }
}

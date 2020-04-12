using Evolutionary.Core.Characteristics;
using System;
using System.Collections.Generic;

namespace Evolutionary.Core.Mutations
{
    public interface IMutator
    {
        CharacteristicsList MutateCharacteristics(CharacteristicsList values);
    }
}
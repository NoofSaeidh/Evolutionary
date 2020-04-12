using Evolutionary.Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Characteristics
{
    public class CharacteristicsList : IReadOnlyList<CharacteristicValue>, ICollection
    {
        private readonly CharacteristicValue[] _values;

        public CharacteristicsList(params CharacteristicValue[] values)
        {
            _values = values;
        }

        public CharacteristicValue this[int index] => _values[index];
        public int this[Characteristic characteristic]
        {
            get
            {
                var val = Array.Find(_values, c => c.Characteristic.Equals(characteristic));
                if (val == default)
                    throw new ArgumentException("Cannot find value with specified index");
                return val.Value;
            }
        }

        public int Count => _values.Length;

        public bool IsSynchronized => _values.IsSynchronized;

        public object SyncRoot => _values.SyncRoot;

        public void CopyTo(Array array, int index)
        {
            _values.CopyTo(array, index);
        }

        public IEnumerator<CharacteristicValue> GetEnumerator()
        {
            return ((IReadOnlyList<CharacteristicValue>)_values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

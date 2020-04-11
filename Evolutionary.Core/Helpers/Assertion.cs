using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Helpers
{
    internal static class Assertion
    {
        [Conditional("DEBUG")]
        public static void AssertPosition(int index, int maxValue, string paramName)
        {
            if (index < 0 || index >= maxValue)
            {
                throw new ArgumentOutOfRangeException(paramName, "Index was out of range");
            }
        }
    }
}

using Evolutionary.Core.Global;
using Evolutionary.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Helpers
{
    internal static class ThrowHelper
    {
        [Conditional("DEBUG")]
        public static void Check_ArgumentNull(object? obj, string paramName)
        {
            if (obj is null)
                throw new ArgumentNullException(paramName);
        }

        [Conditional("DEBUG")]
        public static void Check_ArgumentOutOfRange(Index2d index, Index2d maxValue, string paramName)
        {
            Check_ArgumentOutOfRange(index.X, maxValue.X, paramName);
            Check_ArgumentOutOfRange(index.Y, maxValue.Y, paramName);
        }

        [Conditional("DEBUG")]
        public static void Check_ArgumentOutOfRange(int index, int maxValue, string paramName)
        {
            if (index < 0 || index >= maxValue)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        [Conditional("DEBUG")]
        public static void Check_StructNotInitalized(params object?[] properties)
        {
            if (properties.Any(p => p is null))
            {
                throw new InvalidOperationException("The struct was not initialized. One of property is null.");
            }
        }

    }
}

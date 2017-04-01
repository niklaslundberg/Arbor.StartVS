using System.Collections.Generic;
using System.Collections.Immutable;

namespace StartVS
{
    public static class CustomImmutableArrayExtensions
    {
        public static ImmutableArray<T> SafeToImmutableArray<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return ImmutableArray<T>.Empty;

            if (enumerable is ImmutableArray<T>)
                return (ImmutableArray<T>) enumerable;

            return enumerable.ToImmutableArray();
        }
    }
}
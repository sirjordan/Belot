using System.Collections.Generic;

namespace Belot.Helpers
{
    public static class Extenders
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            foreach (T item in values)
            {
                collection.Add(item);
            }
        }
    }
}

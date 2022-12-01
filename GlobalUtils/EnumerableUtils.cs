using System.Collections.Generic;
using System.Linq;

namespace GlobalUtils {
    public static class EnumerableUtils {
        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> enumerable) {
            return enumerable.Where(item1 => enumerable.Count(item2 => EqualityComparer<T>.Default.Equals(item2, item1)) > 1).Distinct();
        }
    }
}
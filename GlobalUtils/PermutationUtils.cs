using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalUtils {
    public class PermutationUtils {

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length) {
            if (length == 1)
                return list.Select(item => new T[] { item });

            return GetPermutations(list, length - 1).SelectMany(
                    item => list.Where(itemDuplicate => !item.Contains(itemDuplicate)),
                    (item1, item2) => item1.Concat(new T[] { item2 })
                );
        }
    }
}
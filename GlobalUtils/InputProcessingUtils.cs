
using System.Collections.Generic;
using System.Text;

namespace GlobalUtils {
    public static class InputProcessingUtils {

        public static List<string> ConcatGroupOfLines<T>(T input, string groupItemSeparator, string groupSeparator,
                  bool insertSeparatorAfterLastLine = true) where T : ICollection<string> {
            var concatenatedGroups = new List<string>();
            var stringBuilder = new StringBuilder();

            if (insertSeparatorAfterLastLine)
                input.Add(groupSeparator);

            foreach (var row in input) {
                if (row != groupSeparator) {
                    _ = stringBuilder.Append($"{groupItemSeparator}{row}");
                }
                else {
                    concatenatedGroups.Add(stringBuilder.ToString().Trim());
                    _ = stringBuilder.Clear();
                }
            }

            return concatenatedGroups;
        }
    }
}
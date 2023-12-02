using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2022.Day06 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var code = input[0];

            var part1 = FindMarker(code, 4);
            var part2 = FindMarker(code, 14);

            return (part1, part2);
        }

        private static int FindMarker(string code, int distinctCount) {
            for (var i = 0; i < code.Length; i++) {
                var distinctCodePart = code.Skip(i).Take(distinctCount).Distinct().Count();
                if (distinctCodePart == distinctCount) {
                    return i + distinctCount;
                }
            }
            return -1;
        }
    }
}
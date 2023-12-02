using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2022.Day03 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => true;

        public (object, object) Solve(List<string> input) {
            var part1 = 0;
            var part2 = 0;

            foreach (var line in input) {
                var middle = line.Length / 2;
                var compartment1 = line[..middle].ToCharArray();
                var compartment2 = line[middle..].ToCharArray();

                part1 += CalculateSharedItemPriority(new[] { compartment1, compartment2 });
            }

            for (var i = 0; i < input.Count; i += 3) {
                var compartment1 = input[i].ToCharArray();
                var compartment2 = input[i + 1].ToCharArray();
                var compartment3 = input[i + 2].ToCharArray();

                part2 += CalculateSharedItemPriority(new[] { compartment1, compartment2, compartment3 });
            }

            return (part1, part2);
        }

        private static int CalculateSharedItemPriority(char[][] compartments) {
            var sharedItem = compartments.Aggregate((c1, c2) => c1.Intersect(c2).ToArray()).Single();
            return sharedItem - (char.IsUpper(sharedItem) ? 38 : 96);

        }
    }
}
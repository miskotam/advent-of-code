using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Day02 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = input.Sum(row => {
                var sideLengths = row.Split('x').Select(int.Parse).ToArray();
                var side1 = sideLengths[0] * sideLengths[1];
                var side2 = sideLengths[2] * sideLengths[1];
                var side3 = sideLengths[2] * sideLengths[0];
                return 2 * side1 + 2 * side2 + 2 * side3 + new[] { side1, side2, side3 }.Min();
            });

            object part2 = input.Sum(row => {
                var sideLengths = row.Split('x').Select(int.Parse).ToArray().OrderBy(x => x).ToArray();
                var smallestFaceSize = 2 * sideLengths[0] + 2 * sideLengths[1];
                return smallestFaceSize + sideLengths[0] * sideLengths[1] * sideLengths[2];
            });

            return (part1, part2);
        }
    }
}
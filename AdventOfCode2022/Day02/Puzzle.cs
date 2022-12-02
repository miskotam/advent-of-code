using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2022.Day02 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var scoreTablePart1 = new Dictionary<string, int> {
                ["A X"] = 1 + 3,
                ["A Y"] = 2 + 6,
                ["A Z"] = 3 + 0,
                ["B X"] = 1 + 0,
                ["B Y"] = 2 + 3,
                ["B Z"] = 3 + 6,
                ["C X"] = 1 + 6,
                ["C Y"] = 2 + 0,
                ["C Z"] = 3 + 3
            };
            part1 = input.Sum(line => scoreTablePart1[line]);

            var scoreTablePart2 = new Dictionary<string, int> {
                ["A X"] = 3 + 0,
                ["A Y"] = 1 + 3,
                ["A Z"] = 2 + 6,
                ["B X"] = 1 + 0,
                ["B Y"] = 2 + 3,
                ["B Z"] = 3 + 6,
                ["C X"] = 2 + 0,
                ["C Y"] = 3 + 3,
                ["C Z"] = 1 + 6
            };
            part2 = input.Sum(line => scoreTablePart2[line]);

            return (part1, part2);
        }
    }
}
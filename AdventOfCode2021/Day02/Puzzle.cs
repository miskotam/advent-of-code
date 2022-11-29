using System.Collections.Generic;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2021.Day02 {

    public partial class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            (int depth, int dist) submarinePositionPart1 = (0, 0);
            (int depth, int dist, int aim) submarinePositionPart2 = (0, 0, 0);

            var pattern = new Regex("""(?<command>\w+) (?<value>\d+)""");

            foreach (var line in input) {
                var match = pattern.Match(line);
                var command = match.Groups["command"].Value;
                var value = int.Parse(match.Groups["value"].Value);
                switch (command) {
                    case "forward":
                        submarinePositionPart1.dist += value;
                        submarinePositionPart2.depth += value;
                        submarinePositionPart2.dist += submarinePositionPart2.aim * value;
                        break;
                    case "up":
                        submarinePositionPart1.depth -= value;
                        submarinePositionPart2.aim -= value;
                        break;
                    case "down":
                        submarinePositionPart1.depth += value;
                        submarinePositionPart2.aim += value;
                        break;
                }
            }

            object part1 = submarinePositionPart1.depth * submarinePositionPart1.dist;
            object part2 = submarinePositionPart2.depth * submarinePositionPart2.dist;

            return (part1, part2);
        }
    }
}
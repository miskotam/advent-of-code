using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day09 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;
        private static readonly Regex _pattern = new("""(?<direction>\w+) (?<distance>\d+)""");

        public (object, object) Solve(List<string> input) {

            var part1 = CalculateRopePathLength(input, 2);
            var part2 = CalculateRopePathLength(input, 10);

            return (part1, part2);
        }

        private static int CalculateRopePathLength(List<string> input, int ropeLength) {
            var rope = new (int x, int y)[ropeLength];
            var visited = new HashSet<(int, int)> { (0, 0) };
            foreach (var line in input) {
                var match = _pattern.Match(line);
                var direction = match.Groups["direction"].Value;
                var distance = int.Parse(match.Groups["distance"].Value);
                for (var dist = 0; dist < distance; dist++) {
                    switch (direction) {
                        case "R":
                            rope[0] = (rope[0].x + 1, rope[0].y);
                            break;
                        case "L":
                            rope[0] = (rope[0].x - 1, rope[0].y);
                            break;
                        case "U":
                            rope[0] = (rope[0].x, rope[0].y + 1);
                            break;
                        case "D":
                            rope[0] = (rope[0].x, rope[0].y - 1);
                            break;
                    }
                    for (var i = 1; i < ropeLength; i++) {
                        var (x, y) = rope[i - 1];
                        var delta = (x: x - rope[i].x, y: y - rope[i].y);
                        if (delta.x > 1 && delta.y > 1) {
                            rope[i] = (x - 1, y - 1);
                        }
                        else if (delta.x > 1 && delta.y < -1) {
                            rope[i] = (x - 1, y + 1);
                        }
                        else if (delta.x < -1 && delta.y > 1) {
                            rope[i] = (x + 1, y - 1);
                        }
                        else if (delta.x < -1 && delta.y < -1) {
                            rope[i] = (x + 1, y + 1);
                        }
                        else if (delta.x < -1) {
                            rope[i] = (x + 1, y);
                        }
                        else if (delta.y < -1) {
                            rope[i] = (x, y + 1);
                        }
                        else if (delta.x > 1) {
                            rope[i] = (x - 1, y);
                        }
                        else if (delta.y > 1) {
                            rope[i] = (x, y - 1);
                        }
                    }
                    _ = visited.Add(rope.Last());
                }
            }

            return visited.Count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2021.Day05 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var mapPart1 = new Dictionary<(int, int), int>();
            var mapPart2 = new Dictionary<(int, int), int>();
            var pattern = new Regex("""(?<x1>\d+),(?<y1>\d+) -> (?<x2>\d+),(?<y2>\d+)""");

            foreach (var line in input) {
                var match = pattern.Match(line);
                var x1 = int.Parse(match.Groups["x1"].Value);
                var y1 = int.Parse(match.Groups["y1"].Value);
                var x2 = int.Parse(match.Groups["x2"].Value);
                var y2 = int.Parse(match.Groups["y2"].Value);
                if (x1 == x2) {
                    var ys = new[] { y1, y2 }.OrderBy(y => y).ToArray();
                    for (var i = ys[0]; i < ys[1] + 1; i++) {
                        var point = (x1, i);
                        if (!mapPart1.ContainsKey(point))
                            mapPart1[point] = 0;
                        mapPart1[point]++;
                        if (!mapPart2.ContainsKey(point))
                            mapPart2[point] = 0;
                        mapPart2[point]++;
                    }
                }
                else
                if (y1 == y2) {
                    var xs = new[] { x1, x2 }.OrderBy(x => x).ToArray();
                    for (var i = xs[0]; i < xs[1] + 1; i++) {
                        var point = (i, y1);
                        if (!mapPart1.ContainsKey(point))
                            mapPart1[point] = 0;
                        mapPart1[point]++;
                        if (!mapPart2.ContainsKey(point))
                            mapPart2[point] = 0;
                        mapPart2[point]++;
                    }
                }
                else {
                    var delta = (x: Math.Sign(x2 - x1), y: Math.Sign(y2 - y1));
                    var x = x1;
                    var y = y1;
                    var point = (x, y);
                    if (!mapPart2.ContainsKey(point))
                        mapPart2[point] = 0;
                    mapPart2[point]++;

                    while (x != x2 && y != y2) {
                        x += delta.x;
                        y += delta.y;
                        point = (x, y);
                        if (!mapPart2.ContainsKey(point))
                            mapPart2[point] = 0;
                        mapPart2[point]++;
                    }
                }

            }

            var part1 = mapPart1.Values.Count(x => x > 1);
            var part2 = mapPart2.Values.Count(x => x > 1);

            return (part1, part2);
        }
    }
}
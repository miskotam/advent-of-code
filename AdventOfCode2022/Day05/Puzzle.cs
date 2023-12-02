using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day05 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var cratesPart1 = CreateCranes(input);
            var cratesPart2 = CreateCranes(input);

            var pattern = new Regex("""move (?<count>\d+) from (?<from>\d+) to (?<to>\d+)""");
            var operations = input.SkipWhile(line => !line.StartsWith("move")).Select(line => {
                var match = pattern.Match(line);
                var count = int.Parse(match.Groups["count"].Value);
                var from = int.Parse(match.Groups["from"].Value) - 1;
                var to = int.Parse(match.Groups["to"].Value) - 1;
                return (count, from, to);
            }).ToArray();

            RearrangeCrates(cratesPart1, operations, false);
            RearrangeCrates(cratesPart2, operations, true);

            part1 = cratesPart1.Select(x => x.LastOrDefault().ToString()).Aggregate((x, y) => x + y);
            part2 = cratesPart2.Select(x => x.LastOrDefault().ToString()).Aggregate((x, y) => x + y);

            return (part1, part2);
        }

        private static void RearrangeCrates(List<List<char>> cratesPart1, (int count, int from, int to)[] operations, bool isCrateMover9001) {
            foreach (var operation in operations) {
                var (count, from, to) = operation;
                var toMove = new List<char>();
                for (var i = 0; i < count; i++) {
                    var crate = cratesPart1[from].Last();
                    cratesPart1[from].RemoveAt(cratesPart1[from].Count - 1);
                    toMove.Add(crate);
                }
                if (isCrateMover9001)
                    toMove.Reverse();
                foreach (var item in toMove)
                    cratesPart1[to].Add(item);
            }
        }

        private static List<List<char>> CreateCranes(List<string> input) {
            var cranes = new List<List<char>>();
            var craneCount = (int)Math.Ceiling(input[0].Length / 4.0);
            for (var c = 0; c < craneCount; c++)
                cranes.Add(new List<char>());

            for (var i = 0; i < input.Count; i++) {
                var line = input[i];
                if (line.Contains('[')) {
                    for (var c = 0; c < craneCount; c++) {
                        var crate = line[1 + c * 4];
                        if (crate == ' ')
                            continue;
                        cranes[c].Insert(0, crate);
                    }
                }
                else {
                    break;
                }
            }
            return cranes;
        }
    }
}
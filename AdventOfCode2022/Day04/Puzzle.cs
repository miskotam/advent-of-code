using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day04 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = 0;
            var part2 = 0;
            var pattern = new Regex("""(?<elf1S>\d+)-(?<elf1E>\d+),(?<elf2S>\d+)-(?<elf2E>\d+)""");

            foreach (var line in input) {
                var match = pattern.Match(line);
                var elf1S = int.Parse(match.Groups["elf1S"].Value);
                var elf1E = int.Parse(match.Groups["elf1E"].Value);
                var elf2S = int.Parse(match.Groups["elf2S"].Value);
                var elf2E = int.Parse(match.Groups["elf2E"].Value);
                var range1 = Enumerable.Range(elf1S, elf1E - elf1S + 1).ToList();
                var range2 = Enumerable.Range(elf2S, elf2E - elf2S + 1).ToList();
                var overlapCount = range1.Intersect(range2).Count();

                if (range1.Count == overlapCount || range2.Count == overlapCount) {
                    part1++;
                }
                if (overlapCount > 0) {
                    part2++;
                }
            }

            return (part1, part2);
        }
    }
}
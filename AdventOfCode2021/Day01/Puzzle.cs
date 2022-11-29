using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2021.Day01 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1List = input.ConvertAll(int.Parse);

            var part1 = part1List
                .Skip(1)
                .Select((x, i) => x > part1List[i] ? 1 : 0)
                .Sum();

            var part2List = part1List
                .Skip(2)
                .Select((_, i) => part1List[i] + part1List[i + 1] + part1List[i + 2])
                .ToList();

            var part2 = part2List
                .Skip(1)
                .Select((x, i) => x > part2List[i] ? 1 : 0)
                .Sum();

            return (part1, part2);
        }

    }
}
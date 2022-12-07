using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2021.Day06 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var fishes = new long[9];
            foreach (var fish in input[0].Split(',').Select(int.Parse))
                fishes[fish]++;


            var part1Count = 80;
            for (var i = 0; i < part1Count; i++)
                fishes = SimulateADay(fishes);
            part1 = fishes.Sum();

            var part2Count = 256;
            for (var i = part1Count; i < part2Count; i++)
                fishes = SimulateADay(fishes);
            part2 = fishes.Sum();

            return (part1, part2);
        }

        private static long[] SimulateADay(long[] fishes) {
            return new long[]{
                fishes[1],
                fishes[2],
                fishes[3],
                fishes[4],
                fishes[5],
                fishes[6],
                fishes[7] + fishes[0],
                fishes[8],
                fishes[0]
            };
        }
    }
}
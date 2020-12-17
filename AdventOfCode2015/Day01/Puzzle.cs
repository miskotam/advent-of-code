using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Day01 {
    public class Puzzle {
        public (object, object) Solve(List<string> input) {
            var part1 = Part1(input);
            var part2 = Part2(input);

            return (part1, part2);
        }

        private static int Part1(List<string> input) => input[0].Sum(c => c == '(' ? 1 : -1);

        private static int Part2(List<string> input) {
            int part2;
            var currentLevel = 0;
            part2 = -1;
            for (var i = 0; i < input[0].Length; i++) {
                if (input[0][i] == '(')
                    currentLevel++;
                else
                    currentLevel--;

                if (currentLevel == -1) {
                    part2 = i + 1;
                    break;
                }
            }

            return part2;
        }
    }
}
using System.Collections.Generic;
using GlobalUtils;

namespace AdventOfCode2015.Day03 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;
        public (object, object) Solve(List<string> input) {
            var part1 = Part1(input);
            var part2 = Part2(input);

            return (part1, part2);
        }

        private static int Part1(List<string> input) {
            var x = 0;
            var y = 0;
            var robotSantaDirections = new HashSet<(int x, int y)> { (x, y) };

            foreach (var direction in input[0])
                _ = robotSantaDirections.Add(CheckDirection(direction, ref x, ref y));

            return robotSantaDirections.Count;
        }

        private static int Part2(List<string> input) {
            var x1 = 0;
            var y1 = 0;
            var x2 = 0;
            var y2 = 0;
            var robotSantaDirections = new HashSet<(int x, int y)> { (x1, y1) };

            for (var i = 0; i < input[0].Length; i++) {
                var direction = input[0][i];
                if (i % 2 == 0)
                    _ = robotSantaDirections.Add(CheckDirection(direction, ref x1, ref y1));
                else
                    _ = robotSantaDirections.Add(CheckDirection(direction, ref x2, ref y2));
            }

            return robotSantaDirections.Count;
        }

        private static (int x, int y) CheckDirection(char direction, ref int x, ref int y) {
            switch (direction) {
                case '^':
                    y++;
                    break;
                case 'v':
                    y--;
                    break;
                case '>':
                    x++;
                    break;
                case '<':
                    x--;
                    break;
            }

            return (x, y);
        }
    }
}
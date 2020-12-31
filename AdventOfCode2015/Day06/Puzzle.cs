using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace AdventOfCode2015.Day06 {
    public class Puzzle : IPuzzle {
        private static readonly string _pattern =
            @"(?<type>turn on|turn off|toggle) (?<x1>\d{1,3}),(?<y1>\d{1,3}) through (?<x2>\d{1,3}),(?<y2>\d{1,3})";

        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = Part1(input);
            var part2 = Part2(input);

            return (part1, part2);
        }

        private static object Part1(List<string> input) {
            var lightGrid = new Dictionary<(int x, int y), bool>();
            return ProcessInput(input, lightGrid, (grid, actionType, x, y) => TurnLightsOnOff(ref grid, actionType, x, y)).Count(v => v);
        }

        private static object Part2(List<string> input) {
            var lightGrid = new Dictionary<(int x, int y), int>();
            return ProcessInput(input, lightGrid, (grid, actionType, x, y) => SetLightsBrightness(ref grid, actionType, x, y)).Sum(v => v);
        }

        private static Dictionary<(int x, int y), T>.ValueCollection ProcessInput<T>(List<string> input,
            Dictionary<(int x, int y), T> lightGrid,
            Action<Dictionary<(int x, int y), T>, string, int, int> solver) {
            foreach (var line in input) {
                var match = Regex.Match(line, _pattern);
                var type = match.Groups["type"].Value;
                var x1 = int.Parse(match.Groups["x1"].Value);
                var x2 = int.Parse(match.Groups["x2"].Value);
                var y1 = int.Parse(match.Groups["y1"].Value);
                var y2 = int.Parse(match.Groups["y2"].Value);

                for (var x = x1; x <= x2; x++) {
                    for (var y = y1; y <= y2; y++) {
                        if (!lightGrid.ContainsKey((x, y)))
                            lightGrid[(x, y)] = default;

                        solver(lightGrid, type, x, y);
                    }
                }
            }

            return lightGrid.Values;
        }

        private static void TurnLightsOnOff(ref Dictionary<(int x, int y), bool> lightGrid, string type, int x, int y) {
            if (string.Equals(type, "turn on"))
                lightGrid[(x, y)] = true;
            else if (string.Equals(type, "turn off"))
                lightGrid[(x, y)] = false;
            else
                lightGrid[(x, y)] = !lightGrid[(x, y)];
        }

        private static void SetLightsBrightness(ref Dictionary<(int x, int y), int> lightGrid, string type, int x, int y) {
            if (string.Equals(type, "turn on"))
                lightGrid[(x, y)] = lightGrid[(x, y)] + 1;
            else if (string.Equals(type, "turn off"))
                lightGrid[(x, y)] = Math.Max(0, lightGrid[(x, y)] - 1);
            else
                lightGrid[(x, y)] = lightGrid[(x, y)] + 2;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day10 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part2 = null;

            var pattern = new Regex("""(?<instruction>\w+)( (?<value>-*\d+))?""");
            var cycles = 0;
            var spritePosition = 1;
            var samples = new List<int>();
            var pixels = new List<char>();

            foreach (var line in input) {
                var match = pattern.Match(line);
                var instruction = match.Groups["instruction"].Value;
                if (instruction == "addx") {
                    RunCycle(ref cycles, spritePosition, samples, pixels);
                    RunCycle(ref cycles, spritePosition, samples, pixels);
                    var value = int.Parse(match.Groups["value"].Value);
                    spritePosition += value;
                }
                else {
                    RunCycle(ref cycles, spritePosition, samples, pixels);
                }
            }
            var part1 = samples.Sum();
            for (var i = 0; i < pixels.Count; i++) {
                if (i % 40 == 0)
                    Console.WriteLine();
                Console.Write(pixels[i]);
            }
            Console.WriteLine();
            return (part1, part2);
        }

        private static void RunCycle(ref int cycles, int spritePosition, List<int> samples, List<char> pixels) {
            cycles++;

            var register = (cycles - 20) % 40 == 0;
            if (register)
                samples.Add(spritePosition * cycles);

            var draw = new[] { spritePosition - 1, spritePosition, spritePosition + 1 }.Contains(cycles % 40 - 1);
            pixels.Add(draw ? '#' : '.');
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2022.Day01 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var rawCalorieGroups = InputProcessingUtils.ConcatGroupOfLines(input, "\n", "");
            var parsedCalorieGroups = rawCalorieGroups.Select(group => group.Split('\n').Select(int.Parse));

            part1 = parsedCalorieGroups.Select(group => group.Sum()).Max();
            part2 = parsedCalorieGroups.Select(group => group.Sum()).OrderDescending().Take(3).Sum();

            return (part1, part2);
        }
    }
}
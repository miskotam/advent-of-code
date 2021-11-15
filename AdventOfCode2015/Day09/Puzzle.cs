using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2015.Day09 {

    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var distanceMap = input.Select(row => {
                var x = row.Split(" = ");
                var y = x[0].Split(" to ");
                return (from: y[0], to: y[1], distance: int.Parse(x[1]));
            }).ToList();

            var paths = TravelingSalesmanUtils.GenerateTSPPaths(distanceMap);

            return (paths.First().distance, paths.Last().distance);
        }
    }
}
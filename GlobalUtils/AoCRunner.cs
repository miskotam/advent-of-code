using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalUtils {
    public static class AoCRunner {
        public static async Task Run(int year, int day, List<IPuzzle> puzzles) {
            var puzzle = puzzles[day - 1];
            var input = await new InputLoader(year).ReadInput(day, puzzle.SampleMode);
            var result = puzzle.Solve(input);
            // new ClipboardUtils().CopyToClipBoard(result.Item2 ?? result.Item1);
            Console.WriteLine(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalUtils {
    public static class AoCRunner {
        public static async Task Run(List<IPuzzle> puzzles, int year, int day = -1) {
            day = day < 0 ? puzzles.Count : day;
            var puzzle = puzzles[day - 1];
            var input = await new InputLoader(year).ReadInput(day, puzzle.SampleMode);
            var result = puzzle.Solve(input);
            // new ClipboardUtils().CopyToClipBoard(result.Item2 ?? result.Item1);
            Console.WriteLine(result);
        }
    }
}
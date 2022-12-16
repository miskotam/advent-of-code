using System.Threading.Tasks;
using GlobalUtils;

namespace AdventOfCode2022 {
    public class Program {
        private static async Task Main() {
            await AoCRunner.Run(new() {
                    new Day01.Puzzle(),
                    new Day02.Puzzle(),
                    new Day03.Puzzle(),
                    new Day04.Puzzle(),
                    new Day05.Puzzle(),
                    new Day06.Puzzle(),
                    new Day07.Puzzle(),
                    new Day08.Puzzle(),
                    new Day09.Puzzle(),
                    new Day10.Puzzle(),
                    new Day11.Puzzle(),
                    new Day12.Puzzle(),
                }, 2022);
        }
    }
}
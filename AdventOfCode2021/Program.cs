using System.Threading.Tasks;
using GlobalUtils;

namespace AdventOfCode2021 {
    public class Program {
        private static async Task Main() {
            await AoCRunner.Run(2021, 6,
                new() {
                 new Day01.Puzzle(),
                 new Day02.Puzzle(),
                 new Day03.Puzzle(),
                 new Day04.Puzzle(),
                 new Day05.Puzzle(),
                 new Day06.Puzzle(),
                });
        }
    }
}
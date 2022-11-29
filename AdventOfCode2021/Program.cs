using System.Threading.Tasks;
using GlobalUtils;

namespace AdventOfCode2021 {
    public class Program {
        private static async Task Main() {
            await AoCRunner.Run(2021, 2,
                new() {
                 new Day01.Puzzle(),
                 new Day02.Puzzle(),
                });
        }
    }
}
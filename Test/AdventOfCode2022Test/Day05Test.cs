using System.Linq;
using AdventOfCode2022.Day05;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day05Test {

        private const string Input =
        "    [D]    \n[N] [C]    \n[Z] [M] [P]\n1   2   3\n\nmove 1 from 2 to 1\nmove 3 from 1 to 3\nmove 2 from 2 to 1\nmove 1 from 1 to 2";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split("\n").ToList());
            Assert.Equal("CMZ", result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split("\n").ToList());
            Assert.Equal("MCD", result.Item2);
        }
    }
}

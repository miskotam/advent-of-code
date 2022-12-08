using System.Linq;
using AdventOfCode2022.Day08;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day08Test {

        private const string Input = "30173\n25512\n65332\n23549\n35190";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split("\n").ToList());
            Assert.Equal(22, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split("\n").ToList());
            Assert.Equal(8, result.Item2);
        }
    }
}

using System.Linq;
using Xunit;
using AdventOfCode2015.Day10;

namespace AdventOfCode2015Test {
    public class Day10Test {
        private const string Input = "1";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(82350, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(1166642, result.Item2);
        }
    }
}

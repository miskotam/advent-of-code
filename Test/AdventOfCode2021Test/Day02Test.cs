using System.Linq;
using AdventOfCode2021.Day02;
using Xunit;

namespace AdventOfCode2021Test {
    public class Day02Test {
        private const string Input = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(150, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(900, result.Item2);
        }
    }
}

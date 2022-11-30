using System.Linq;
using AdventOfCode2021.Day03;
using Xunit;

namespace AdventOfCode2021Test {
    public class Day03Test {
        private const string Input = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(198, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(230, result.Item2);
        }
    }
}

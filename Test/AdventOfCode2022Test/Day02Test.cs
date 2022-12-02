using System.Linq;
using AdventOfCode2022.Day02;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day02Test {

        private const string Input = "A X\nA Y\nA Z\nB X\nB Y\nB Z\nC X\nC Y\nC Z\nA X";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(49, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(48, result.Item2);
        }
    }
}

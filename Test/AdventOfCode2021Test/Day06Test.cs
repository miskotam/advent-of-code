using System.Linq;
using AdventOfCode2021.Day06;
using Xunit;

namespace AdventOfCode2021Test {
    public class Day06Test {

        private const string Input = @"3,4,3,1,2";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(5934L, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(26984457539L, result.Item2);
        }
    }
}

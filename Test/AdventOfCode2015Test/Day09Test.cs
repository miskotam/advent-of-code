using System.Linq;
using Xunit;
using AdventOfCode2015.Day09;

namespace AdventOfCode2015Test {
    public class Day09Test {
        private const string Input = "London to Dublin = 464\nLondon to Belfast = 518\nDublin to Belfast = 141";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(605, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(982, result.Item2);
        }
    }
}

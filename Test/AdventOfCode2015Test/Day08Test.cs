using System.Linq;
using Xunit;
using AdventOfCode2015.Day08;

namespace AdventOfCode2015Test {
    public class Day08Test {
        private const string Input = "\"\"\n\"abc\"\n\"aaa\\\"aaa\"\n\"\\x27\"";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(12, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(19, result.Item2);
        }
    }
}

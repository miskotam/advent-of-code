using Xunit;
using System.Collections.Generic;
using AdventOfCode2015.Day06;

namespace AdventOfCode2015Test {
    public class Day06Test {
        [Theory]
        [InlineData("toggle 0,0 through 999,0\nturn off 499,499 through 500,500", 1000)]
        [InlineData("toggle 0,0 through 999,0", 1000)]
        [InlineData("turn off 499,499 through 500,500", 0)]
        public void TestPart1(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item1);
        }

        [Theory]
        [InlineData("toggle 0,0 through 999,0\nturn off 499,499 through 500,500", 2000)]
        [InlineData("toggle 0,0 through 999,0", 2000)]
        [InlineData("turn off 499,499 through 500,500", 0)]
        [InlineData("turn on 0,0 through 0,0", 1)]
        public void TestPart2(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item2);
        }
    }
}

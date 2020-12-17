using Xunit;
using System.Collections.Generic;
using AdventOfCode2015.Day02;

namespace AdventOfCode2015Test {
    public class Day02Test {
        [Theory]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void TestPart1(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item1);
        }

        [Theory]
        [InlineData("2x3x4", 34)]
        [InlineData("1x1x10", 14)]
        public void TestPart2(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item2);
        }
    }
}

using Xunit;
using System.Collections.Generic;
using AdventOfCode2015.Day03;

namespace AdventOfCode2015Test {
    public class Day03Test {
        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void TestPart1(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item1);
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void TestPart2(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item2);
        }
    }
}

using Xunit;
using System.Collections.Generic;
using AdventOfCode2015.Day04;

namespace AdventOfCode2015Test {
    public class Day04Test {
        [Theory]
        [InlineData("abcdef", 609043)]
        [InlineData("pqrstuv", 1048970)]
        [InlineData("bgvyzdsv", 254575)]
        public void TestPart1(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item1);
        }

        [Theory]
        [InlineData("bgvyzdsv", 1038736)]
        public void TestPart2(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item2);
        }
    }
}

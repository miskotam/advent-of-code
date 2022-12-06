using System.Collections.Generic;
using AdventOfCode2022.Day06;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day06Test {

        private const string Input = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(new List<string> { Input });
            Assert.Equal(7, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(new List<string> { Input });
            Assert.Equal(19, result.Item2);
        }
    }
}

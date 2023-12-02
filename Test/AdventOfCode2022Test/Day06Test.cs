using System.Collections.Generic;
using AdventOfCode2022.Day06;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day06Test {

        private const string Input = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";

        private readonly (object, object) _result;

        public Day06Test() => _result = new Puzzle().Solve(new List<string> { Input });

        [Fact]
        public void TestPart1() => Assert.Equal(7, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(19, _result.Item2);
    }
}

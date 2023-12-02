using System.Linq;
using AdventOfCode2022.Day14;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day14Test {

        private const string Input = "498,4 -> 498,6 -> 496,6\n503,4 -> 502,4 -> 502,9 -> 494,9";

        private readonly (object, object) _result;

        public Day14Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(24, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(93, _result.Item2);
    }
}

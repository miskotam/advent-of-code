using System.Linq;
using AdventOfCode2022.Day10;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day10Test {

        private const string Input = "addx 15\naddx -11\naddx 6\naddx -3\naddx 5\naddx -1\naddx -8\naddx 13\naddx 4\nnoop\naddx -1\naddx 5";

        private readonly (object, object) _result;

        public Day10Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(420, _result.Item1);
    }
}

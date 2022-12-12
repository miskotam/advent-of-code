using System.Linq;
using AdventOfCode2022.Day08;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day08Test {

        private const string Input = "30173\n25512\n65332\n23549\n35190";

        private readonly (object, object) _result;

        public Day08Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(22, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(8, _result.Item2);
    }
}

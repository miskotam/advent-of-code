using System.Linq;
using AdventOfCode2022.Day12;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day12Test {

        private const string Input = "Sabqponm\nabcryxxl\naccszExk\nacctuvwj\nabdefghi";

        private readonly (object, object) _result;

        public Day12Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(31, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(29, _result.Item2);
    }
}

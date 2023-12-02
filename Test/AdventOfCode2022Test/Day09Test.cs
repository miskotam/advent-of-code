using System.Linq;
using AdventOfCode2022.Day09;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day09Test {

        private const string Input =
        "R 4\nU 4\nL 3\nD 1\nR 4\nD 1\nL 5\nR 2\nU 4\nL 3\nD 1\nR 4\nD 1\nL 5\nR 2\nU 4\nL 3\nD 1\nR 4\nD 1\nL 5\nR 2\nU 4\nL 3";

        private readonly (object, object) _result;

        public Day09Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(33, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(3, _result.Item2);
    }
}

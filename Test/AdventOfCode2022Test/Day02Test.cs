using System.Linq;
using AdventOfCode2022.Day02;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day02Test {

        private const string Input = "A X\nA Y\nA Z\nB X\nB Y\nB Z\nC X\nC Y\nC Z\nA X";

        private readonly (object, object) _result;

        public Day02Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(49, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(48, _result.Item2);
    }
}

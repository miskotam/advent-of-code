using System.Linq;
using AdventOfCode2022.Day04;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day04Test {

        private const string Input = "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8";

        private readonly (object, object) _result;

        public Day04Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(2, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(4, _result.Item2);
    }
}

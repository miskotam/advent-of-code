using System.Linq;
using AdventOfCode2022.Day01;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day01Test {

        private const string Input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";

        private readonly (object, object) _result;

        public Day01Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(24000, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(45000, _result.Item2);
    }
}

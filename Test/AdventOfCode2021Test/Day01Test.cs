using System.Linq;
using AdventOfCode2021.Day01;
using Xunit;

namespace AdventOfCode2021Test {
    public class Day01Test {
        private const string Input = "1\n2\n3\n2\n1\n1\n2\n3";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(4, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(2, result.Item2);
        }
    }
}

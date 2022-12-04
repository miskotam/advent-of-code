using System.Linq;
using AdventOfCode2022.Day04;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day04Test {

        private const string Input = "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(2, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(4, result.Item2);
        }
    }
}

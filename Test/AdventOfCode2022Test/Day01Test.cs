using System.Linq;
using AdventOfCode2022.Day01;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day01Test {

        private const string Input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";

        [Fact]
        public void TestPart1() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(24000, result.Item1);
        }

        [Fact]
        public void TestPart2() {
            var result = new Puzzle().Solve(Input.Split('\n').ToList());
            Assert.Equal(45000, result.Item2);
        }
    }
}

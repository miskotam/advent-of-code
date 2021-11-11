using System.Linq;
using Xunit;
using AdventOfCode2015.Day07;

namespace AdventOfCode2015Test {
    public class Day07Test {
        private const string Input = "456 -> b\nb RSHIFT 2 -> g\nNOT g -> a";
        private const string Input2 = "d OR b -> a\n456 -> b\nNOT b -> c\nx AND c -> d\nb LSHIFT 2 -> x";

        [Theory]
        [InlineData(Input, 65421)]
        [InlineData(Input2, 2024)]
        public void TestPart1(string input, object expectedOutput) {
            var result = new Puzzle().Solve(input.Split('\n').ToList());
            Assert.Equal(expectedOutput, result.Item1);
        }

        [Theory]
        [InlineData(Input, 49180)]
        [InlineData(Input2, 8168)]
        public void TestPart2(string input, object expectedOutput) {
            var result = new Puzzle().Solve(input.Split('\n').ToList());
            Assert.Equal(expectedOutput, result.Item2);
        }
    }
}

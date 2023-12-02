using System.Linq;
using AdventOfCode2022.Day03;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day03Test {

        private const string Input = "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\n CrZsJsPPZsGzwwsLwLmpwMDw";

        private readonly (object, object) _result;

        public Day03Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(157, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(70, _result.Item2);
    }
}

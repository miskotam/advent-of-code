using Xunit;
using System.Collections.Generic;
using AdventOfCode2015.Day05;

namespace AdventOfCode2015Test {
    public class Day05Test {
        [Theory]
        [InlineData("aaagiesjsszenskf", 1)]
        [InlineData("sknufchjdvccccta", 0)]
        [InlineData("ugknbfddgicrmopn", 1)]
        [InlineData("uurcxstgmygtbstg", 0)]
        [InlineData("ieodomkazucvgmuy", 0)]
        [InlineData("tcnyqaczcfffkrtl", 0)]
        [InlineData("jchzalrnumimnmhp", 0)]
        [InlineData("haegwjzuvuyypxyu", 0)]
        [InlineData("dvszwmarrgswjxmb", 0)]
        [InlineData("aabcdefwshwmfgaa", 0)]
        [InlineData("abcdedhwuslfeghi", 0)]
        public void TestPart1(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item1);
        }

        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb", 1)]
        [InlineData("sknufchjdvccccta", 1)]
        [InlineData("xxyxxdleisbwwzha", 1)]
        [InlineData("uurcxstgmygtbstg", 0)]
        [InlineData("ieodomkazucvgmuy", 0)]
        public void TestPart2(string input, object expectedOutput) {
            var result = new Puzzle().Solve(new List<string> { input });
            Assert.Equal(expectedOutput, result.Item2);
        }
    }
}

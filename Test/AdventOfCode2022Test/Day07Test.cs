using System.Linq;
using AdventOfCode2022.Day07;
using Xunit;

namespace AdventOfCode2022Test {
    public class Day07Test {

        private const string Input = "$ cd /\n$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\ndir d\n$ cd a\n$ ls\ndir e\n29116 f\n2557 g\n62596 h.lst\n$ cd e\n$ ls\n584 i\n$ cd ..\n$ cd ..\n$ cd d\n$ ls\n4060174 j\n8033020 d.log\n5626152 d.ext\n7214296 k";

        private readonly (object, object) _result;

        public Day07Test() => _result = new Puzzle().Solve(Input.Split("\n").ToList());

        [Fact]
        public void TestPart1() => Assert.Equal(95437L, _result.Item1);

        [Fact]
        public void TestPart2() => Assert.Equal(24933642L, _result.Item2);
    }
}

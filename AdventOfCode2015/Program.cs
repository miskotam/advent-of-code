using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalUtils;

namespace AdventOfCode2015 {
    public class Program {
        private static readonly int _year = 2015;
        private static readonly int _day = 10;
        private static readonly InputLoader _inputLoader = new(_year);
        private static readonly ClipboardUtils _clipBoardUtils = new();

        private static readonly List<IPuzzle> _days = new() {
            new Day01.Puzzle(),
            new Day02.Puzzle(),
            new Day03.Puzzle(),
            new Day04.Puzzle(),
            new Day05.Puzzle(),
            new Day06.Puzzle(),
            new Day07.Puzzle(),
            new Day08.Puzzle(),
            new Day09.Puzzle(),
            new Day10.Puzzle(),
        };

        private static async Task Main() {
            var puzzle = _days[_day - 1];
            var input = await _inputLoader.ReadInput(_day, puzzle.SampleMode);
            var result = puzzle.Solve(input);
            _clipBoardUtils.CopyToClipBoard(result.Item2 ?? result.Item1);
            Console.WriteLine(result);
        }
    }
}
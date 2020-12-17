
using System;
using System.Collections.Generic;
using GlobalUtils;

namespace AdventOfCode2015 {
    public class Program {
        private static readonly int _year = 2015;
        private static readonly int _day = 1;
        private static readonly InputLoader _inputLoader = new InputLoader(_year);
        private static readonly Utils _utils = new Utils();

        public delegate (object, object) DayProgram(List<string> input);

        private static readonly List<DayProgram> _days = new List<DayProgram> {
            new Day01.Puzzle().Solve
        };

        private static void Main() {
            var result = _days[_day - 1].Invoke(_inputLoader.ReadInput(_day));
            _utils.CopyToClipBoard(result.Item2 ?? result.Item1);
            Console.WriteLine(result);
        }
    }
}
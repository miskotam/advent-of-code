using System.Text;
using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2015.Day10 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = -1;

            var number = input.First();

            for (var iterationCounter = 0; iterationCounter < 50; iterationCounter++) {
                var mark = number[0];
                var markCount = 0;
                var newNumber = new StringBuilder();
                for (var i = 0; i < number.Length; i++) {
                    if (number[i] == mark) {
                        markCount++;
                    }
                    else {
                        _ = newNumber.Append($"{markCount}{mark}");
                        mark = number[i];
                        markCount = 1;
                    }
                }
                _ = newNumber.Append($"{markCount}{number[^1]}");
                number = newNumber.ToString();

                if (iterationCounter == 39)
                    part1 = number.Length;
            }

            return (part1, number.Length);
        }
    }
}
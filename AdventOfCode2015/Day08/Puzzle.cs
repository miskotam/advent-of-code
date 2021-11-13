using System.Collections.Generic;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2015.Day08 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = Part1(input);

            var part2 = Part2(input);

            return (part1, part2);
        }

        private static int Part1(List<string> input) {
            var totalCharacterLength = 0;
            var inMemoryStringValues = 0;

            foreach (var row in input) {
                var modifiedRow = new string(row);
                modifiedRow = Regex.Replace(modifiedRow, "\\\\\"", match => "\"");
                modifiedRow = Regex.Replace(modifiedRow, @"\\{2}", match => "\\");
                modifiedRow = Regex.Replace(modifiedRow, @"\\x[A-Fa-f0-9]{2}", match => HexUtils.HexToAscii(match.Value[2..]));

                totalCharacterLength += row.Length;
                inMemoryStringValues += modifiedRow.Length - 2;
            }

            return totalCharacterLength - inMemoryStringValues;
        }

        private static int Part2(List<string> input) {
            var newlyEncodedString = 0;
            var totalCharacterLength = 0;

            foreach (var row in input) {
                var modifiedRow = new string(row);

                modifiedRow = Regex.Replace(modifiedRow, @"\\", match => "\\\\");
                modifiedRow = Regex.Replace(modifiedRow, "\"", match => "\\\"");

                newlyEncodedString += modifiedRow.Length + 2;
                totalCharacterLength += row.Length;
            }

            return newlyEncodedString - totalCharacterLength;
        }
    }
}
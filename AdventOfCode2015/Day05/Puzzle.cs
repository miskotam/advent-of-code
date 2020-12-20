using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015.Day05 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = Part1(input);
            object part2 = Part2(input);

            return (part1, part2);
        }

        private static int Part2(List<string> input) {
            var niceWords = 0;
            foreach (var word in input) {
                var repeatRuleCount = false;
                var pairRule = false;
                for (var i = 1; i < word.Length; i++) {
                    if (!pairRule) {
                        var wordPart = word[(i - 1)..(i + 1)];
                        pairRule = word[(i + 1)..].Contains(wordPart);
                    }
                    if (!repeatRuleCount && i > 1 && word[i - 2] == word[i]) {
                        repeatRuleCount = true;
                    }
                    if (repeatRuleCount && pairRule) {
                        niceWords++;
                        break;
                    }
                }

            }

            return niceWords;
        }

        private static int Part1(List<string> input) {
            var niceWords = 0;
            var blackList = new[] { "ab", "cd", "pq", "xy" };

            foreach (var word in input) {
                var vowels = new Dictionary<char, int> { { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 } };
                var duplicateCheck = false;
                if (blackList.Any(wordPart => word.Contains(wordPart)))
                    continue;

                for (var i = 0; i < word.Length; i++) {
                    var c = word[i];
                    if (vowels.ContainsKey(c))
                        vowels[c]++;

                    if (i > 0) {
                        if (word[i - 1] == c)
                            duplicateCheck = true;
                    }

                    if (duplicateCheck && vowels.Values.Sum() > 2) {
                        niceWords++;
                        break;
                    }
                }


            }

            return niceWords;
        }
    }
}
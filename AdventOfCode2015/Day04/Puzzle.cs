using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015.Day04 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = CalculateHashSuffix("00000", input[0]);
            object part2 = CalculateHashSuffix("000000", input[0]);

            return (part1, part2);
        }

        private static int CalculateHashSuffix(string prefix, string input) {
            var hashSuffix = -1;
            var sb = new StringBuilder();
            var hash = string.Empty;
            using var md5 = MD5.Create();

            while (!hash.StartsWith(prefix)) {
                _ = sb.Clear();
                hashSuffix++;
                var inputBytes = Encoding.ASCII.GetBytes($"{input}{hashSuffix}");
                var hashBytes = md5.ComputeHash(inputBytes);

                foreach (var b in hashBytes)
                    _ = sb.Append(b.ToString("X2"));

                hash = sb.ToString();
            }

            return hashSuffix;
        }
    }
}
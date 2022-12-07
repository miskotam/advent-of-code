using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day07 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var filePattern = new Regex("""(?<size>\d+) .*""");
            var cdDownPattern = new Regex("""\$ cd (?<folder>.*)""");
            var cdUpPattern = new Regex("""\$ cd \.\.""");

            var folders = new Dictionary<string, long>();
            var currentFolder = new Stack<string>();

            foreach (var line in input) {
                var cdDownMatch = cdDownPattern.Match(line);
                var cdUpMatch = cdUpPattern.Match(line);
                var fileMatch = filePattern.Match(line);
                if (cdUpMatch.Success) {
                    _ = currentFolder.Pop();
                }
                else if (cdDownMatch.Success) {
                    var folder = cdDownMatch.Groups["folder"].Value;
                    currentFolder.Push(folder);
                }
                else if (fileMatch.Success) {
                    var fileSize = int.Parse(fileMatch.Groups["size"].Value);
                    var currentFolderPath = currentFolder.Reverse().ToArray();
                    for (var i = 0; i < currentFolderPath.Length; i++) {
                        var subFolderPath = string.Join("/", currentFolderPath[..(i + 1)]);
                        if (!folders.ContainsKey(subFolderPath))
                            folders[subFolderPath] = 0;
                        folders[subFolderPath] += fileSize;
                    }
                }
            }

            part1 = folders.Values.Where(size => size < 100000).Sum();
            var requiredSpace = 30000000 - (70000000 - folders["/"]);
            part2 = folders.Values.Where(size => size > requiredSpace).Order().First();

            return (part1, part2);
        }
    }
}

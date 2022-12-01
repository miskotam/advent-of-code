using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2021.Day04 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = 0;
            var part2 = 0;

            var numbers = input[0].Split(',').Select(int.Parse);
            var bingoBoards = CreateBingoBoards(input.Skip(2).Select(line => line.Replace("  ", " ").Trim()).ToList()).ToList();
            foreach (var number in numbers) {
                bingoBoards = bingoBoards.Select(board => MatrixUtils.FindAndReplace(board, number, -1)).ToList();
                for (var boardIndex = 0; boardIndex < bingoBoards.Count; boardIndex++) {
                    var boardCopy = bingoBoards.ToList()[boardIndex];
                    var hasAWinner = false;
                    for (var i = 0; i < boardCopy.GetLength(0); i++) {
                        var row = MatrixUtils.GetRow(boardCopy, i);
                        var col = MatrixUtils.GetColumn(boardCopy, i);
                        if (row.All(x => x == -1) || col.All(x => x == -1)) {
                            var result = MatrixUtils.Find(boardCopy, (cell) => cell > -1);
                            if (part1 == 0)
                                part1 = result.Sum(x => x) * number;
                            hasAWinner = true;
                            break;
                        }
                    }
                    if (hasAWinner) {
                        if (bingoBoards.Count > 1) {
                            bingoBoards.RemoveAt(boardIndex);
                        }
                        else {
                            var result = MatrixUtils.Find(boardCopy, (cell) => cell > -1);
                            part2 = result.Sum(x => x) * number;
                            break;
                        }
                    }
                    if (part1 > 0 && part2 > 0)
                        break;
                }
                if (part1 > 0 && part2 > 0)
                    break;
            }

            return (part1, part2);
        }

        private static IEnumerable<int[,]> CreateBingoBoards(List<string> input) {
            var flattenedBingoBoards = InputProcessingUtils.ConcatGroupOfLines(input, "\n", string.Empty);

            foreach (var flattenBoard in flattenedBingoBoards) {
                yield return MatrixUtils.LineToIntMatrix(flattenBoard, " ", "\n");
            }
        }
    }
}
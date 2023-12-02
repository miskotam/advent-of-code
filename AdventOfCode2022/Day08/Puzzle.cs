using System;
using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2022.Day08 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var forest = MatrixUtils.ToIntMatrix(input);
            var height = forest.GetLength(0);
            var width = forest.GetLength(1);
            var interiorVisibleTrees = 0;
            var scores = new List<int>();

            for (var x = 1; x < height - 1; x++) {
                for (var y = 1; y < width - 1; y++) {
                    var row = MatrixUtils.GetRow(forest, x);
                    var column = MatrixUtils.GetColumn(forest, y);
                    var tree = forest[x, y];

                    var left = row[..y].Reverse().ToArray();
                    var right = row[(y + 1)..];
                    var top = column[..x].Reverse().ToArray();
                    var bottom = column[(x + 1)..];

                    if (top.All(t => t < tree) || left.All(t => t < tree) ||
                       bottom.All(t => t < tree) || right.All(t => t < tree)) {
                        interiorVisibleTrees++;
                    }

                    var score = 1;
                    score *= CalculateViewingDistance(tree, top.ToList());
                    score *= CalculateViewingDistance(tree, left.ToList());
                    score *= CalculateViewingDistance(tree, bottom.ToList());
                    score *= CalculateViewingDistance(tree, right.ToList());
                    scores.Add(score);
                }
            }

            var part1 = interiorVisibleTrees + (height - 1) * 2 + (width - 1) * 2;
            var part2 = scores.Max();

            return (part1, part2);
        }

        private static int CalculateViewingDistance(int tree, List<int> trees) {
            var distance = trees.TakeWhile(t => t < tree).Count();
            return distance == trees.Count ? trees.Count : distance + 1;
        }
    }
}
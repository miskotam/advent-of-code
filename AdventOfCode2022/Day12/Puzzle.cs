using System;
using System.Collections.Generic;
using System.Linq;
using GlobalUtils;
using GlobalUtils.PathFinding;

namespace AdventOfCode2022.Day12 {

    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        private readonly Func<Node<char>, Node<char>[,], IEnumerable<Node<char>>> _neighborSelectorFunc = (c, g) => MatrixUtils
        .GetDirect4Neighbors(g, c.GridX, c.GridY)
        .Where(n => n.MovementPenalty - c.MovementPenalty <= 1);

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var heightMap = MatrixUtils.ToNodeMatrix<char[][], char>(input.Select(line => line.ToCharArray()).ToArray(), (height) => {
                if (height == 'S')
                    return 0;
                if (height == 'E')
                    return 'z' - 'a';
                return height - 'a';
            });

            var endNode = MatrixUtils.Find(heightMap, x => (char)x.Value == 'E').Single();
            var part1StartNodes = MatrixUtils.Find(heightMap, x => (char)x.Value == 'S').ToList();
            var part2StartNodes = MatrixUtils.Find(heightMap, x => (char)x.Value is 'S' or 'a').ToList();

            var part1Steps = part1StartNodes.Select(startNode => AStar<char>.FindPath(heightMap, startNode, endNode, _neighborSelectorFunc));
            part1 = part1Steps.First().Count;

            var part2Steps = part2StartNodes.Select(startNode => AStar<char>.FindPath(heightMap, startNode, endNode, _neighborSelectorFunc));
            part2 = part2Steps.Select(x => x?.Count ?? int.MaxValue).Min();

            return (part1, part2);
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2022.Day14 {

    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var rock = new HashSet<(int x, int y)>();

            foreach (var line in input) {
                var rawCoordinates = line.Split(" -> ");
                var intCoordinates = rawCoordinates.Select(rawCoordinate => {
                    var coordinate = rawCoordinate.Split(',');
                    return (x: int.Parse(coordinate[0]), y: int.Parse(coordinate[1]));
                }).ToArray();

                for (var i = 1; i < intCoordinates.Length; i++) {
                    var coordinate1 = intCoordinates[i - 1];
                    var coordinate2 = intCoordinates[i];
                    if (coordinate1.x == coordinate2.x) {
                        var yMax = Math.Max(coordinate1.y, coordinate2.y);
                        var yMin = coordinate1.y + coordinate2.y - yMax;
                        for (var y = yMin; y <= yMax; y++) {
                            _ = rock.Add((coordinate1.x, y));
                        }
                    }
                    else if (coordinate1.y == coordinate2.y) {
                        var xMax = Math.Max(coordinate1.x, coordinate2.x);
                        var xMin = coordinate1.x + coordinate2.x - xMax;
                        for (var x = xMin; x <= xMax; x++) {
                            _ = rock.Add((x, coordinate1.y));
                        }
                    }
                }
            }

            var part1 = SimulateSandPouring(rock, false);
            var part2 = SimulateSandPouring(rock, true);

            return (part1, part2);
        }

        private static int SimulateSandPouring(HashSet<(int x, int y)> rock, bool hasFloor) {
            var sX = 500;
            var sY = 0;
            var sand = new HashSet<(int x, int y)>();
            var maxY = rock.Select(r => r.y).Max();

            while (true) {
                if (!hasFloor && sY + 1 > maxY)
                    break;
                if (hasFloor && sand.Contains((500, 0)))
                    break;

                if (sY > maxY) {
                    _ = sand.Add((sX, sY));
                    sX = 500;
                    sY = 0;
                }
                else if (!rock.Contains((sX, sY + 1)) && !sand.Contains((sX, sY + 1))) {
                    sY++;
                }
                else if (!rock.Contains((sX - 1, sY + 1)) && !sand.Contains((sX - 1, sY + 1))) {
                    sY++;
                    sX--;
                }
                else if (!rock.Contains((sX + 1, sY + 1)) && !sand.Contains((sX + 1, sY + 1))) {
                    sY++;
                    sX++;
                }
                else {
                    _ = sand.Add((sX, sY));
                    sX = 500;
                    sY = 0;
                }
            }

            return sand.Count;
        }
    }
}
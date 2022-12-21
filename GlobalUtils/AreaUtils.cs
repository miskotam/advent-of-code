using System;
using System.Collections.Generic;

namespace GlobalUtils {
    public static class AreaUtils {
        public static bool IsInRectangle(int x1, int y1, int x2, int y2, int x, int y) {
            return x >= x1 && x <= x2 && y >= y1 && y <= y2;
        }

        public static bool IsInManhattanArea(int x1, int y1, int x2, int y2, int distance) {
            return ManhattanDistance(x1, y1, x2, y2) <= distance;
        }

        public static int ManhattanDistance(int x1, int y1, int x2, int y2) {
            return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
        }

        public static List<(int x, int y)> GetManhattanArea(int x, int y, int n, bool onlyEdges) {
            var points = new List<(int x, int y)>();
            for (var i = onlyEdges ? n : 1; i <= n; i++) {
                points.Add((x, y + i));
                points.Add((x, y - i));
                points.Add((x + i, y));
                points.Add((x - i, y));
                for (var j = 1; j <= i - 1; j++) {
                    points.Add((x + j, y + i - j));
                    points.Add((x - j, y + i - j));
                    points.Add((x + j, y - i + j));
                    points.Add((x - j, y - i + j));
                }
            }

            return points;
        }
    }
}
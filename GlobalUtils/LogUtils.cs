using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalUtils {
    public static class LogUtils {
        public static void Log(string input) {
            Console.WriteLine(input);
        }

        public static void Log(params object[] input) {
            Console.WriteLine(string.Join(", ", input.Select(x => x.ToString())));
        }

        public static void LogToFile(params (HashSet<(int x, int y)> matrix, char toDraw)[] matrixParts) {
            var logPath = "log.txt";
            File.Delete(logPath);
            File.Create(logPath).Close();
            var xs = matrixParts.SelectMany(p => p.matrix.Select(m => m.x));
            var maxX = xs.Max();
            var minX = xs.Min();
            var ys = matrixParts.SelectMany(p => p.matrix.Select(m => m.y));
            var maxY = ys.Max();
            var minY = ys.Min();

            for (var y = minY; y <= maxY; y++) {
                if (y != minY)
                    File.AppendAllText(logPath, "\n");
                for (var x = minX; x <= maxX; x++) {
                    var draw = false;
                    foreach (var (matrix, toDraw) in matrixParts) {
                        if (matrix.Contains((x, y))) {
                            File.AppendAllText(logPath, $"{toDraw}");
                            draw = true;
                        }
                    }
                    if (!draw)
                        File.AppendAllText(logPath, ".");
                }
            }
        }

        public static void Log<T>(IEnumerable<T> input) {
            Console.WriteLine(string.Join(", ", input.Select(x => x.ToString())));
        }

        public static void Log<T>(T[,] matrix) {
            for (var x = 0; x < matrix.GetLength(0); x++)
                Console.WriteLine(string.Join("", Enumerable.Range(0, matrix.GetLength(1)).Select(y => matrix[x, y]).ToArray()));
        }

        public static void LogToFile<T>(T[,] matrix) {
            var logPath = "log.txt";
            File.Delete(logPath);
            File.Create(logPath).Close();

            for (var x = 0; x < matrix.GetLength(1); x++)
                File.AppendAllText(logPath, string.Join("", Enumerable.Range(0, matrix.GetLength(0)).Select(y => matrix[y, x]).ToArray()) + '\n');
        }
    }
}
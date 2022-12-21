using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day15 {

    public class Puzzle : IPuzzle {
        public bool SampleMode => true;

        private readonly HashSet<(int x, int y)> _targetRow = new();
        private readonly Dictionary<(int x, int y), int> _sensors = new();
        private readonly List<(int x, int y)> _beacons = new();

        public (object, object) Solve(List<string> input) {
            var positionPattern = new Regex("""Sensor at x=(?<sensorX>-*\d+), y=(?<sensorY>-*\d+): closest beacon is at x=(?<beaconX>-*\d+), y=(?<beaconY>-*\d+)""");

            var targetY = SampleMode ? 10 : 2000000;
            foreach (var line in input) {
                var match = positionPattern.Match(line);
                var sensorX = int.Parse(match.Groups["sensorX"].Value);
                var sensorY = int.Parse(match.Groups["sensorY"].Value);
                var beaconX = int.Parse(match.Groups["beaconX"].Value);
                var beaconY = int.Parse(match.Groups["beaconY"].Value);
                var sensorRadius = AreaUtils.ManhattanDistance(sensorX, sensorY, beaconX, beaconY);
                var sensor = (sensorX, sensorY);
                var beacon = (beaconX, beaconY);

                _sensors.Add(sensor, sensorRadius);
                _beacons.Add(beacon);

                ExtendTargetRow(sensor, sensorRadius, beacon, targetY);
            }

            var part1 = _targetRow.Where(x => x.y == targetY).Count();

            var part2 = -1L;
            var searchLimit = SampleMode ? 20 : 4000000;
            foreach (var kvp in _sensors) {
                var sensorX = kvp.Key.x;
                var sensorY = kvp.Key.y;
                var sensorRadius = kvp.Value;
                foreach (var (x, y) in AreaUtils.GetManhattanArea(sensorX, sensorY, sensorRadius + 1, true)) {
                    var result = IsInsideSensorArea(x, y, 0, searchLimit);
                    if (!result) {
                        part2 = x * 4000000L + y;
                        break;
                    }
                }
                if (part2 > 0)
                    break;
            }

            return (part1, part2);
        }

        private bool IsInsideSensorArea(int x, int y, int minSearchLimit, int maxSearchLimit) {
            var point = (x, y);
            if (_sensors.ContainsKey(point) || _beacons.Contains(point)
                || x < minSearchLimit || x > maxSearchLimit
                || y < minSearchLimit || y > maxSearchLimit) {
                return true;
            }
            var isInsideSensorArea = false;
            foreach (var kvp in _sensors) {
                var sensorX = kvp.Key.x;
                var sensorY = kvp.Key.y;
                var sensorRadius = kvp.Value;
                if (AreaUtils.IsInManhattanArea(point.x, point.y, sensorX, sensorY, sensorRadius)) {
                    isInsideSensorArea = true;
                    break;
                }
            }

            if (!isInsideSensorArea) {
                return isInsideSensorArea;
            }
            return true;
        }

        private void ExtendTargetRow((int x, int y) sensor, int sensorRadius, (int x, int y) beacon, int targetRow) {
            if (sensor.y - sensorRadius > targetRow && sensor.y + sensorRadius < targetRow)
                return;

            var minSearchLimit = sensor.x - sensorRadius;
            var maxSearchLimit = sensor.x + sensorRadius;
            for (var x = minSearchLimit; x <= maxSearchLimit; x++) {
                if (sensor.x == x && sensor.y == targetRow || beacon.x == x && beacon.y == targetRow)
                    continue;
                var dist = AreaUtils.ManhattanDistance(sensor.x, sensor.y, x, targetRow);
                if (dist <= sensorRadius)
                    _ = _targetRow.Add((x, y: targetRow));
            }
        }
    }
}
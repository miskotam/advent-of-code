using System.Collections.Generic;
using System.Linq;

namespace GlobalUtils {
    public class TravelingSalesmanUtils {
        public static (List<string> path, int distance) GetShortestPath(List<(string from, string to, int distance)> distanceMap) {
            return GenerateTSPPaths(distanceMap).First();
        }

        public static (List<string> path, int distance) GetLongestPath(List<(string from, string to, int distance)> distanceMap) {
            return GenerateTSPPaths(distanceMap).Last();
        }

        public static IEnumerable<(List<string> path, int distance)> GenerateTSPPaths(List<(string from, string to, int distance)> distanceMap) {
            var cities = distanceMap.SelectMany((entry) => new[] { entry.from, entry.to }).ToHashSet().ToArray();
            var cityListPermutations = PermutationUtils.GetPermutations(cities, cities.Length);

            return cityListPermutations
            .Select(cityList => {
                var cityArray = cityList.ToArray();
                var distance = 0;
                var path = new List<string>();
                for (var i = 0; i < cityArray.Length; i++) {
                    var city1 = cityArray[i];
                    path.Add(city1);
                    if (cityArray.Length > i + 1) {
                        var city2 = cityArray[i + 1];
                        var sectionDistance = distanceMap.First(d => d.from == city1
                                                  && d.to == city2
                                                  || d.to == city1
                                                  && d.from == city2).distance;
                        distance += sectionDistance;
                    }
                    else {
                        break;
                    }
                }
                return (path, distance);
            })
            .OrderBy(p => p.distance);
        }
    }
}
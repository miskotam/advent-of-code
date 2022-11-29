using System.Collections.Generic;
using System.Linq;
using GlobalUtils;

namespace AdventOfCode2015.Day07 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = CalculateSignalForA(new List<string>(input));
            var part2 = CalculateSignalForA(new List<string>(input), part1);

            return (part1, part2);
        }

        private static int CalculateSignalForA(List<string> input, int bOverride = -1) {
            var operationCache = new Dictionary<string, int>();
            var index = 0;

            while (new List<string>(input).Any()) {
                var row = input[index];
                var connectionInstruction = row.Split(" -> ");
                var wiresAndGates = connectionInstruction[0].Split(' ');

                // Constant wiring
                if (wiresAndGates.Length == 1) {
                    // Override "b" for part 2
                    if (connectionInstruction[1] == "b" && bOverride > 0) {
                        operationCache[connectionInstruction[1]] = bOverride;
                        _ = input.Remove(row);
                        index = -1;
                    }
                    // Wire is constant
                    else if (int.TryParse(wiresAndGates[0], out var wire)) {
                        operationCache[connectionInstruction[1]] = wire;
                        _ = input.Remove(row);
                        index = -1;
                    }
                    // Wire can be resolved from the cache
                    else if (operationCache.ContainsKey(wiresAndGates[0])) {
                        operationCache[connectionInstruction[1]] = operationCache[wiresAndGates[0]];
                        _ = input.Remove(row);
                        index = -1;
                    }
                }
                // Complement gate
                else if (wiresAndGates.Length == 2) {
                    if (operationCache.ContainsKey(wiresAndGates[1])) {
                        operationCache[connectionInstruction[1]] = ~operationCache[wiresAndGates[1]] + 65536;
                        _ = input.Remove(row);
                        index = -1;
                    }
                }
                // Two operand gate
                else if (wiresAndGates.Length == 3) {
                    if (!int.TryParse(wiresAndGates[0], out var wire1)) {
                        if (operationCache.ContainsKey(wiresAndGates[0])) {
                            wire1 = operationCache[wiresAndGates[0]];
                        }
                        else {
                            wire1 = -1;
                        }
                    }
                    if (!int.TryParse(wiresAndGates[2], out var wire2)) {
                        if (operationCache.ContainsKey(wiresAndGates[2])) {
                            wire2 = operationCache[wiresAndGates[2]];
                        }
                        else {
                            wire2 = -1;
                        }
                    }
                    if (wire1 > -1 && wire2 > -1) {
                        switch (wiresAndGates[1]) {
                            case "AND":
                                operationCache[connectionInstruction[1]] = wire1 & wire2;
                                break;
                            case "OR":
                                operationCache[connectionInstruction[1]] = wire1 | wire2;
                                break;
                            case "LSHIFT":
                                operationCache[connectionInstruction[1]] = wire1 << wire2;
                                break;
                            case "RSHIFT":
                                operationCache[connectionInstruction[1]] = wire1 >> wire2;
                                break;
                        }
                        _ = input.Remove(row);
                        index = -1;
                    }
                }
                if (operationCache.ContainsKey("a"))
                    return operationCache["a"];

                index++;
            }

            return -1;
        }
    }
}
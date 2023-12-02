using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GlobalUtils;

namespace AdventOfCode2022.Day11 {
    public class Monkey {
        public readonly List<long> Items;
        public readonly int Test;
        public readonly int[] ThrowTo;
        public readonly Func<long, int, long> Operation;
        public readonly int OperationValue;
        public long InspectCount { get; private set; }
        public Monkey(List<long> items, int test, int throwToTrue, int throwToFalse, Func<long, int, long> operation, int operationValue) {
            Items = items;
            Test = test;
            ThrowTo = new[] { throwToTrue, throwToFalse };
            Operation = operation;
            OperationValue = operationValue;
        }

        public void DoTurn(List<Monkey> monkeys, bool hasRelief) {
            var simplifier = hasRelief ? 0 : monkeys.Select(m => m.Test).Aggregate((a, b) => a * b);
            while (Items.Count > 0) {
                var item = Items.First();
                Items.RemoveAt(0);
                var newItem = Operation(item, OperationValue);
                if (hasRelief)
                    newItem = (int)Math.Floor(newItem / 3f);
                else
                    newItem %= simplifier;
                var throwTarget = newItem % Test == 0 ? 0 : 1;
                ThrowItemTo(monkeys[ThrowTo[throwTarget]], newItem);
                InspectCount++;
            }
        }

        public Monkey Clone() {
            return new Monkey(Items.ToList(), Test, ThrowTo[0], ThrowTo[1], Operation, OperationValue);
        }

        private static void ThrowItemTo(Monkey monkey, long item) {
            monkey.Items.Add(item);
        }
    }

    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            object part1 = null;
            object part2 = null;

            var monkeys = new List<Monkey>();
            var itemPattern = new Regex("Starting items: (?<items>.*)");
            var operationPattern = new Regex("Operation: new = old (?<operation>.) (?<value>.*)");
            var testPattern = new Regex("""Test: divisible by (?<test>\d+)""");
            var throwPattern = new Regex("""If (true|false): throw to monkey (?<throwTo>\d+)""");

            var add = (long worryLevel, int addend) => worryLevel += addend == 0 ? worryLevel : addend;
            var multiply = (long worryLevel, int multiplier) => worryLevel *= multiplier == 0 ? worryLevel : multiplier;

            for (var i = 0; i < input.Count; i += 7) {
                var input1 = input[i + 1];
                var itemMatch = itemPattern.Match(input1);
                var strings = itemMatch.Groups["items"].Value.Split(", ");
                var items = strings.Select(long.Parse).ToList();

                var operationMatch = operationPattern.Match(input[i + 2]);
                var operation = operationMatch.Groups["operation"].Value == "+" ? add : multiply;
                var isInt = int.TryParse(operationMatch.Groups["value"].Value, out var operationValue);
                operationValue = isInt ? operationValue : 0;

                var testMatch = testPattern.Match(input[i + 3]);
                var test = int.Parse(testMatch.Groups["test"].Value);

                var throwTrueMatch = throwPattern.Match(input[i + 4]);
                var throwTrue = int.Parse(throwTrueMatch.Groups["throwTo"].Value);

                var throwFalseMatch = throwPattern.Match(input[i + 5]);
                var throwFalse = int.Parse(throwFalseMatch.Groups["throwTo"].Value);

                monkeys.Add(new Monkey(items, test, throwTrue, throwFalse, operation, operationValue));
            }

            var monkeysPart1 = monkeys.Select(m => m.Clone()).ToList();
            for (var i = 0; i < 20; i++) {
                foreach (var monkey in monkeysPart1) {
                    monkey.DoTurn(monkeysPart1, true);
                }
            }

            var monkeysPart2 = monkeys.Select(m => m.Clone()).ToList();
            for (var i = 0; i < 10000; i++) {
                foreach (var monkey in monkeysPart2) {
                    monkey.DoTurn(monkeysPart2, false);
                }
            }

            part1 = monkeysPart1.Select(m => m.InspectCount).OrderDescending().Take(2).Aggregate((a, b) => a * b);
            part2 = monkeysPart2.Select(m => m.InspectCount).OrderDescending().Take(2).Aggregate((a, b) => a * b);

            return (part1, part2);
        }
    }
}
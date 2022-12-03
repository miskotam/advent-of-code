﻿using System.Threading.Tasks;
using GlobalUtils;

namespace AdventOfCode2022 {
    public class Program {
        private static async Task Main() {
            await AoCRunner.Run(new() {
                    new Day01.Puzzle(),
                    new Day02.Puzzle(),
                    new Day03.Puzzle(),
                }, 2022);
        }
    }
}
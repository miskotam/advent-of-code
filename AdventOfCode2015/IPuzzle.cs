using System.Collections.Generic;

namespace AdventOfCode2015 {
    public interface IPuzzle {
        bool SampleMode { get; }
        (object, object) Solve(List<string> input);
    }
}
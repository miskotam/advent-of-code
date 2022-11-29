using System.Collections.Generic;

namespace GlobalUtils {
    public interface IPuzzle {
        bool SampleMode { get; }
        (object, object) Solve(List<string> input);
    }
}
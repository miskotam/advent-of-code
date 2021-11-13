using System;

namespace GlobalUtils {
    public class HexUtils {
        public static string HexToAscii(string hex) {
            var asciiResult = string.Empty;

            for (var i = 0; i < hex.Length; i += 2) {
                var chairPairToConvert = hex.Substring(i, 2);
                var asciiDecimal = Convert.ToInt32(chairPairToConvert, 16);
                var asciiChar = (char)asciiDecimal;
                asciiResult += asciiChar.ToString();
            }

            return asciiResult;
        }
    }
}
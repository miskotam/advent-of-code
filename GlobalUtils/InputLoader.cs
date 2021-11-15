using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace GlobalUtils {
    public class InputLoader {
        private const string Session = "";
        public int Year { get; }

        public InputLoader(int year) => Year = year;

        public List<string> ReadInput(int day, bool sample = false) {
            var basePath = $"Day{day:D2}";
            if (!Directory.Exists(basePath))
                basePath = $"AdventOfCode{Year}\\Day{day:D2}";

            var inputPath = $"{basePath}\\day{day:D2}.in";
            var samplePath = $"{basePath}\\day{day:D2}.sample";

            if (!File.Exists(inputPath))
                File.Create(inputPath).Close();
            if (!File.Exists(samplePath))
                File.Create(samplePath).Close();

            if (sample)
                return File.ReadLines(samplePath).ToList();

            var fileLines = File.ReadLines(inputPath).ToList();
            if (fileLines.Any())
                return fileLines;

            var webLines = GetInput($"https://adventofcode.com/{Year}/day/{day}/input");
            File.WriteAllLines(inputPath, webLines);

            return webLines;
        }

        private static List<string> GetInput(string uri) {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            var cookieContainer = new CookieContainer();
            var cookie = new Cookie("session", Session) {
                Domain = "adventofcode.com"
            };
            cookieContainer.Add(cookie);
            request.CookieContainer = cookieContainer;

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli;

            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);

            string line;
            var lines = new List<string>();
            while ((line = reader.ReadLine()) != null)
                lines.Add(line);

            return lines;
        }
    }
}
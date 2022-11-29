using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlobalUtils {
    public class InputLoader {
        public int Year { get; }

        public InputLoader(int year) => Year = year;

        public async Task<List<string>> ReadInput(int day, bool sample = false) {
            var basePath = $"Day{day:D2}";
            if (!Directory.Exists(basePath))
                basePath = $"AdventOfCode{Year}/Day{day:D2}";

            var inputPath = $"{basePath}/day{day:D2}.in";
            var samplePath = $"{basePath}/day{day:D2}.sample";

            if (!File.Exists(inputPath))
                File.Create(inputPath).Close();
            if (!File.Exists(samplePath))
                File.Create(samplePath).Close();

            if (sample)
                return File.ReadLines(samplePath).ToList();

            var fileLines = File.ReadLines(inputPath).ToList();
            if (fileLines.Any())
                return fileLines;

            var webLines = await GetInput($"https://adventofcode.com/{Year}/day/{day}/input");
            File.WriteAllLines(inputPath, webLines);

            return webLines;
        }

        private static async Task<List<string>> GetInput(string uri) {
            var sessionPath = "../session.txt";
            if (!File.Exists(sessionPath))
                throw new Exception("Cannot fetch input. No session found.");

            var session = File.ReadLines(sessionPath).First();
            var request = (HttpWebRequest)WebRequest.Create(uri);
            var myClient = new HttpClient(new HttpClientHandler());
            var response1 = await myClient.GetAsync(uri);
            var streamResponse = await response1.Content.ReadAsStreamAsync();
            var cookieContainer = new CookieContainer();
            var cookie = new Cookie("session", session) {
                Domain = "adventofcode.com"
            };
            cookieContainer.Add(cookie);
            request.CookieContainer = cookieContainer;

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli;

            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);
            using var reader2 = new StreamReader(streamResponse);

            string line;
            var lines = new List<string>();
            while ((line = reader.ReadLine()) != null)
                lines.Add(line);

            var lines2 = new List<string>();
            while ((line = reader2.ReadLine()) != null)
                lines2.Add(line);

            return lines;
        }
    }
}
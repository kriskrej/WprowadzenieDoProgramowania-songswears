using System.IO;
using System.Text.RegularExpressions;

namespace SongSwears {
    class Censor {
        protected string[] badWords;

        public Censor() {
            var profanitiesFile = File.ReadAllText("profanities.txt");
            profanitiesFile = profanitiesFile.Replace("*", "");
            profanitiesFile = profanitiesFile.Replace("(", "");
            profanitiesFile = profanitiesFile.Replace(")", "");
            profanitiesFile = profanitiesFile.Replace("\"", "");
            badWords = profanitiesFile.Split(',');
        }

        public string Fix(string tekst) {
            foreach (var word in badWords) {
                tekst = ReplaceBadWord(tekst, word);
            }

            return tekst;
        }

        static string ReplaceBadWord(string tekst, string word) {
            var pattern = "\\b" + word + "\\b";
            return Regex.Replace(tekst, pattern, "____", RegexOptions.IgnoreCase);
        }
    }
}
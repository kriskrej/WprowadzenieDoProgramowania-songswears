using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SongSwears
{
    class Program
    {
        static void Main(string[] args)
        {
            //var songAnalysis = new SongAnalysis("Kazik", "12 groszy");

            var tekst = "Programowanie jest w chuj fajne!";
            var censor = new Censor();
            Console.WriteLine( censor.Fix(tekst) );
        }
    }

    class Censor
    {
        string[] badWords;
        public Censor()
        {
            var profanitiesFile = File.ReadAllText("profanities.txt");
            profanitiesFile = profanitiesFile.Replace("*", "");
            profanitiesFile = profanitiesFile.Replace("(", "");
            profanitiesFile = profanitiesFile.Replace(")", "");
            profanitiesFile = profanitiesFile.Replace("\"", "");
            badWords = profanitiesFile.Split(',');
        }

        public string Fix(string tekst)
        {
            foreach (var word in badWords)
            {
                tekst = ReplaceBadWord(tekst, word);
            }

            return tekst;
        }

        private static string ReplaceBadWord(string tekst, string word)
        {
            var pattern = "\\b"+word+"\\b";
            return Regex.Replace(tekst, pattern, "____", RegexOptions.IgnoreCase);
        }
    }
}

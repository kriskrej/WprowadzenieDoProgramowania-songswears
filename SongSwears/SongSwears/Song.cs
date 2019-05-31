using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace SongSwears {
    class Song {
        public string title;
        public string artist;
        public string lyrics;

        public Song(string band, string songName) {
            var browser = new WebClient();
            string url = "https://api.lyrics.ovh/v1/" + band + "/" + songName;
            var json = browser.DownloadString(url);
            var lyricsData = JsonConvert.DeserializeObject<LyricsovhResponse>(json);

            title = songName;
            artist = band;
            lyrics = lyricsData.lyrics;

        }

        public int CountOccurrences(string word) {
            var pattern = "\\b" + word + "\\b";
            return Regex.Matches(lyrics, pattern, RegexOptions.IgnoreCase).Count;
        }
    }
}
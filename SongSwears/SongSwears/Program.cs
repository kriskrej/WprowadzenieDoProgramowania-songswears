using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSwears {
    class Program {
        static void Main(string[] args) {
            var eminemSwearStats = new SwearStats();
            var song = new Song("Eminem", "Stan");
            eminemSwearStats.AddSwearsFrom(song);
            
        }
    }

    class SwearStats:Censor {
        Dictionary<string, int> allSwears = new Dictionary<string, int>();
        public void AddSwearsFrom(Song song) {
            foreach (var word in badWords) {
                var occurrences = song.CountOccurrences(word);
            }
        }
    }
}
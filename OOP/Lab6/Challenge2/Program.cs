using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Songs Song1 = new Songs("Title1", "Ali", 1);
            Songs Song2 = new Songs("Title2", "None", 2);
            Songs Song3 = new Songs("Title3", "Artist", 30);
           PlayList Playlist = new PlayList("MyPlaylist");
            Playlist.AddSong(Song1);
            Playlist.AddSong(Song2);
            Playlist.AddSong(Song3);
            Playlist.Print();
            Playlist.CalculateDuration();
            Console.WriteLine("Playlist Duration: " + Playlist.GetDuration());
        }
    }
}

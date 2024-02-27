using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class PlayList
    {
        private string Title;
        private List<Songs> Songs;
        private int Duration;
        public PlayList(string Title)
        {
            Title = Title;
            Songs = new List<Songs>();
        }
        public void AddSong(Songs song)
        {
            Songs.Add(song);
        }
        public void RemoveSong(Songs song)
        {
            Songs.Remove(song);
        }
        public void CalculateDuration()
        {
            Duration = 0;
            foreach (Songs song in Songs)
            {
                Duration += song.GetDuration();
            }
        }
        public int GetDuration()
        {
            return Duration;
        }
        public void Print()
        {
            Console.WriteLine("Playlist: " + Title);
            foreach (Songs song in Songs)
            {
                song.Print();
            }
        }
    }
}

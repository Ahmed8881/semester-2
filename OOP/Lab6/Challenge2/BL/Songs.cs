using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Songs
    {
        private string Title;
        private string Artist;
        private int Duration;
        public Songs(string title, string artist, int duration)
        {
            this.Title = title;
            this.Artist = artist;
            this.Duration = duration;
        }
        public string GetTitle()
        {
            return Title;
        }
        public string GetArtist()
        {
            return Artist;
        }
        public int GetDuration()
        {
            return Duration;
        }
        public void SetTitle(string title)
        {
            this.Title = title;
        }
        public void SetArtist(string artist)
        {
            this.Artist = artist;
        }
        public void SetDuration(int duration)
        {
            this.Duration = duration;
        }
        public void Print()
        {
            Console.WriteLine("Title: " + Title + " Artist: " + Artist + " Duration: " + Duration);
        }
    }
}

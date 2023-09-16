using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Music : Media, IMediaPlayable
    {
        private string artist;
        public Music(string title, string artist, int year) : base(title, year)
        {
            this.artist = artist;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Music: {this.title} {this.year}");
            Console.WriteLine($"Artist: {this.artist}");
        }

        public void Play()
        {
            Console.WriteLine($"Playing the music: {this.title}");
        }
    }
}

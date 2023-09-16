using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Movie : Media, IMediaPlayable
    {
        public string DirectorName;
        public Movie() { }
        public Movie(string directorName, string title, int year) : base(title, year)
        {
            DirectorName = directorName;
        }
        public void Play()
        {
            Console.WriteLine($"Playing the movie {this.title}");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{this.title} Directed by: {this.DirectorName}");
            Console.WriteLine($"Released in {this.year}");
        }
    }
}

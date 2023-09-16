using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class LINQ
    {
        public static void LINQExPression()
        {
            Console.WriteLine("LINQ Expressions");



            List<Media> mediaList = new List<Media>() {
            new Movie("Christopher Nolan", "The Prestige", 2008),
            new Movie("Nicholas Winding Refn", "Drive", 2011),
            new Music("Abbey Road", "The Beatles", 1969),
            new Music("In the Court of the Crimson King", "King Crimson", 1969),
            new Music("Plagiarism", "Yorushika", 2020),
            new Movie("Robert Eggers", "The Northman", 2022),
            new Movie("Robert Eggers", "The Lighthouse", 2019),
        };

            var firstMovie = mediaList.FirstOrDefault(m => m is Movie);
            var lastMusic = mediaList.LastOrDefault(m => m is Music);
            var mediaReleasedIn1969 = mediaList.Where(m => m.year == 1969).ToList();
            var findMoviesByDirector = mediaList.Where(m => m is Movie && ((Movie)m).DirectorName == "Robert Eggers").Cast<Movie>().ToList();

            Console.WriteLine("First Movie: ");
            if (firstMovie != null)
                firstMovie.DisplayInfo();
            else
                Console.WriteLine("No movie found");

            Console.WriteLine("\nLast Music");
            if (lastMusic != null)
                lastMusic.DisplayInfo();
            else
                Console.WriteLine("No Music found");

            Console.WriteLine("\nMedia released in 1969");
            foreach (var media in mediaReleasedIn1969)
            {
                media.DisplayInfo();
            }

            Console.WriteLine("\nMovies by Robert Eggers");
            foreach (var movie in findMoviesByDirector)
            {
                movie.DisplayInfo();

            }
        }
    }
}

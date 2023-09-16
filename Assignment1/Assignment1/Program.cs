using System.Threading.Channels;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LINQ.LINQExPression();

            Console.WriteLine("\nMain Program Start\n\n");

            string? title, directorOrArtist, description;
            int year;

            Console.WriteLine("Enter title of your Media: ");
            title = Console.ReadLine() ?? "Unknown Title";

            while (true)
            {
                Console.Write("Enter the released year: ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input for year. Please enter a valid year");
                }
            }

            while (true)
            {
                Console.Write("Enter director/artist: (director for movie. artist for music): ");
                directorOrArtist = Console.ReadLine();
                Console.WriteLine(directorOrArtist);
                if (directorOrArtist != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid please input correctly");
                }
            }

            Media media;

            if (directorOrArtist!.ToLower() == "director")
            {
                Console.WriteLine("Enter name of director");
                string director = Console.ReadLine();
                director = director ?? "Unknown Director";
                media = new Movie(director, title, year);
            }
            else
            {
                Console.WriteLine("Enter name of artist");
                string artist = Console.ReadLine() ?? "Unknown Artist";
                media = new Music(title, artist, year);
            }
            PlayMedia((IMediaPlayable)media);
            media.DisplayInfo();
        }

        static void PlayMedia(IMediaPlayable media)
        {
            media.Play();
        }
    }
}
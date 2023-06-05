using Traine_MovieDB;

internal class Program
{
    private static void Main(string[] args)
    {
        Utils utils = new Utils();

        int missingMovie = 0;
        int addedMovies = 0;
        
        


        Console.WriteLine("Start reading file...");
        List<Final> final = new List<Final>();
        List<Movie> movies = utils.createListByCSVHelper<Movie>("\\movies.csv");
        


        Console.WriteLine("Start adding movies");
        foreach (var record in movies)
        {
            string finalYear = utils.tryRemove(record.Year, record.Title, ref missingMovie);
            if (finalYear != "")
            {
                final.Add(new Final
                {
                    Title = record.Title,
                    Year = finalYear,
                    Directors = record.Directors,
                    Actors = record.Actors,
                    Genre = record.Genre,
                    Plot = record.Description,
                    Poster = record.Img_Url.Replace("https://m.media-amazon.com/images", ""),
                    Countries = record.Countries,
                    Url = record.Imdb_Url
                });
                addedMovies++;
            }

        }

        utils.saveFileAsCSV("\\final.csv", ref final);
        utils.showResault(ref missingMovie, ref addedMovies);
    }
}
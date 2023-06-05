using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Traine_MovieDB
{
    public class Utils
    {
        public static CsvConfiguration config { get; set; } = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
        public static string basicPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

        public Utils ()
        { 
            config.MissingFieldFound = null;
            config.BadDataFound = null;
            config.Delimiter = ",";
        }


        public string tryRemove (string someValue, string title, ref int missingMovie)
        {
            string finalYear = "";
            try
            {
                finalYear = someValue.Remove(someValue.Length - 2, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine($"{e.Message}");
                Console.WriteLine($"{title}");
                Console.WriteLine("Program didn't add this position to final list :(");
                Console.WriteLine("");
                missingMovie++;
            }
            return finalYear;
        }

        public List<T> createListByCSVHelper<T> (string fromPathFile)
        {
            List<T> movies;
            string basicPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            using (var reader = new StreamReader(basicPath + fromPathFile))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                var records = csv.GetRecords<T>();
                movies = csv.GetRecords<T>().ToList();
            }
            return movies;
        }



        public void saveFileAsCSV<T> (string fileName, ref List<T> finaleFile)
        {
            using (var writer = new StreamWriter(basicPath + fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(finaleFile);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved!");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void showResault (ref int missingMovie, ref int allSavedRecords)
        {
            if (missingMovie == 0)
            {
                Console.WriteLine($"Missed movies: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{missingMovie.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
            } else
            {
                Console.Write($"Missed movies: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{missingMovie.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("");
            Console.WriteLine($"All saved movies in file: {allSavedRecords.ToString()}");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

        }
    }
}
